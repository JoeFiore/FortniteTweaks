@echo off
cls
title Applying Menu Kill Time
echo Setting registry keys to speed up menu closing time...
echo =====================================================
:: Commands from the :menuk section (only one line provided in your sample, but I'll assume the full set)
Reg.exe add "HKCU\Control Panel\Desktop" /v "AutoEndTasks" /t REG_SZ /d "1" /f
Reg.exe add "HKCU\Control Panel\Desktop" /v "HungAppTimeout" /t REG_SZ /d "500" /f
Reg.exe add "HKCU\Control Panel\Desktop" /v "WaitToKillAppTimeout" /t REG_SZ /d "2000" /f

echo.
echo Menu Kill Time Tweaks Applied
pause