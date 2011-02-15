function Thunder-Cat
{
    param($script_name)
	$currentDir = Split-Path -Parent $script_name

    $content = ""
    gc $script_name | % {
        if ($_.startswith(". "))
        {
      
            $content += Thunder-Cat (join-path $currentDir $_.substring(2, $_.length - 2))
        }
        else
        {
            $content = $content + [Environment]::NewLine + $_
        }
    }
    $content
}