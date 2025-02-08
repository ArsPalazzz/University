//#include <iostream>
//#include <stdio.h>
//
////В матрице элементы диагонали расположить в обратном порядке
//
//void main() {
//	setlocale(LC_ALL, "ru");
//	const int size = 5;
//	int arr[size][size];
//	int arr2[size];
//	
//	for (int i = 0; i < size; i++) {
//		for (int j = 0; j < size; j++) {
//			*(*(arr + i) + j) = rand() % 15 + 1;
//		}
//	}
//
//	printf("Исходный массив:\n");
//
//	for (int i = 0; i < size; i++) {
//		for (int j = 0; j < size; j++) {
//			printf("%d\t", *(*(arr + i) + j));
//		}
//		printf("\n");
//	}
//
//	for (int i = 0, j = 0; i < size; i++, j++) {
//		arr2[i] = *(*(arr + i) + j);
//	}
//
//	for (int i = 0, j = size - 1; i < size; i++, j--) {
//		*(*(arr + j) + j) = *(arr2 + i);
//	}
//
//	printf("Конечный массив:\n");
//
//	for (int i = 0; i < size; i++) {
//		for (int j = 0; j < size; j++) {
//			printf("%d\t", *(*(arr + i) + j));
//		}
//		printf("\n");
//	}
//}