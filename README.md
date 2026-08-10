# LocalDBCrudDemo

Dimostratore WinForms CRUD per prodotti e utenti, con autenticazione ed esportazione CSV,
Excel e PDF su SQL Server LocalDB.

## Stack

- C# e WinForms
- .NET Framework 4.8
- SQL Server LocalDB

## Apertura

Aprire `LocalDB_mdf.sln` con Visual Studio 2022 e ripristinare i pacchetti NuGet indicati in
`packages.config`.

Il database `DatabaseEsempio.mdf` rimane disponibile localmente ma è escluso da Git perché può
contenere dati e hash di utenti. Prima di rendere il repository riproducibile serviranno uno
schema SQL pulito e dati di esempio anonimi.
