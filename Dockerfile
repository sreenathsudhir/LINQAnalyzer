# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and project files first to leverage Docker caching
COPY ["LINQAnalyzer.sln", "./"]
COPY ["src/Core/LINQAnalyzer.Domain/LINQAnalyzer.Domain.csproj", "src/Core/LINQAnalyzer.Domain/"]
COPY ["src/Core/LINQAnalyzer.Application/LINQAnalyzer.Application.csproj", "src/Core/LINQAnalyzer.Application/"]
COPY ["src/Infrastructure/LINQAnalyzer.Infrastructure/LINQAnalyzer.Infrastructure.csproj", "src/Infrastructure/LINQAnalyzer.Infrastructure/"]
COPY ["src/Presentation/LINQAnalyzer.UI/LINQAnalyzer.UI.csproj", "src/Presentation/LINQAnalyzer.UI/"]
COPY ["src/Presentation/LINQAnalyzer.CLI/LINQAnalyzer.CLI.csproj", "src/Presentation/LINQAnalyzer.CLI/"]

RUN dotnet restore

# Copy source code and publish Blazor UI
COPY . .
WORKDIR "/src/src/Presentation/LINQAnalyzer.UI"
RUN dotnet publish "LINQAnalyzer.UI.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "LINQAnalyzer.UI.dll"]