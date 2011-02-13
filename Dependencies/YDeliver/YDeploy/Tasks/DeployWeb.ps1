task DeployWeb {

    $webApplications = $null

    if ($remoteConfig.targets.DeployWeb.$ip -ne $null) {
        $webApplications = $remoteConfig.targets.DeployWeb.$ip.keys
    } else {
        $webApplications = $localConfig.targets.DeployWeb.localhost.keys
    }

    foreach($webapp in $webApplications) {
        $mergedDeploymentConfig = Merge-DeployConfigurations $localConfig $remoteConfig $ip $webapp 
        Deploy-IISWebsite $mergedDeploymentConfig
    }
}


