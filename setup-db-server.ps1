Write-Host "Pull SQL Server image" -ForegroundColor blue
docker pull mcr.microsoft.com/mssql/server:2022-latest

Write-Host "Create a new SQL Server docker container" -ForegroundColor blue
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Test123456!" -p 1433:1433 --name localsql --hostname sql1 -d mcr.microsoft.com/mssql/server:2022-latest
