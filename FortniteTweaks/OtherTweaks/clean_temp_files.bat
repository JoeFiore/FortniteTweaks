@echo off
cls
title Cleaning Temporary Files
echo Cleaning temporary files and flushing caches...
echo =============================================
:: Commands from the :clean section

:: Flush the DNS cache
ipconfig /flushdns

:: Stop Windows Update services
net stop wuauserv >nul 2>&1
net stop UsoSvc >nul 2>&1

:: Remove all files from the user's temp directory
del /s /f /q "%temp%\*.*"

:: Remove all files from the Windows temp directory
del /s /f /q C:\Windows\Temp\*.*

:: Clear the Prefetch folder
del /s /f /q C:\Windows\Prefetch\*.*

:: Remove and recreate SoftwareDistribution (to force clean updates)
echo Removing and recreating SoftwareDistribution folder...
rd /s /q "C:\Windows\SoftwareDistribution"
md "C:\Windows\SoftwareDistribution"

:: Disk Cleanup using cleanmgr (runs preset cleanup tasks)
cleanmgr /sagerun:1

echo.
echo Cleaned All Temp Files
pause