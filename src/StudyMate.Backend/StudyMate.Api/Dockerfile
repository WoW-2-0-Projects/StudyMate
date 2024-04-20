FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["StudyMate.Api/StudyMate.Api.csproj", "StudyMate.Api/"]
COPY ["StudyMate.Infrastructure/StudyMate.Infrastructure.csproj", "StudyMate.Infrastructure/"]
COPY ["StudyMate.Application/StudyMate.Application.csproj", "StudyMate.Application/"]
COPY ["StudyMate.Domain/StudyMate.Domain.csproj", "StudyMate.Domain/"]
COPY ["StudyMate.Persistence/StudyMate.Persistence.csproj", "StudyMate.Persistence/"]
RUN dotnet restore "StudyMate.Api/StudyMate.Api.csproj"
COPY . .
WORKDIR "/src/StudyMate.Api"
RUN dotnet build "StudyMate.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "StudyMate.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudyMate.Api.dll"]
