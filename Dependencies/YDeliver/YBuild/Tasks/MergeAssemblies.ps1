task MergeAssemblies {
    Log-Message "Merging assemblies with ILMerge..."
   
    $toolsDir = $ybc.toolsDir
    $buildDir = $ybc.buildDir

    $ILMerge = "$toolsDir\ILMerge\ILMerge.exe"

    $outputDir = "$buildDir\ilmerge"

    $target = $config.ilmerge.target
    $filename = $config.ilmerge.filename

    $config.ilmerge.assemblies | % { $assemblies += "$rootDir\$_ " }

    if (-not (Test-Path $outputDir)) {
        md $outputDir | Out-Null
    }

    iex "$ILMerge /target:$target /out:$buildDir\ilmerge\$filename $assemblies"
}

