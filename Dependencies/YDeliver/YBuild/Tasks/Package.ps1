task Package {
    Log-Message "Packaging artifact of the build..."

    $buildDir = $ybc.buildDir
    $packageDir = $ybc.packageDir
    $toolsDir = $ybc.toolsDir
    $solution = $ybc.solution

    if (-not (Test-Path $packageDir)) {
        md $packageDir | Out-Null
    }

    if ($config.ilmerge -ne $null) {
        ExecuteTask MergeAssemblies
    }

    foreach($source in $($config.packageContents).keys){
        Copy-ArtifactItem "$rootDir\$source" "$($packageDir)\$($config.packageContents[$source])"
    }

    pushd $packageDir

    $zip = "$toolsDir\7z\7za.exe"
    $zipFileName = Get-ChildItem $solution | % { $_.BaseName }

    & $zip a -r "$buildDir\$($zipFileName).zip" *

    popd
}
