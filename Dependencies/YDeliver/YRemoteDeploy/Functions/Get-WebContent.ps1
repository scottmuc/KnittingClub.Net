<# 
 .Synopsis
  Gets the content at a specified http url

 .Parameter url
  Url that returns content

 .Parameter file
  Optional parameter that redirects download of content to a file. If left out
  content is returned as a string
  
 .Parameter force
  Forces the acceptance of content from an untrusted source (eg. invalid certificate)
#>
Function Get-WebContent([string] $url, [string] $file = "", [switch]$force) {

    if($force) { 
        [Net.ServicePointManager]::ServerCertificateValidationCallback = {$true} 
    }
    
    $webclient = New-Object system.net.webclient

    Write-Host -fore Green $url

    if ($file -eq "") {
        return $webclient.DownloadString($url)
    } else {
        $webclient.DownloadFile($url, $file)
    }
}
