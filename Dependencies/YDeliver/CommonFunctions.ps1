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

