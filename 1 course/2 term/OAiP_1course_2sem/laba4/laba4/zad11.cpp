//#include <iostream>
//#include <Windows.h>
//using namespace std;
//
////�������� ������. �.�.�, ���� ��������, �����, �������, ����� ������ ��� �����, ���������. 
////�������������� ������������ ������������ � ���� �������� (�� ������� ����). 
//
//struct DateOfBirth {
//	int* day;
//	int* month;
//	int* year;
//};
//
//struct MyMan {
//	char* lastName = new char[15];
//	char* firstName = new char[15];
//	char* patronymic = new char[15];
//	struct DateOfBirth goD;
//	char* address = new char[50];
//	char* phone = new char[14];
//	char* placeOfStudy = new char[5];
//};
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
//	case 1:
//		err = fopen_s(&f, "Number1(11).txt", "w");
//		break;
//	case 2:
//		err = fopen_s(&f, "Number2(11).txt", "w");
//		break;
//	case 3:
//		err = fopen_s(&f, "Number3(11).txt", "w");
//		break;
//	default: printf("������ �������� ���");
//		return;
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
//		if (strcmp(Obj[i].lastName, str) == 0) {
//			printf("\n�������: %s\n���: %s\n��������: %s\n���� ��������: %d.%d.%d", Obj[i].lastName, Obj[i].firstName, Obj[i].patronymic, Obj[i].goD.day, Obj[i].goD.month, Obj[i].goD.year);
//			printf("\n�����: %s\n�������: %s\n����� �����/������: %s\n", Obj[i].address, Obj[i].phone, Obj[i].placeOfStudy);
//		}
//	}
//}
//
//void main() {
//	setlocale(LC_ALL, "ru");
//	const int allMen = 2;
//	MyMan goM[allMen];
//
//	for (int i = 0; i < allMen; i++) {
//		printf("LastName is ");
//		cin.getline(goM[i].lastName, 15);
//		printf("FirstName is ");
//		cin.getline(goM[i].firstName, 15);
//		printf("Patronymic is ");
//		cin.getline(goM[i].patronymic, 15);
//		printf("Day is ");
//		scanf_s("%d", &goM[i].goD.day);
//		printf("Month is ");
//		scanf_s("%d",&goM[i].goD.month);
//		printf("Year is ");
//		scanf_s("%d", &goM[i].goD.year);
//		printf("Address is ");
//		cin.get();
//		cin.getline(goM[i].address, 30);
//		printf("Phone is ");
//		cin.getline(goM[i].phone, 14);
//		printf("Place of study is ");
//		cin.getline(goM[i].placeOfStudy, 5);
//	}
//
//
//
//	show(goM, allMen);
//
//	int* curday; //������������ � ��
//	int *curmonth;
//	printf("\n������� ������� ����(1-31): ");
//	scanf_s("%d", &curday);
//	printf("������� ������� �����(1-12): ");
//	scanf_s("%d", &curmonth);
//
//	for (int i = 0; i < allMen; i++) {
//		if ((curday == goM[i].goD.day) && (curmonth == goM[i].goD.month)) {
//			printf("\n\t\t\t\t\t!!!� ��������� %s %s ������� ���� ��������!!!\n", goM[i].firstName, goM[i].lastName);
//		}
//	}
//
//	do {
//		printf("\n������� '0' ����� �����\n������� '1' ����� ������� ������ � ����\n������� '2' ����� ��������� ������ �� �����\n");
//		printf("������� '3' ����� ����� �������� � �������� �� ��� �������\n������� '4' ����� ������� ���� ���������\n\n");
//
//		int change;
//		scanf_s("%d", &change);
//
//		do {
//			switch (change) {
//			case 0:
//				exit(0);
//				break;
//			case 1:
//				write(goM, allMen);
//				break;
//			case 2:
//				read(goM, allMen);
//				break;
//			case 3:
//				find(goM, allMen);
//				break;
//			case 4:
//				system("cls");
//				printf("������� ������� ��������, ������ � ������� ������ �������: ");
//				char str[15];
//				cin >> str;
//				int myI;
//
//				for (int i = 0; i < allMen; i++) {
//					if (strcmp(goM[i].lastName, str) == 0) {
//						myI = i;
//						break;
//					}
//				}
//
//				printf("\n1)�������: %s\n", goM[myI].lastName);
//				printf("2)���: %s\n", goM[myI].firstName);
//				printf("3)��������: %s\n", goM[myI].patronymic);
//				printf("4)���� ��������: %d.%d.%d\n", goM[myI].goD.day, goM[myI].goD.month, goM[myI].goD.year);
//				printf("5)�����: %s\n", goM[myI].address);
//				printf("6)�������: %s\n", goM[myI].phone);
//				printf("7)����� �����/������: %s\n", goM[myI].placeOfStudy);
//
//				int choiz;
//
//				printf("\n��� �� ����� �� ������ �������?(1-7): ");
//				scanf_s("%d", &choiz);
//
//				switch (choiz) {
//				case 1:
//					goM[myI].lastName = (char*)" ";
//					break;
//				case 2:
//					goM[myI].firstName = (char*)" ";
//					break;
//				case 3:
//					goM[myI].patronymic = (char*)" ";
//					break;
//				case 4:
//					goM[myI].goD.day = (int*)0;
//					goM[myI].goD.month = (int*)0;
//					goM[myI].goD.year = (int*)0;
//					break;
//				case 5:
//					goM[myI].address = (char*)" ";
//					break;
//				case 6:
//					goM[myI].phone = (char*)" ";
//					break;
//				case 7:
//					goM[myI].placeOfStudy = (char*)" ";
//				}
//
//				printf("\n1)�������: %s\n", goM[myI].lastName);
//				printf("2)���: %s\n", goM[myI].firstName);
//				printf("3)��������: %s\n", goM[myI].patronymic);
//				printf("4)���� ��������: %d.%d.%d\n", goM[myI].goD.day, goM[myI].goD.month, goM[myI].goD.year);
//				printf("5)�����: %s\n", goM[myI].address);
//				printf("6)�������: %s\n", goM[myI].phone);
//				printf("7)����� �����/������: %s\n", goM[myI].placeOfStudy);
//			}
//		} while (change > 7 || change < 0);
//	} while (true);
//}