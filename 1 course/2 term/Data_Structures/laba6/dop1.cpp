//#include <iostream>
//#include <stdio.h>
//#include <ctime>
//
////. ���������� ����� fileA �  ����� �����, �������� ������� �����������.  
////�������� ���� fileB, ������������ �� fileA �������, ������� ����������� � fileA ����� 2 ���.
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
//	err = fopen_s(&fa, "fileA13.1.txt", "w");
//	if (err != 0)
//	{
//		perror("���������� ������� ����\n");
//		return EXIT_FAILURE;
//	}
//
//	for (int i = 0; i < sizeof(arr) / sizeof(arr[0]); i++)
//	{
//		fprintf(fa, "%d, ", *(arr + i));
//	}
//
//	printf("������ �������� � ���� fileA13.1.txt\n");
//	fclose(fa);
//
//	err = fopen_s(&fb, "fileB13.1.txt", "w");
//	if (err != 0) {
//		perror("���������� ������� ����\n");
//		return EXIT_FAILURE;
//	}
//
//	int myMas[30];
//	int k = 0;
//	for (int i = 0; i < 10; i++) { //�������� �� ������
//		for (int j = 0; j < sizeof(arr) / sizeof(arr[0]); j++) { //�������� �� ��������� �������
//			if (*(arr + j) == i) {
//				if (count < 2) {
//					count++;
//					*(myMas + j) = *(arr + j);
//					k++;
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
//	printf("������ �������� � ���� fileB13.1.txt\n");
//	fclose(fb);
//
//}