//#include <iostream>
//#include <stdio.h>
//
////������� ��������� ���� F1 �� �����, ��� �� 5 �����, � �������� � ���� ����������. 
////����������� � ���� F2 ������ ������ �� F1, ������� �� �������� ����. 
//int main() {
//	setlocale(LC_ALL, "ru");
//	FILE* ff;
//	FILE* sf;
//	bool chislo = false;
//
//	const char* str[] = { "hello", "su4", "dude", "2b", "maaan"};
//	errno_t err;
//	err = fopen_s(&ff, "fileA10.2.txt", "w");
//
//	if (err) {
//		perror("���������� ������� ����!\n");
//		return EXIT_FAILURE;
//	}
//
//	for (int i = 0; i < sizeof(str)/sizeof(str[0]); i++)
//	{
//		fputs(*(str + i), ff);
//		fprintf(ff, "\n");
//	}
//
//	printf("������ �������� � ���� fileA10.2.txt\n");
//	fclose(ff);
//
//	const char* str2[sizeof(str)];
//	err = fopen_s(&sf, "fileB10.2.txt", "w");
//
//	if (err) {
//		perror("���������� ������� ����!\n");
//		return EXIT_FAILURE;
//	}
//
//	for (int i = 0; i < sizeof(str) / sizeof(str[0]); i++) {
//		for (int j = 0; j < 6; j++) {
//			if ((( * (*(str + i) + j)) >= '0') && ((*(*(str + i) + j)) <= '9')) {
//				chislo = true;
//			}
//		}
//		if (chislo == false) {
//			fputs(*(str + i), sf);
//			fprintf(sf, "\n");
//		}
//		chislo = false;
//	}
//
//	printf("������ �������� � ���� fileB10.2.txt\n");
//	fclose(sf);
//
//}
