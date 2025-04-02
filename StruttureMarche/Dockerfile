# Fase 1: Runtime di base
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Fase 2: Costruzione del progetto
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copia entrambi i progetti
COPY ["StruttureMarche/StruttureMarche.csproj", "StruttureMarche/"]

# Esegui il restore per tutti i progetti
RUN dotnet restore "StruttureMarche/StruttureMarche.csproj"

# Copia tutti i file sorgente
COPY . .

# Compila il progetto
WORKDIR "/src/StruttureMarche"
RUN dotnet build -c Release -o /app/build

# Fase 3: Pubblicazione
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Fase 4: Immagine finale per l'esecuzione
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "StruttureMarche.dll"]
