
function Copy-ArtifactItem {
    param($source, $destination)

	if (Test-Path $source -PathType Container) {
		xcopy /E /I	$source\*.* $destination | Out-Null
	} else {		
		echo F | xcopy $source $destination | Out-Null
	}
}


