import sys
import random


class Book:
    def __init__(self, title = [None] * (100), author = [None] * (100), year = None):
        self.title = title
        self.author = author
        self.year = year



def main():
    library = [Book() for _ in range(100)]
    bookCount = 0
    choice = None
    while True:
        print("\nBiblioteka - wybierz opcję:\n", end = '')
        print("1. Dodaj książkę\n", end = '')
        print("2. Wyświetl wszystkie książki\n", end = '')
        print("3. Szukaj książki\n", end = '')
        print("4. Usuń książkę\n", end = '')
        print("5. Wyjdź\n", end = '')
        print("Wybór: ", end = '')
        choice = int(input(""))
        match choice:
            case 1: 
                print("\nDodawanie książki:\n", end = '')
                print("Tytuł: ", end = '')
                library[bookCount].title = str(input(""))
                print("Autor: ", end = '')
                library[bookCount].author = str(input(""))
                print("Rok wydania: ", end = '')
                library[bookCount].year = int(input(""))
                bookCount += 1
            case 2: 
                print("\nWszystkie książki w bibliotece:\n", end = '')
                i = 0
                for _ in range(0, bookCount):
                    if i < bookCount:
                        print("Książka {}:\n".format(i + 1), end = '')
                        print("Tytuł: {}\n".format(library[i].title), end = '')
                        print("Autor: {}\n".format(library[i].author), end = '')
                        print("Rok wydania: {}\n".format(library[i].year), end = '')
                        i += 1
            case 3: 
                print("\nSzukanie książki:\n", end = '')
                print("Podaj tytuł książki: ", end = '')
                searchTitle = [None] * (100)
                searchTitle = str(input(""))
                i = 0
                for _ in range(0, bookCount):
                    if i < bookCount:
                        if library[i].title == searchTitle:
                            print("Znaleziono książkę:\n", end = '')
                            print("Tytuł: {}\n".format(library[i].title), end = '')
                            print("Autor: {}\n".format(library[i].author), end = '')
                            print("Rok wydania: {}\n".format(library[i].year), end = '')
                            break
                        i += 1
            case 4: 
                print("\nUsuwanie książki:\n", end = '')
                print("Podaj tytuł książki do usunięcia: ", end = '')
                deleteTitle = [None] * (100)
                deleteTitle = str(input(""))
                i = 0
                for _ in range(0, bookCount):
                    if i < bookCount:
                        if library[i].title == deleteTitle:
                            j = i
                            for _ in range(i, bookCount - 1):
                                if j < bookCount - 1:
                                    library[j].title = library[j + 1].title
                                    library[j].author = library[j + 1].author
                                    library[j].year = library[j + 1].year
                                    j += 1
                            bookCount -= 1
                            print("Książka usunięta.\n", end = '')
                        j += 1
            case 5: 
                print("\nDo widzenia!\n", end = '')
            case _: 
                print("\nNiepoprawny wybór. Spróbuj ponownie.\n", end = '')
        if not (choice != 5):
            break
    return 0
    

if __name__ == "__main__":
    main()