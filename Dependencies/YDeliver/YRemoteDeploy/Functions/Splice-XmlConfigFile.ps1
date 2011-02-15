function Splice-XmlConfigFile($file, $spliceConfig) {
    if (-not (Test-Path $file)) { return }

    [xml] $xml = gc $file
    Set-XmlValues $xml $spliceConfig.spliceMap $spliceConfig.namespaces
    $xml.Save($file)
}

function Set-XmlValues($xml, $spliceMap, $ns) {

    $spliceMap.keys | % {
        $xpath = $_
        $setSpec = $spliceMap[$_]

        $baseCommand = "`$xml | Select-Xml -XPath `$xpath"

        if ($ns -ne $null) {
            $baseCommand += " -Namespace `$ns"
        }

        $setSpec | % {
            $spec = $_
            $command = $baseCommand

            if ($spec.StartsWith("@"))
            {
                $firstEquals = $spec.indexOf("=")
                $attribute = $spec.substring(1, $firstEquals - 1)
                $value = $spec.substring($firstEquals + 1)
                $attribute
                $value
                $command += " | % { `$_.Node.$attribute = `"$value`" }"
            }
            else
            {
                $command += " | % { `$_.Node.innerText = `"$spec`" }"
            }

            Write-Host "Executing Command: $command"
            iex $command
        }
    }
}
