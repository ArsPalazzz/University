#include <iostream>
#include <fstream>
#include "myList.h"
using namespace std;
#define NAME_SIZE 30
#define CITY_SIZE 20

//-----------------------------------------------------------
int menu(void)
{
	char s[80];  int c;
	cout << endl;
	cout << "1. Ввод имени" << endl;
	cout << "2. Удаление имени" << endl;
	cout << "3. Вывод на экран" << endl;
	cout << "4. Поиск" << endl;
	cout << "5. Запись в файл" << endl;
	cout << "6. Чтение из файла" << endl;
	cout << "7.(Вариант 10) Добавление элемента в начало списка" << endl;
	cout << "8.(Вариант 2) Удаление K элементов из начала списка" << endl;
	cout << "9.(Вариант 12) Функция удаления первого встречающегося элемента с заданным значением x" << endl;
	cout << "10.(Вариант 11) Функция замены i-го элемента списка элементом с заданным значением x" << endl;
	cout << "0. Выход" << endl;
	cout << endl;
	do
	{
		cout << "Ваш выбор: ";
		cin.sync();
		gets_s(s);
		cout << endl;
		c = atoi(s);
	} while (c < 0 || c > 10);
	return c;
}
//-----------------------------------------------------------
void insert(Address* e, Address** phead, Address** plast) //Добавление в конец списка
{
	Address* p = *plast;
	if (*plast == NULL)
	{
		e->next = NULL;
		e->prev = NULL;
		*plast = e;
		*phead = e;
		return;
	}
	else
	{
		p->next = e;
		e->next = NULL;
		e->prev = p;
		*plast = e;
	}
}
//-----------------------------------------------------------
Address* setElement()      // Создание элемента и ввод его значений с клавиатуры 
{
	Address* temp = new  Address();
	if (!temp)
	{
		cerr << "Ошибка выделения памяти памяти";
		return NULL;
	}
	cout << "Введите имя: ";
	cin.getline(temp->name, NAME_SIZE - 1, '\n');
	cin.ignore(cin.rdbuf()->in_avail());
	cin.clear();
	cout << "Введите возраст: ";
	cin >> temp->myX;
	cin.get();
	cout << "Введите город: ";
	cin.getline(temp->city, CITY_SIZE - 1, '\n');
	cin.ignore(cin.rdbuf()->in_avail());
	cin.clear();
	temp->next = NULL;
	temp->prev = NULL;
	return temp;
}
//-----------------------------------------------------------
void outputList(Address** phead, Address** plast)      //Вывод списка на экран
{
	Address* t = *phead;
	while (t)
	{
		printf("%-8s\t%-8s\t%-2d\n", t->name, t->city, t->myX);
		t = t->next;
	}
	cout << "" << endl;
}
//-----------------------------------------------------------
void find(char name[NAME_SIZE], Address** phead)    // Поиск имени в списке
{
	Address* t = *phead;
	while (t)
	{
		if (!strcmp(name, t->name)) break;
		t = t->next;
	}
	if (!t)
		cerr << "Имя не найдено" << endl;
	else
		cout << t->name << ' ' << t->city << endl;
}
//-----------------------------------------------------------
void delet(char name[NAME_SIZE], Address** phead, Address** plast)  // Удаление имени 
{
	struct Address* t = *phead;
	while (t)
	{
		if (!strcmp(name, t->name))  break;
		t = t->next;
	}
	if (!t)
		cerr << "Имя не найдено" << endl;
	else
	{
		if (*phead == t)
		{
			*phead = t->next;
			if (*phead)
				(*phead)->prev = NULL;
			else
				*plast = NULL;
		}
		else
		{
			t->prev->next = t->next;
			if (t != *plast)
				t->next->prev = t->prev;
			else
				*plast = t->prev;
		}
		delete t;
		cout << "Элемент удален" << endl;
	}
}

void writeToFile(Address** phead)       //Запись в файл
{
	struct Address* t = *phead;
	FILE* fp;
	errno_t err = fopen_s(&fp, "mlist", "wb");
	if (err)
	{
		cerr << "Файл не открывается" << endl;
		exit(1);
	}
	cout << "Сохранение в файл" << endl;
	while (t)
	{
		fwrite(t, sizeof(struct Address), 1, fp);
		t = t->next;
	}
	fclose(fp);
}
//-----------------------------------------------------------
void readFromFile(Address** phead, Address** plast)          //Считывание из файла
{
	struct Address* t;
	FILE* fp;
	errno_t err = fopen_s(&fp, "mlist", "rb");
	if (err)
	{
		cerr << "Файл не открывается" << endl;
		exit(1);
	}
	while (*phead)
	{
		*plast = (*phead)->next;
		delete* phead;
		*phead = *plast;
	}
	*phead = *plast = NULL;
	cout << "Загрузка из файла" << endl;
	while (!feof(fp))
	{
		t = new Address();
		if (!t)
		{
			cerr << "Ошибка выделения памяти" << endl;
			return;
		}
		if (1 != fread(t, sizeof(struct Address), 1, fp)) break;
		insert(t, phead, plast);
	}
	fclose(fp);
}

void insertFront(Address* e, Address** phead, Address** plast) {
	Address* p = *phead;
	if (*phead == NULL) {
		e->next = NULL;
		e->prev = NULL;
		*phead = e;
		*plast = e;
		return;
	}
	else {
		p->prev = e;
		e->prev = NULL;
		e->next = p;
		*phead = e;
	}
}

void deleteKFront(Address** phead, Address** plast) {
	int kolich;
	printf("Введите число удаляемых чисел: ");
	scanf_s("%d", &kolich);
	cin.get();

	for (int i = 0; i < kolich; i++) {
		Address* t = *phead;
		*phead = t->next;
		if (*phead)
			(*phead)->prev = NULL;
		else
			*plast = NULL;
		delete t;
	}
	cout << "Элементы удалены" << endl;
}

void deleteX(Address** phead, Address** plast) {
	Address* t = *phead;
	int x;
	printf("Введите x: ");
	scanf_s("%d", &x);
	cin.get();

	while (t)
	{
		if (t->myX == x)  break;
		t = t->next;
	}
	if (!t)
		cerr << "Имя не найдено" << endl;
	else
	{
		if (*phead == t)
		{
			*phead = t->next;
			if (*phead)
				(*phead)->prev = NULL;
			else
				*plast = NULL;
		}
		else
		{
			t->prev->next = t->next;
			if (t != *plast)
				t->next->prev = t->prev;
			else
				*plast = t->prev;
		}
		delete t;
		cout << "Элемент удален" << endl;
	}
}

void changeX(Address** phead, Address** plast) {
	int myI, x;
	printf("Введите номер(i) элемента: ");
	scanf_s("%d", &myI);
	cin.get();
	printf("Введите x: ");
	scanf_s("%d", &x);
	cin.get();

	Address* t = *phead;

	for (int i = 0; i < myI - 1; i++) {
		t = t->next;
	}

	if (!t)
		cerr << "Элемент не найден" << endl;
	else {
		t->myX = x;
		printf("Элемент был заменен\n");
	}
}