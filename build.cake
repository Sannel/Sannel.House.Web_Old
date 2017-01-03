#tool nuget:?package=Newtonsoft.Json&version=9.0.1
#r "tools\Newtonsoft.Json\lib\net45\Newtonsoft.Json.dll"

using Newtonsoft.Json.Linq;
//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");


//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

var solution = "Sannel.House.Web.sln";
var alphaVersion = "0.1.0-alpha-";
var betaVersion = "0.2.1-beta-";
var releaseVersion = "0.3.";
var buildVersion = String.Format("{0}0001", alphaVersion);

// Define directories.
var buildDir = Directory("./Build");

var solutionFullPath = File(System.IO.Path.Combine(buildDir, solution));

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////
Task("AppVeyorUpdate")
	.Does(() =>
{
	if(AppVeyor.IsRunningOnAppVeyor)
	{
		Information("Building on AppVeyor");
		buildVersion = AppVeyor.Environment.Build.Version;
		if(String.Compare(AppVeyor.Environment.Repository.Branch, "master") != 0)
		{
			buildVersion = String.Format("{0}{1:0000}", alphaVersion, AppVeyor.Environment.Build.Number); 
		}
		Information("Build Version is {0}", buildVersion);
	}
	else
	{
		Information("Not building on AppVeyor");
	}
});

Task("Clean")
	.IsDependentOn("AppVeyorUpdate")
	.Does(() =>
{
	CleanDirectory(buildDir);
});

Task("Copy-To-Build")
	.IsDependentOn("Clean")
	.Does(()=>
{
	CopyDirectory("./src", buildDir + Directory("src"));
	CopyFiles(solution, buildDir);
});

Task("Update-Version-Files")
	.IsDependentOn("Copy-To-Build")
	.Does(()=>
{
	var projectjsonFiles = GetFiles(System.IO.Path.Combine(buildDir, "**/project.json"));
	foreach(var file in projectjsonFiles)
	{
		var data = System.IO.File.ReadAllText(file.FullPath);
		var token = JObject.Parse(data);
		var version = token.SelectToken("version");
		if(version != null)
		{
			token.Remove("version");
		}
		token.Add("version", buildVersion);
		System.IO.File.WriteAllText(file.FullPath, token.ToString());
		Information("Updated file {0}", file);
	}
});

Task("Restore-NuGet-Packages")
	.IsDependentOn("Update-Version-Files")
	.Does(() =>
{
	NuGetRestore(solutionFullPath);
});


Task("Build")
	.IsDependentOn("Restore-NuGet-Packages")
	.Does(() =>
{
	if(IsRunningOnWindows())
	{
	  // Use MSBuild
	  MSBuild(solutionFullPath, settings =>
		settings.SetConfiguration(configuration));
	}
	else
	{
	  // Use XBuild
	  XBuild("./src/Example.sln", settings =>
		settings.SetConfiguration(configuration));
	}
});

Task("Publish")
	.IsDependentOn("Build")
	.Does(() =>
{
	DotNetCorePublish(System.IO.Path.Combine(buildDir, "src", "Sannel.House.Web"), new DotNetCorePublishSettings
	{
		Framework = "netcoreapp1.1",
		Configuration = configuration,
		OutputDirectory = System.IO.Path.Combine(buildDir, "artifacts")
	});

	CopyFiles(System.IO.Path.Combine(buildDir, "src", "Sannel.House.Web", "Start.*"), System.IO.Path.Combine(buildDir, "artifacts"));
});

Task("Zip")
	.IsDependentOn("Publish")
	.Does(() =>
{
	var zipFilePath = System.IO.Path.Combine(buildDir, String.Format("Sannel.House.Web.{0}.zip", buildVersion));
	Zip(System.IO.Path.Combine(buildDir, "artifacts"), zipFilePath);
	if(AppVeyor.IsRunningOnAppVeyor)
	{
		AppVeyor.UploadArtifact(zipFilePath);
	}	
});

Task("Run-Unit-Tests")
	.Does(() =>
{
	DotNetCoreTest("./src/Sannel.House.Web.Tests");
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
	.IsDependentOn("Zip");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
