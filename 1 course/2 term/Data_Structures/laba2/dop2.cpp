//#include <iostream>
//#include <cstdio>
//#include <string.h>
//
////перевод из двоичной системы в десятичную
//void main() {
//	setlocale(LC_ALL, "ru");
//	int numb = 0;
//	char arr[33];
//	printf("Введите число в двоичном виде: ");
//	gets_s(arr);
//	_strrev(arr);
//	for (int i = 0; i < strlen(arr); i++) {
//		numb += (*(arr + i) - '0') * pow(2, i); //т.к. тут код ASCII, нам нужно из кода числа вычесть код '0'
//	}
//
//	printf("%d", numb);
//}