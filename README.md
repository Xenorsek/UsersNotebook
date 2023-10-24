# appName

Aplikacja zbudowana w technologii ASP.NET Core 7.0 MVC, która pozwala na dodawanie, usuwanie, modyfikowanie oraz generowanie raportu użytkowników.

## Wymagania

- [.NET SDK 7.0](https://dotnet.microsoft.com/download/dotnet/7.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio 2022](https://visualstudio.microsoft.com/visual-studio-preview/) lub nowszy (opcjonalnie)

## Instalacja

1. **Pobieranie Repozytorium**
   
   ```bash
   git clone https://github.com/your-username/appName.git
   cd appName
   ```
2. **Konfiguracja Bazy Danych**

Upewnij się, że masz działający serwer SQL Server.
Stwórz bazę danych o nazwie, której chcesz użyć dla aplikacji.
Aktualizacja Connection String

Otwórz plik appsettings.json w głównym katalogu projektu. Znajdź sekcję ConnectionStrings i zaktualizuj wartość DefaultConnection zgodnie z konfiguracją Twojego serwera SQL i nazwą bazy danych.

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=your_server_name;Database=your_database_name;Trusted_Connection=true;MultipleActiveResultSets=true;"
}
```
3. **Migracje Bazy Danych**
   ```bash
   cd appName.Data
   dotnet ef database update
   ```
4. **Uruchomienie Aplikacji**
```bash
cd ..
dotnet run
```
5. **Korzystanie z Aplikacji**
Po uruchomieniu, otwórz przeglądarkę internetową i przejdź do https://localhost:5001.
Możesz również uruchomić aplikację w IIS Express co powinno uruchomić od razu aplikację.

Aplikacja pozwala na:

Dodawanie nowych użytkowników
Usuwanie istniejących użytkowników
Modyfikowanie danych użytkowników
Generowanie raportu użytkowników
      
