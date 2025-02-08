//#include <iostream>
//#include <stdio.h>
//
///*написать 2 функции.В главной реализовать ввод двух матриц, а во второй сделать произведение двух любых матриц
//ну матрицы сам можешь задать в главной, а вот со второй там надо реализовать передачу двух двумерных массивов в 
//параметры функции и сделать так, чтобы эта функция возвращала в качестве значения матрицу))))) */
//
//int** mult(int** firstArr, int** secondArr, int** thirdArr);
//
//void main() {
//	setlocale(LC_ALL, "ru");
//
//	int** arr1 = new int* [3]; //Выделение памяти под массив
//	int** arr2 = new int* [3];
//	int** arr3 = new int* [3];
//
//	for (int i = 0; i < 3; i++) { //Выделение памяти для элементом массива
//		*(arr1 + i) = new int[3];
//	}
//
//	for (int i = 0; i < 3; i++) {
//		*(arr2 + i) = new int[3];
//	}
//
//	for (int i = 0; i < 3; i++) {
//		*(arr3 + i) = new int[3];
//	}
//
//
//	for (int i = 0; i < 3; i++) { //Заполнение массива
//		for (int j = 0; j < 3; j++) {
//			*(*(arr1 + i) + j) = rand() % 10 + 1;
//		}
//	}
//
//	for (int i = 0; i < 3; i++) {
//		for (int j = 0; j < 3; j++) {
//			*(*(arr2 + i) + j) = rand() % 10 + 1;
//		}
//	}
//	
//	printf("Первый массив:\n");
//
//	for (int i = 0; i < 3; i++) { //Вывод массива
//		for (int j = 0; j < 3; j++) {
//			printf("%d\t", *(* (arr1 + i) + j));
//		}
//		printf("\n");
//	}
//
//	printf("Второй массив:\n");
//
//	for (int i = 0; i < 3; i++) {
//		for (int j = 0; j < 3; j++) {
//			printf("%d\t", *(*(arr2 + i) + j));
//		}
//		printf("\n");
//	}
//
//	mult(arr1, arr2, arr3); //Вызов функции
//
//	printf("Третий массив:\n");
//
//	for (int i = 0; i < 3; i++) { //Вывод 3 массива
//		for (int j = 0; j < 3; j++) {
//			printf("%d\t", *(*(arr3 + i) + j));
//		}
//		printf("\n");
//	}
//
//	for (int i = 0; i < 3; i++) { //Очистка памяти
//		delete[] arr1[i];
//	}
//
//	for (int i = 0; i < 3; i++) {
//		delete[] arr2[i];
//	}
//
//	for (int i = 0; i < 3; i++) {
//		delete[] arr3[i];
//	}
//	
//	delete[] arr1;
//	delete[] arr2;
//	delete[] arr3;
//}
//
//int** mult(int** firstArr, int** secondArr, int** thirdArr) {
//	for (int i = 0; i < 3; i++) {
//		for (int j = 0; j < 3; j++) {
//			*(*(thirdArr + i) + j) = 0;
//			for (int k = 0; k < 3; k++) {
//				*(*(thirdArr + i) + j) += *(*(firstArr + i) + k) * (*(*(secondArr + k) + j));
//			}
//		}
//	}
//	return thirdArr;
//}