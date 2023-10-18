FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WoverineMiddlewareProblems/WoverineMiddlewareProblems.csproj", "WoverineMiddlewareProblems/"]
RUN dotnet restore "WoverineMiddlewareProblems/WoverineMiddlewareProblems.csproj"
COPY . .
WORKDIR "/src/WoverineMiddlewareProblems"
RUN dotnet build "WoverineMiddlewareProblems.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WoverineMiddlewareProblems.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WoverineMiddlewareProblems.dll"]
