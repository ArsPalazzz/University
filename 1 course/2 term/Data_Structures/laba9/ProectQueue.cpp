#include "myQueue.h"
#include <iostream>
using namespace std;

//(Вариант 8) - Создать очередь для целых чисел и функции для ввода, вывода, удаления и определения размера очереди. 
//Разработать функцию, которая удаляет из очереди первый отрицательный элемент, если такой есть.

int main()
{
	setlocale(LC_ALL, "ru");
	Queue* begin = NULL, * end, * t, * m, * k;
	t = new Queue;
	m = new Queue;
	int choice;
	int p, size;
	int curSize = 1;
	printf("Введите размер очереди: ");
	scanf_s("%d", &size);
	printf("Введите число: ");
	scanf_s("%d", &p);
	t->info = p;        //первый элемент
	t->next = NULL;
	begin = end = t;

	for (int i = 1; i < size; i++) //создание очереди
	{
		cout << "Введите число: ";
		cin >> p;
		create(&begin, &end, p, &curSize, &size);
	}

	printf("\n");
	view(begin);
	printf("\n");

	for (;;)
	{
		cout << "\nВыберите команду:" << endl;
		cout << "1(Вариант 8) - Добавление элемента в очередь" << endl;
		cout << "2(Вариант 8) - Вывод элементов очереди" << endl;
		cout << "3(Вариант 8) - Извлечение элемента из очереди" << endl;
		cout << "4(Вариант 8) - Определить размер очереди" << endl;
		cout << "5(Вариант 8) - Удаление первого отрицательного элемента" << endl;
		cout << "6(Вариант 3) - Удаление первых 3 элементов" << endl;
		cout << "7(Вариант 3) - Поиск максимального элемента очереди" << endl;
		cout << "8(Вариант 2) - Количество элементов между минимальным и максимальным элементом" << endl;
		cout << "9(Вариант 6) - Вывести элементы очереди до первого нулевого (включительно)" << endl;
		cout << "0 - Выход\n" << endl;
		cin >> choice;
		switch (choice)
		{
		case 1:
			cout << "Введите элемент: ";
			cin >> p;
			create(&begin, &end, p, &curSize, &size);
			cout << endl;
			break;
		case 2:
			cout << "\nЭлементы в очереди: \n";
			if (begin == NULL)   //вывод на экран
				cout << "Их нет" << endl;
			else
				view(begin);
			break;
		case 3:
			fromFIFO(&begin, &end);
			break;
		case 4:
			int count;
			kolichInQ(begin);
			break;
		case 5:
			delFirOtr(&begin, &end);
			break;
		case 6:
			del3Fir(&begin, &end);
			break;
		case 7:
			view(begin);
			m = findMax(begin);    //определение минимального
			cout << "Максимальный элемент: " << m->info << endl;
			break;
		case 8:
			view(begin);
			k = kolichBMNM(begin);
			break;
		case 9:
			doFZero(begin);
			break;
		case 0:
			return 0;
			break;
		default: printf("Такого значения нет");
		}
	}
	return 0;
}
