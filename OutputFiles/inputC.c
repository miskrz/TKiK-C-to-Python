#include <stdio.h>
#include <string.h>

struct Book {
    char title[100];
    char author[100];
    int year;
};


int main() {
    struct Book library[100];

    int bookCount = 0, choice;   
    
    do {
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
                printf("\nDodawanie książki:\n");
                printf("Tytuł: ");
                scanf("%s", library[bookCount].title);
                printf("Autor: ");
                scanf("%s", library[bookCount].author);
                printf("Rok wydania: ");
                scanf("%d", &library[bookCount].year);

                bookCount++;
                break;
                
            case 2:
                printf("\nWszystkie książki w bibliotece:\n");
                for(int i = 0; i < bookCount; i++) {
                    printf("Książka %d:\n", i + 1);
                    printf("Tytuł: %s\n", library[i].title);
                    printf("Autor: %s\n", library[i].author);
                    printf("Rok wydania: %d\n", library[i].year);
                }
                break;
                
            case 3:
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
                printf("\nUsuwanie książki:\n");
                printf("Podaj tytuł książki do usunięcia: ");
                char deleteTitle[100];
                scanf("%s", deleteTitle);
                
                for(int i = 0; i < bookCount; i++) {
                    if(strcmp(library[i].title, deleteTitle) == 0) {
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
                printf("\nDo widzenia!\n");
                break;
                
            default:
                printf("\nNiepoprawny wybór. Spróbuj ponownie.\n");
                break;
        }
        
    } while(choice != 5);
    
    return 0;

}