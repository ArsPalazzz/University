#include <iostream>
#define SIZE 6

//Ввести массивы А и В. В массив С перенести те элементы массива А, которые больше максимального элемента массива В. 
//Массив С отсортировать по убыванию, используя алгоритмы сортировок: «пузырек», в сортировка простой вставкой.

int findMax(int* arr);
void bubbleSort(int* arr);

int main()
{
    setlocale(LC_ALL, "ru");
    int* A = new int[SIZE];
    int* B = new int[SIZE];
    int* C = new int[SIZE];

    for (int i = 0; i < SIZE; i++) {
        A[i] = rand() % 20;
        B[i] = rand() % 10;
    }

    printf("Массив A: ");
    for (int i = 0; i < SIZE; i++) {
        printf("%d\t", *(A + i));
    }

    printf("\nМассив B: ");
    for (int i = 0; i < SIZE; i++) {
        printf("%d\t", *(B + i));
    }

    int maxB = findMax(B);
    printf("\nМаксимальный элемент: %d", maxB);
    int j = 0;

    for (int i = 0; i < SIZE; i++) {
        if (A[i] > maxB) {
            *(C + j) = *(A + i);
            ++j;
        }
    }

    printf("\nМассив C: ");

    for (int i = 0; i <= sizeof(C) / sizeof(C[0]); i++) {
        printf("%d\t", *(C + i));
    }
  
    printf("\nМассив C после сортировки: ");
    bubbleSort(C);

    for (int i = 0; i <= sizeof(C) / sizeof(C[0]); i++) {
        printf("%d\t", *(C + i));
    }

}

int findMax(int* arr) {
    int max = 0;
    for (int i = 0; i < SIZE; i++) {
        if (arr[i] > max)
            max = arr[i];
    }

    return max;
}

void bubbleSort(int* arr) {
    int i, j, t;
    int n = sizeof(arr) / sizeof(arr[0]);
    for (i = 0; i < n; i++)
        for (j = n; j > i; j--)
            if (arr[j - 1] < arr[j])
            {
                t = arr[j];
                arr[j] = arr[j - 1];
                arr[j - 1] = t;
            }
}
