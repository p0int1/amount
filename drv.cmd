@echo off
setlocal enableextensions enabledelayedexpansion
::mode con:cols=30 lines=10

if %1.==. (
echo No param 1
exit
)

telnet 10.66.9.119 2%1
