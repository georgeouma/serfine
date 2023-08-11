FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Serfine.PublicAPI/Serfine.PublicAPI.csproj", "Serfine.PublicAPI/"]
RUN dotnet restore "Serfine.PublicAPI/Serfine.PublicAPI.csproj"
COPY . .
WORKDIR "/src/Serfine.PublicAPI"
RUN dotnet build "Serfine.PublicAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Serfine.PublicAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Serfine.PublicAPI.dll"]
