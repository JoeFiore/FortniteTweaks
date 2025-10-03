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
REM Fortnite Config Tweak Execution (Open GameUserSettings.ini)
REM Corresponds to Option [8] from the main menu
REM ============================================================

:FORTNITE_CONFIG
cls
echo Locating Fortnite Configuration file...
echo.

set CONFIG_PATH="%LOCALAPPDATA%\FortniteGame\Saved\Config\WindowsClient"
set CONFIG_FILE="%CONFIG_PATH%\GameUserSettings.ini"

if exist %CONFIG_FILE% (
    echo Found config file at: %CONFIG_FILE%
    echo Opening file in Notepad for manual tweaks...
    start "" notepad %CONFIG_FILE%
    echo.
    echo Please make your changes, save the file, and close Notepad.
) else (
    echo ERROR: Fortnite config file not found!
    echo Please ensure Fortnite has been launched at least once.
    echo Expected location: %CONFIG_FILE%
)

echo.
echo Press any key to close this window...
pause