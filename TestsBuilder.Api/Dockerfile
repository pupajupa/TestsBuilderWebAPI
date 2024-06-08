#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
ENV DATABASE_URL=192.168.0.101
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TestsBuilder.Api/TestsBuilder.Api.csproj", "TestsBuilder.Api/"]
COPY ["TestsBuilder.Application/TestsBuilder.Application.csproj", "TestsBuilder.Application/"]
COPY ["TestsBuilder.Domain/TestsBuilder.Domain.csproj", "TestsBuilder.Domain/"]
COPY ["TestsBuilder.Contracts/TestsBuilder.Contracts.csproj", "TestsBuilder.Contracts/"]
COPY ["TestsBuilder.Infastructure/TestsBuilder.Infastructure.csproj", "TestsBuilder.Infastructure/"]
RUN dotnet restore "./TestsBuilder.Api/TestsBuilder.Api.csproj"
COPY . .
WORKDIR "/src/TestsBuilder.Api"
RUN dotnet build "./TestsBuilder.Api.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TestsBuilder.Api.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestsBuilder.Api.dll"]