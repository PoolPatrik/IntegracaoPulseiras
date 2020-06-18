@echo off
net stop "SecullumImportador"
set @diretorio=%~dp0
set @programa=ConsoleWS.exe uninstall
cd %@diretorio%
%@programa%
pause