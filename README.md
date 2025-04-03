# StruttureMarcheProject

“Strutture Marche Project” è un progetto MVC sviluppato in .NET 6 con Visual Studio, che permette di recuperare i dati da un file JSON contenente una lista di strutture ricettive nelle Marche. I dati vengono visualizzati in un'interfaccia web che offre funzionalità di ricerca e filtro per facilitare la consultazione. Inoltre, è stato implementato un servizio SOAP che consente di visualizzare la lista delle strutture in formato XML. Per garantire una distribuzione e un'esecuzione consistenti su qualsiasi ambiente, il progetto è stato successivamente containerizzato utilizzando Docker.

## 🚀 Funzionalità

1. 🔎 **Visualizzazione delle Strutture nelle Marche**: Mostra una lista di tutti le strutture ricettive nelle Marche, nella pagina di ricerca.
2. 📑 **Filtraggio e Ricerca**: Permette di filtrare le strutture in base alla denominazione, al comune o alla provincia.
3. 📡 **Servizio SOAP**: Fornisce un endpoint SOAP (**/FunctionMarche.wsdl**) per ottenere la lista delle strutture nelle Marche in formato XML.

## 📦 Come installare il progetto?

1. **Clona la repository**:
   ```bash
   git clone https://github.com/D4mi4n0/StruttureMarcheProject.git

2. **Apri il progetto in Visual Studio 2022**:
   - Apri Visual Studio;
   - Seleziona "Apri un progetto o una soluzione";
   - Naviga fino alla cartella del progetto e seleziona il file .sln.

3. **Esegui l'Applicazione**: Premi F5 o clicca su "Esegui" per avviare l'applicazione in modalità debug.

4. **Accesso al servizio SOAP**: per accedere al servizio SOAP, vai a http://localhost:5100/FunctionMarche.wsdl.

## 🐳 Docker

1. **Crea l'immagine docker**:
   ```bash
   docker build -t strutture-marche -f StruttureMarche/Dockerfile .

2. **Esegui il container docker**:
   ```bash
   docker run -d -p 8080:80 --name strutture-marche-container strutture-marche

3. **Collegati al servizio localhost del docker**:
   ```bash
   Start-Process "http://localhost:8080"

4. **Per fermare il docker**:
   ```bash
   docker stop strutture-marche-container

5. **Per rimuovere il docker**:
   ```bash
   docker rm strutture-marche-container

Per riusare il docker (se rimosso), ripartire dal punto 1. Se non è rimosso, ripartire dal punto 3.

## 🤝 Contributori

- Damiano Montanaro
- Riccardo Imani Noobar

## Un'ultima cosa...

Abbiate pietà di noi, abbiamo sofferto come dei dromedari nel fare questo progetto.
