@echo off
pushd
echo creating input file
cd TestSuite\Node\JSFiles
node KarmaMain.js
if %errorlevel% EQU 0 (
echo input file sucessfully created
) else (
echo Failed to create input file )

popd