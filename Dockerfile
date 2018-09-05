FROM microsoft/dotnet-framework:4.7.2-sdk-windowsservercore-ltsc2016 AS build

WORKDIR /app
COPY . .
RUN nuget restore Aspose.Storage.Cloud.Sdk.sln

WORKDIR /app
RUN dotnet build Aspose.Storage.Cloud.Sdk.sln /p:Configuration=Release /p:OutDir=../publish /p:TargetFrameworkVersion=v4.7.2

FROM build AS testrunner
WORKDIR /app/Aspose.Storage.Cloud.Sdk.Tests
ENTRYPOINT ["dotnet", "test", "Aspose.Storage.Cloud.Sdk.Tests.csproj", \
            "--no-build", \
			"/p:TargetFrameworkVersion=v4.7.2", \
			"/p:Configuration=Release", \
			"/p:OutDir=../publish"] \
			--results-directory ../publish/TestResults/Aspose.Storage.Cloud.Sdk.Tests.trx

FROM build AS publish
WORKDIR /app
RUN dotnet publish Aspose.Storage.Cloud.Sdk.sln /p:Configuration=Release /p:OutDir=../publish /p:TargetFrameworkVersion=v4.7.2