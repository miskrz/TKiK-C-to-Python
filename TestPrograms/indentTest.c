#include <stdio.h>
struct myStructure {
    int number1;
    int number2;
};
int dodawanie(int liczba1,int liczba2){
    return liczba1 + liczba2;
}

int main() {
    int input1;
    char input2;
    printf("Podaj cyfrę od 0 do 9 oraz literę:\n");
    scanf("%d %c", &input1,&input2);
    
    struct myStructure s1;
    printf("Podaj 2 liczby\n");
    scanf("%d%d", &s1.number1, &s1.number2);
    printf("Struktura: %d %d\n", s1.number1, s1.number2);

    if (input1 == 0) {
        printf("Zero\n");
    } else if(input1>0) {
        if (input1 == 1) {
            printf("Jeden\n");
        } else {
            if (input1 == 2) {
                printf("Dwa\n");
            } else {
                if (input1 == 3) {
                    printf("Trzy\n");
                } else {
                    if (input1 == 4) {
                        printf("Cztery\n");
                    } else {
                        if (input1 == 5) {
                            printf("Pięć\n");
                        } else {
                            if (input1 == 6) {
                                printf("Sześć\n");
                            } else {
                                if (input1 == 7) {
                                    printf("Siedem\n");
                                } else {
                                    if (input1 == 8) {
                                        printf("Osiem\n");
                                    } else {
                                        if (input1 == 9) {
                                            printf("Dziewięć\n");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    else{
        printf("Mniejszy od zero\n");
    }
    switch(input2) {
        case 'a':
            printf("Wybrano opcję a\n");
            break;
        case 'b':
            printf("Wybrano opcję b\n");
            break;
        case 'c':
            printf("Wybrano opcję c\n");
            break;
        case 'd':
            printf("Wybrano opcję d\n");
            break;
        case 'e':
            printf("Wybrano opcję e\n");
            break;
        case 'f':
            printf("Wybrano opcję f\n");
            break;
        default:
            printf("Wybrano inną literę niż a, b, c, d, e, f.\n");
            break;
    }
    if (s1.number1 > 0) {
        printf("Liczba %d jest dodatnia\n", s1.number1);
        if (s1.number2 > 0) {
            printf("Liczba %d jest dodatnia\n", s1.number2);
        }
        else if(s1.number2 < 0){
            printf("Liczba %d jest ujemna\n", s1.number2);
        }
        else {
            printf("Liczba %d jest rowna 0\n", s1.number2);
        }
    }
    else if(s1.number1 < 0){
        printf("Liczba %d jest ujemna\n", s1.number1);
        if (s1.number2 > 0) {
            printf("Liczba %d jest dodatnia\n", s1.number2);
        }
        else if(s1.number2 < 0){
            printf("Liczba %d jest ujemna\n", s1.number2);
        }
        else {
            printf("Liczba %d jest rowna 0\n", s1.number2);
        }
    }
    else {
        printf("Liczba %d jest rowna 0\n", s1.number1);
        if (s1.number2 > 0) {
            printf("Liczba %d jest dodatnia\n", s1.number2);
        }
        else if(s1.number2 < 0){
            printf("Liczba %d jest ujemna\n", s1.number2);
        }
        else {
            printf("Liczba %d jest rowna 0\n", s1.number2);
        }
    }
    int suma = dodawanie(s1.number1,s1.number2);
    printf("Suma liczb %d oraz %d to %d",s1.number1,s1.number2,suma );

    return 0;
}