//#include <iostream>
//#include <stdio.h>
//#include <ctime>
//
////Компоненты файла fileA –  целые числа, значения которых повторяются.  
////Получить файл fileB, образованный из fileA исключением повторных вхождений одного и того же числа
//
//int main() {
//	setlocale(LC_ALL, "ru");
//	FILE* fa;
//	FILE* fb;
//	errno_t err;
//	srand(time(NULL));
//
//	int arr[30];
//	int count = 0;
//
//	for (int i = 0; i < sizeof(arr) / sizeof(arr[0]); i++) {
//		*(arr + i) = rand() % 7;
//	}
//
//	err = fopen_s(&fa, "fileA9.1.txt", "w");
//	if (err != 0)
//	{
//		perror("Невозможно создать файл\n");
//		return EXIT_FAILURE;
//	}
//
//	for (int i = 0; i < sizeof(arr) / sizeof(arr[0]); i++)
//	{
//		fprintf(fa, "%d, ", *(arr + i));
//	}
//
//	printf("Данные записаны в файл fileA9.1.txt\n");
//	fclose(fa);
//
//	err = fopen_s(&fb, "fileB9.1.txt", "w");
//	if (err != 0) {
//		perror("Невозможно создать файл\n");
//		return EXIT_FAILURE;
//	}
//
//	int myMas[30];
//	for (int i = 0; i < 10; i++) { //Проходит по цифрам
//		for (int j = 0; j < sizeof(arr) / sizeof(arr[0]); j++) { //Проходит по элементам массива
//			if (*(arr + j) == i) {
//				if (count < 1) {
//					count++;
//					*(myMas + j) = *(arr + j);
//				}
//			}
//		}
//		count = 0;
//	}
//
//	for (int i = 0; i < 30; i++) {
//		if (*(myMas + i) >= 0 && *(myMas + i) <= 6) {
//			fprintf(fb, "%d, ", *(myMas + i));
//		}
//	}
//
//	printf("Данные записаны в файл fileB9.1.txt\n");
//	fclose(fb);
//
//}