@echo off
cls
title Uninstalling Windows Apps
echo Uninstalling common bloatware apps...
echo =====================================
:: Commands from the :deb1 section
:: Uninstall 3D Builder
powershell -Command "Get-AppxPackage *3dbuilder* | Remove-AppxPackage"
:: Uninstall Alarms and Clock
powershell -Command "Get-AppxPackage *windowsalarms* | Remove-AppxPackage"
:: ... (Paste the rest of the uninstall commands) ...
:: Uninstall Mixed Reality Portal
powershell -Command "Get-AppxPackage *holographic* | Remove-AppxPackage"

echo.
echo App Debloat Complete.
pause