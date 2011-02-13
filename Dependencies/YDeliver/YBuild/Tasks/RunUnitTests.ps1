task RunUnitTests {
    $testProjects = ""

    $buildConfiguration = $ybc.buildConfiguration
    $toolsDir = $ybc.toolsDir
    $buildDir = $ybc.buildDir

    Get-ChildItem "$rootDir\*.Tests\*.csproj" | %{
        $testProjects += "$(split-path $_.fullname)\bin\$buildConfiguration\$([system.io.path]::GetFilenameWithoutExtension($_.name)).dll "
    }

    $nunit = "$toolsDir\NUnit\nunit-console.exe"
    $testType = "Unit"
    Log-Message "Running $testType Tests..."
    iex "$nunit $testProjects /xml=$buildDir\$testType-Test-Reports.xml"

    Exit-IfError "Build Failed - $testType Test".toUpper()
}
