FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/VkTask/Host/VkTask.Host.Migrator/VkTask.Host.Migrator.csproj", "VkTask.Host.Migrator/"]
RUN dotnet restore "src/VkTask/Host/VkTask.Host.Migrator/VkTask.Host.Migrator.csproj"
COPY . .
WORKDIR "/src/VkTask.Host.Migrator"
RUN dotnet build "VkTask.Host.Migrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VkTask.Host.Migrator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VkTask.Host.Migrator.dll"]
