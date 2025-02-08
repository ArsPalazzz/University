#include "myQueue.h"
#include <iostream>
using namespace std;

//(������� 8) - ������� ������� ��� ����� ����� � ������� ��� �����, ������, �������� � ����������� ������� �������. 
//����������� �������, ������� ������� �� ������� ������ ������������� �������, ���� ����� ����.

int main()
{
	setlocale(LC_ALL, "ru");
	Queue* begin = NULL, * end, * t, * m, * k;
	t = new Queue;
	m = new Queue;
	int choice;
	int p, size;
	int curSize = 1;
	printf("������� ������ �������: ");
	scanf_s("%d", &size);
	printf("������� �����: ");
	scanf_s("%d", &p);
	t->info = p;        //������ �������
	t->next = NULL;
	begin = end = t;

	for (int i = 1; i < size; i++) //�������� �������
	{
		cout << "������� �����: ";
		cin >> p;
		create(&begin, &end, p, &curSize, &size);
	}

	printf("\n");
	view(begin);
	printf("\n");

	for (;;)
	{
		cout << "\n�������� �������:" << endl;
		cout << "1(������� 8) - ���������� �������� � �������" << endl;
		cout << "2(������� 8) - ����� ��������� �������" << endl;
		cout << "3(������� 8) - ���������� �������� �� �������" << endl;
		cout << "4(������� 8) - ���������� ������ �������" << endl;
		cout << "5(������� 8) - �������� ������� �������������� ��������" << endl;
		cout << "6(������� 3) - �������� ������ 3 ���������" << endl;
		cout << "7(������� 3) - ����� ������������� �������� �������" << endl;
		cout << "8(������� 2) - ���������� ��������� ����� ����������� � ������������ ���������" << endl;
		cout << "9(������� 6) - ������� �������� ������� �� ������� �������� (������������)" << endl;
		cout << "0 - �����\n" << endl;
		cin >> choice;
		switch (choice)
		{
		case 1:
			cout << "������� �������: ";
			cin >> p;
			create(&begin, &end, p, &curSize, &size);
			cout << endl;
			break;
		case 2:
			cout << "\n�������� � �������: \n";
			if (begin == NULL)   //����� �� �����
				cout << "�� ���" << endl;
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
			m = findMax(begin);    //����������� ������������
			cout << "������������ �������: " << m->info << endl;
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
		default: printf("������ �������� ���");
		}
	}
	return 0;
}
