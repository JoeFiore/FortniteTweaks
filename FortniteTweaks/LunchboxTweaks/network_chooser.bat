@echo off
REM --- ADMIN CHECK (Added for automatic elevation) ---
NET SESSION >nul 2>&1
IF %ERRORLEVEL% NEQ 0 (
    ECHO Set UAC = CreateObject^("Shell.Application"^) > "%temp%\elevate.vbs"
    ECHO UAC.ShellExecute "%~s0", "", "", "runas", 1 >> "%temp%\elevate.vbs"
    "%temp%\elevate.vbs"
    exit /b
)

REM ============================================================
REM Network Chooser Execution (Basic or Advanced)
REM ============================================================
cls
echo Applying basic low latency network tweaks...
netsh int tcp set global autotuninglevel=disable
netsh int tcp set global rss=enabled
netsh int tcp set global chimney=disabled
netsh int tcp set global dca=enabled
ipconfig /flushdns
ipconfig /release
ipconfig /renew
cls
echo Basic network tweaks applied.
pause
cls
echo Advanced Network Optimizations (will backup affected registry keys first)
echo.
set backup_dir=%~dp0regbackups
if not exist "%backup_dir%" mkdir "%backup_dir%"
echo Exporting current network interface registry keys...
reg export "HKLM\SYSTEM\CurrentControlSet\Services\Tcpip\Parameters\Interfaces" "%backup_dir%\Interfaces_Backup.reg" /y >nul 2>&1
reg export "HKLM\SYSTEM\CurrentControlSet\Services\Tcpip\Parameters" "%backup_dir%\Tcpip_Params_Backup.reg" /y >nul 2>&1
echo Backups saved to %backup_dir%
echo.
echo Applying global TCP settings...
netsh int tcp set global autotuninglevel=disabled
netsh int tcp set global congestionprovider=ctcp
netsh int tcp set global ecncapability=disabled
netsh int tcp set global rss=enabled
netsh int tcp set global chimney=disabled
netsh int tcp set global dca=enabled
echo.
echo Applying per-adapter registry tweaks (TcpAckFrequency=1, TCPNoDelay=1)...
for /f "tokens=*" %%A in ('reg query "HKLM\SYSTEM\CurrentControlSet\Services\Tcpip\Parameters\Interfaces" ^| findstr /r /c:"\\{[0-9A-Fa-f-]*\\}"') do (
    set "iface=%%A"
    call :apply_iface_reg "%%A"
)
echo.
cls
echo Advanced network tweaks applied. A full system restart is recommended.
pause
:apply_iface_reg
rem %1 contains the registry path
setlocal enabledelayedexpansion
set regpath=%~1
rem Remove possible leading spaces
for /f "delims=" %%R in ('echo %regpath%') do set regpath=%%R
reg add "%regpath%" /v TcpAckFrequency /t REG_DWORD /d 1 /f >nul 2>&1
reg add "%regpath%" /v TCPNoDelay /t REG_DWORD /d 1 /f >nul 2>&1
endlocal & goto :eof
goto END

:END
echo Exiting Network Tweaks...
pause