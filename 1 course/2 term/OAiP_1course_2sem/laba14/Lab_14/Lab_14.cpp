#include <iostream>
#include <string>
#include <list>
#include <math.h>

using namespace std;

//Вариант 5 (price_list)
// Прайс-лист. Создать хеш-таблицу со следующими полями: стоимость товара, название товара. Ключ – стоимость товара
//Функция основана на суммировании кодировок символов по АSCII

//class Hash
//{
//	int BUCKET;
//
//	list<string>* table;
//public:
//	Hash(int b)
//	{
//		this->BUCKET = b;
//		table = new list<string>[BUCKET];
//	}; // Constructor
//
//	void insertItem(string val, int key)
//	{
//		int index = hashFunction(val, key);
//		table[index].push_back(val);
//	}
//
//	int hashFunction(string val, int x) {
//		int hash_i = 0;
//		int sum_of_ascii = 0;
//		for (size_t i = 0; i < val.length(); i++)
//		{
//			sum_of_ascii += int(val[i]);
//			hash_i = (x * sum_of_ascii) % BUCKET;
//		}
//		return hash_i;
//	}
//
//	void displayHash() {
//		for (int i = 0; i < BUCKET; i++) {
//			if (!table[i].empty())
//			{
//				cout << "Cписок\t" << i;
//				for (auto x : table[i])
//					cout << '\t' << "> " << x;
//				cout << endl;
//			}
//		}
//	}
//};
//int main()
//{
//	setlocale(0, "");
//
//	int choice = 0;
//	Hash table(21);
//	int count = 0;
//	string* arr;
//	arr = new string[100];
//
//	do
//	{
//		system("cls");
//		system("color 4");
// 
//		cout << "Выберите действие\n";
//		cout << "1 - Добавить товар\n";
//		cout << "2 - Вывести таблицу на экран\n";
//		cout << "0 - Выход из программы\n";
//
//		cin >> choice;
//
//		switch (choice)
//		{
//
//		case 1:
//		{
//			system("cls");
//			int N;
//			string C;
//			cout << "Введите название товара: "; cin >> C;
//			cout << "Введите цену товара: "; cin >> N;
//			arr[count] = C;
//			table.insertItem(arr[count], N);
//			count++;
//			system("pause");
//		}break;
//		case 2:
//		{
//			system("cls");
//			table.displayHash();
//			system("pause");
//		}break;
//		case 0:
//		{
//			return 0;
//		}break;
//		default:
//			break;
//		}
//	} while (true);
//}

//Вариант 9 (passport_list)
// Паспорт. Реализовать хеш-таблицу со следующими полями: номер паспорта, имя клиента. Ключ – номер паспорта
//Функция основана на золотом сечении

class Hash
{
	int bucket;
	list<string>* table;
public:
	Hash(int b)
	{
		this->bucket = b;
		table = new list<string>[bucket];
	}; // constructor

	void insertitem(string val, int key)
	{
		int index = hashfunction(val, key);
		table[index].push_back(val);
	}

	int hashfunction(string val, int x) {
			double a = 0.618034;
			int hash_i = (val.length() * (x * a));
			hash_i = hash_i % bucket;
			return hash_i;
	}

	void displayhash() {
		for (int i = 0; i < bucket; i++) {
			if (!table[i].empty())
			{
				cout << "cписок\t" << i;
				for (auto x : table[i])
					cout << '\t' << "> " << x;
				cout << endl;
			}
		}
	}
};
int main()
{
	setlocale(0, "");

	int choice = 0;
	Hash table(21);
	int count = 0;
	string* arr;
	arr = new string[100];

	do
	{
		system("cls");
		system("color 4");
 
		cout << "выберите действие\n";
		cout << "1 - добавить клиента\n";
		cout << "2 - вывести таблицу на экран\n";
		cout << "0 - выход из программы\n";

		cin >> choice;

		switch (choice)
		{
		case 1:
		{
			system("cls");
			int n;
			string c;
			cout << "введите имя клиента: "; cin >> c;
			cout << "введите номер паспорта: "; cin >> n;
			arr[count] = c;
			table.insertitem(arr[count], n);
			count++;
			system("pause");
		}break;
		case 2:
		{
			system("cls");
			table.displayhash();
			system("pause");
		}break;
		case 0:
		{
			return 0;
		}break;
		default:
			break;
		}
	} while (true);
}

