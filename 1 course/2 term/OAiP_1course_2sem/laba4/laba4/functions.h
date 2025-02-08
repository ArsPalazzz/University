//#pragma once
//#include <iostream>
//#include <Windows.h>
//
//
//void show(const MyMan Obj[], const int all) {
//	system("cls");
//	printf(" �\tLastName\tFirstName\tPatronymic\tDayOfBirth\tAddress\t\t\tPhone\t\tPlace of study\n");
//	printf("===================================================================================================================================\n");
//
//	for (int i = 0; i < all; i++) {
//		printf(" %d\t%-10s\t%-10s\t%-10s\t%d.%d.%d\t%-20s\t%-15s\t%-10s\n", i + 1, Obj[i].lastName, Obj[i].firstName, Obj[i].patronymic, Obj[i].goD.day, Obj[i].goD.month, Obj[i].goD.year, Obj[i].address, Obj[i].phone, Obj[i].placeOfStudy);
//	}
//}
//
//void write(const MyMan Obj[], const int all) {
//	printf("\n������� ����� ��������, ������ �������� �� ������ �������� � ����: ");
//	int man;
//	scanf_s("%d", &man);
//
//	errno_t err;
//	FILE* f;
//
//	switch (man) {
//		case 1:
//			err = fopen_s(&f, "Number1(11).txt", "w");
//			break;
//		case 2:
//			err = fopen_s(&f, "Number2(11).txt", "w");
//			break;
//		case 3:
//			err = fopen_s(&f, "Number3(11).txt", "w");
//			break;
//		default: printf("������ �������� ���");
//			return;
//	}
//
//	fprintf(f, "�������: %s\n", Obj[man - 1].lastName);
//	fprintf(f, "���: %s\n", Obj[man - 1].firstName);
//	fprintf(f, "��������: %s\n", Obj[man - 1].patronymic);
//	fprintf(f, "���� ��������: %d.%d.%d\n", Obj[man - 1].goD.day, Obj[man - 1].goD.month, Obj[man - 1].goD.year);
//	fprintf(f, "�����: %s\n", Obj[man - 1].address);
//	fprintf(f, "�������: %s\n", Obj[man - 1].phone);
//	fprintf(f, "����� �����/������: %s\n", Obj[man - 1].placeOfStudy);
//
//	fclose(f);
//
//	printf("������ ���� ������� �������� � ����");
//}
//
//void read(const MyMan Obj[], const int all) {
//	printf("\n������� ����� ��������, �������� � ������� �� ������ ���������: ");
//	int man;
//	scanf_s("%d", &man);
//	char* estr;
//	char str[50];
//
//	errno_t err;
//	FILE* f;
//
//	switch (man) {
//	case 1:
//		err = fopen_s(&f, "Number1(11).txt", "r");
//		break;
//	case 2:
//		err = fopen_s(&f, "Number2(11).txt", "r");
//		break;
//	case 3:
//		err = fopen_s(&f, "Number3(11).txt", "r");
//		break;
//	case 4:
//		err = fopen_s(&f, "Number4(11).txt", "r");
//		break;
//	case 5:
//		err = fopen_s(&f, "Number5(11).txt", "r");
//		break;
//	default: printf("������ �������� ���");
//		return;
//	}
//
//	estr = fgets(str, sizeof(str), f);
//
//	printf("�������: %s\n", Obj[man - 1].lastName);
//	printf("���: %s\n", Obj[man - 1].firstName);
//	printf("��������: %s\n", Obj[man - 1].patronymic);
//	printf("���� ��������: %d.%d.%d\n", Obj[man - 1].goD.day, Obj[man - 1].goD.month, Obj[man - 1].goD.year);
//	printf("�����: %s\n", Obj[man - 1].address);
//	printf("�������: %s\n", Obj[man - 1].phone);
//	printf("����� �����/������: %s\n", Obj[man - 1].placeOfStudy);
//
//	fclose(f);
//}
//
//
//void find(const MyMan Obj[], const int all) {
//	system("cls");
//	printf("������� ������� ��������, ������ � ������� �� ������ �����: ");
//	char str[15];
//	cin >> str;
//
//	for (int i = 0; i < all; i++) {
//		if (strcmp(Obj[i].lastName,str) == 0) {
//			printf("\n�������: %s\n���: %s\n��������: %s\n���� ��������: %d.%d.%d", Obj[i].lastName, Obj[i].firstName, Obj[i].patronymic, Obj[i].goD.day, Obj[i].goD.month, Obj[i].goD.year);
//			printf("\n�����: %s\n�������: %s\n����� �����/������: %s\n", Obj[i].address, Obj[i].phone, Obj[i].placeOfStudy);
//		}
//	}
//}