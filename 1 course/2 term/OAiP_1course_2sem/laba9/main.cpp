#include <iostream>
#include <fstream>
#include "myList.h"
using namespace std;
#define NAME_SIZE 30
#define CITY_SIZE 20
//10, 2, 12, 11
//-----------------------------------------------------------
int main(void)
{
	Address* head = NULL;
	Address* last = NULL;
	setlocale(LC_CTYPE, "Rus");
	while (true)
	{
		switch (menu())
		{
		case 1:  insert(setElement(), &head, &last);
			break;
		case 2: {	  char dname[NAME_SIZE];
			cout << "Введите имя: ";
			cin.getline(dname, NAME_SIZE - 1, '\n');
			cin.ignore(cin.rdbuf()->in_avail());
			cin.sync();
			delet(dname, &head, &last);
		}
			  break;
		case 3:  outputList(&head, &last);
			break;
		case 4: {	  char fname[NAME_SIZE];
			cout << "Введите имя: ";
			cin.getline(fname, NAME_SIZE - 1, '\n');
			cin.ignore(cin.rdbuf()->in_avail());
			cin.sync();
			find(fname, &head);
		}
			  break;
		case 5:
			writeToFile(&head);
			break;
		case 6:
			readFromFile(&head, &last);
			break;
		case 7:
			insertFront(setElement(), &head, &last);
			break;
		case 8:
			deleteKFront(&head, &last);
			break;
		case 9:
			deleteX(&head, &last);
			break;
		case 10:
			changeX(&head, &last);
			break;
		case 0:  exit(0);
		default: exit(1);
		}
	}
	return 0;
}