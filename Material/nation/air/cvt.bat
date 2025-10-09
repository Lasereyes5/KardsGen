@echo off
title Lain
set svgo_dir=F:\Projects\others\executable\friction-svgo-1.0.0-rc.2-windows-x64

FOR /R friction-svg\ %%i IN (*.svg) DO %svgo_dir%\svgo-win -i %%i -o %%~nxi
