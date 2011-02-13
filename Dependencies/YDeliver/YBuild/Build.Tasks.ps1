$msbuild   = "$(get-content env:systemroot)\Microsoft.NET\Framework\v3.5\MSBuild.exe /tv:3.5"

$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path
. "$scriptDir\..\CommonFunctions.ps1"

Import-Tasks $scriptDir
