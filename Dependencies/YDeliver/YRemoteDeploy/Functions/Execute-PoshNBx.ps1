function Execute-PoshNBx($config, $remoteScript, $cred) {
    $remoteCommand = Thunder-Cat $remoteScript
    $scriptBlock   = $ExecutionContext.InvokeCommand.NewScriptBlock($remoteCommand)

    $config.targets.keys | % {
        $target = $_
        
        Write-Host Running $target
        
        $config.targets[$target].keys | % {
            $ip = $_                
            
            if ($cred -eq $null) { 
                Invoke-Command -ComputerName $ip -ScriptBlock $($scriptBlock) -ArgumentList ($config, $target, $ip)
            } else {
                Invoke-Command -ComputerName $ip -ScriptBlock $($scriptBlock) -ArgumentList ($config, $target, $ip) -Credential $cred
            }
        }
    }    
}
