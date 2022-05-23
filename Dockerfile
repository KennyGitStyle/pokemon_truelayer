# Build Process

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /source

COPY . .

RUN dotnet restore "./Pokemon.API/Pokemon.API.csproj" --disable-parallel
RUN dotnet publish "./Pokemon.API/Pokemon.API.csproj" -c release -o /pokemon-app --no-restore

# Serve Process

FROM mcr.microsoft.com/dotnet/sdk:6.0

WORKDIR /pokemon
COPY --from=build /pokemon-app ./

EXPOSE 5000

ENTRYPOINT [ "dotnet", "Pokemon.API.dll" ]