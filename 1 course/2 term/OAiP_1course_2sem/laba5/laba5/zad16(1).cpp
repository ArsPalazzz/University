#include <iostream>
#include <Windows.h>
using namespace std;

//Преподаватели. Фамилия преподавателя, название экзамена, дата экзамена. Выбор по дате экзамена. 
//Дату экзамена реализовать с помощью битового поля

struct Byte {
	unsigned day : 5;
	unsigned month : 4;
	unsigned year : 11;
};

struct Dude {
	struct Byte goB;
	char* lastName = new char[15];
	char* nameOfExam = new char[15];
};

void show(struct Dude Obj[], const int all) {
	system("cls");
	printf(" №\tLastName\tName of exam\tDate of exam\n");
	printf("==========================================================\n");

	for (int i = 0; i < all; i++) {
		printf(" %d\t%-10s\t%-10s\t%d.%d.%d\n", i + 1, Obj[i].lastName, Obj[i].nameOfExam, Obj[i].goB.day, Obj[i].goB.month, Obj[i].goB.year);
	}
}


void main() {
	setlocale(LC_ALL, "ru");
	HANDLE h = GetStdHandle(STD_OUTPUT_HANDLE);
	SetConsoleTextAttribute(h, 7);

	const int allMen = 2;
	Dude goD[allMen];
	int myDay, myMonth, myYear;

	for (int i = 0; i < allMen; i++) {

		printf("Lastname is ");
		gets_s(goD[i].lastName, 15);
		printf("Name of exam is ");
		gets_s(goD[i].nameOfExam, 15);
		printf("Day is ");
		scanf_s("%d", &myDay);
		goD[i].goB.day = myDay;
		printf("Month is ");
		scanf_s("%d", &myMonth);
		goD[i].goB.month = myMonth;
		printf("Year is ");
		scanf_s("%d", &myYear);
		goD[i].goB.year = myYear;
		cin.get();
	}

	show(goD, allMen);


	do {
		printf("\n1)Нажмите '0' чтобы выйти\n2)Нажмите '1' найти данные о человеке и удалить их\n");
		int choise;
		scanf_s("\n%d", &choise);

		if (choise) {
			system("cls");
			printf("Введите день экзамена, данные о котором хотите удалить: ");
			int d, m, y;
			int myI;
			scanf_s("%d", &d);
			printf("Введите месяц экзамена, данные о котором хотите удалить: ");
			scanf_s("%d", &m);
			printf("Введите год экзамена, данные о котором хотите удалить: ");
			scanf_s("%d", &y);

			for (int i = 0; i < allMen; i++) {
				if ((goD[i].goB.day == d) && (goD[i].goB.month == m) && (goD[i].goB.year == y)) {
					SetConsoleTextAttribute(h, 2);
					printf("\n1)Фамилия: %s\n2)Название экзамена: %s\n", goD[i].lastName, goD[i].nameOfExam);
					SetConsoleTextAttribute(h, 4);
					printf("3)Дата экзамена(нельзя удалить): %d.%d.%d\n", goD[i].goB.day, goD[i].goB.month, goD[i].goB.year);
					myI = i;
					SetConsoleTextAttribute(h, 7);
					break;
				}
			}

			printf("Что из этого вы хотите изменить?(1 или 2): ");

			int choise2;
			scanf_s("%d", &choise2);

			if (choise2 == 1) {
				goD[myI].lastName = (char*)"";
			}
			else if (choise2 == 2) {
				goD[myI].nameOfExam = (char*)"";
			}

			SetConsoleTextAttribute(h, 2);
			printf("\n1)Фамилия: %s\n2)Название экзамена: %s\n", goD[myI].lastName, goD[myI].nameOfExam);
			SetConsoleTextAttribute(h, 4);
			printf("3)Дата экзамена(нельзя удалить): %d.%d.%d\n", goD[myI].goB.day, goD[myI].goB.month, goD[myI].goB.year);
			SetConsoleTextAttribute(h, 7);

		}
		else {
			SetConsoleTextAttribute(h, 0);
			exit(0);
		}

	} while (true);
}