//Вариант 6 (trip_list)
// Железная дорога. Создать хеш-таблицу со следующими полями: номер маршрута, маршрут. Ключ – номер маршрута
//Функция с косинусом

//class Hash
//{
//	int BUCKET;
//
//	list<string>* table;
//public:
//	Hash(int b)
//	{
//		this->BUCKET = b;
//		table = new list<string>[BUCKET];
//	}; // Constructor
//
//	void insertItem(string val, int key)
//	{
//		int index = hashFunction(val, key);
//		table[index].push_back(val);
//	}
//
//	int hashFunction(string val, int x) {
//		double a = cos(x);
//		int hash_i = (val.length() * x * a);
//		hash_i = hash_i % BUCKET;
//		return hash_i;
//	}
//
//	void displayHash() {
//		for (int i = 0; i < BUCKET; i++) {
//			if (!table[i].empty())
//			{
//				cout << "Cписок\t" << i;
//				for (auto x : table[i])
//					cout << '\t' << "> " << x;
//				cout << endl;
//			}
//		}
//	}
//};
//int main()
//{
//	setlocale(0, "");
//
//	int choice = 0;
//	Hash table(21);
//	int count = 0;
//	string* arr;
//	arr = new string[100];
//
//	do
//	{
//		system("cls");
//		system("color 4");
// 
//		cout << "Выберите действие\n";
//		cout << "1 - Добавить маршрут\n";
//		cout << "2 - Вывести таблицу на экран\n";
//		cout << "0 - Выход из программы\n";
//
//		cin >> choice;
//
//		switch (choice)
//		{
//		case 1:
//		{
//			system("cls");
//			int N;
//			string C;
//			cout << "Введите названии маршрута: "; cin >> C;
//			cout << "Введите номер маршрута: "; cin >> N;
//			arr[count] = C;
//			table.insertItem(arr[count], N);
//			count++;
//			system("pause");
//		}break;
//		case 2:
//		{
//			system("cls");
//			table.displayHash();
//			system("pause");
//		}break;
//		case 0:
//		{
//			return 0;
//		}break;
//		default:
//			break;
//		}
//	} while (true);
//}

//Вариант 3 (director_list)
// Школа. Создать хеш-таблицу со следующими полями: номер школы, фамилия директора. Ключ – номер школы
//Функция с числом ПИ

//class Hash
//{
//	int BUCKET;
//
//	list<string>* table;
//public:
//	Hash(int b)
//	{
//		this->BUCKET = b;
//		table = new list<string>[BUCKET];
//	}; // Constructor
//
//	void insertItem(string val, int key)
//	{
//		int index = hashFunction(val, key);
//		table[index].push_back(val);
//	}
//
//	int hashFunction(string val, int x) {
//		double pi = 3.14159265;
//		int hash_i = (val.length() * x / pi);
//		hash_i = hash_i % BUCKET;
//		return hash_i;
//	}
//
//	void displayHash() {
//		for (int i = 0; i < BUCKET; i++) {
//			if (!table[i].empty())
//			{
//				cout << "Cписок\t" << i;
//				for (auto x : table[i])
//					cout << '\t' << "> " << x;
//				cout << endl;
//			}
//		}
//	}
//};
//int main()
//{
//	setlocale(0, "");
//
//	int choice = 0;
//	Hash table(21);
//	int count = 0;
//	string* arr;
//	arr = new string[100];
//
//	do
//	{
//		system("cls");
//		system("color 4");
//
//		cout << "Выберите действие\n";
//		cout << "1 - Добавить школу\n";
//		cout << "2 - Вывести таблицу на экран\n";
//		cout << "0 - Выход из программы\n";
//
//		cin >> choice;
//
//		switch (choice)
//		{
//		case 1:
//		{
//			system("cls");
//			int N;
//			string C;
//			cout << "Введите фамилию директора: "; cin >> C;
//			cout << "Введите номер школы: "; cin >> N;
//			arr[count] = C;
//			table.insertItem(arr[count], N);
//			count++;
//			system("pause");
//		}break;
//		case 2:
//		{
//			system("cls");
//			table.displayHash();
//			system("pause");
//		}break;
//		case 0:
//		{
//			return 0;
//		}break;
//		default:
//			break;
//		}
//	} while (true);
//}