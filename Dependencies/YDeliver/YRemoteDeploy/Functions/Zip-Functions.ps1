# zip functions
$z = "C:\7z\7za.exe"

function Unzip-File {
    param($source, $destination)

    if ($destination -ne "") {$destination = "-o" + $destination }
    
	Remove-Item $destination -Recurse -ErrorAction silentlycontinue
    & $z x -y $source $destination 
}
