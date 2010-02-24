@echo off
cls
if "%1"=="" goto targetlist

tools\nant\bin\NAnt.exe -buildfile:default.build %1

goto end

:targetlist
tools\nant\bin\NAnt.exe -buildfile:default.build -projecthelp

:end