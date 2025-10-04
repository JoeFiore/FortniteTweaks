@echo off
cls
title Managing Startup Apps
echo Opening Task Manager. Please go to the 'Startup' tab and disable unnecessary programs.
echo ====================================================================================
:: Commands from the :startup section
powershell -Command "& {Add-Type -AssemblyName System.Windows.Forms; [System.Windows.Forms.MessageBox]::Show('Go to startup and disable everything you don't need.', 'Risxn Free Tweaking Panel', 'OK', [System.Windows.Forms.MessageBoxIcon]::Information);}"
start taskmgr