
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /app
EXPOSE 5006
ARG BUILD_CONFIGURATION=Release

# copy csproj and restore as distinct layers
COPY "email-proxy/email-proxy.sln" "email-proxy/"
COPY "email-proxy/email-proxy/email-proxy.csproj" "email-proxy/"
RUN dotnet restore "email-proxy/email-proxy.csproj"

# copy everything else and build app
COPY "email-proxy/email-proxy" "email-proxy/"
COPY "email-proxy/email-proxy-config/appsettings.json" "./email-proxy/"

WORKDIR "/app/email-proxy"
RUN dotnet build "email-proxy.csproj" -c $BUILD_CONFIGURATION -o /app/build
#RUN dotnet publish -c release -o /app --no-restore 

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "email-proxy.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
    
FROM mcr.microsoft.com/dotnet/aspnet:7.0

WORKDIR /app
COPY --from=publish ./app/publish ./

ENTRYPOINT "dotnet" "email-proxy.dll"
