@echo off
cls
title Applying General Windows Settings
echo Applying general system and aesthetic tweaks...
echo ==============================================
:: Commands from the :wsettings section
Reg.exe add "HKLM\SYSTEM\CurrentControlSet\Control\Remote Assistance" /v "fAllowToGetHelp" /t REG_DWORD /d "0" /f
Reg.exe add "HKLM\SOFTWARE\Policies\Microsoft\Edge" /v "StartupBoostEnabled" /t REG_DWORD /d "0" /f
:: ... (Paste the rest of the 20+ REG ADD commands from :wsettings) ...
Reg.exe add "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MultitaskingView\AllUpView" /v "Remove TaskView" /t REG_DWORD /d "1" /f

echo.
echo Windows Settings Fully Optimized
pause