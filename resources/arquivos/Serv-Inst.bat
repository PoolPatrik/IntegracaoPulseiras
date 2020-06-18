@echo off
set @diretorio=%~dp0
set @programa=ConsoleWS.exe install
cd %@diretorio%
%@programa%
net start "SecullumImportador"
pause