#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443



FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY ["gl-api.csproj", "."]
RUN dotnet restore "./gl-api.csproj"
COPY . .
WORKDIR "/src/."
RUN echo "build_number is $build_number"
RUN dotnet build "gl-api.csproj" --no-restore -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "gl-api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
ARG build_number=1.0.42
WORKDIR /app
COPY --from=publish /app/publish .
ENV APP_VERSION $build_number
ENTRYPOINT ["dotnet", "gl-api.dll"]