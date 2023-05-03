FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY DistributedLockExample.csproj ./
RUN dotnet restore ./DistributedLockExample.csproj
COPY ./ ./
RUN dotnet publish ./DistributedLockExample.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
EXPOSE 443
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "DistributedLockExample.dll"]