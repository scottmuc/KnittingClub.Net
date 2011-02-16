function Get-Conventions($conventions) {

    $conventions | % {
        if ($ybc.$_ -eq $null) {
            Log-Message -message "Missing convention: $_ Please update your .\build.ps1 to have a value for `$ybc.$_" -type "error"
            cd $rootDir
            exit 1
        }
        $ybc.$_
    }

}
