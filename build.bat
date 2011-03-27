@echo off
if "%BUILD_NUMBER%"=="" (
    set BUILD_NUMBER=1.0.0.0
)

@powershell set-executionpolicy unrestricted
@powershell .\build.ps1 -ver /v:n -buildNumber %BUILD_NUMBER%
 