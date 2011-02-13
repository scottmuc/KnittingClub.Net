function Import-Tasks($scriptDir) {
    gci "$scriptDir\Tasks" | % { . $_.FullName } 
}

function Exit-IfError($message) {

    if ($lastexitcode -ne 0) {
        Write-Host -foreground red $message
        exit 1
    }
}

function Log-Message($message, $type = "message") {
    
    switch ($type.ToLower()){
        "message" { $messageColor = "Green" }
        "error"   { $messageColor = "Red" }
        "warning" { $messageColor = "Yellow" }
        "info"    { $messageColor = "Cyan" }
    }
    
    Write-Host -ForegroundColor $messageColor "`n==========================================="
    Write-Host -ForegroundColor $messageColor $message
    Write-Host -ForegroundColor $messageColor "===========================================`n"
}


function Copy-ArtifactItem {
    param($source, $destination)

	if (Test-Path $source -PathType Container) {
		xcopy /E /I	$source\*.* $destination | Out-Null
	} else {		
		echo F | xcopy $source $destination | Out-Null
	}
}

function Merge-Hash($base, $new) {
    if ($new -eq $null) { return $base.Clone() }
    if ($base -eq $null) { return $new.Clone() }

    foreach($key in $new.keys) {
        
        if ($new["$key"] -eq $null) {
            Write-Host "The key of [$key] is null... skipping"
        } elseif ($new["$key"] -is [Hashtable]) {
            if ($base[$key] -eq $null)
            {
                $base[$key] = $new[$key].Clone()
            } else {
                if ($base[$key] -is [String]){
                    $base[$key] = $new[$key]
                } else {
                    $base[$key] = Merge-Hash $base[$key].Clone() $new[$key].Clone()
                }
            }
        } else {
            $base[$key] = $new[$key]
        }
    }
    return $base
}

function Merge-DeployConfigurations($baseConfig, $overrideConfig, $ip, $webapp) {

    $mergedBase = Merge-Hash $baseConfig $baseConfig.targets.DeployWeb.localhost.$webapp
    $mergedOverrides = Merge-Hash $overrideConfig $overrideConfig.targets.DeployWeb.$ip.$webapp

    $mergedConfig = Merge-Hash $mergedBase $mergedOverrides

    return $mergedConfig
}

