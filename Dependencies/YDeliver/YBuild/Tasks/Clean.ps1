task Clean {
    Log-Message "Cleaning the project..."

    $buildDir = $ybc.buildDir
    $solution = $ybc.solution

    Get-ChildItem $rootDir -Include bin, obj -Recurse | %{ Remove-Item $_\* -Force -Recurse }
    Remove-Item $buildDir -Force -Recurse -ErrorAction silentlycontinue

    iex "$msbuild $solution /t:clean $verbose"

    if (-not (Test-Path $buildDir)) {
        $output = mkdir $buildDir
    }
}

