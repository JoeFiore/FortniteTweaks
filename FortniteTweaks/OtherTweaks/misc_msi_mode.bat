@echo off
cls
title Opening MSI Utility
echo Opening MSI Utility V3.exe.
echo Please run the utility to enable MSI Mode for your GPU/NIC.
echo ========================================================
:: Commands from the :msi section (just starts the utility)
powershell -Command "& {Add-Type -AssemblyName System.Windows.Forms; [System.Windows.Forms.MessageBox]::Show('Use the MSI Utility to enable Message Signaled Interrupts (MSI) Mode for your GPU/NIC for lower latency.', 'Risxn Free Tweaking Panel', 'OK', [System.Windows.Forms.MessageBoxIcon]::Information);}"
start C:\risxnfree\resources\MSI_Utility_V3.exe
echo.
echo Any Key to Continue
pause