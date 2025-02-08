//#include <iostream>
//#include <cstdio>
//using namespace std;
//
////Дан массив строк. Найти среднюю длину строки. Если длина строки больше средней, то строку обрезать, если больше, то добавить пробелы
//
//void main() {
//	setlocale(LC_ALL, "ru");
//	printf("Заполняйте строки:\n");
//	const int size = 99;
//	char arr1[size], arr2[size], arr3[size], arr4[size], arr5[size]; //объявление массивов
//	char* arr11;
//	char* arr12;
//	char* arr13;
//	char* arr14;
//	char* arr15;
//
//	gets_s(arr1, size); //ввод строк
//	gets_s(arr2, size);
//	gets_s(arr3, size);
//	gets_s(arr4, size);
//	gets_s(arr5, size);
//
//	int len1 = strlen(arr1); //количество символов в массиве
//	int len2 = strlen(arr2);
//	int len3 = strlen(arr3);
//	int len4 = strlen(arr4);
//	int len5 = strlen(arr5);
//
//	int len = (len1 + len2 + len3 + len4 + len5) / 5;
//	printf("len is %d\n", len);
//	arr11 = new char[len]; // выделение памяти
//	arr12 = new char[len];
//	arr13 = new char[len];
//	arr14 = new char[len];
//	arr15 = new char[len];
//	{
//		if (len1 > len) {
//			for (int i = 0; i < len; i++) {
//				*(arr11 + i) = *(arr1 + i);
//			}
//			puts(arr11);
//		}
//
//		else if (len1 == len) {
//			for (int i = 0; i < len; i++) {
//				*(arr11 + i) = *(arr1 + i);
//			}
//			puts(arr11);
//		}
//
//		else {
//			for (int i = len1; i < len; i++) {
//				*(arr1 + i) = 'z';
//			}
//			puts(arr11);
//		}
//	}
//
//	{
//		if (len2 > len) {
//			for (int i = 0; i < len; i++) {
//				*(arr12 + i) = *(arr2 + i);
//			}
//			puts(arr12);
//		}
//
//		else if (len2 == len) {
//			for (int i = 0; i < len; i++) {
//				*(arr12 + i) = *(arr2 + i);
//			}
//			puts(arr12);
//		}
//
//		else {
//			for (int i = len2; i < len; i++) {
//				*(arr2 + i) = 'z';
//			}
//			puts(arr12);
//		}
//	}
//
//	{
//		if (len3 > len) {
//			
//			for (int i = 0; i < len; i++) {
//				*(arr13 + i) = *(arr3 + i);
//			}
//			puts(arr13);
//		}
//
//		else if (len3 == len) {
//			for (int i = 0; i < len; i++) {
//				*(arr13 + i) = *(arr3 + i);
//			}
//			puts(arr13);
//		}
//
//		else {
//			
//			for (int i = len1; i < len; i++) {
//				*(arr3 + i) = 'z';
//			}
//			puts(arr13);
//		}
//	}
//
//	{
//		if (len4 > len) {
//			
//			for (int i = 0; i < len; i++) {
//				*(arr14 + i) = *(arr4 + i);
//			}
//			puts(arr14);
//		}
//
//		else if (len4 == len) {
//			for (int i = 0; i < len; i++) {
//				*(arr14 + i) = *(arr4 + i);
//			}
//			puts(arr14);
//		}
//
//		else {
//		
//			for (int i = len4; i < len; i++) {
//				*(arr4 + i) = 'z';
//			}
//			puts(arr14);
//		}
//	}
//
//	{
//		if (len5 > len) {
//			
//			for (int i = 0; i < len; i++) {
//				*(arr15 + i) = *(arr5 + i);
//			}
//			puts(arr15);
//		}
//
//		else if (len5 == len) {
//			for (int i = 0; i < len; i++) {
//				*(arr15 + i) = *(arr5 + i);
//			}
//			puts(arr15);
//		}
//
//		else {
//			
//			for (int i = len5; i < len; i++) {
//				*(arr5 + i) = 'z';
//			}
//			puts(arr15);
//		}
//	}
//
//}