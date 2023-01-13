#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Contacter.Web/Contacter.Web.csproj", "src/Contacter.Web/"]
RUN dotnet restore "src/Contacter.Web/Contacter.Web.csproj"
COPY . .
WORKDIR "/src/src/Contacter.Web"
RUN dotnet build "Contacter.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Contacter.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Contacter.Web.dll"]