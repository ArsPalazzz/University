#include <iostream>
#include "myStack.h"
#include <fstream>
using namespace std;

int main()	{
	setlocale(LC_ALL, "Rus");
	int choice;
	Stack* myStk = new Stack; //выделение памяти для стека
	myStk->head = NULL;       //инициализация первого элемента	
	for (;;)
	{
		cout << "Выберите команду:" << endl;
		cout << "1 - Добавление элемента в стек" << endl;
		cout << "2 - Извлечение элемента из стека" << endl;
		cout << "3 - Вывод стека" << endl;
		cout << "4(Вариант 10) - Есть ли в стеке элемент, леж в данном диапазоне" << endl;
		cout << "5(Вариант 11) - Удаление элементов, кратных 3" << endl;
		cout << "6(Вариант 3) - Удаление первого положительного элемента" << endl;
		cout << "7(Вариант 2) - Удаление первого отрицательного элемента" << endl;
		cout << "8 - Очистка стека" << endl;
		cout << "9 - Запись в файл" << endl;
		cout << "10 - Считывание из файла" << endl;
		cout << "0 - Выход\n" << endl;
		cin >> choice;
		switch (choice)
		{
		case 1: cout << "Введите элемент: " << endl;
			cin >> choice;
			push(choice, myStk);
			cout << endl;
			break;
		case 2: choice = pop(myStk);
			if (choice != -1)
				cout << "Извлеченный элемент: " << choice << endl;
			break;
		case 3: cout << "Весь стек: " << endl;
			show(myStk);
			break;
		case 4:
			int a, b;
			printf("Введите первое число: ");
			scanf_s("%d", &a);
			printf("Введите второе число: ");
			scanf_s("%d", &b);
			diap(myStk, a, b);
			break;
		case 5:
			del3(myStk);
			break;
		case 6:
			delFP(myStk);
			break;
		case 7:
			delFO(myStk);
			break;
		case 8:
			clear(myStk);
			break;
		case 9:
			inFile(myStk);
			break;
		case 10:
			outFile(myStk);
			break;
		case 0: 
			return 0;
			break;
		}
	}
	return 0;
}
