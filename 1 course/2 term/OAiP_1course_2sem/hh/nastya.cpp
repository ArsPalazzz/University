//#include <iostream>
//#include <stdio.h>
//
////���� ��� ������� A(m) � B(n), �������� ������ C(m+n) ���������� ������� �������� ������� � � ����� �������� ������� �
//
//void main() {
//	setlocale(LC_ALL, "ru");
//	int size1, size2;
//	printf("������� ������ ������� �������: ");
//	scanf_s("%d", &size1);
//	printf("������� ������ ������� �������: ");
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
//	printf("������ ������:\n");
//
//	for (int i = 0; i < size1; i++) {
//		printf("%d\t", *(arr1 + i));
//	}
//
//	printf("\n������ ������:\n");
//
//	for (int i = 0; i < size2; i++) {
//		printf("%d\t", *(arr2 + i));
//	}
//
//	printf("\n������ ������:\n");
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