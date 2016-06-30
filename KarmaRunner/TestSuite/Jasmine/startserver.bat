pushd %~dp0
IF "%1"=="" (
node web-server.js
) ELSE (
node web-server.js %1
)