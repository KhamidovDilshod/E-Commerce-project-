FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["E_Commerce.Api/E_Commerce.Api.csproj", "E_Commerce.Api/"]
RUN dotnet restore "E_Commerce.Api/E_Commerce.Api.csproj"
COPY . .
WORKDIR "/src/E_Commerce.Api"
RUN dotnet build "E_Commerce.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "E_Commerce.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "E_Commerce.Api.dll"]
