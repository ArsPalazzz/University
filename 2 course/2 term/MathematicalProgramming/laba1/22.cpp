#include "Auxil.h"                            // ��������������� ������� 
#include <iostream>
#include <ctime>
#include <locale>
#include <stdlib.h>

using namespace std;
//#define CYCLE 100

//������ ������� ���������� ����������

//����� ������� ���������� ����������



long double fact(int N)
{
	if (N < 0) // ���� ������������ ���� ������������� �����
		return 0; // ���������� ����
	if (N == 0) // ���� ������������ ���� ����,
		return 1; // ���������� ��������� �� ���� - �� �����������, �� ��� 1 =)
	else // �� ���� ��������� �������
		return N * fact(N - 1); // ������ ��������.
}

int main()
{
	/*int N = 21;*/

	double  av1 = 0, av2 = 0;
	clock_t  t1 = 0, t2 = 0;

	setlocale(LC_ALL, "rus");
	auxil::start();                          // ����� ��������� 
	t1 = clock();                            // �������� ������� 

	
	int N;
	setlocale(0, ""); // �������� ���������
	cout << "������� ����� ��� ���������� ����������: ";
	cin >> N;
	cout << "��������� ��� ����� " << N << " = " << fact(N) << endl << endl; // fact(N) - ������� ��� ���������� ����������.

	t2 = clock();                            // �������� ������� 


	std::cout << std::endl << "����������������� (�.�):   " << (t2 - t1);
	std::cout << std::endl << "                  (���):   " << ((double)(t2 - t1)) / ((double)CLOCKS_PER_SEC);
	std::cout << std::endl;
	system("pause");
	return 0;
}