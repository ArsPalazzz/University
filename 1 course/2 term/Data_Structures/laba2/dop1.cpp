//#include <iostream>
//#include <stdio.h>
//
//
////������� ���� ������ �������� ��������� �������. �������� � ����� ������� ��� ����� ������� ��������
//void main() {
//	setlocale(LC_ALL, "ru");
//
//	printf("������� ���������� ��������� ������� �������: ");
//	int kolichEl1;
//
//	scanf_s("%d", &kolichEl1);
//
//	int* arr1 = new int[kolichEl1];
//	int* arr2 = new int[kolichEl1 - 5 + 3];
//	int kolichnech = 0, j = 0, lastI;
//
//	for (int i = 0; i < kolichEl1; i++) { //������������� �������
//		*(arr1 + i) = rand() % 20 + 1;
//	}
//
//	for (int i = 0; i < kolichEl1; i++) { //����� �������
//		printf("%d\t", *(arr1 + i));
//	}
//	printf("\n");
//
//	for (int i = 0; i < kolichEl1; i++) {
//		if (kolichnech == 5) { //����� ��� ����� 5, ������� �� �����
//		lastI = i;
//		break;
//		}
//		else if ((*(arr1 + i) % 2) == 1) { //���� ����� ��������, �� ������ �-�� ��������
//			kolichnech++;
//		}
//		else if ((*(arr1 + i) % 2) == 0) {
//			*(arr2 + j) = *(arr1 + i); //� ��� ������� ������ ������ ������
//				j++;
//		}
//	}
//
//	for (int i = 0; i < kolichEl1 - lastI; i++) {
//		*(arr2 + lastI + i - 5) = *(arr1 + lastI + i);
//	}
//
//	for (int i = 0; i < 3; i++) {
//		*(arr2 + i + (kolichEl1 - 5)) = 0;
//	}
//
//	for (int i = 0; i < kolichEl1 - 5 + 3; i++) {
//		printf("%d\t", *(arr2 + i));
//	}
//
//	delete[] arr2;
//	delete[] arr1;
//}