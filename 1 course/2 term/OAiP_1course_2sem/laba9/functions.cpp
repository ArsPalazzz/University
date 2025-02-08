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
	cout << "1. ���� �����" << endl;
	cout << "2. �������� �����" << endl;
	cout << "3. ����� �� �����" << endl;
	cout << "4. �����" << endl;
	cout << "5. ������ � ����" << endl;
	cout << "6. ������ �� �����" << endl;
	cout << "7.(������� 10) ���������� �������� � ������ ������" << endl;
	cout << "8.(������� 2) �������� K ��������� �� ������ ������" << endl;
	cout << "9.(������� 12) ������� �������� ������� �������������� �������� � �������� ��������� x" << endl;
	cout << "10.(������� 11) ������� ������ i-�� �������� ������ ��������� � �������� ��������� x" << endl;
	cout << "0. �����" << endl;
	cout << endl;
	do
	{
		cout << "��� �����: ";
		cin.sync();
		gets_s(s);
		cout << endl;
		c = atoi(s);
	} while (c < 0 || c > 10);
	return c;
}
//-----------------------------------------------------------
void insert(Address* e, Address** phead, Address** plast) //���������� � ����� ������
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
Address* setElement()      // �������� �������� � ���� ��� �������� � ���������� 
{
	Address* temp = new  Address();
	if (!temp)
	{
		cerr << "������ ��������� ������ ������";
		return NULL;
	}
	cout << "������� ���: ";
	cin.getline(temp->name, NAME_SIZE - 1, '\n');
	cin.ignore(cin.rdbuf()->in_avail());
	cin.clear();
	cout << "������� �������: ";
	cin >> temp->myX;
	cin.get();
	cout << "������� �����: ";
	cin.getline(temp->city, CITY_SIZE - 1, '\n');
	cin.ignore(cin.rdbuf()->in_avail());
	cin.clear();
	temp->next = NULL;
	temp->prev = NULL;
	return temp;
}
//-----------------------------------------------------------
void outputList(Address** phead, Address** plast)      //����� ������ �� �����
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
void find(char name[NAME_SIZE], Address** phead)    // ����� ����� � ������
{
	Address* t = *phead;
	while (t)
	{
		if (!strcmp(name, t->name)) break;
		t = t->next;
	}
	if (!t)
		cerr << "��� �� �������" << endl;
	else
		cout << t->name << ' ' << t->city << endl;
}
//-----------------------------------------------------------
void delet(char name[NAME_SIZE], Address** phead, Address** plast)  // �������� ����� 
{
	struct Address* t = *phead;
	while (t)
	{
		if (!strcmp(name, t->name))  break;
		t = t->next;
	}
	if (!t)
		cerr << "��� �� �������" << endl;
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
		cout << "������� ������" << endl;
	}
}

void writeToFile(Address** phead)       //������ � ����
{
	struct Address* t = *phead;
	FILE* fp;
	errno_t err = fopen_s(&fp, "mlist", "wb");
	if (err)
	{
		cerr << "���� �� �����������" << endl;
		exit(1);
	}
	cout << "���������� � ����" << endl;
	while (t)
	{
		fwrite(t, sizeof(struct Address), 1, fp);
		t = t->next;
	}
	fclose(fp);
}
//-----------------------------------------------------------
void readFromFile(Address** phead, Address** plast)          //���������� �� �����
{
	struct Address* t;
	FILE* fp;
	errno_t err = fopen_s(&fp, "mlist", "rb");
	if (err)
	{
		cerr << "���� �� �����������" << endl;
		exit(1);
	}
	while (*phead)
	{
		*plast = (*phead)->next;
		delete* phead;
		*phead = *plast;
	}
	*phead = *plast = NULL;
	cout << "�������� �� �����" << endl;
	while (!feof(fp))
	{
		t = new Address();
		if (!t)
		{
			cerr << "������ ��������� ������" << endl;
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
	printf("������� ����� ��������� �����: ");
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
	cout << "�������� �������" << endl;
}

void deleteX(Address** phead, Address** plast) {
	Address* t = *phead;
	int x;
	printf("������� x: ");
	scanf_s("%d", &x);
	cin.get();

	while (t)
	{
		if (t->myX == x)  break;
		t = t->next;
	}
	if (!t)
		cerr << "��� �� �������" << endl;
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
		cout << "������� ������" << endl;
	}
}

void changeX(Address** phead, Address** plast) {
	int myI, x;
	printf("������� �����(i) ��������: ");
	scanf_s("%d", &myI);
	cin.get();
	printf("������� x: ");
	scanf_s("%d", &x);
	cin.get();

	Address* t = *phead;

	for (int i = 0; i < myI - 1; i++) {
		t = t->next;
	}

	if (!t)
		cerr << "������� �� ������" << endl;
	else {
		t->myX = x;
		printf("������� ��� �������\n");
	}
}