# Create projects
if($True){
	dotnet new "cluu.project.base" -n DemoClientDevelopment
}

if($True){
	dotnet new "cluu.project.apppackage" -n DemoClientDevelopment.AppPackage
}

if($True){
	dotnet new "cluu.project.actions" -n DemoClientDevelopment.Actions
}

if($True){
	dotnet new "cluu.project.database" -n DemoClientDevelopment.Database -c "Server=localhost\SQLEXPRESS;Database=Cluu_6_App_Dev;TrustServerCertificate=True;Integrated Security=true;Connection Timeout=30"
}

if($True){
	dotnet new "cluu.project.metadata" -n DemoClientDevelopment.Metadata -c "Server=localhost\SQLEXPRESS;Database=Cluu_6_App_Dev;TrustServerCertificate=True;Integrated Security=true;Connection Timeout=30"
}

if($True){
	dotnet new "cluu.project.test" -n DemoClientDevelopment.Tests
}

if($True){
	dotnet new "cluu.project.webui" -n DemoClientDevelopment.Web.UI
}

# Add projects to solution
$filesToAdd = Get-ChildItem **/*.csproj
$filesToAdd += Get-ChildItem **/*.sqlproj
$slnPath = Get-ChildItem *.sln
foreach($fileToAdd in $filesToAdd){
	dotnet sln $slnPath add $fileToAdd
}

# Correctly add Database project to solution
(Get-Content $slnPath).replace('("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "DemoClientDevelopment.Database"', '("{00D1A9C2-B5F0-4AF3-8072-F6C62B433612}") = "DemoClientDevelopment.Database"') | Set-Content $slnPath

# CLI installieren
dotnet new tool-manifest

if($(wget -Uri https://nuget.softwarehelden.intern/Cluu_Release_6.0/index.json).StatusCode -eq 200){
	dotnet tool install cluu.cli
	dotnet tool restore
}

pause