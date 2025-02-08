//#include <iostream>
//#include <cstdio>
//using namespace std;
//
////Дан массив строк. Найти среднюю длину строки. Если длина строки больше средней, то строку обрезать, если больше, то добавить пробелы
//void main() {
//	int kolichStrok = 4;
//	char** arr = new char* [kolichStrok];
//
//	for (int i = 0; i < kolichStrok; i++) {//Выделение памяти
//		*(arr + i) = new char[30];
//	}
//
//	for (int i = 0; i < kolichStrok; i++) {//Ввод строк
//		gets_s(*(arr + i), 30);
//	}
//
//	int len1 = strlen(*(arr));
//	int len2 = strlen(*(arr + 1));
//	int len3 = strlen(*(arr + 2));
//	int len4 = strlen(*(arr + 3));
//	int len = (len1 + len2 + len3 + len4) / 4;
//
//	char** arr2 = new char* [kolichStrok];
//
//	for (int i = 0; i < kolichStrok; i++) {//Выделение памяти
//		*(arr2 + i) = new char[len + 1];
//	}
//
//	for (int i = 0; i < kolichStrok; i++) {
//		if (strlen(*(arr + i)) > len) {
//			for (int j = 0; j < len; j++) {
//				*(*(arr2 + i) + j) = *(*(arr + i) + j);
//			}
//			puts(*(arr2 + i));
//		}
//		else if (strlen(*(arr + i)) == len) {
//			puts(*(arr + i));
//		}
//		else if (strlen(*(arr + i)) < len) {
//			for (int j = 0; j < len; j++) {
//				if (j < strlen(*(arr + i))) {
//					*(*(arr2 + i) + j) = *(*(arr + i) + j);
//				}
//				else {
//					*(*(arr2 + i) + j) = ' ';
//				}
//			}
//			puts(*(arr2 + i));
//		}
//	}
//
//	for (int i = 0; i < kolichStrok; i++) { //Очистка памяти
//		delete[] * (arr2 + i);
//	}
//
//	for (int i = 0; i < kolichStrok; i++) {
//		delete[] * (arr + i);
//	}
//
//	delete[] arr2;
//	delete[] arr;
//}