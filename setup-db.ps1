Write-Host "Executing database creation" -ForegroundColor blue
sqlcmd -S "localhost,1433" -U SA -P "Test123456!" -d master -Q "CREATE DATABASE [contacter-database];"

Write-Host "Creating migrations bundle" -ForegroundColor blue
dotnet ef --project "./src/Contacter.Persistence" migrations bundle --force

Write-Host "Executing migration" -ForegroundColor blue
./efbundle.exe --connection 'Server=127.0.0.1,1433;Database=contacter-database;User Id=SA;Password=Test123456!;Encrypt=False'