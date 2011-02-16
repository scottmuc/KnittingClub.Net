task Compile {
    Log-Message "Compiling $solution ..."
    $solution, $buildConfiguration = Get-Conventions solution, buildConfiguration

    $newVersion = 'AssemblyVersion("' + $buildVersion + '")';
    $newFileVersion = 'AssemblyFileVersion("' + $buildVersion + '")';

    Get-ChildItem $rootDir -Recurse | ? {$_.Name -eq "AssemblyInfo.cs"} | % {
        $tmpFile = "$($_.FullName).tmp"

        gc $_.FullName |
            %{$_ -replace 'AssemblyVersion\("[0-9]+(\.([0-9]+|\*)){1,3}"\)', $newVersion } |
            %{$_ -replace 'AssemblyFileVersion\("[0-9]+(\.([0-9]+|\*)){1,3}"\)', $newFileVersion }  | 
              Out-File $tmpFile -encoding UTF8

        Move-Item $tmpFile $_.FullName -force        
    }

    Exec { msbuild $solution /p:Configuration=$buildConfiguration $verbose } "Build Failed - Compilation"
}

