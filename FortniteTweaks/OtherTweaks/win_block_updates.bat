@echo off
cls
title Opening Windows Update Blocker
echo Opening Wub.exe. Please click 'Disable Updates' and 'Apply'.
echo ========================================================
:: Commands from the :wub section
powershell -Command "& {Add-Type -AssemblyName System.Windows.Forms; [System.Windows.Forms.MessageBox]::Show('Click disable updates and apply.', 'Risxn Free Tweaking Panel', 'OK', [System.Windows.Forms.MessageBoxIcon]::Information);}"
start C:\risxnfree\resources\Wub.exe
echo.
echo Any Key to Continue
pause