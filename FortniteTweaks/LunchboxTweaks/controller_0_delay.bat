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
REM Controller 0 Delay Tweak Execution
REM Corresponds to Option [3] from the main menu
REM ============================================================

:CONTROLLER0
echo.
echo ============================================
echo  Applying Controller 0 Delay Tweaks
echo  (Full Registry + Windows Optimizations)
echo ============================================
echo.

:: ===== Disable Xbox Game Bar / Game DVR features =====
reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\GameDVR" /v "AppCaptureEnabled" /t REG_DWORD /d 0 /f
reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\GameDVR" /v "BackgroundRecordingEnabled" /t REG_DWORD /d 0 /f
reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\GameBar" /v "ShowStartupPanel" /t REG_DWORD /d 0 /f
reg add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\GameBar" /v "AllowAutoGameMode" /t REG_DWORD /d 0 /f

:: ===== Optimize Multimedia Class Scheduler Service (MMCSS) for gaming =====
reg add "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile" /v "NetworkThrottlingIndex" /t REG_DWORD /d 0xffffffff /f
reg add "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile" /v "SystemResponsiveness" /t REG_DWORD /d 0 /f
reg add "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile\Tasks\Games" /v "GPU Priority" /t REG_DWORD /d 8 /f
reg add "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile\Tasks\Games" /v "Priority" /t REG_DWORD /d 6 /f
reg add "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile\Tasks\Games" /v "Scheduling Category" /t REG_SZ /d "High" /f

:: ===== Disable HPET (High Precision Event Timer) =====
bcdedit /deletevalue useplatformclock

:: ===== Input / GUI responsiveness =====
reg add "HKCU\Control Panel\Desktop" /v "MenuShowDelay" /t REG_SZ /d 0 /f >nul
reg add "HKCU\Control Panel\Desktop" /v "ForegroundLockTimeout" /t REG_DWORD /d 0 /f >nul
reg add "HKCU\Control Panel\Keyboard" /v "KeyboardDelay" /t REG_SZ /d 0 /f >nul
reg add "HKCU\Control Panel\Keyboard" /v "KeyboardSpeed" /t REG_SZ /d 31 /f >nul
reg add "HKCU\Control Panel\Mouse" /v "MouseHoverTime" /t REG_SZ /d 0 /f >nul

:: ===== USB / Controller polling =====
reg add "HKLM\SYSTEM\CurrentControlSet\Services\USB" /v "DisableSelectiveSuspend" /t REG_DWORD /d 1 /f >nul
reg add "HKLM\SYSTEM\CurrentControlSet\Services\HidUsb" /v "SelectiveSuspendEnabled" /t REG_DWORD /d 0 /f >nul

:: ===== Network stack optimizations =====
netsh int tcp set global autotuninglevel=disabled
netsh int tcp set global chimney=disabled
netsh int tcp set global dca=enabled
netsh int tcp set global rss=enabled
netsh int tcp set global netdma=enabled
netsh int tcp set global ecncapability=disabled
netsh int tcp set global timestamps=disabled

:: ===== Flush + reset networking =====
ipconfig /release
timeout /t 2 >nul
ipconfig /renew
ipconfig /flushdns
netsh winsock reset

:: ===== Extra Network optimizations =====
netsh int tcp set global congestionprovider=ctcp

:: ===== Timer / Power latency =====
bcdedit /set useplatformclock false
bcdedit /set disabledynamictick yes
bcdedit /set tscsyncpolicy Enhanced

:: ===== Temp cleanup =====
del /q /f "%TEMP%\*" >nul 2>&1
for /d %%p in ("%TEMP%\*.*") do rmdir "%%p" /s /q >nul 2>&1

:: ===== Registry tweaks for controller smoothness =====
reg add "HKCU\System\CurrentControlSet\Control\GameController" /v "PollRate" /t REG_DWORD /d 1 /f >nul 2>&1

:: ===== Fortnite & launcher process priority =====
for %%p in ("FortniteClient-Win64-Shipping.exe" "FortniteClient-Win64-Shipping_EAC.exe" "FortniteClient-Win64-Shipping_BE.exe" "EpicGamesLauncher.exe") do (
    tasklist /FI "IMAGENAME eq %%~p" 2>NUL | find /I "%%~p" >nul
    if not errorlevel 1 wmic process where "name='%%~p'" CALL setpriority 128 >nul 2>&1
)

echo.
echo Controller 0 Delay tweaks applied successfully!
pause