import sys
import random


LOSUJ = 0
if LOSUJ == 1: 
    losuj = 1
else: 
    losuj = 0

def partition(arr, low, high):
    pivot = arr[high]
    i = (low - 1)
    j = low
    for _ in range(low, 1 + high - 1):
        if j <= high - 1:
            if arr[j] <= pivot:
                i += 1
                temp = arr[i]
                arr[i] = arr[j]
                arr[j] = temp
            j += 1
    temp = arr[i + 1]
    arr[i + 1] = arr[high]
    arr[high] = temp
    return i + 1
    

def quickSort(arr, low, high):
    if low < high:
        pi = partition(arr, low, high)
        quickSort(arr, low, pi - 1)
        quickSort(arr, pi + 1, high)
    

def main():
    seed = None
    print("Podaj ziarno: ", end = '')
    seed = int(input(""))
    random.seed(seed)
    n = 20
    print("Podaj ilosc liczb do posortowania: ", end = '')
    n = int(input(""))
    arr = [None] * (n)
    if losuj:
        i = 0
        for _ in range(0, n):
            if i < n:
                arr[i] = random.randint(0, sys.maxsize) % 200 - 100
                i += 1
        print("Wylosowane liczby:\n", end = '')
    else: 
        print("Podaj {} liczb:\n".format(n), end = '')
        i = 0
        for _ in range(0, n):
            if i < n:
                arr[i] = int(input(""))
                i += 1
    i = 0
    for _ in range(0, n):
        if i < n:
            print("{} ".format(arr[i]), end = '')
            i += 1
    quickSort(arr, 0, n - 1)
    print("\nPosortowane liczby:\n", end = '')
    i = 0
    for _ in range(0, n):
        if i < n:
            print("{} ".format(arr[i]), end = '')
            i += 1
    print("\n", end = '')
    return 0
    

if __name__ == "__main__":
    main()