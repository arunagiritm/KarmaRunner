@echo off
pushd
echo creating input file
cd TestSuite\Node\JSFiles
node KarmaMain.js
echo input file sucessfully created
popd