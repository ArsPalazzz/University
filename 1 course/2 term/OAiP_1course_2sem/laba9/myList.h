#pragma once

#include <iostream>
#include <fstream>
using namespace std;
#define NAME_SIZE 30
#define CITY_SIZE 20


struct Address
{
	char name[NAME_SIZE];
	char city[CITY_SIZE];
	int myX;
	Address* next;
	Address* prev;
};

int menu(void);
void insert(Address* e, Address** phead, Address** plast);
Address* setElement();
void outputList(Address** phead, Address** plast);
void find(char name[NAME_SIZE], Address** phead);
void delet(char name[NAME_SIZE], Address** phead, Address** plast);
void writeToFile(Address** phead);
void readFromFile(Address** phead, Address** plast);
void insertFront(Address* e, Address** phead, Address** plast);
void deleteKFront(Address** phead, Address** plast);
void deleteX(Address** phead, Address** plast);
void changeX(Address** phead, Address** plast);