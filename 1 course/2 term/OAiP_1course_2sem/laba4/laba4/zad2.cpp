//#include <iostream>
//#include <fstream>
//using namespace std;
////Список клиентов гостиницы. Паспортные данные, даты приезда и отъезда, номер, тип размещения
// //(люкс, одноместный, двухместный, трехместный, апартаменты). Поиск гостя по фамилии.
// //основа 2 вариант
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
// cout << "Что вы хотите сделать?\n\n";
// cout << "1. Ввод элементов структуры с клавиатуры\n";
// cout << "2. Вывод элементов структуры в консольное окно\n";
// cout << "3. Удаление заданной структурированной переменной\n";
// cout << "4. Поиск информации\n";
// cout << "5. Запись информации в файл\n";
// cout << "6. Чтение данных из файла\n";
// cout << "7. Выйти из программы\n";
// cin >> choice;
// switch (choice)
// {
// case 1:
// {
// for (int i = 0; i < count; i++)
// {
// cout << "-------— Клиент " << i + 1 << " —-------\n";
// cout << "Введите ваше имя: ";
// cin >> chel1[i].Firstname;
// cout << "Ваша фамилия: ";
// cin >> chel1[i].Surname;
// cout << "Ваш возраст: ";
// cin >> chel1[i].Age;
// cout << "Дата приезда: ";
// cin >> chel1[i].IncomingDate;
// cout << "Дата отъезда: ";
// cin >> chel1[i].LeavingDate;
// cout << "Номер комнаты: ";
// cin >> chel1[i].Roomnumber;
// cout << "Тип комнаты (люкс, одноместный, двухместный, трехместный, апартаменты): ";
// cin >> chel1[i].TypeOfRoom;
// cout << "\n\n";
// }
// cout << "\n";
// }
// break;
// case 2:
// {
// cout << "--------— Информация о клиентах —--------\n";
// for (int i = 0; i < count; i++)
// {
// cout << "-----=== Клиент " << i + 1 << " ===-----\n";
// cout << "Ваше Имя: " << chel1[i].Firstname;
// cout << "\nВаша Фамилия: " << chel1[i].Surname;
// cout << "\nВаш Возраст: " << chel1[i].Age;
// cout << "\nДата приезда: " << chel1[i].IncomingDate;
// cout << "\nДата отъезда: " << chel1[i].LeavingDate;
// cout << "\nНомер комнаты: " << chel1[i].Roomnumber;
// cout << "\nТип комнаты: " << chel1[i].TypeOfRoom << "\n";
// cout << "--------------------------------------------\n\n";
// }
// }
// break;
// case 3:
// {
// cout << "Какую информацию о клиенте хотите удалить?\n";
// for (int i = 0; i < count; i++)
// {
// cout << "Клиент №" << i + 1 << "\n";
// cout << "1. Ваше Имя: ";
// cout << "\n2. Ваша Фамилия: ";
// cout << "\n3. Ваш Возраст: ";
// cout << "\n4. Дата приезда: ";
// cout << "\n5. Дата отъезда: ";
// cout << "\n6. Номер комнаты: ";
// cout << "\n7. Тип комнаты: \n";
// cin >> choice;
// switch (choice)
// {
// case 1:
// chel1[i].Firstname = (char*)"не указано";
// cout << "Данные удалены\n";
// break;
// case 2:
// chel1[i].Surname = (char*)"не указано";
// cout << "Данные удалены\n";
// break;
// case 3:
// chel1[i].Age = (char*)"не указано";
// cout << "Данные удалены\n";
// break;
// case 4:
// chel1[i].IncomingDate = (char*)"не указано";
// cout << "Данные удалены\n";
// break;
// case 5:
// chel1[i].LeavingDate = (char*)"не указано";
// cout << "Данные удалены\n";
// break;
// case 6:
// chel1[i].Roomnumber = (char*)"не указано";
// cout << "Данные удалены\n";
// break;
// case 7:
// chel1[i].TypeOfRoom = (char*)"не указано";
// cout << "Данные удалены\n";
// break;
// default:
// break;
// }
// }
// }
// break;
// case 4:
// {
// cout << "Введите имя клиента: \n";
// cin >> client_name;
// for (int i = 0; i < count; i++)
// {
// if (strcmp(chel1[i].Firstname, client_name) == 0)
// {
// cout << "-----=== Клиент " << i + 1 << " ===-----\n";
// cout << "Ваше Имя: " << chel1[i].Firstname;
// cout << "\nВаша Фамилия: " << chel1[i].Surname;
// cout << "\nВаш Возраст: " << chel1[i].Age;
// cout << "\nДата приезда: " << chel1[i].IncomingDate;
//
//cout << "\nДата отъезда: " << chel1[i].LeavingDate;
// cout << "\nНомер комнаты: " << chel1[i].Roomnumber;
// cout << "\nТип комнаты: " << chel1[i].TypeOfRoom << "\n";
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
// cout << "Файл не может быть создан((\n";
// else cout << "Файл data.txt создан.\n";
// for (int i = 0; i < count; i++)
// {
// fout << "-----=== Клиент " << i + 1 << " ===-----\n";
// fout << "Ваше Имя: " << chel1[i].Firstname;
// fout << "\nВаша Фамилия: " << chel1[i].Surname;
// fout << "\nВаш Возраст: " << chel1[i].Age;
// fout << "\nДата приезда: " << chel1[i].IncomingDate;
// fout << "\nДата отъезда: " << chel1[i].LeavingDate;
// fout << "\nНомер комнаты: " << chel1[i].Roomnumber;
// fout << "\nТип комнаты: " << chel1[i].TypeOfRoom << "\n";
// fout << "--------------------------------------------\n\n";
// }
// cout << "Данные в файл записаны!\n";
// fout.close();
// }
// break;
// case 6:
// {
// ifstream fin("data.txt");
// if (!fin.is_open())
// cout << "Файл не может быть создан((\n";
// else cout << "Файл data.txt открыт.\n";
// fin.getline(data, 50);
// cout << "\nИнформация в файле:\n";
// for (int i = 0; i < count; i++)
// {
// cout << "-----=== Клиент " << i + 1 << " ===-----\n";
// cout << "Ваше Имя: " << chel1[i].Firstname;
// cout << "\nВаша Фамилия: " << chel1[i].Surname;
// cout << "\nВаш Возраст: " << chel1[i].Age;
// cout << "\nДата приезда: " << chel1[i].IncomingDate;
// cout << "\nДата отъезда: " << chel1[i].LeavingDate;
// cout << "\nНомер комнаты: " << chel1[i].Roomnumber;
// cout << "\nТип комнаты: " << chel1[i].TypeOfRoom << "\n";
// cout << "--------------------------------------------\n\n";
// }
// fin.close();
// }
// break;
// case 7:
// return printf("Удачных покупок!\n\n");
// }
//
// choice = 2;
// }
//
//
//}