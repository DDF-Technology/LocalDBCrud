# LocalDBCrudDemo

Dimostratore desktop CRUD per la gestione di prodotti e utenti. L'applicazione WinForms usa SQL
Server LocalDB, include un flusso di autenticazione ed esporta dati in CSV, Excel e PDF.

## Funzioni

- accesso utente e gestione delle anagrafiche;
- creazione, lettura, modifica ed eliminazione dei prodotti;
- ricerca e visualizzazione tabellare;
- esportazione dei dati nei formati CSV, XLSX e PDF.

## Stack e requisiti

- C# e Windows Forms;
- .NET Framework 4.8;
- SQL Server Express LocalDB;
- Visual Studio 2022 e pacchetti NuGet elencati in `packages.config`.

Aprire `LocalDB_mdf.sln`, ripristinare i pacchetti e compilare il progetto `LocalDB_mdf`.

## Struttura e dati locali

- `LocalDB_mdf/`: sorgenti, form, modelli e configurazione del progetto;
- `LocalDB_mdf.sln`: soluzione Visual Studio;
- `packages/`: cache locale storica dei pacchetti.

Il database `DatabaseEsempio.mdf` è escluso da Git perché può contenere dati e hash di utenti. Un
clone non è quindi ancora autosufficiente: servono uno script SQL pulito, dati anonimi di esempio e
istruzioni per impostare la stringa di connessione.

## Stato e sicurezza

Progetto didattico, non progettato per dati reali. Autenticazione, gestione delle password, query e
validazione degli input devono essere riesaminate prima di qualunque uso diverso dalla demo locale.

## Proprietà e licenza

Copyright © 2026 Fabio De Deo — [www.ddf.technology](https://www.ddf.technology/). Tutti i
diritti riservati. Consultare [LICENSE](LICENSE).
