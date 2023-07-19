FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["APCExam/APCExam.csproj", "APCExam/"]
RUN dotnet restore "APCExam/APCExam.csproj"
COPY . .
WORKDIR "/src/APCExam"
RUN dotnet build "APCExam.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "APCExam.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "APCExam.dll"]
