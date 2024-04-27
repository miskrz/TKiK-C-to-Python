#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <stdbool.h> // Dodatkowa biblioteka dla typu danych bool

// Struktura reprezentująca książkę
struct Book {
    char title[100];
    char author[100];
    int year;
};
int test_funkcja(void);
unsigned long long int silnia(int n);
bool isValidYear(int year);

int test_funkcja(void) {
    printf("test");
    int x = 10 / 2;
    float y = 5 * 10.3;
    double z = 10 * 5.3;
    int a = 0;
    a += 2;
    a -= 3;
    a *= 10;
    a /= 2989;
    a++;
    a--;
}
unsigned long long int silnia(int n) {
    // Warunek kończący rekurencję
    if (n == 0 || n == 1) {
        return 1;
    } else {
        // Wywołanie rekurencyjne
        return n * silnia(n - 1);
    }
}
bool isValidYear(int year) {
    return (year >= 0 && year <= 2024); // Załóżmy, że 2024 to maksymalny rok wydania
}

int main() {
    // Tablica książek
    struct Book library[100];

    // Licznik książek w bibliotece
    int bookCount = 0;
    
    // Zmienna do przechowywania wyboru użytkownika
    int choice;

    char test = 'x';
    
    do {
        // Wyświetlanie menu
        printf("\nBiblioteka - wybierz opcję:\n");
        printf("1. Dodaj książkę\n");
        printf("2. Wyświetl wszystkie książki\n");
        printf("3. Szukaj książki\n");
        printf("4. Usuń książkę\n");
        printf("5. Wyjdź\n");
        printf("Wybór: ");
        
        scanf("%d", &choice);
        
        switch(choice) {
            case 1:
                // Dodawanie książki
                printf("\nDodawanie książki:\n");
                printf("Tytuł: ");
                scanf("%s", library[bookCount].title);
                printf("Autor: ");
                scanf("%s", library[bookCount].author);

                int year;
                do {
                    printf("Rok wydania: ");
                    scanf("%d", &year);
                    if (!isValidYear(year)) {
                        printf("Nieprawidłowy rok wydania. Podaj rok od 0 do 2024.\n");
                    }
                } while (!isValidYear(year)); // Kontynuuj pytanie o rok, dopóki nie będzie poprawny

                library[bookCount].year = year;

                bookCount++;
                break;
                
            case 2:
                // Wyświetlanie wszystkich książek
                printf("\nWszystkie książki w bibliotece:\n");
                for(int i = 0; i < bookCount; i++) {
                    printf("Książka %d:\n", i + 1);
                    printf("Tytuł: %s\n", library[i].title);
                    printf("Autor: %s\n", library[i].author);
                    printf("Rok wydania: %d\n", library[i].year);
                }
                break;
                
            case 3:
                // Szukanie książki
                printf("\nSzukanie książki:\n");
                printf("Podaj tytuł książki: ");
                char searchTitle[100];
                scanf("%s", searchTitle);
                
                for(int i = 0; i < bookCount; i++) {
                    if(strcmp(library[i].title, searchTitle) == 0) {
                        printf("Znaleziono książkę:\n");
                        printf("Tytuł: %s\n", library[i].title);
                        printf("Autor: %s\n", library[i].author);
                        printf("Rok wydania: %d\n", library[i].year);
                        break;
                    }
                }
                break;
                
            case 4:
                // Usuwanie książki
                printf("\nUsuwanie książki:\n");
                printf("Podaj tytuł książki do usunięcia: ");
                char deleteTitle[100];
                scanf("%s", deleteTitle);
                
                for(int i = 0; i < bookCount; i++) {
                    if(strcmp(library[i].title, deleteTitle) == 0) {
                        // Przesunięcie pozostałych książek
                        for(int j = i; j < bookCount - 1; j++) {
                            strcpy(library[j].title, library[j + 1].title);
                            strcpy(library[j].author, library[j + 1].author);
                            library[j].year = library[j + 1].year;
                        }
                        bookCount--;
                        printf("Książka usunięta.\n");
                        break;
                    }
                }
                break;
                
            case 5:
                // Wyjście z programu
                printf("\nDo widzenia!\n");
                break;
                
            default:
                printf("\nNiepoprawny wybór. Spróbuj ponownie.\n");
                break;
        }

    } while(choice != 5);
    char *tekst;

    // Alokacja pamięci dla tekstu
    tekst = (char *)malloc(100 * sizeof(char)); // Przykładowy rozmiar 100 bajtów

    // Sprawdzenie, czy alokacja pamięci się powiodła
    if (tekst == NULL) {
        printf("Nie udalo sie zalokowac pamieci!");
    } else {
        printf("Pamiec zalokowana pomyslnie.");
        /*
         * Tutaj można wykonywać operacje na zaalokowanej pamięci
         * Na przykład: strcpy(tekst, "Przykladowy tekst")
         */
        free(tekst); // Zwolnienie zaalokowanej pamięci
    }
    int liczba;

    printf("Podaj liczbe calkowita: ");
    scanf("%d", &liczba);

    // Wywołanie funkcji rekurencyjnej
    unsigned long long int wynik = silnia(liczba);

    printf("Silnia z %d wynosi %llu.\n", liczba, wynik);

    return 0;
}
