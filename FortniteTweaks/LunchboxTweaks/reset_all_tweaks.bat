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
REM MASTER SCRIPT: RESET ALL TWEAKS
REM Combines Advanced Revert, Network Reset, and Cleanup
REM ============================================================

:RESET_ALL
cls
echo =======================================================
echo          INITIATING MASTER "RESET ALL TWEAKS"
echo =======================================================
echo.

REM --- 1. ADVANCED TWEAK REVERT (System Services & Registry) ---
echo [1/3] Running Advanced Tweak Revert (via dedicated script)...
set revert_advanced_script=%~dp0reset_advanced_tweaks.bat
if exist "%revert_advanced_script%" (
    CALL "%revert_advanced_script%"
) else (
    echo WARNING: Advanced Revert Script not found. Skipping registry/service restore.
)
echo.

REM --- 2. NETWORK STACK RESET ---
echo [2/3] Resetting Network Stack (Flush, Winsock, Global TCP defaults)...
ipconfig /flushdns
netsh winsock reset
netsh int ip reset
netsh int tcp set global autotuninglevel=normal
echo Network stack reset complete.
echo.

REM --- 3. GENERAL CLEANUP ---
echo [3/3] Performing final temp and cache cleanup...
del /q /f "%TEMP%\*" >nul 2>&1
for /d %%p in ("%TEMP%\*.*") do rmdir "%%p" /s /q >nul 2>&1
echo Temp files cleaned.
echo.

echo =======================================================
echo ALL TWEAKS HAVE BEEN RESET TO NEAR-DEFAULT SETTINGS!
echo =======================================================
echo.
echo A REBOOT IS HIGHLY RECOMMENDED!
pause