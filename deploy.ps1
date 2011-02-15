param(
    $task = @("DeployWeb"),
    $verbose = "/noconsolelogger",  #q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic]. e.g.: /v:n
    $ip = "localhost",
    $configurationOverrides = @{ }
)

# Obtain the root project path to base all other pathes off of
$global:rootDir = Split-Path -Parent $MyInvocation.MyCommand.Path

# Import project specific conventions (ybc = YDeploy Build Conventions)
$ybc = @{}
$ybc.toolsDir = "$rootDir\Dependencies"

Import-Module webadministration

# PSake is the task execution framework being used
Import-Module "$($ybc.toolsDir)\PSake\psake.psm1" -force

# PowerYaml is needed to load the YAML build file
Import-Module "$($ybc.toolsDir)\$dependenciesDir\PowerYaml\PowerYaml.psm1" -force
$config = Get-Yaml -YamlFile "$rootDir\deploy.yml"

Invoke-Psake "$($ybc.toolsDir)\YDeliver\YDeploy\Deployment.Tasks.ps1" -taskList $task `
    -parameters @{
        "rootDir" = $rootDir;
        "verbose" = $verbose;
        "localConfig" = $config;
        "remoteConfig" = $configurationOverrides;
        "ip" = $ip;
        "ybc" = $ybc;
      }
