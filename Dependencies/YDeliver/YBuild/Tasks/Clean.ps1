task Clean {
    Log-Message "Cleaning the project..."
    $buildDir, $solution = Get-Conventions buildDir, solution

    # Thinking of making bin, obj folders a convention
    Get-ChildItem $rootDir -Include bin, obj -Recurse | %{ Remove-Item $_\* -Force -Recurse }
    Remove-Item $buildDir -Force -Recurse -ErrorAction silentlycontinue

    Exec { msbuild $solution /t:clean $verbose } "Could not clean the project"
    Exec { mkdir $buildDir | Out-Null }
}
