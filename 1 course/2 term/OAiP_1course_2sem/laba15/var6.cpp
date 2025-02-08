//#include <iostream>
//#define SIZE 8
//
////Ввести массив А, в массив В скопировать все элементы массива А, имеющие четное значение. 
////Массив В отсортировать по возрастанию, используя алгоритмы сортировок: сортировка Шелла, сортировка выбором
//
//void selectSort(int* arr, int size);
//
//void main() {
//	setlocale(LC_ALL, "ru");
//	int A[SIZE];
//	int B[SIZE];
//
//	for (int i = 0; i < SIZE; i++) {
//		*(A + i) = rand() % 14;
//	}
//
//	printf("Массив A: ");
//
//   for (int i = 0; i < SIZE; i++) {
//        printf("%d\t", *(A + i));
//   }
//
//   int j = 0;
//   for (int i = 0; i < SIZE; i++) {
//	   if (*(A + i) % 2 == 0) {
//		   *(B + j) = *(A + i);
//		   ++j;
//	   }
//   }
//
//   printf("\nМассив B: ");
//
//   for (int i = 0; i < j; i++) {
//	   printf("%d\t", *(B + i));
//   }
//
//   selectSort(B, j);
//
//   printf("\nМассив B после сортировки: ");
//
//   for (int i = 0; i < j; i++) {
//	   printf("%d\t", *(B + i));
//   }
//}
//
//void selectSort(int *arr, int size)
//{
//	int k, i, j;
//	for (i = 0; i < 5 - 1; i++)
//	{
//		for (j = i + 1, k = i; j < size; j++)
//			if (arr[j] < arr[k])
//				k = j;
//		int c = arr[k];
//		arr[k] = arr[i];
//		arr[i] = c;
//	}
//}

