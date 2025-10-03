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
REM Reset Advanced Tweaks Execution
REM Corresponds to Option [9] from the main menu
REM ============================================================
cls
echo ======================================================
echo          RESETTING ADVANCED TWEAKS
echo ======================================================
echo.

set revert_file=%~dp0Revert_FortniteTweaks.bat
set backup_dir=%~dp0regbackups

if exist "%revert_file%" (
    echo Found Revert Script. Executing to restore system services and registry...
    CALL "%revert_file%"
) else (
    echo ERROR: The revert script was NOT found!
    echo Ensure you ran "Cleanup / Performance Mode (Advanced)" first.
    echo Default Windows settings will NOT be restored without this file.
)

echo.
echo Deleting Registry Backup Folder...
if exist "%backup_dir%" (
    rmdir /s /q "%backup_dir%"
    echo Successfully deleted %backup_dir%
) else (
    echo Backup folder not found. Nothing to delete.
)

echo.
echo ADVANCED TWEAKS RESET COMPLETE. A REBOOT IS RECOMMENDED.
pause