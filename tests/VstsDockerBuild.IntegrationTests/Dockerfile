FROM microsoft/dotnet:2.0-sdk-jessie AS build

COPY . ./app
WORKDIR /app/tests/VstsDockerBuild.IntegrationTests
RUN dotnet restore