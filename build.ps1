param(
    # The following Tasks will be exuted serially. The build process must be explicitly
    # listed here. No auto task dependency resoltuion is going on here.
    $task = @("EnvironmentCheck", "Clean", "Compile", "Package"),

    # By default the build version is what is automatically populated by Visual Studio in an
    # AssemblyInfo.cs file. This can be overridden by a CI server by passing the -buildVersion arg
    $buildVersion = "1.0.0.0",

    # These are MSBuild specific verbosity levels. If you want see more build output it can be
    # changed via the -verbose parameter.
    #   $verbose = "minimial"  # debug, info, warn, error, fatal, none
    $verbose = "/noconsolelogger"  #q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic]. e.g.: /v:n
)

# One root dir to rule them all and in global scope bind them!
$global:rootDir = Split-Path -Parent $MyInvocation.MyCommand.Path

# Import project specific conventions (ybc = YDeploy Build Conventions)
$ybc = @{}
$ybc.buildDir = "$rootDir\build"
$ybc.packageDir = "$rootDir\build\package"
$ybc.solution = (Resolve-Path $rootDir\*.sln)
$ybc.toolsDir = "$rootDir\Dependencies"
$ybc.buildConfiguration = "Release"

# PSake is the task execution framework being used
Import-Module "$($ybc.toolsDir)\PSake\psake.psm1" -force

# PowerYaml is needed to load the YAML build file
Import-Module "$($ybc.toolsDir)\$dependenciesDir\PowerYaml\PowerYaml.psm1" -force
$config = Get-Yaml -YamlFile "$rootDir\build.yml"

# Here's where the build is actually executed
Invoke-Psake "$($ybc.toolsDir)\YDeliver\YBuild\Build.Tasks.ps1" -framework $config.dotnet.framework_version -taskList $task `
    -parameters @{
        "buildVersion" = $buildVersion;
        "ybc" = $ybc;
        "config" = $config;
        "rootDir" = $rootDir;
        "verbose" = $verbose;
      }
