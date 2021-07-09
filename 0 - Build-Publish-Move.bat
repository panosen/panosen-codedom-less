@echo off

dotnet restore

dotnet build --no-restore -c Release

move /Y Panosen.CodeDom.Less\bin\Release\Panosen.CodeDom.Less.*.nupkg D:\LocalSavoryNuget\
move /Y Panosen.CodeDom.Less.Engine\bin\Release\Panosen.CodeDom.Less.Engine.*.nupkg D:\LocalSavoryNuget\

pause