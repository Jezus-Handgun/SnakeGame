# 🐍 Snake Game - Console Edition

Prosta gra Snake zaimplementowana w języku C# działająca w konsoli. Projekt powstał w celu nauki pracy z systemem kontroli wersji Git oraz współpracy zespołowej na platformie GitHub.

## 🚀 Funkcje
- **Klasyczna rozgrywka:** Zbieranie punktów i rośnięcie węża.
- **Tryb Multiplayer (PvP):** Możliwość gry dla dwóch osób na jednej klawiaturze!
- **System kolizji:** Wykrywanie zderzeń ze ścianami, własnym ogonem oraz przeciwnikiem.
- **Dynamiczny wynik:** Wyświetlanie punktacji w czasie rzeczywistym.

## 🎮 Sterowanie

Gra obsługuje dwóch graczy jednocześnie:

| Gracz | Ruch w górę | Ruch w dół | Ruch w lewo | Ruch w prawo | Kolor Węża |
| :---: | :---: | :---: | :---: | :---: | :---: |
| **Gracz 1** | Strzałka ↑ | Strzałka ↓ | Strzałka ← | Strzałka → | 🔴 Czerwony |
| **Gracz 2** | W | S | A | D | 🟡 Żółty |

## 🕹️ Zasady Gry
1. Celem gry jest zebranie jak największej liczby punktów poprzez zjadanie symbolu `*`.
2. Każde zjedzenie punktu wydłuża węża.
3. Gra kończy się, gdy:
    - Wąż uderzy w ścianę.
    - Wąż uderzy w swój własny ogon.
    - Wąż uderzy w przeciwnika (w trybie multiplayer).
4. W trybie dla dwóch graczy wygrywa ten, kto przetrwa dłużej!

## 🛠️ Wymagania i Uruchomienie
- **Środowisko:** .NET Framework / .NET Core
- **IDE:** Visual Studio 2019/2022
- **System:** Windows

### Jak uruchomić projekt?
1. Sklonuj repozytorium:
   ```bash
   git clone https://github.com/Jezus-Handgun/SnakeGame.git

Informatyka niestacjonarna  
Semestr 5  
Sebastian Goździński, numer albumu: 147590  
Jakub Bunar, numer albumu: 147554  
