# Stage 1: Build and publish the server project
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Server/Portfolio.Server.csproj", "Server/"]
COPY ["Client/Portfolio.Client.csproj", "Client/"]
COPY ["Shared/Portfolio.Shared.csproj", "Shared/"]
RUN dotnet restore "Server/Portfolio.Server.csproj"
COPY . .
RUN dotnet publish "Server/Portfolio.Server.csproj" -c Release -o /app/publish

# Stage 2: Build the runtime image with ASP.NET Core
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "Portfolio.Server.dll"]
