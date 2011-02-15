param($environmentFile, 
      $application, 
      $credential 
     )
    
$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path 

gci "$scriptDir\Functions" | % { . $_.FullName } 

Import-Module "$scriptDir\..\..\PowerYaml\PowerYaml.psm1"
$environmentYaml = Get-Yaml -yamlFile (Resolve-Path $environmentFile).Path 

$config = $environmentYaml.applications.$application

$slug = "$($environment)_$($application)"
$config.deploy.unzip_dir         = "C:\temp\$slug"
$config.deploy.download_artifact = "C:\temp\$($slug)_installer.zip"
$config.deploy.unzip_dir         = "$($config.deploy.unzip_dir)$(get-date -format 'yyyMMddHHmmss')"

Execute-PoshNBx -config $config -remoteScript "$scriptDir\remote_poshnbx.ps1" -cred $credential
