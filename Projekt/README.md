# System Monitorowania Wydatków Domowych

## Spis treści

- Opis projektu
- Funkcjonalności
- Technologie
- Struktura projektu
- Instrukcja uruchomienia

---

## Opis projektu

System Monitorowania Wydatków Domowych to aplikacja internetowa stworzona w technologii ASP.NET Core MVC.

Aplikacja umożliwia zarządzanie wydatkami domowymi poprzez dodawanie, edytowanie, usuwanie oraz przeglądanie zapisanych danych. Dane przechowywane są w bazie danych SQL Server z wykorzystaniem Entity Framework Core.

Projekt został wykonany w celu nauki tworzenia aplikacji webowych opartych o architekturę MVC oraz pracy z bazami danych.

---

## Funkcjonalności

### Zarządzanie wydatkami

- Dodawanie wydatków
- Edycja wydatków
- Usuwanie wydatków
- Przeglądanie listy wydatków

### Kategorie i metody płatności

- Przypisywanie kategorii do wydatków
- Przypisywanie metod płatności do wydatków

### Filtrowanie i wyszukiwanie

- Filtrowanie po kategorii
- Filtrowanie po metodzie płatności
- Wyszukiwanie po opisie
- Sortowanie po kwocie

### Raportowanie

- Suma wszystkich wydatków
- Podsumowanie wydatków według kategorii
- Dashboard ze statystykami:
  - Liczba wydatków
  - Suma wydatków
  - Największy wydatek

---

## Technologie

Projekt został wykonany przy użyciu:

- ASP.NET Core MVC
- C#
- Entity Framework Core
- SQL Server LocalDB
- HTML
- CSS
- Bootstrap
- Git
- GitHub

---

## Struktura projektu

### Foldery

- Controllers
- Models
- Views
- Data
- Migrations
- wwwroot

### Główne pliki

- Program.cs
- appsettings.json

### Modele

- Wydatek
- Kategoria
- MetodaPlatnosci

### Relacje

- Wydatek → Kategoria
- Wydatek → MetodaPlatnosci

---

## Instrukcja uruchomienia

### Wymagania

- .NET SDK
- SQL Server LocalDB
- Visual Studio Code

### Uruchomienie projektu

1. Sklonuj repozytorium

2. Przejdź do katalogu projektu

3. Przywróć pakiety

4. Utwórz bazę danych

5. Uruchom aplikację

6. Otwórz adres wyświetlony w terminalu

---

## Autor

Michał Słomiński
