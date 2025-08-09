@echo off
title Lain
set dotnet_dir=C:\Windows\Microsoft.NET\Framework64\v4.0.30319\
%dotnet_dir%msbuild /p:Configuration=Release /p:Platform=x64
