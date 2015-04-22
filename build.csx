var target = Argument("target", "Build");
var solutions = GetFiles("./*.sln");
var outputDir = "./build/";

Task("Clean")
    .Does(() =>
{
    CleanDirectory(outputDir);
});

Task("Restore")
    .IsDependentOn("Clean")
    .Does(() =>
{
    foreach(var solution in solutions)
    {
        NuGetRestore(solution);
    }
});

Task("Build")
    .IsDependentOn("Restore")
    .Does(() =>
{
    foreach(var solution in solutions)
    {
        MSBuild(solution, settings => 
            settings
                .WithTarget("Build")
            	.SetPlatformTarget(PlatformTarget.MSIL)
                .SetConfiguration("debug")
                .WithProperty("RunOctoPack", "true"));
    }
});

//Task("NUnitTests")
//    .IsDependentOn("Build")
//    .Does(() =>
//{
//    NUnit(GetFiles("./UnitTestProject*/bin/debug/UnitTestProject*.dll"),
//        new NUnitSettings 
//        {
//            ToolPath = "./packages/NUnit.Runners/tools/nunit-console.exe"
//        });
//});

Task("CreateRelease")
    .IsDependentOn("Build")
    .Does(() =>
{
	OctoCreateRelease(
		"TestMathieu"
		new OctoCreateReleaseSettings
		{
			packageFolder = "./ConsoleApplication1/bin/debug/"
		});
}

RunTarget(target);