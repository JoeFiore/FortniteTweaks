@echo off
cls
title Reinstalling Windows Apps
echo Reinstalling commonly removed bloatware apps...
echo =============================================
:: Commands from the :deb2 section
:: Reinstall 3D Builder
powershell -Command "Get-AppxPackage -AllUsers *3dbuilder* | Foreach {Add-AppxPackage -DisableDevelopmentMode -Register \"\$($_.InstallLocation)\AppXManifest.xml\"}"
:: Reinstall Alarms and Clock
powershell -Command "Get-AppxPackage -AllUsers *windowsalarms* | Foreach {Add-AppxPackage -DisableDevelopmentMode -Register \"\$($_.InstallLocation)\AppXManifest.xml\"}"
:: ... (Paste the rest of the reinstall commands) ...
:: Reinstall Mixed Reality Portal
powershell -Command "Get-AppxPackage -AllUsers *holographic* | Foreach {Add-AppxPackage -DisableDevelopmentMode -Register \"\$($_.InstallLocation)\AppXManifest.xml\"}"

echo.
echo Reinstalled Apps.
pause