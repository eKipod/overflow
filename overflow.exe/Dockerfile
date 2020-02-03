#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["overflow.exe/overflow.exe.csproj", "overflow.exe/"]
COPY ["overflow/overflow.csproj", "overflow/"]
RUN dotnet restore "overflow.exe/overflow.exe.csproj"
COPY . .
WORKDIR "/src/overflow.exe"
RUN dotnet build "overflow.exe.csproj" -c Release -o /app/build

FROM build AS test
WORKDIR /src
COPY ["overflow.test/overflow.test.csproj", "overflow.test/"]
RUN dotnet restore "overflow.test/overflow.test.csproj"
COPY . .
WORKDIR "/src/overflow.test"
RUN dotnet test "overflow.test.csproj" -c Release --logger "trx;LogFileName=testresults.trx" --results-directory /var/temp

FROM build AS publish
RUN dotnet publish "overflow.exe.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "overflow.exe.dll"]