//#include <iostream>
//#include <cstdio>
//#include <string.h>
//
////������� �� �������� ������� � ����������
//void main() {
//	setlocale(LC_ALL, "ru");
//	int numb = 0;
//	char arr[33];
//	printf("������� ����� � �������� ����: ");
//	gets_s(arr);
//	_strrev(arr);
//	for (int i = 0; i < strlen(arr); i++) {
//		numb += (*(arr + i) - '0') * pow(2, i); //�.�. ��� ��� ASCII, ��� ����� �� ���� ����� ������� ��� '0'
//	}
//
//	printf("%d", numb);
//}
//
////������� �� ���������� ������� � ��������
//void main() {
//	setlocale(LC_ALL, "ru"); //������ ����� Release, � �� Debug
//	int numb;
//	char arr[33];
//	printf("������� �����: ");
//	scanf_s("%d", &numb); //�� 32 �� 63 ������������
//	int i = 0;
//	while(numb) {
//		*(arr + i) = (numb % 2) + '0';
//		numb /= 2;
//		i++;
//	}
//	_strrev(arr);
//	printf("%s", arr);
//}