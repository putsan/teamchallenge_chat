FROM mcr.microsoft.com/dotnet/aspnet:latest AS base
WORKDIR /app
EXPOSE 7209

FROM mcr.microsoft.com/dotnet/sdk:latest AS build
WORKDIR /src
COPY ["Ldis_Project_Reliz.Server.csproj", "./"]
RUN dotnet restore "Ldis_Project_Reliz.Server.csproj"
COPY . .
WORKDIR "/src/Ldis_Project_Reliz.Server"
RUN dotnet build "Ldis_Project_Reliz.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ldis_Project_Reliz.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ldis_Project_Reliz.Server.dll"]
