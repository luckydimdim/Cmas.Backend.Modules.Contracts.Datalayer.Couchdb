:: msbuild /t:pack /p:Configuration=Release
:: cd .\Cmas.Backend.Modules.Contracts.Datalayer.Couchdb\bin\Release\
:: nuget push Cmas.Backend.Modules.Contracts.Datalayer.Couchdb.1.0.4.nupkg -Source http://cm-ylng-msk-04/nuget/nuget

cd .\Cmas.Backend.Modules.Contracts.Datalayer.Couchdb\bin\Debug\
nuget push Cmas.Backend.Modules.Contracts.Datalayer.Couchdb.1.0.8.nupkg -Source http://cm-ylng-msk-04/nuget/nuget
pause