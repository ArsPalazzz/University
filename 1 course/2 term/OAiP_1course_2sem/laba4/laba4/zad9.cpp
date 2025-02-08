//#include <iostream>
//#include <conio.h>
//using namespace std;
//
////Студенты. Ф.И.О., дата поступления, специальность, группа, факультет, средний балл. Выбор по фамилии.
//
//struct ReceiptDate {
//	int* day;
//	int* month;
//	int* year;
//};
//
//
//struct Students {
//	char* lastName = new char[15];
//	char* firstName = new char[15];
//	char* patronymic = new char[15];
//	ReceiptDate goR;
//	char* spec = new char[10];
//	int* group;
//	char* faculty = new char[10];
//	double avrBall;
//};
//
//
//void show(const Students Obj[], const int all) {
//	system("cls");
//	printf(" №\tLastName\tFirstName\tPatronymic\tReceipt Date\tSpeciality\tGroup\tFaculty\t\tAverage ball\n");
//	printf("======================================================================================================================================\n");
//
//	for (int i = 0; i < all; i++) {
//		printf(" %d\t%-10s\t%-10s\t%-10s\t%d.%d.%d\t%-10s\t%d\t%-10s\t%4.2f\n", i + 1, Obj[i].lastName, Obj[i].firstName, Obj[i].patronymic, Obj[i].goR.day, Obj[i].goR.month, Obj[i].goR.year, Obj[i].spec, Obj[i].group, Obj[i].faculty, Obj[i].avrBall);
//	}
//}
//
//void write(const Students Obj[], const int all) {
//	printf("\nВведите номер человека, данные которого вы хотите записать в файл: ");
//	int man;
//	scanf_s("%d", &man);
//
//	errno_t err;
//	FILE* f;
//
//	switch (man) {
//	case 1:
//		err = fopen_s(&f, "Number1(9).txt", "w");
//		break;
//	case 2:
//		err = fopen_s(&f, "Number2(9).txt", "w");
//		break;
//	case 3:
//		err = fopen_s(&f, "Number3(9).txt", "w");
//		break;
//	default: printf("Такого человека нет");
//		return;
//	}
//
//	fprintf(f, "Фамилия: %s\n", Obj[man - 1].lastName);
//	fprintf(f, "Имя: %s\n", Obj[man - 1].firstName);
//	fprintf(f, "Отчество: %s\n", Obj[man - 1].patronymic);
//	fprintf(f, "Дата поступления: %d.%d.%d\n", Obj[man - 1].goR.day, Obj[man - 1].goR.month, Obj[man - 1].goR.year);
//	fprintf(f, "Специальность: %s\n", Obj[man - 1].spec);
//	fprintf(f, "Группа: %d\n", Obj[man - 1].group);
//	fprintf(f, "Факультет: %s\n", Obj[man - 1].faculty);
//	fprintf(f, "Средний балл: %4.2f\n", Obj[man - 1].avrBall);
//
//	fclose(f);
//
//	printf("Данные были успешно записаны в файл");
//}
//
//void read(const Students Obj[], const int all) {
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
//		err = fopen_s(&f, "Number1(9).txt", "r");
//		break;
//	case 2:
//		err = fopen_s(&f, "Number2(9).txt", "r");
//		break;
//	case 3:
//		err = fopen_s(&f, "Number3(9).txt", "r");
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
//	printf("Дата поступления: %d.%d.%d\n", Obj[man - 1].goR.day, Obj[man - 1].goR.month, Obj[man - 1].goR.year);
//	printf("Специальность: %s\n", Obj[man - 1].spec);
//	printf("Группа: %d\n", Obj[man - 1].group);
//	printf("Факультет: %s\n", Obj[man - 1].faculty);
//	printf("Средний балл: %4.2f\n", Obj[man - 1].avrBall);
//
//	fclose(f);
//}
//
//
//void find(const Students Obj[], const int all) {
//	system("cls");
//	printf("Введите фамилию человека, данные о котором вы хотите найти: ");
//	char str[15];
//	cin >> str;
//
//	for (int i = 0; i < all; i++) {
//		if (strcmp(Obj[i].lastName, str) == 0) {
//			printf("\nФамилия: %s\nИмя: %s\nОтчество: %s\nДата поступления: %d.%d.%d", Obj[i].lastName, Obj[i].firstName, Obj[i].patronymic, Obj[i].goR.day, Obj[i].goR.month, Obj[i].goR.year);
//			printf("\nСпециальность: %s\nГруппа: %d\nФакультет: %s\nСредний балл: %4.2f\n", Obj[i].spec, Obj[i].group, Obj[i].faculty, Obj[i].avrBall);
//		}
//	}
//}
//
//void main() {
//	setlocale(LC_ALL, "ru");
//	const int allStudents = 2;
//	Students goS[allStudents];
//
//	for (int i = 0; i < allStudents; i++) {
//		printf("LastName is ");
//		if (i > 0) {
//			cin.get();
//			cin.get();
//		}
//		cin.getline(goS[i].lastName, 15);
//		printf("FirstName is ");
//		cin.getline(goS[i].firstName, 15);
//		printf("Patronymic is ");
//		cin.getline(goS[i].patronymic, 15);
//		printf("Day is ");
//		scanf_s("%d", &goS[i].goR.day);
//		printf("Month is ");
//		scanf_s("%d", &goS[i].goR.month);
//		printf("Year is ");
//		scanf_s("%d", &goS[i].goR.year);
//		printf("Speciality is ");
//		cin.get();
//		cin.getline(goS[i].spec, 10);
//		printf("Group is ");
//		scanf_s("%d", &goS[i].group);
//		cin.get();
//		printf("Faculty is ");
//		cin.getline(goS[i].faculty, 10);
//		printf("Average ball is ");
//		scanf_s("%lf", &goS[i].avrBall);
//		cin.get();
//	}
//
//	show(goS, allStudents);
//
//		do {
//		printf("\nВведите '0' чтобы выйти\nВведите '1' чтобы сделать запись в файл\nВведите '2' чтобы прочитать данные из файла\n");
//		printf("Введите '3' чтобы найти сведения о человеке по его фамилии\nВведите '4' чтобы удалить поле структуры\n\n");
//		cin.get();
//		int change;
//		scanf_s("%d", &change);
//
//		do {
//			switch (change) {
//			case 0:
//				exit(0);
//				break;
//			case 1:
//				write(goS, allStudents);
//				break;
//			case 2:
//				read(goS, allStudents);
//				break;
//			case 3:
//				find(goS, allStudents);
//				break;
//			case 4:
//				system("cls");
//				printf("Введите фамилию человека, данные о котором хотите удалить: ");
//				char str[15];
//				cin >> str;
//				int myI;
//
//				for (int i = 0; i < allStudents; i++) {
//					if (strcmp(goS[i].lastName, str) == 0) {
//						myI = i;
//						break;
//					}
//				}
//
//				printf("\n1)Фамилия: %s\n", goS[myI].lastName);
//				printf("2)Имя: %s\n", goS[myI].firstName);
//				printf("3)Отчество: %s\n", goS[myI].patronymic);
//				printf("4)Дата поступления: %d.%d.%d\n", goS[myI].goR.day, goS[myI].goR.month, goS[myI].goR.year);
//				printf("5)Специальность: %s\n", goS[myI].spec);
//				printf("6)Группа: %d\n", goS[myI].group);
//				printf("7)Факультет: %s\n", goS[myI].faculty);
//				printf("8)Средний балл: %4.2f\n", goS[myI].avrBall);
//
//				int choiz;
//
//				printf("\nЧто из этого вы хотите удалить?(1-8): ");
//				scanf_s("%d", &choiz);
//
//				switch (choiz) {
//				case 1:
//					goS[myI].lastName = (char*)" ";
//					break;
//				case 2:
//					goS[myI].firstName = (char*)" ";
//					break;
//				case 3:
//					goS[myI].patronymic = (char*)" ";
//					break;
//				case 4:
//					goS[myI].goR.day = (int*)0;
//					goS[myI].goR.month = (int*)0;
//					goS[myI].goR.year = (int*)0;
//					break;
//				case 5:
//					goS[myI].spec = (char*)" ";
//					break;
//				case 6:
//					goS[myI].group = 0;
//					break;
//				case 7:
//					goS[myI].faculty = (char*)" ";
//					break;
//				case 8:
//					goS[myI].avrBall = 0;
//				}
//
//				printf("\n1)Фамилия: %s\n", goS[myI].lastName);
//				printf("2)Имя: %s\n", goS[myI].firstName);
//				printf("3)Отчество: %s\n", goS[myI].patronymic);
//				printf("4)Дата поступления: %d.%d.%d\n", goS[myI].goR.day, goS[myI].goR.month, goS[myI].goR.year);
//				printf("5)Специальность: %s\n", goS[myI].spec);
//				printf("6)Группа: %d\n", goS[myI].group);
//				printf("7)Факультет: %s\n", goS[myI].faculty);
//				printf("8)Средний балл: %2.1f\n", goS[myI].avrBall);
//			}
//		} while (change > 8 || change < 0);
//	} while (true);
//}