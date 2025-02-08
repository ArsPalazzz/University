//#pragma once
//#include <iostream>
//#include <Windows.h>
//
//
//void show(const MyMan Obj[], const int all) {
//	system("cls");
//	printf(" №\tLastName\tFirstName\tPatronymic\tDayOfBirth\tAddress\t\t\tPhone\t\tPlace of study\n");
//	printf("===================================================================================================================================\n");
//
//	for (int i = 0; i < all; i++) {
//		printf(" %d\t%-10s\t%-10s\t%-10s\t%d.%d.%d\t%-20s\t%-15s\t%-10s\n", i + 1, Obj[i].lastName, Obj[i].firstName, Obj[i].patronymic, Obj[i].goD.day, Obj[i].goD.month, Obj[i].goD.year, Obj[i].address, Obj[i].phone, Obj[i].placeOfStudy);
//	}
//}
//
//void write(const MyMan Obj[], const int all) {
//	printf("\nВведите номер человека, данные которого вы хотите записать в файл: ");
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
//		default: printf("Такого человека нет");
//			return;
//	}
//
//	fprintf(f, "Фамилия: %s\n", Obj[man - 1].lastName);
//	fprintf(f, "Имя: %s\n", Obj[man - 1].firstName);
//	fprintf(f, "Отчество: %s\n", Obj[man - 1].patronymic);
//	fprintf(f, "День рождения: %d.%d.%d\n", Obj[man - 1].goD.day, Obj[man - 1].goD.month, Obj[man - 1].goD.year);
//	fprintf(f, "Адрес: %s\n", Obj[man - 1].address);
//	fprintf(f, "Телефон: %s\n", Obj[man - 1].phone);
//	fprintf(f, "Место учебы/работы: %s\n", Obj[man - 1].placeOfStudy);
//
//	fclose(f);
//
//	printf("Данные были успешно записаны в файл");
//}
//
//void read(const MyMan Obj[], const int all) {
//	printf("\nВведите номер человека, сведения о котором вы хотите прочитать: ");
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
//	default: printf("Такого человека нет");
//		return;
//	}
//
//	estr = fgets(str, sizeof(str), f);
//
//	printf("Фамилия: %s\n", Obj[man - 1].lastName);
//	printf("Имя: %s\n", Obj[man - 1].firstName);
//	printf("Отчество: %s\n", Obj[man - 1].patronymic);
//	printf("День рождения: %d.%d.%d\n", Obj[man - 1].goD.day, Obj[man - 1].goD.month, Obj[man - 1].goD.year);
//	printf("Адрес: %s\n", Obj[man - 1].address);
//	printf("Телефон: %s\n", Obj[man - 1].phone);
//	printf("Место учебы/работы: %s\n", Obj[man - 1].placeOfStudy);
//
//	fclose(f);
//}
//
//
//void find(const MyMan Obj[], const int all) {
//	system("cls");
//	printf("Введите фамилию человека, данные о котором вы хотите найти: ");
//	char str[15];
//	cin >> str;
//
//	for (int i = 0; i < all; i++) {
//		if (strcmp(Obj[i].lastName,str) == 0) {
//			printf("\nФамилия: %s\nИмя: %s\nОтчество: %s\nДата рождения: %d.%d.%d", Obj[i].lastName, Obj[i].firstName, Obj[i].patronymic, Obj[i].goD.day, Obj[i].goD.month, Obj[i].goD.year);
//			printf("\nАдрес: %s\nТелефон: %s\nМесто учебы/работы: %s\n", Obj[i].address, Obj[i].phone, Obj[i].placeOfStudy);
//		}
//	}
//}