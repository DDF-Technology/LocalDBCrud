# LocalDBCrudDemo

Applicazione didattica Windows Forms che mostra un flusso CRUD completo su SQL Server Express
LocalDB: autenticazione locale, gestione di prodotti e utenti, ricerca, ordinamento ed esportazione
CSV/XLSX.

![Schermata CRUD con dati fittizi](docs/screenshots/crud-dashboard.png)

## Funzioni

- creazione automatica del database locale al primo avvio;
- dati iniziali esclusivamente fittizi;
- inserimento, lettura, modifica ed eliminazione dei prodotti;
- ricerca e ordinamento della griglia;
- gestione dimostrativa degli utenti;
- esportazione dei dati in CSV e XLSX;
- password derivate con PBKDF2-HMAC-SHA256, sale casuale e 100.000 iterazioni.

## Requisiti

- Windows 10/11;
- .NET Framework 4.8;
- SQL Server Express LocalDB (`MSSQLLocalDB`);
- Visual Studio 2022 per compilare i sorgenti.

## Primo avvio

Aprire `LocalDB_mdf.sln`, ripristinare i pacchetti NuGet e compilare. Al primo avvio l'applicazione
crea il database `LocalDBCrudDemo`, le tabelle e tre prodotti fittizi.

Credenziali iniziali esclusivamente dimostrative:

```text
Username: demo
Password: demo
```

Cambiare o eliminare l'utente demo se si usa il progetto per ulteriori esercizi.

## Compilazione

```powershell
nuget restore .\LocalDB_mdf.sln
msbuild .\LocalDB_mdf.sln /t:Rebuild /p:Configuration=Release
```

## Ambito e limiti

Questo è un esempio didattico, non un modello pronto per dati reali o ambienti di produzione.
Non implementa ruoli, audit log, recupero password, rate limiting, migrazioni versionate o una
strategia completa di backup. L'istanza LocalDB appartiene all'utente Windows corrente.

L'export PDF presente nell'archivio storico è stato rimosso prima della pubblicazione MIT perché
dipendeva da componenti con licenza AGPL/commerciale. Restano CSV e XLSX tramite dipendenze
compatibili, elencate in [THIRD_PARTY_NOTICES.md](THIRD_PARTY_NOTICES.md).

## Licenza

Codice e documentazione originali sono distribuiti con licenza [MIT](LICENSE).
Copyright © 2026 Fabio De Deo — [DDF.Technology](https://www.ddf.technology/).
