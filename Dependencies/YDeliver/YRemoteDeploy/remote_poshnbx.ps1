param($config, $target, $ip)

. .\Functions\Get-WebContent.ps1    
. .\Functions\Zip-Functions.ps1
. .\Functions\TeamCity-Functions.ps1

$deploy_config = $config.deploy

Write-Host Artifact: $deploy_config.download_artifact
Write-Host Unzip Dir: $deploy_config.unzip_dir

$download_dir = Split-Path $deploy_config.download_artifact
if (-not (Test-Path $download_dir)) { mkdir $download_dir }

$unzip_dir = "$($deploy_config.unzip_dir)"

Download-TeamCityArtifact -project $deploy_config.teamcity_project_id -artifact $deploy_config.teamcity_artifact_name -dest $deploy_config.download_artifact -team_city_url $deploy_config.teamcity_url

Unzip-File $deploy_config.download_artifact $unzip_dir | Out-Null

# TODO add some error checking here. If the artifact isn't here or the unzip_dir then something
# horrible has happened
cd $unzip_dir

### This can be executed because this script gets Thunder-Cat'ed ###
Set-ExecutionPolicy Unrestricted
####################################################################

$drive = Get-InstallDrive $config
Ensure-IISServerDirectory($drive)

& ".\deploy.ps1" -task $target -ip $ip -remoteConfig $config
