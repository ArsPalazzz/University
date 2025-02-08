//#include <iostream>
//#include <stdio.h>
//using namespace std;
//
//
////Установить в 0 n битов в числе А влево от позиции p, заменить ими m битов числа В, начиная с позиции q
//
//void main() {
//	setlocale(LC_ALL, "ru");
//	int n, A, p, m, B, q;
//	char arr1[33], arr2[33];
//
//	printf("Число A: ");
//	scanf_s("%d", &A); //93 - 01011101
//	_itoa_s(A, arr1, 2);
//	printf("%s", arr1);
//
//	printf("\nКоличество битов n: ");
//	scanf_s("%d", &n);
//
//	printf("Позиция p: ");
//	scanf_s("%d", &p);
//
//	unsigned int mask1 = (1 << n) - 1;
//	A ^= (mask1 << (p - 1));
//	_itoa_s(A, arr1, 2);
//	printf("%s", arr1);
//
//	printf("\nЧисло B: ");
//	scanf_s("%d", &B); //75 - 01001011
//	_itoa_s(B, arr2, 2);
//	printf("%s", arr2);
//
//	printf("\nКоличество битов m: ");
//	scanf_s("%d", &m);
//
//	printf("Позиция q: ");
//	scanf_s("%d", &q);
//
//	unsigned int mask2 = (1 << m) - 1;
//	B &= ~(mask2 << (q - 1));
//	_itoa_s(B, arr2, 2);
//	printf("%s", arr2);
//
//	/* A = 150; 
//	 char tmp[33];
//	_itoa_s(A, tmp, 2);
//	cout << " Число А: " << tmp << endl;
//	_itoa_s(0x24, tmp, 2);
//	cout << " Маска для А: " << tmp << endl;
//	_itoa_s(A | 0x24, tmp, 2);
//	cout << " Результат: " << tmp << endl << endl;*/
//}






