@echo off
title Lain
set dotnet_dir=dotnet 
%dotnet_dir%msbuild /p:Configuration=Release /p:Platform=x64
