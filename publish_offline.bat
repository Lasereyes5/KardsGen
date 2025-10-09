@echo off
title Lain

cd KardsGen
dotnet nuget disable source nuget.org
dotnet publish /restore /p:RestoreAdditionalProjectSources=packages
dotnet nuget enable source nuget.org
