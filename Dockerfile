FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["ClassStatusUploader/ClassStatusUploader.csproj", "ClassStatusUploader/"]
RUN dotnet restore "ClassStatusUploader/ClassStatusUploader.csproj"
COPY . .
WORKDIR "/src/ClassStatusUploader"
RUN dotnet build "ClassStatusUploader.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ClassStatusUploader.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ClassStatusUploader.dll"]