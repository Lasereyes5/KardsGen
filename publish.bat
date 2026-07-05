@echo off
title Lain

dotnet msbuild /t:publish /p:PublishAot=true /p:_SuppressWinFormsTrimError=true /restore /p:Configuration=Release /p:Platform=x64