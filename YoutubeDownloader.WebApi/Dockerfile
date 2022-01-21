FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["YoutubeDownloader.WebApi/YoutubeDownloader.WebApi.csproj", "YoutubeDownloader.WebApi/"]
COPY ["YoutubeDownloader.Common/YoutubeDownloader.Common.csproj", "YoutubeDownloader.Common/"]
COPY ["YoutubeDownloader.Persistence/YoutubeDownloader.Persistence.csproj", "YoutubeDownloader.Persistence/"]
RUN dotnet restore "YoutubeDownloader.WebApi/YoutubeDownloader.WebApi.csproj"
COPY . .
WORKDIR "/src/YoutubeDownloader.WebApi"
RUN dotnet build "YoutubeDownloader.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YoutubeDownloader.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YoutubeDownloader.WebApi.dll"]
