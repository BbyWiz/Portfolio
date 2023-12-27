FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Client/Portfolio.Client.csproj", "Client/"]
RUN dotnet restore "Client/Portfolio.Client.csproj"
COPY . .
RUN dotnet publish "Client/Portfolio.Client.csproj" -c Release -o /app/publish

# Stage 2: Build the runtime image with Nginx and Alpine
FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=build /app/publish/wwwroot .
# Be sure to provide a proper nginx.conf configured for serving a Blazor app
COPY Client/nginx.conf /etc/nginx/nginx.conf
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]


# Dockerfile