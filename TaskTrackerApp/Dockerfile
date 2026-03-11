# Этап 1: Сборка
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# Копируем файлы проекта и восстанавливаем зависимости
COPY *.csproj .
RUN dotnet restore

# Копируем всё остальное и собираем проект
COPY . .
RUN dotnet publish -c Release -o /app

# Этап 2: Запуск (легковесный образ)
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "TaskTrackerApp.dll"]