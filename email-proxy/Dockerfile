ARG PROJECT_NAME="email-proxy"	
ARG ENVIRONMENT

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

ARG DEFINE_CONSTANTS
ARG ENVIRONMENT
ARG PROJECT_NAME

WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY ${PROJECT_NAME}/*.csproj ./${PROJECT_NAME}/
RUN dotnet restore --interactive

# copy everything else and build app
COPY ${PROJECT_NAME}/. ./${PROJECT_NAME}/
COPY ${PROJECT_NAME}-config/appsettings.${ENVIRONMENT}.json ./${PROJECT_NAME}/

WORKDIR /source/${PROJECT_NAME}
RUN dotnet build ${PROJECT_NAME}.csproj /p:DefineConstants=$DEFINE_CONSTANTS -c release
RUN dotnet publish -c release -o /app --no-restore --no-build

FROM mcr.microsoft.com/dotnet/aspnet:7.0
	
ARG PROJECT_NAME
ARG ENVIRONMENT
ENV PROJECT_NAME_DLL=${PROJECT_NAME}".dll"
ENV CURRENT_ENVIRONMENT="--environment="${ENVIRONMENT}
WORKDIR /app
COPY --from=build-env /app ./

ENTRYPOINT "dotnet" $PROJECT_NAME_DLL $CURRENT_ENVIRONMENT