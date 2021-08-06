FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://*:5000
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY src/ ./
RUN dotnet restore "Otus.PublicSale.sln"
RUN dotnet build "Otus.PublicSale.sln" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Otus.PublicSale.WebApi/Otus.PublicSale.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/build ./
COPY --from=publish /app/publish ./
CMD dotnet Otus.PublicSale.WebApi.dll
