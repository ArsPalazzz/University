#include <iostream>
#include <stdio.h>

//������ ����� A � ���������, ������� ����� � ����� ������� � �������� ���� �� 13, ������� ��� ����

void main() {
	setlocale(LC_ALL, "ru");
	int A;
	char arr[16]; //4700

	printf("A is: ");
	scanf_s("%d", &A);
	_itoa_s(A, arr, 2);
	printf("%s", arr);

	unsigned int maskA = (1 << 11) - 1;
	A &= maskA & (1 << 2);
	_itoa_s(A, arr, 2);
	printf("\n%s", arr);
}