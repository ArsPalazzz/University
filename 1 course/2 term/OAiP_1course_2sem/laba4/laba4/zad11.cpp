//#include <iostream>
//#include <Windows.h>
//using namespace std;
//
////Записная книжка. Ф.И.О, дата рождения, адрес, телефон, место работы или учебы, должность. 
////Автоматическое формирование поздравления с днем рождения (по текущей дате). 
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
//	case 1:
//		err = fopen_s(&f, "Number1(11).txt", "w");
//		break;
//	case 2:
//		err = fopen_s(&f, "Number2(11).txt", "w");
//		break;
//	case 3:
//		err = fopen_s(&f, "Number3(11).txt", "w");
//		break;
//	default: printf("Такого человека нет");
//		return;
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
//		if (strcmp(Obj[i].lastName, str) == 0) {
//			printf("\nФамилия: %s\nИмя: %s\nОтчество: %s\nДата рождения: %d.%d.%d", Obj[i].lastName, Obj[i].firstName, Obj[i].patronymic, Obj[i].goD.day, Obj[i].goD.month, Obj[i].goD.year);
//			printf("\nАдрес: %s\nТелефон: %s\nМесто учебы/работы: %s\n", Obj[i].address, Obj[i].phone, Obj[i].placeOfStudy);
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
//	int* curday; //поздравление с др
//	int *curmonth;
//	printf("\nВведите текущий день(1-31): ");
//	scanf_s("%d", &curday);
//	printf("Введите текущий месяц(1-12): ");
//	scanf_s("%d", &curmonth);
//
//	for (int i = 0; i < allMen; i++) {
//		if ((curday == goM[i].goD.day) && (curmonth == goM[i].goD.month)) {
//			printf("\n\t\t\t\t\t!!!У человечка %s %s сегодня день рождения!!!\n", goM[i].firstName, goM[i].lastName);
//		}
//	}
//
//	do {
//		printf("\nВведите '0' чтобы выйти\nВведите '1' чтобы сделать запись в файл\nВведите '2' чтобы прочитать данные из файла\n");
//		printf("Введите '3' чтобы найти сведения о человеке по его фамилии\nВведите '4' чтобы удалить поле структуры\n\n");
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
//				printf("Введите фамилию человека, данные о котором хотите удалить: ");
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
//				printf("\n1)Фамилия: %s\n", goM[myI].lastName);
//				printf("2)Имя: %s\n", goM[myI].firstName);
//				printf("3)Отчество: %s\n", goM[myI].patronymic);
//				printf("4)День рождения: %d.%d.%d\n", goM[myI].goD.day, goM[myI].goD.month, goM[myI].goD.year);
//				printf("5)Адрес: %s\n", goM[myI].address);
//				printf("6)Телефон: %s\n", goM[myI].phone);
//				printf("7)Место учебы/работы: %s\n", goM[myI].placeOfStudy);
//
//				int choiz;
//
//				printf("\nЧто из этого вы хотите удалить?(1-7): ");
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
//				printf("\n1)Фамилия: %s\n", goM[myI].lastName);
//				printf("2)Имя: %s\n", goM[myI].firstName);
//				printf("3)Отчество: %s\n", goM[myI].patronymic);
//				printf("4)Дата рождения: %d.%d.%d\n", goM[myI].goD.day, goM[myI].goD.month, goM[myI].goD.year);
//				printf("5)Адрес: %s\n", goM[myI].address);
//				printf("6)Телефон: %s\n", goM[myI].phone);
//				printf("7)Место учебы/работы: %s\n", goM[myI].placeOfStudy);
//			}
//		} while (change > 7 || change < 0);
//	} while (true);
//}