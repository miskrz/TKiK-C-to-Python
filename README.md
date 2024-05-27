# Konwerter - C/Python

## Dane studenta(-ów)
- Michał Krzempek
- Kacper Machnik
- Tomasz Madeja

## Dane kontaktowe
- krzempekm@student.agh.edu.pl
- kmachnik@student.agh.edu.pl
- tomaszmadeja@student.agh.edu.pl

## Założenia programu
1. Napisanie programu, który przekształci plik z języka C na język Python.
2. Rodzaj translatora: kompilator
3. Wynik działania programu: Kompilator języka C do Python
4. Język implementacji: C#
5. Sposób realizacji skanera/parsera: [Antlrv4](https://www.antlr.org/)

## Spis tokenów
[C_Tokens](https://github.com/miskrz/TKiK-C-to-Python/blob/main/Grammars/C_Tokens.g4)

## Gramatyka przetwarzanego formatu
[C_Grammar](https://github.com/miskrz/TKiK-C-to-Python/blob/main/Grammars/C_Grammar.g4)

## Informacja o stosowanych generatorach skanerów/parserów, pakietach zewnętrznych
- [Antlrv4](https://www.antlr.org/download.html)
- [Visual Studio Code](https://code.visualstudio.com/)
- [Dodatek (extension) #C For Visual Studio Code - OmniSharp](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
- [Platforma .Net 7.0](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
- GUI w postaci strony internetowej opartej na ASP.NET Core.
## Krótka instrukcja obsługi:
### Uruchamianie
1. Do samego uruchomienia wymagany są powyższe pakiety.
2. Aby uruchomić aplikację należy, po pobraniu repozytorium, komendą zmienić aktualny folder na Website (`cd Website`), następnie uruchomić aplikację po wpisaniu `dotnet run`.
3. Program powinien się uruchomić i wyświetlić link do strony.
4. Przyciski i opisy na stronie są czytelne i nie wymagają instrukcji obsługi.

### Ewentualne modyfikacje
1. Aby modyfikować gramatykę należy pobrać [antlr4](https://github.com/antlr/antlr4/blob/master/doc/getting-started.md#installation) oraz przy pomocy np. NuGet'a zainstalować pakiet `Antlr4.Runtime.Standard`
2. Generowanie potrzebnych plików (Parser, Listener, Visitor, itp.) do działania następuje po użyciu skrótu klawiszowego `ctrl + shift + G`.
## Przykład użycia:
```c
#include <stdio.h>

int main(void) {
    int i = 0;
    
    return 0;
}
```
### Gramatyka
Przykład generowanego drzewa:

![Parse Tree Example](/Resources/parseTreeDarkBackground.png)
### Przykładowe możliwości programu
Powyższy program:

![simpletest](/Resources/simpletest.png)

Przykładowy program z strukturą, scanf i printf:

![advancedtest](/Resources/advancedtest.png)


### GUI 
1. Ręczne wpisywanie bądź wczytywanie danych z pliku (format `.c` lub `.txt`)
2. Zapis do schowka lub zapis do pliku (pobiera plik `output.py`)
3. Przycisk "Konwertuj", który wywołuje funkcję konwertującą
4. Przycisk "Github" - link do repozytorium
5. Obsługa błędów - w razie błędu w gramatyce, zmienia kolor linii, w której znaleziono błąd na czerwony, a dokładniejsze informacje umieszcza w okienku "Błędy" 
![error](/Resources/error.png)
## Link do repozytorium z kodem GitHub:
- [Repozytorium z kodem](https://github.com/miskrz/TKiK-C-to-Python/)
## Dodatkowe informacje o projekcie
- Kompilator obsługuje wszystkie podstawowe funkcjonalności języka C jak np.: funkcje, deklaracja, inicjalizacja, tablice, struktury, funkcje (`if`, `else`, `for`, `while`, `do while`, `switch`) i wiele więcej
- Kompilator obsługuje również wybrane dodatkowe funkcje biblioteczne: `scanf`, `printf`, `srand`, `rand`, `strcmp`, `strcpy`

---

[**Link do strony na wiki**](https://home.agh.edu.pl/~jpi/dokuwiki/doku.php?id=dydaktyka:kompilatory:2024:projekty:temat6)
