//#include <iostream>
//#include <fstream>
//using namespace std;
////������ �������� ���������. ���������� ������, ���� ������� � �������, �����, ��� ����������
// //(����, �����������, �����������, �����������, �����������). ����� ����� �� �������.
// //������ 2 �������
//
//struct Hotel
//{
// char* Firstname = new char[50];
// char* Surname = new char[50];
// char* Age = new char[50];
// char* IncomingDate = new char[50];
// char* LeavingDate = new char[50];
// char* Roomnumber = new char[50];
// char* TypeOfRoom = new char[50];
//};
//int main()
//{
// setlocale(LC_ALL, "");
// int choice = -1;
// char data[50];
// char* client_name = new char[50];
// const int count = 2;
// Hotel chel1[count];
// while (choice != 0)
// {
// cout << "��� �� ������ �������?\n\n";
// cout << "1. ���� ��������� ��������� � ����������\n";
// cout << "2. ����� ��������� ��������� � ���������� ����\n";
// cout << "3. �������� �������� ����������������� ����������\n";
// cout << "4. ����� ����������\n";
// cout << "5. ������ ���������� � ����\n";
// cout << "6. ������ ������ �� �����\n";
// cout << "7. ����� �� ���������\n";
// cin >> choice;
// switch (choice)
// {
// case 1:
// {
// for (int i = 0; i < count; i++)
// {
// cout << "-------� ������ " << i + 1 << " �-------\n";
// cout << "������� ���� ���: ";
// cin >> chel1[i].Firstname;
// cout << "���� �������: ";
// cin >> chel1[i].Surname;
// cout << "��� �������: ";
// cin >> chel1[i].Age;
// cout << "���� �������: ";
// cin >> chel1[i].IncomingDate;
// cout << "���� �������: ";
// cin >> chel1[i].LeavingDate;
// cout << "����� �������: ";
// cin >> chel1[i].Roomnumber;
// cout << "��� ������� (����, �����������, �����������, �����������, �����������): ";
// cin >> chel1[i].TypeOfRoom;
// cout << "\n\n";
// }
// cout << "\n";
// }
// break;
// case 2:
// {
// cout << "--------� ���������� � �������� �--------\n";
// for (int i = 0; i < count; i++)
// {
// cout << "-----=== ������ " << i + 1 << " ===-----\n";
// cout << "���� ���: " << chel1[i].Firstname;
// cout << "\n���� �������: " << chel1[i].Surname;
// cout << "\n��� �������: " << chel1[i].Age;
// cout << "\n���� �������: " << chel1[i].IncomingDate;
// cout << "\n���� �������: " << chel1[i].LeavingDate;
// cout << "\n����� �������: " << chel1[i].Roomnumber;
// cout << "\n��� �������: " << chel1[i].TypeOfRoom << "\n";
// cout << "--------------------------------------------\n\n";
// }
// }
// break;
// case 3:
// {
// cout << "����� ���������� � ������� ������ �������?\n";
// for (int i = 0; i < count; i++)
// {
// cout << "������ �" << i + 1 << "\n";
// cout << "1. ���� ���: ";
// cout << "\n2. ���� �������: ";
// cout << "\n3. ��� �������: ";
// cout << "\n4. ���� �������: ";
// cout << "\n5. ���� �������: ";
// cout << "\n6. ����� �������: ";
// cout << "\n7. ��� �������: \n";
// cin >> choice;
// switch (choice)
// {
// case 1:
// chel1[i].Firstname = (char*)"�� �������";
// cout << "������ �������\n";
// break;
// case 2:
// chel1[i].Surname = (char*)"�� �������";
// cout << "������ �������\n";
// break;
// case 3:
// chel1[i].Age = (char*)"�� �������";
// cout << "������ �������\n";
// break;
// case 4:
// chel1[i].IncomingDate = (char*)"�� �������";
// cout << "������ �������\n";
// break;
// case 5:
// chel1[i].LeavingDate = (char*)"�� �������";
// cout << "������ �������\n";
// break;
// case 6:
// chel1[i].Roomnumber = (char*)"�� �������";
// cout << "������ �������\n";
// break;
// case 7:
// chel1[i].TypeOfRoom = (char*)"�� �������";
// cout << "������ �������\n";
// break;
// default:
// break;
// }
// }
// }
// break;
// case 4:
// {
// cout << "������� ��� �������: \n";
// cin >> client_name;
// for (int i = 0; i < count; i++)
// {
// if (strcmp(chel1[i].Firstname, client_name) == 0)
// {
// cout << "-----=== ������ " << i + 1 << " ===-----\n";
// cout << "���� ���: " << chel1[i].Firstname;
// cout << "\n���� �������: " << chel1[i].Surname;
// cout << "\n��� �������: " << chel1[i].Age;
// cout << "\n���� �������: " << chel1[i].IncomingDate;
//
//cout << "\n���� �������: " << chel1[i].LeavingDate;
// cout << "\n����� �������: " << chel1[i].Roomnumber;
// cout << "\n��� �������: " << chel1[i].TypeOfRoom << "\n";
// cout << "--------------------------------------------\n\n";
//
// }
// }
// }
// break;
// case 5:
// {
// ofstream fout("data-2.txt");
// if (!fout.is_open())
// cout << "���� �� ����� ���� ������((\n";
// else cout << "���� data.txt ������.\n";
// for (int i = 0; i < count; i++)
// {
// fout << "-----=== ������ " << i + 1 << " ===-----\n";
// fout << "���� ���: " << chel1[i].Firstname;
// fout << "\n���� �������: " << chel1[i].Surname;
// fout << "\n��� �������: " << chel1[i].Age;
// fout << "\n���� �������: " << chel1[i].IncomingDate;
// fout << "\n���� �������: " << chel1[i].LeavingDate;
// fout << "\n����� �������: " << chel1[i].Roomnumber;
// fout << "\n��� �������: " << chel1[i].TypeOfRoom << "\n";
// fout << "--------------------------------------------\n\n";
// }
// cout << "������ � ���� ��������!\n";
// fout.close();
// }
// break;
// case 6:
// {
// ifstream fin("data.txt");
// if (!fin.is_open())
// cout << "���� �� ����� ���� ������((\n";
// else cout << "���� data.txt ������.\n";
// fin.getline(data, 50);
// cout << "\n���������� � �����:\n";
// for (int i = 0; i < count; i++)
// {
// cout << "-----=== ������ " << i + 1 << " ===-----\n";
// cout << "���� ���: " << chel1[i].Firstname;
// cout << "\n���� �������: " << chel1[i].Surname;
// cout << "\n��� �������: " << chel1[i].Age;
// cout << "\n���� �������: " << chel1[i].IncomingDate;
// cout << "\n���� �������: " << chel1[i].LeavingDate;
// cout << "\n����� �������: " << chel1[i].Roomnumber;
// cout << "\n��� �������: " << chel1[i].TypeOfRoom << "\n";
// cout << "--------------------------------------------\n\n";
// }
// fin.close();
// }
// break;
// case 7:
// return printf("������� �������!\n\n");
// }
//
// choice = 2;
// }
//
//
//}