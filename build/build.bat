@echo off
cls
if "%1"=="" goto targetlist

tools\nant\bin\NAnt.exe -buildfile:main.build %1

goto end

:targetlist
tools\nant\bin\NAnt.exe -buildfile:main.build -projecthelp

:end