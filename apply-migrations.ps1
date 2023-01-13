Write-Host "Creating migrations bundle" -ForegroundColor blue
dotnet ef --project "./src/Contacter.Persistence" migrations bundle --force

Write-Host "Executing migration" -ForegroundColor blue
./efbundle.exe --connection 'Server=127.0.0.1,1433;Database=contacter-database;User Id=SA;Password=Test123456!;Encrypt=False'