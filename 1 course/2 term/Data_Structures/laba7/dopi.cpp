//#include <iostream>
//#include "myStack.h"
//#include <fstream>
//using namespace std;
//int main()
//{
//	setlocale(LC_ALL, "Rus");
//	int choice;
//	Stack* myStk = new Stack; //��������� ������ ��� �����
//	myStk->head = NULL;       //������������� ������� ��������	
//	for (;;)
//	{
//		cout << "�������� �������:" << endl;
//		cout << "1 - ���������� �������� � ����" << endl;
//		cout << "2 - ���������� �������� �� �����" << endl;
//		cout << "3 - ����� �����" << endl;
//		cout << "4(������� 10) - ���� �� � ����� �������, ��� � ������ ���������" << endl;
//		cout << "5(������� 11) - �������� ���������, ������� 3" << endl;
//		cout << "8 - ������� �����" << endl;
//		cout << "9 - ������ � ����" << endl;
//		cout << "10 - ���������� �� �����" << endl;
//		cout << "0 - �����\n" << endl;
//		cin >> choice;
//		switch (choice)
//		{
//		case 1: cout << "������� �������: " << endl;
//			cin >> choice;
//			push(choice, myStk);
//			cout << endl;
//			break;
//		case 2: choice = pop(myStk);
//			if (choice != -1)
//				cout << "����������� �������: " << choice << endl;
//			break;
//		case 3: cout << "���� ����: " << endl;
//			show(myStk);
//			break;
//		case 4:
//			int a, b;
//			printf("������� ������ �����: ");
//			scanf_s("%d", &a);
//			printf("������� ������ �����: ");
//			scanf_s("%d", &b);
//			diap(myStk, a, b);
//			break;
//		case 5:
//			del3(myStk);
//			break;
//		case 6:
//			delFP(myStk);
//		case 8:
//			clear(myStk);
//			break;
//		case 9:
//			inFile(myStk);
//			break;
//		case 10:
//			outFile(myStk);
//			break;
//		case 0:
//			return 0;
//			break;
//		}
//	}
//	return 0;
//}