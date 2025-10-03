@echo off
cls
title Initial Setup - RISXN FREE

:: Define the sentinel file path
set SENTINEL_FILE="C:\risxnfree\setup_complete.txt"

:: Check if setup has already been completed
if exist %SENTINEL_FILE% (
    echo [!] Setup already completed. Exiting.
    exit /b 0
)

echo RISXN FREE V20 - Initial Setup and Resource Download
echo =======================================================

:: Create the main directory structure if it doesn't exist
md C:\risxnfree\resources >nul 2>&1
md C:\risxnfree\PowerPlan >nul 2>&1
if not exist "C:\temp\" mkdir "C:\temp\"

echo.
echo [+] Creating System Restore Point (Risxn Free V20 Restore Point)
powershell.exe -Command "Checkpoint-Computer -Description 'Risxn Free V20' -RestorePointType 'MODIFY_SETTINGS'"

echo.
echo [+] Downloading Resources (MSI Util, Wub, Power Plan, DQ Guide)
echo    (This may take a moment...)
curl -g -k -L -# -o "C:\risxnfree\resources\Wub.exe" "https://r2.e-z.host/9e71d386-8c79-465c-9927-36ba4162c8f4/9cllihtz.exe"
curl -g -k -L -# -o "C:\risxnfree\resources\DQ_Guide.txt" "https://github.com/risxntweaks/data-queue-size-txt/releases/download/text/Data.Queue.Size.Guide.txt"
curl -g -k -L -# -o "C:\risxnfree\resources\MSI_Utility_V3.exe" "https://r2.e-z.host/9e71d386-8c79-465c-9927-36ba4162c8f4/9tlvwpdm.exe"
curl -g -k -L -# -o "C:\risxnfree\PowerPlan\RisxnFree.pow" "https://files.catbox.moe/2a716s.pow"

echo.
echo [+] Initial Setup Complete! Creating sentinel file.
:: Create the sentinel file to mark the setup as complete
echo Setup Complete > %SENTINEL_FILE%

echo =======================================================
pause