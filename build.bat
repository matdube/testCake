@echo off
cls 

nuget Install "Cake" -OutputDirectory "packages" -ExcludeVersion -Source "C:\dev\sources\cake\build\v0.2.2\nuget"
nuget Install -OutputDirectory "packages" -ExcludeVersion

for %%i in (nuget.exe) do (set nugetFullPath=%%~$PATH:i)
"packages\Cake\Cake.exe" build.csx

pause