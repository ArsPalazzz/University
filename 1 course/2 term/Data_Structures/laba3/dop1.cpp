//#include <iostream>
//#include <cstdio>
//
//
////Ввести строку символов. Посчитать сколько раз встречался каждый из символов
//void main() {
//	setlocale(LC_ALL, "ru");
//	const int size = 99;
//	char arr[size];
//	printf("Введите строку:\n");
//	fgets(arr, size, stdin);
//
//	for (char i = 'A'; i >= 'A' && i <= 'z'; i++) {
//		int count = 0;
//		for (int j = 0; j < size; j++) {
//			if (*(arr + j) == int(i)) {
//				count++;
//			}
//		}
//		if (count != 0) {
//			printf("%c - %d\n", i, count);
//		}
//	}
//}