#include <iostream>
#include "myStack.h"
#include <fstream>
using namespace std;

void push(int x, Stack* myStk)   //Добавление элемента х в стек	
{
	Stack* e = new Stack;    //выделение памяти для нового элемента
	e->data = x;             //запись элемента x в поле v 
	e->next = myStk->head;   //перенос вершины на следующий элемент 
	myStk->head = e;         //сдвиг вершины на позицию вперед
}
int pop(Stack* myStk)   //Извлечение (удаление) элемента из стека
{
	if (myStk->head == NULL)
	{
		cout << "Стек пуст!" << endl;
		return -1;               //если стек пуст - возврат -1 
	}
	else
	{
		Stack* e = myStk->head;   //е - переменная для хранения адреса элемента
		int a = myStk->head->data;   //запись числа из поля data в переменную a 
		myStk->head = myStk->head->next; //перенос вершины
		delete e;                        //удаление временной переменной
		return a;                        //возврат значения удаляемого элемента
	}
}
void show(Stack* myStk)    //Вывод стека
{
	Stack* e = myStk->head;    //объявляется указатель на вершину стека
	int a;
	if (e == NULL)
		cout << "Стек пуст!" << endl;
	while (e != NULL)
	{
		a = e->data;          //запись значения в переменную a 
		cout << a << " ";
		e = e->next;
	}
	cout << endl;
}

void diap(Stack* myStk, int first, int second) {
	Stack* e = myStk->head;    //объявляется указатель на вершину стека
	bool a = false;
	while (e != NULL)
	{
		if ((e->data > first) && (e->data < second)) {
			a = true;
		}
		e = e->next;
	}
	if (a) {
		printf("Есть\n");
	}
	else {
		printf("Нет\n");
	}
}

void del3(Stack* myStk) {
	Stack* e = myStk->head;
	if (myStk->head == nullptr) {
		printf("Стек пуст");
		return;
	}
	else {
		Stack* previous, * current, * temp;
		while (e != NULL) {
			if ((e->data) % 3 == 0) {
				temp = myStk->head;
				e = e->next;
				myStk->head = myStk->head->next;
				delete temp;
			}
			else {
				previous = myStk->head;
				current = myStk->head->next;
				while (current != NULL && (!((current->data) % 3 == 0)))
				{
					previous = current;
					current = current->next; // перейти к следующему 
				}
				if (current != NULL)
				{
					temp = current;
					previous->next = current->next;
					delete temp;
				}
				e = e->next;
			}
		}
		printf("Готово\n");
	}
}

void delFP(Stack* myStk) {
	Stack* e = myStk->head;
	if (myStk->head == nullptr) {
		printf("Стек пуст");
		return;
	}
	else {
		Stack* temp, * previous, * current;
		if (myStk->head->data > 0) {
			temp = myStk->head;
			myStk->head = myStk->head->next;
			delete temp;
			printf("Первое положительное число удалено!\n");
			return;
		}
		else {
			previous = myStk->head;
			current = myStk->head->next;

			while (current != NULL && (!((current->data) > 0)))
			{
				previous = current;
				current = current->next; // перейти к следующему 
			}
			if (current != NULL)
			{
				temp = current;
				previous->next = current->next;
				delete temp;
				printf("Первое положительное число удалено!\n");
			}
			else {
				printf("Положительных чисел нет\n");
			}
		}
	}
}


void delFO(Stack* myStk) {
	Stack* e = myStk->head;
	if (myStk->head == nullptr) {
		printf("Стек пуст");
		return;
	}
	else {
		Stack* temp, * previous, * current;
		if (myStk->head->data < 0) {
			temp = myStk->head;
			myStk->head = myStk->head->next;
			delete temp;
			printf("Первое отрицательное число удалено!\n");
			return;
		}
		else {
			previous = myStk->head;
			current = myStk->head->next;

			while (current != NULL && (!((current->data) > 0)))
			{
				previous = current;
				current = current->next; // перейти к следующему 
			}
			if (current != NULL)
			{
				temp = current;
				previous->next = current->next;
				delete temp;
				printf("Первое отрицательное число удалено!\n");
			}
			else {
				printf("Отрицательных чисел нет\n");
			}
		}
	}
}

void clear(Stack* myStk) {
	while (myStk->head != nullptr) {
		Stack* e = myStk->head;   //е - переменная для хранения адреса элемента
		int a = myStk->head->data;   //запись числа из поля data в переменную a 
		myStk->head = myStk->head->next; //перенос вершины
		delete e;
	}
	printf("Стек очищен\n");
}

void inFile(Stack* myStk) {
	ofstream fout("myStack.txt");
	Stack* e = myStk->head;    //объявляется указатель на вершину стека
	int a;
	if (e == NULL)
		cout << "Стек пуст!" << endl;
	while (e != NULL)
	{
		fout << e->data << " ";
		e = e->next;
	}
	fout.close();
	printf("Данные записаны");
	cout << endl;
}

void outFile(Stack* myStk) {
	ifstream fin("myStack.txt");
	Stack* e = myStk->head;    //объявляется указатель на вершину стека
	char file[20];
	fin.getline(file, 20);
	cout << file << endl;

	fin.close();
	printf("Данные считаны");
	cout << endl;
}