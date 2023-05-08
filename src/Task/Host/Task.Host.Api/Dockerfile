FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Task/Host/Task.Host.Api/Task.Host.Api.csproj", "Task.Host.Api/"]
RUN dotnet restore "src/Task/Host/Task.Host.Api/Task.Host.Api.csproj"
COPY . .
WORKDIR "/src/Task.Host.Api"
RUN dotnet build "Task.Host.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Task.Host.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Task.Host.Api.dll"]
