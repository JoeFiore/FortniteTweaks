@echo off
REM --- ADMIN CHECK (Added for automatic elevation) ---
NET SESSION >nul 2>&1
IF %ERRORLEVEL% NEQ 0 (
    ECHO Set UAC = CreateObject^("Shell.Application"^) > "%temp%\elevate.vbs"
    ECHO UAC.ShellExecute "%~s0", "", "", "runas", 1 >> "%temp%\elevate.vbs"
    "%temp%\elevate.vbs"
    exit /b
)

REM ============================================================
REM Cleanup / Performance Mode (Advanced) Execution
REM Corresponds to Option [7] -> [2] from the main menu
REM ============================================================

:CLEANUP_ADVANCED
cls
echo Advanced Cleanup & Performance Mode (backing up settings first)...
set backup_dir=%~dp0regbackups
if not exist "%backup_dir%" mkdir "%backup_dir%"
echo Exporting service and policy-related registry keys...
reg export "HKLM\SYSTEM\CurrentControlSet\Services\SysMain" "%backup_dir%\SysMain_Backup.reg" /y >nul 2>&1
reg export "HKLM\SYSTEM\CurrentControlSet\Services\WSearch" "%backup_dir%\WSearch_Backup.reg" /y >nul 2>&1
reg export "HKLM\SYSTEM\CurrentControlSet\Control\QualityOfService" "%backup_dir%\QoS_Backup.reg" /y >nul 2>&1
echo Backups saved to %backup_dir%
echo.
echo Stopping and disabling SysMain (Superfetch) and Windows Search...
sc stop SysMain >nul 2>&1
sc config SysMain start= disabled >nul 2>&1
sc stop WSearch >nul 2>&1
sc config WSearch start= disabled >nul 2>&1
echo.
echo Disabling background apps and telemetry lite (current user)...
powershell -Command "Get-Process -ErrorAction SilentlyContinue | Out-Null; Set-ItemProperty -Path 'HKCU:\Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications' -Name 'Users' -Value 0 -ErrorAction SilentlyContinue" >nul 2>&1
echo.
echo Setting power plan to Ultimate Performance...
powercfg -setactive scheme_max
echo.
echo.
echo Creating a revert script to restore services and registry...
set revert_file=%~dp0Revert_FortniteTweaks.bat
echo @echo off > "%revert_file%"
echo cls >> "%revert_file%"
echo echo Restoring system settings from registry backups... >> "%revert_file%"

:: FIX: Instead of a complex FOR loop, we list the specific files we backed up, 
:: which is safer and avoids the syntax error when CALLing.
echo reg import "%~dp0regbackups\SysMain_Backup.reg" /y >> "%revert_file%"
echo reg import "%~dp0regbackups\WSearch_Backup.reg" /y >> "%revert_file%"
echo reg import "%~dp0regbackups\QoS_Backup.reg" /y >> "%revert_file%"

echo echo Restoring SysMain and WSearch services... >> "%revert_file%"
echo sc config SysMain start= auto >> "%revert_file%"
echo sc start SysMain >> "%revert_file%"
echo sc config WSearch start= auto >> "%revert_file%"
echo sc start WSearch >> "%revert_file%"

echo echo Revert complete. Press any key to continue... >> "%revert_file%"
echo pause >> "%revert_file%"
echo exit /b 0 >> "%revert_file%"

echo.
echo Advanced cleanup and performance tweaks applied.
pause