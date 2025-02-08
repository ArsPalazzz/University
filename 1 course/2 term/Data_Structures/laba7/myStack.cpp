//#include <iostream>
//#include "myStack.h"
//#include <fstream>
//using namespace std;
//void push(int x, Stack* myStk)   //Добавление элемента х в стек	
//{
//	Stack* e = new Stack;    //выделение памяти для нового элемента
//	e->data = x;             //запись элемента x в поле v 
//	e->next = myStk->head;   //перенос вершины на следующий элемент 
//	myStk->head = e;         //сдвиг вершины на позицию вперед
//}
//int pop(Stack* myStk)   //Извлечение (удаление) элемента из стека
//{
//	if (myStk->head == NULL)
//	{
//		cout << "Стек пуст!" << endl;
//		return -1;               //если стек пуст - возврат -1 
//	}
//	else
//	{
//		Stack* e = myStk->head;   //е - переменная для хранения адреса элемента
//		int a = myStk->head->data;   //запись числа из поля data в переменную a 
//		myStk->head = myStk->head->next; //перенос вершины
//		delete e;                        //удаление временной переменной
//		return a;                        //возврат значения удаляемого элемента
//	}
//}
//void show(Stack* myStk)    //Вывод стека
//{
//	Stack* e = myStk->head;    //объявляется указатель на вершину стека
//	int a;
//	if (e == NULL)
//		cout << "Стек пуст!" << endl;
//	while (e != NULL)
//	{
//		a = e->data;          //запись значения в переменную a 
//		cout << a << " ";
//		e = e->next;
//	}
//	cout << endl;
//}
//
//void diap(Stack* myStk, int first, int second) {
//	Stack* e = myStk->head;    //объявляется указатель на вершину стека
//	int a = 0;
//	while (e != NULL)
//	{
//		if ((e->data > first) && (e->data < second)) {
//			a++;
//		}
//		e = e->next;
//	}
//	if (a) {
//		printf("Есть\n");
//	}
//	else {
//		printf("Нет\n");
//	}
//}
//
//void clear(Stack* myStk) {
//	while (myStk->head != nullptr) {
//		Stack* e = myStk->head;   //е - переменная для хранения адреса элемента
//		int a = myStk->head->data;   //запись числа из поля data в переменную a 
//		myStk->head = myStk->head->next; //перенос вершины
//		delete e;
//	}
//	printf("Стек очищен\n");
//}
//
//void inFile(Stack* myStk) {
//	ofstream fout("myStack.txt");
//	Stack* e = myStk->head;    //объявляется указатель на вершину стека
//	int a;
//	if (e == NULL)
//		cout << "Стек пуст!" << endl;
//	while (e != NULL)
//	{
//		fout << e->data << " ";
//		e = e->next;
//	}
//	fout.close();
//	printf("Данные записаны");
//	cout << endl;
//}
//
//void outFile(Stack* myStk) {
//	ifstream fin("myStack.txt");
//	Stack* e = myStk->head;    //объявляется указатель на вершину стека
//	char file[20];
//	fin.getline(file, 20);
//	cout << file << endl;
//
//	fin.close();
//	printf("Данные считаны");
//	cout << endl;
//}