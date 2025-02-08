//#include <iostream>
//#include <stdio.h>
//#include <conio.h>
//using namespace std;
//
////Преподаватели. Фамилия преподавателя, название экзамена, дата экзамена. Выбор по фамилии
//
//
//struct Prepods {
//	char* lastName = new char[15];
//	char* exam = new char[10];
//	int* day;
//	int* month;
//	int* year;
//};
//
//
//void show(const Prepods Obj[], const int all) {
//	system("cls");
//	printf(" №\tLastName\tName of exam\tDate of exam\n");
//	printf("===========================================================================\n");
//
//	for (int i = 0; i < all; i++) {
//		printf(" %d\t%-10s\t%-10s\t%d.%d.%d\n", i + 1, Obj[i].lastName, Obj[i].exam, Obj[i].day, Obj[i].month, Obj[i].year);
//	}
//}
//
//void write(const Prepods Obj[], const int all) {
//	printf("\nВведите номер человека, данные которого вы хотите записать в файл: ");
//	int man;
//	scanf_s("%d", &man);
//
//	errno_t err;
//	FILE* f;
//
//	switch (man) {
//	case 1:
//		err = fopen_s(&f, "Number1(15).txt", "w");
//		break;
//	case 2:
//		err = fopen_s(&f, "Number2(15).txt", "w");
//		break;
//	case 3:
//		err = fopen_s(&f, "Number3(15).txt", "w");
//		break;
//	default: printf("Такого человека нет");
//		return;
//	}
//
//	fprintf(f, "Фамилия: %s\n", Obj[man - 1].lastName);
//	fprintf(f, "Название экзамена: %s\n", Obj[man - 1].exam);
//	fprintf(f, "Дата экзамена: %d.%d.%d\n", Obj[man - 1].day, Obj[man - 1].month, Obj[man - 1].year);
//
//	fclose(f);
//
//	printf("Данные были успешно записаны в файл");
//}
//
//void read(const Prepods Obj[], const int all) {
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
//		err = fopen_s(&f, "Number1(15).txt", "r");
//		break;
//	case 2:
//		err = fopen_s(&f, "Number2(15).txt", "r");
//		break;
//	case 3:
//		err = fopen_s(&f, "Number3(15).txt", "r");
//		break;
//	default: printf("Такого человека нет");
//		return;
//	}
//
//	estr = fgets(str, sizeof(str), f);
//
//	printf("Фамилия: %s\n", Obj[man - 1].lastName);
//	printf("Название экзамена: %s\n", Obj[man - 1].exam);
//	printf("Дата экзамена: %d.%d.%d\n", Obj[man - 1].day, Obj[man - 1].month, Obj[man - 1].year);
//
//	fclose(f);
//}
//
//
//void find(const Prepods Obj[], const int all) {
//	system("cls");
//	printf("Введите фамилию человека, данные о котором вы хотите найти: ");
//	char str[15];
//	cin >> str;
//
//	for (int i = 0; i < all; i++) {
//		if (strcmp(Obj[i].lastName, str) == 0) {
//			printf("\nФамилия: %s\nНазвание экзамена: %s\nДата экзамена: %d.%d.%d\n", Obj[i].lastName, Obj[i].exam, Obj[i].day, Obj[i].month, Obj[i].year);
//		}
//	}
//}
//
//void main() {
//	setlocale(LC_ALL, "ru");
//	const int allPrepods = 2;
//	Prepods goP[allPrepods];
//
//	for (int i = 0; i < allPrepods; i++) {
//		printf("LastName is ");
//		cin.getline(goP[i].lastName, 15);
//		printf("Name of exam is ");
//		cin.getline(goP[i].exam, 15);
//		printf("Day is ");
//		scanf_s("%d", &goP[i].day);
//		printf("Month is ");
//		scanf_s("%d", &goP[i].month);
//		printf("Year is ");
//		scanf_s("%d", &goP[i].year);
//		cin.get();
//	}
//
//	show(goP, allPrepods);
//
//	do {
//		printf("\nВведите '0' чтобы выйти\nВведите '1' чтобы сделать запись в файл\nВведите '2' чтобы прочитать данные из файла\n");
//		printf("Введите '3' чтобы найти сведения о человеке по его фамилии\nВведите '4' чтобы удалить поле структуры\n\n");
//		int change;
//		scanf_s("%d", &change);
//
//		do {
//			switch (change) {
//			case 0:
//				exit(0);
//				break;
//			case 1:
//				write(goP, allPrepods);
//				break;
//			case 2:
//				read(goP, allPrepods);
//				break;
//			case 3:
//				find(goP, allPrepods);
//				break;
//			case 4:
//				printf("Введите фамилию человека, данные о котором хотите удалить: ");
//				char str[15];
//				cin >> str;
//				int myI;
//
//				for (int i = 0; i < allPrepods; i++) {
//					if (strcmp(goP[i].lastName, str) == 0) {
//						myI = i;
//						break;
//					}
//				}
//
//				printf("\n1)Фамилия: %s\n", goP[myI].lastName);
//				printf("2)Название экзамена: %s\n", goP[myI].exam);
//				printf("3)Дата экзамена: %d.%d.%d\n", goP[myI].day, goP[myI].month, goP[myI].year);
//
//				int choiz;
//
//				printf("\nЧто из этого вы хотите удалить?(1-3): ");
//				scanf_s("%d", &choiz);
//
//				switch (choiz) {
//				case 1:
//					goP[myI].lastName = (char*)" ";
//					break;
//				case 2:
//					goP[myI].exam = (char*)" ";
//					break;
//				case 3:
//					goP[myI].day = (int*)0;
//					goP[myI].month = (int*)0;
//					goP[myI].year = (int*)0;
//					break;
//				}
//
//				printf("\n1)Фамилия: %s\n", goP[myI].lastName);
//				printf("2)Название экзамена: %s\n", goP[myI].exam);
//				printf("3)Дата экзамена: %d.%d.%d\n", goP[myI].day, goP[myI].month, goP[myI].year);
//				cin.get();
//				_getch();
//			}
//		} while (change > 3 || change < 0);
//	} while (true);
//}