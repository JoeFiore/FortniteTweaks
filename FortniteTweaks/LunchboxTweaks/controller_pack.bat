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
REM Controller Pack Tweak Execution
REM Corresponds to Option [2] from the main menu
REM ============================================================

:CONTROLLER

:: Extra Tweaks - Keyboard/Controller
:: Enable Hardware Accelerated GPU Scheduling
reg add "HKLM\SYSTEM\CurrentControlSet\Control\GraphicsDrivers" /v HwSchMode /t REG_DWORD /d 2 /f

:: USB selective suspend off (better controller/keyboard polling)
reg add "HKLM\SYSTEM\CurrentControlSet\Services\USB" /v DisableSelectiveSuspend /t REG_DWORD /d 1 /f
echo.
echo Applying Controller tweaks for Shotgun + SMG + Bloom + smoother stick movement...
REM Network optimizations
ipconfig /release
timeout /t 2 >nul
ipconfig /renew
netsh winsock reset
netsh int tcp set global autotuninglevel=disabled
netsh int tcp set global congestionprovider=ctcp

REM Temp cleanup
del /q /f "%TEMP%\*" >nul 2>&1
for /d %%p in ("%TEMP%\*.*") do rmdir "%%p" /s /q >nul 2>&1

REM Registry tweaks for controller smoothness
REM Reduce input lag for controller / improve stick polling
reg add "HKCU\Control Panel\Desktop" /v "ForegroundLockTimeout" /t REG_DWORD /d 0 /f >nul 2>&1
reg add "HKCU\System\CurrentControlSet\Control\GameController" /v "PollRate" /t REG_DWORD /d 1 /f >nul 2>&1

REM Boost Fortnite process priority
for %%p in ("FortniteClient-Win64-Shipping.exe" "FortniteClient-Win64-Shipping_EAC.exe" "FortniteClient-Win64-Shipping_BE.exe" "EpicGamesLauncher.exe") do (
tasklist /FI "IMAGENAME eq %%~p" 2>NUL | find /I "%%~p" >nul
if not errorlevel 1 wmic process where "name='%%~p'" CALL setpriority 128 >nul 2>&1
)

echo.
cls
echo Controller stabilizers applied (no deadzone nuking).
:: Light OS-side filtering only. Heavy filtering should be done in-game.
reg add "HKCU\System\GameConfigStore" /v GameDVR_Enabled /t REG_DWORD /d 0 /f >nul
reg add "HKCU\Software\Microsoft\GameBar" /v ShowStartupPanel /t REG_DWORD /d 0 /f >nul
echo Done. Press any key to continue...
pause >nul
cls
echo Applying low-risk latency QoL...
:: Power throttling off for foreground apps
reg add "HKLM\SYSTEM\CurrentControlSet\Control\Power\PowerThrottling" /v PowerThrottlingOff /t REG_DWORD /d 1 /f >nul
:: Disable GameDVR/system overlays that add latency
reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows\GameDVR" /v AllowGameDVR /t REG_DWORD /d 0 /f >nul
reg add "HKCU\System\GameConfigStore" /v GameDVR_Enabled /t REG_DWORD /d 0 /f >nul
echo Done. Press any key to continue...
pause >nul
echo Controller tweaks applied.
pause