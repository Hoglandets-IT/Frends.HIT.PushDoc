$Version = $(Get-Content -Path ".\VERSION")
$KEY = $args[0]

$Parts = $Version.Split('.')
$Last = [int]$Parts[$Parts.Length - 1]
$Last += 1
$Parts[$Parts.Length - 1] = $Last
$Version = $Parts -join "."

Write-Host "Building version $VERSION"
Remove-Item -Path .\Frends.HIT.PushDoc.*.nupkg -Force
dotnet pack --configuration Release --include-source --output . /p:Version=$VERSION Frends.HIT.PushDoc/Frends.HIT.PushDoc.csproj
dotnet nuget push .\Frends.HIT.PushDoc.$VERSION.nupkg -k $KEY -s https://proget.intern.hoglandet.se/nuget/Frends/
Write-Host "Done"
Set-Content -Path .\Version -Value $Version
Remove-Item -Path .\Frends.HIT.PushDoc.*.nupkg -Force
