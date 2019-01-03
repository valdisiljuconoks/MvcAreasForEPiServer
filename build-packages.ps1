cd .\.nuget

.\nuget.exe pack ..\src\MvcAreasForEPiServer\MvcAreasForEPiServer.csproj -Properties Configuration=Release
.\nuget.exe pack ..\src\MvcAreasForEPiServer.Forms\MvcAreasForEPiServer.Forms.csproj -Properties Configuration=Release
cd ..\