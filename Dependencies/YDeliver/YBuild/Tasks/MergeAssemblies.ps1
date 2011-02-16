task MergeAssemblies {
    Log-Message "Merging assemblies with ILMerge..."
  
    $toolsDir, $buildDir = Get-Conventions toolsDir, buildDir
    $ILMerge = "$toolsDir\ILMerge\ILMerge.exe"
    $outputDir = "$buildDir\ilmerge"

    $target = $config.ilmerge.target
    $filename = $config.ilmerge.filename

    $config.ilmerge.assemblies | % { $assemblies += "$rootDir\$_ " }

    if (-not (Test-Path $outputDir)) {
        md $outputDir | Out-Null
    }

    Exec { & $ILMerge /target:$target /out:$buildDir\ilmerge\$filename $assemblies }
}

