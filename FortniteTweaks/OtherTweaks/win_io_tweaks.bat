@echo off
cls
title Applying I/O Tweaks
echo Applying Aggressive I/O and Kernel Velocity Tweaks...
echo ====================================================
:: Commands from the :io section
reg add "HKLM\SYSTEM\CurrentControlSet\Control\Session Manager\I/O System" /v "PassiveIntRealTimeWorkerPriority" /t REG_DWORD /d "18" /f
reg add "HKLM\SYSTEM\CurrentControlSet\Control\KernelVelocity" /v "DisableFGBoostDecay" /t REG_DWORD /d "1" /f

echo.
echo IO Tweaks Applied Sucessfully
pause