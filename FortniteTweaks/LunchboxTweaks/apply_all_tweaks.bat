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
REM MASTER SCRIPT: APPLY ALL NON-INTERACTIVE TWEAKS
REM ============================================================

cls
echo =======================================================
echo     INITIATING MASTER "APPLY ALL TWEAKS" SEQUENCE
echo =======================================================
echo.

REM --- 1. KEYBOARD PACK TWEAKS ---
echo [1/8] Applying Keyboard Pack Tweaks...
CALL LunchboxTweaks\\keyboard_pack.bat
echo.

REM --- 2. CONTROLLER PACK TWEAKS ---
echo [2/8] Applying Controller Pack Tweaks...
CALL LunchboxTweaks\\controller_pack.bat
echo.

REM --- 3. KEYBOARD 0 DELAY TWEAKS ---
echo [3/8] Applying Keyboard 0 Delay Tweaks...
CALL LunchboxTweaks\\keyboard_0_delay.bat
echo.

REM --- 4. CONTROLLER 0 DELAY TWEAKS ---
echo [4/8] Applying Controller 0 Delay Tweaks...
CALL LunchboxTweaks\\controller_0_delay.bat
echo.

REM --- 5. STUTTER/FPS SAFE TWEAKS ---
echo [5/8] Applying Stutter/FPS SAFE Tweaks...
CALL LunchboxTweaks\\stutter_safe.bat
echo.

REM --- 6. STUTTER/FPS AGGRESSIVE TWEAKS ---
echo [6/8] Applying Stutter/FPS AGGRESSIVE Tweaks...
CALL LunchboxTweaks\\stutter_aggressive.bat
echo.

REM --- 7. BASIC NETWORK TWEAKS ---
echo [7/8] Applying Basic Network Tweaks...
CALL LunchboxTweaks\\network_basic.bat
echo.

REM --- 8. CLEANUP / PERFORMANCE TWEAKS ---
echo [8/8] Applying Advanced Cleanup/Performance Tweaks...
CALL LunchboxTweaks\\cleanup_advanced.bat
echo.

REM --- 8. FORTNITE CONFIG TWEAKS ---
echo [8/8] Applying Fortnite Config Tweaks...
CALL LunchboxTweaks\\fortnite_config.bat
echo.

echo =======================================================
echo ALL AUTOMATIC TWEAKS APPLIED!
echo =======================================================
echo.
echo
echo A REBOOT IS HIGHLY RECOMMENDED!
pause