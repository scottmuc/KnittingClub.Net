
function Merge-DeployConfigurations($baseConfig, $overrideConfig, $ip, $webapp) {

    $mergedBase = Merge-Hash $baseConfig $baseConfig.targets.DeployWeb.localhost.$webapp
    $mergedOverrides = Merge-Hash $overrideConfig $overrideConfig.targets.DeployWeb.$ip.$webapp

    $mergedConfig = Merge-Hash $mergedBase $mergedOverrides

    return $mergedConfig
}

