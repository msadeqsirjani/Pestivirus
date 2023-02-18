FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Pestivirus.Api/Pestivirus.Api.csproj", "Pestivirus.Api/"]
RUN dotnet restore "Pestivirus.Api/Pestivirus.Api.csproj"
COPY . .
WORKDIR "/src/Pestivirus.Api"
RUN dotnet build "Pestivirus.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pestivirus.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pestivirus.Api.dll"]