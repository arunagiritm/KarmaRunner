@echo off
set path=%path%;%~dp0;
pushd %1
call karma start %2
if %errorlevel% EQU 0 (
echo karma sucessfully executed
) ELSE (
echo karma execution failed 1>&2
)