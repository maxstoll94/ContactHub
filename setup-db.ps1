Write-Host "Executing database creation" -ForegroundColor blue
sqlcmd -S "localhost,1433" -U SA -P "Test123456!" -d master -Q "CREATE DATABASE [contacter-database];"

Write-Host "Applying migrations" -ForegroundColor blue
dotnet ef --project "./src/Contacter.Persistence" migrations script --idempotent -o 'migration-script.sql'
sqlcmd -S "localhost,1433" -U SA -P "Test123456!" -d master -i 'migration-script.sql'