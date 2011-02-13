$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path
. "$scriptDir\..\CommonFunctions.ps1"

function Set-WebsiteBindings($siteName, $bindings) {

    Get-WebBinding -Name $siteName | Remove-WebBinding

    $bindings | % {
        $hostheader,$ip = $_.Split("|")

        if ($ip -eq $null) { $ip = "*" }
        if ($hostheader -eq $null) { $hostheader = "" }

        Write-Host Adding $hostheader binding to $ip

        New-WebBinding -Name $siteName -IPAddress $ip -Port 80 -HostHeader $hostheader
    }
}

function Deploy-IISWebsite($config) {
    Log-Message "Deploying Website: $($config.ApplicationLabel)"

    $sitePath = "C:\inetpub\wwwroot\$($config.ApplicationLabel)-$(get-date -format 'yyyyMMddHHmmss')"
    $siteName    = $config.ApplicationLabel
    $siteSource  = "$rootDir\$($config.WebSourceDir)"

    Get-Website | %{

        if($_.name -eq $siteName){
            Write-Host "Attempting to stop website $siteName and App Pool $siteName"
            Stop-Website    -Name $siteName
            if ((Get-WebAppPoolState -Name $siteName).value -eq "Started"){ Stop-WebAppPool -Name $siteName }

            write-host "Website status $((Get-WebsiteState -name $siteName).value)"
            write-host "Website status $((Get-WebAppPoolState -name $siteName).value)"
        }
    }

    Write-Host "Copy new website to $sitePath ..."
    Copy-Item "$siteSource" $sitePath -force -recurse

    # ########################################## #
    # edit all the config files for this service #
    # ########################################## #

    if ($config.config -ne $null) {
        $config.config.keys | % { Splice-XMLConfigFile "$sitePath\$_" $config.config[$_] }
    }

    # ########################################## #

    Write-Host "Create new site $siteName ..."
    $output = New-Website -Name $siteName -PhysicalPath $sitePath -force

    Set-WebsiteBindings $siteName $config.WebHostHeader

    if (Test-Path IIS:\AppPools\$siteName)
    {
        Write-Host "AppPool Exists, Removing the old one..."
        Remove-WebAppPool -name $siteName
    }

    Write-Host "Addding New AppPool '$siteName ...'"
    New-WebAppPool -name $siteName

    Set-ItemProperty "IIS:\Sites\$siteName" -name applicationPool -value "$siteName"
    sleep 1

    Start-Website -name $siteName
}




Import-Tasks $scriptDir
