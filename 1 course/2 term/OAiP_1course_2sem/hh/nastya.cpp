//#include <iostream>
//#include <stdio.h>
//
////даны два массива A(m) и B(n), получить массив C(m+n) расположив сначала элементы массива А а потом элементы массива В
//
//void main() {
//	setlocale(LC_ALL, "ru");
//	int size1, size2;
//	printf("Введите размер первого массива: ");
//	scanf_s("%d", &size1);
//	printf("Введите размер второго массива: ");
//	scanf_s("%d", &size2);
//
//	int* arr1 = new int[size1];
//	int* arr2 = new int[size2];
//
//	for (int i = 0; i < size1; i++) {
//		*(arr1 + i) = rand() % 20 + 1;
//	}
//
//	for (int i = 0; i < size2; i++) {
//		*(arr2 + i) = rand() % 20 + 1;
//	}
//
//	printf("Первый массив:\n");
//
//	for (int i = 0; i < size1; i++) {
//		printf("%d\t", *(arr1 + i));
//	}
//
//	printf("\nВторой массив:\n");
//
//	for (int i = 0; i < size2; i++) {
//		printf("%d\t", *(arr2 + i));
//	}
//
//	printf("\nТретий массив:\n");
//
//	int* arr3 = new int[size1 + size2];
//
//	for (int i = 0; i < size1; i++) {
//		*(arr3 + i) = *(arr1 + i);
//	}
//
//	for (int i = 0; i < size2; i++) {
//		*(arr3 + i + size1) = *(arr2 + i);
//	}
//
//	for (int i = 0; i < size1 + size2; i++) {
//		printf("%d\t", *(arr3 + i));
//	}
//
//	delete[] arr3;
//	delete[] arr2;
//	delete[] arr1;
//}