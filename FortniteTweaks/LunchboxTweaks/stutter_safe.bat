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
REM Stutter and FPS (SAFE) Tweak Execution
REM Corresponds to Option [5] -> [1] from the main menu
REM ============================================================

:: Extra Tweaks - FPS/Stutter
:: Disable memory compression (frees RAM, lowers stutter)
powershell -Command "Disable-MMAgent -MemoryCompression"

:: Optimize pagefile (set fixed size 4-8GB for stability)
wmic computersystem where name="%computername%" set AutomaticManagedPagefile=False
wmic pagefileset where name="C:\\pagefile.sys" set InitialSize=4096,MaximumSize=8192

:STUTTER_SAFE
echo Applying SAFE stutter & FPS tweaks...
:: Disable Game DVR/Game Bar
reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\GameDVR" /v "AppCaptureEnabled" /t REG_DWORD /d 0 /f >nul
reg add "HKCU\System\GameConfigStore" /v "GameDVR_Enabled" /t REG_DWORD /d 0 /f >nul
reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\GameDVR" /v "AllowGameDVR" /t REG_DWORD /d 0 /f >nul

:: Network Throttling
reg add "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile" /v "NetworkThrottlingIndex" /t REG_DWORD /d 4294967295 /f >nul
reg add "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile" /v "SystemResponsiveness" /t REG_DWORD /d 0 /f >nul

:: GPU Scheduling Priority
reg add "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile\Tasks\Games" /v "GPU Priority" /t REG_DWORD /d 8 /f >nul
reg add "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile\Tasks\Games" /v "Priority" /t REG_DWORD /d 6 /f >nul
reg add "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile\Tasks\Games" /v "Scheduling Category" /t REG_SZ /d "High" /f >nul

:: Power Plan
powercfg /s 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c >nul

:: Fullscreen optimizations disable (Fortnite)
reg add "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers" /v "FortniteClient-Win64-Shipping.exe" /t REG_SZ /d "~ DISABLEDXMAXIMIZEDWINDOWEDMODE DISABLEDXGI" /f >nul

cls
echo SAFE tweaks applied. Reboot recommended.
pause