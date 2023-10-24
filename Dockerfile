# Użyj oficjalnego obrazu .NET
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
RUN apt-get update && apt-get install -y --allow-unauthenticated libgdiplus
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Zbuduj aplikację
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["UsersNotebook/UsersNotebook.csproj", "UsersNotebook/"]
RUN dotnet restore "UsersNotebook/UsersNotebook.csproj"
COPY . .
WORKDIR "/src/UsersNotebook"
RUN dotnet build "UsersNotebook.csproj" -c Release -o /app/build

# Publikuj aplikację
FROM build AS publish
RUN dotnet publish "UsersNotebook.csproj" -c Release -o /app/publish

# Uruchom aplikację
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UsersNotebook.dll"]