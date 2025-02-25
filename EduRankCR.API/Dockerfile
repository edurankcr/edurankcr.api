FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EduRankCR.Api/EduRankCR.Api.csproj", "EduRankCR.Api/"]
COPY ["EduRankCR.Contracts/EduRankCR.Contracts.csproj", "EduRankCR.Contracts/"]
COPY ["EduRankCR.Domain/EduRankCR.Domain.csproj", "EduRankCR.Domain/"]
COPY ["EduRankCR.Application/EduRankCR.Application.csproj", "EduRankCR.Application/"]
COPY ["EduRankCR.Infrastructure/EduRankCR.Infrastructure.csproj", "EduRankCR.Infrastructure/"]
RUN dotnet restore "EduRankCR.Api/EduRankCR.Api.csproj"
COPY . .
WORKDIR "/src/EduRankCR.Api"
RUN dotnet build "EduRankCR.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "EduRankCR.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EduRankCR.Api.dll"]
