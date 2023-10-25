# UsersNotebook
( na samym dole znajduje się instrukcja jak zainstalować aplikację jako kontener w docker )

Aplikacja zbudowana w technologii ASP.NET Core 7.0 MVC, która pozwala na dodawanie, usuwanie, modyfikowanie oraz generowanie raportu użytkowników.

## Wymagania

- [.NET SDK 7.0](https://dotnet.microsoft.com/download/dotnet/7.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio 2022](https://visualstudio.microsoft.com/visual-studio-preview/) lub nowszy (opcjonalnie)

## Instalacja

1. **Pobieranie Repozytorium**
   
   ```bash
   git clone https://github.com/Xenorsek/UsersNotebook.git
   cd appName
   ```
2. **Konfiguracja Bazy Danych**

Upewnij się, że masz działający serwer SQL Server.
Stwórz bazę danych o nazwie, której chcesz użyć dla aplikacji. ( Polecana UsersNotebook )
Aktualizacja Connection String

Otwórz plik appsettings.json w głównym katalogu projektu. Znajdź sekcję ConnectionStrings i zaktualizuj wartość DefaultConnection zgodnie z konfiguracją Twojego serwera SQL i nazwą bazy danych.

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=your_server_name;Database=your_database_name;Trusted_Connection=true;MultipleActiveResultSets=true;"
}
```
3. **Migracje Bazy Danych**
   
Aplikacja przy pierwszym uruchomieniu powinna utworzyć migrację. Jednak jeżeli będzie taka konieczność należy przeprowadzić ją ręcznie.
  ```bash
   cd UsersNotebook.Data
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
- Dodawanie nowych użytkowników
- Usuwanie istniejących użytkowników
- Modyfikowanie danych użytkowników
- Generowanie raportu użytkowników
## Instalacja przez Docker
### Wymagania

- Docker
- Docker Compose

### Instalacja

1. **Pobieranie Docker i Docker Compose**:
   - Docker: Przejdź na stronę [Docker](https://docs.docker.com/get-docker/) i pobierz oraz zainstaluj Docker dla swojego systemu operacyjnego.
   - Docker Compose: Jeśli korzystasz z systemu inny niż Windows lub Mac, możesz potrzebować zainstalować Docker Compose oddzielnie. Przejdź na stronę [Docker Compose](https://docs.docker.com/compose/install/) i postępuj zgodnie z instrukcjami.

2. **Pobranie projektu**:
   - Sklonuj to repozytorium lub pobierz je jako archiwum ZIP i rozpakuj w wybranym przez siebie miejscu.

3. **Uruchomienie aplikacji**:
   - Przejdź do katalogu z plikiem `docker-compose.yml` w terminalu ( plik znajduje się na poziomie pliku .sln ):
     ```bash
     cd UsersNotebook
     ```
   - Uruchom aplikację za pomocą Docker Compose:
     ```bash
     docker-compose up -d
     ```

## Użycie

Po uruchomieniu aplikacji, otwórz przeglądarkę internetową i wprowadź adres URL hosta Docker (np. `http://localhost:8080`), aby uzyskać dostęp do aplikacji UsersNotebook. Możesz teraz dodawać, edytować, usuwać użytkowników oraz generować raporty.

## Rozwiązywanie problemów

W przypadku problemów z uruchomieniem aplikacji lub błędów podczas jej działania, upewnij się, że wszystkie zależności są poprawnie zainstalowane i skonfigurowane.
