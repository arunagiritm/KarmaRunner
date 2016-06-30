@echo off
pushd %~dp0
echo creating input file
pushd ..\..\Node\JSFiles
call node KarmaMain.js
if %errorlevel% EQU 0 (
echo input file sucessfully created
) else (
echo Failed to create input file )
popd
popd
