#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int partition(int arr[], int low, int high) {
    int pivot = arr[high];
    int i = (low - 1);

    for (int j = low; j <= high - 1; j++) {
        if (arr[j] <= pivot) {
            i++;

            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }

    int temp = arr[i + 1];
    arr[i + 1] = arr[high];
    arr[high] = temp;

    return i + 1;
}

void quickSort(int arr[], int low, int high) {
    if (low < high) {
        int pi = partition(arr, low, high);

        quickSort(arr, low, pi - 1);
        quickSort(arr, pi + 1, high);
    }
}

int main() {
    int seed;
    printf("Podaj ziarno: ");
    scanf("%d", &seed);
    srand(seed);

    int n = 20;
    printf("Podaj ilosc liczb do posortowania: ");
    scanf("%d", &n);

    int arr[n];
    /*printf("Podaj %d liczb:\n", n);
    for (int i = 0; i < n; i++) {
        scanf("%d", &arr[i]);
    }*/
    //int arr[20] = {8, 12, 45, 67, 23, 11, 5, 89, 34, 16, 72, 9, 3, 56, 20, 44, 15, 78, 30, 62};
    
    for (int i = 0; i < n; i++) {
        arr[i] = rand() % 200 - 100;
    } 

    printf("Wylosowane liczby:\n");
    for (int i = 0; i < n; i++) {
        printf("%d ", arr[i]);
    }    
    
    quickSort(arr, 0, n - 1);

    printf("\nPosortowane liczby:\n");
    for (int i = 0; i < n; i++) {
        printf("%d ", arr[i]);
    }
    printf("\n");

    return 0;
}