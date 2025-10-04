@echo off
cls
title Importing Power Plan
echo Importing Free Power Plan...
echo =================================
:: Commands from the :plan section
powercfg -import "C:\risxnfree\Powerplan\RisxnFree.pow"
powercfg.cpl
echo.
echo Plan Imported Sucessfully
pause