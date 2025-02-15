FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EduRankCR.API/EduRankCR.API.csproj", "EduRankCR.API/"]
COPY ["EduRankCR.Application/EduRankCR.Application.csproj", "EduRankCR.Application/"]
COPY ["EduRankCR.Domain/EduRankCR.Domain.csproj", "EduRankCR.Domain/"]
COPY ["EduRankCR.Infrastructure/EduRankCR.Infrastructure.csproj", "EduRankCR.Infrastructure/"]
RUN dotnet restore "EduRankCR.API/EduRankCR.API.csproj"
COPY . .
WORKDIR "/src/EduRankCR.API"
RUN dotnet build "EduRankCR.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "EduRankCR.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EduRankCR.API.dll"]
