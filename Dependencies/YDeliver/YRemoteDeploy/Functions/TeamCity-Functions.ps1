function Get-DefaultTeamCityBaseURL {
    return "localhost"
}

function Download-TeamCityArtifact {
    param($project, $artifact, $team_city_url, $dest)
    
    if ("$team_city_url" -eq "") {$team_city_url = Get-DefaultTeamCityBaseURL}
    
    $url = "http://$team_city_url/guestAuth/repository/download/$project/.lastPinned/$artifact" 

    Get-WebContent -url $url -file $dest
}
