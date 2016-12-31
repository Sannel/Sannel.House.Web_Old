
//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");


//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

var solution = "Sannel.House.Web.sln";
var buildVersion = "0.1.0-alpha-0001";

// Define directories.
var buildDir = Directory("./src") + Directory("Sannel.House.Web") + Directory("bin");

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
		Information("Build Version is {0}", buildVersion);
   Information(
        @"Environment:
        ApiUrl: {0}
        Configuration: {1}
        JobId: {2}
        JobName: {3}
        Platform: {4}
        ScheduledBuild: {5}",
        AppVeyor.Environment.ApiUrl,
        AppVeyor.Environment.Configuration,
        AppVeyor.Environment.JobId,
        AppVeyor.Environment.JobName,
        AppVeyor.Environment.Platform,
        AppVeyor.Environment.ScheduledBuild
        );
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

Task("Restore-NuGet-Packages")
	.IsDependentOn("Clean")
	.Does(() =>
{
	NuGetRestore(solution);
});

Task("Build")
	.IsDependentOn("Restore-NuGet-Packages")
	.Does(() =>
{
	if(IsRunningOnWindows())
	{
	  // Use MSBuild
	  MSBuild(solution, settings =>
		settings.SetConfiguration(configuration));
	}
	else
	{
	  // Use XBuild
	  XBuild("./src/Example.sln", settings =>
		settings.SetConfiguration(configuration));
	}
});

Task("Run-Unit-Tests")
	.IsDependentOn("Build")
	.Does(() =>
{
	NUnit3("./src/**/bin/" + configuration + "/*.Tests.dll", new NUnit3Settings {
		NoResults = true
		});
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
	.IsDependentOn("Build");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
