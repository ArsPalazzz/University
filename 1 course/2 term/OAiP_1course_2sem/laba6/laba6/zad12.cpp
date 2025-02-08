#include <iostream>
#include <fstream>
using namespace std;

 
//Создать список, содержащий элементы вещественного типа. Найти среднее значение положительных элементов.
 
//void insert(list*& p, char value); //Добавление символа в начало списка
//void printList(list* p);       //Вывод списка 
//void toFile(list*& p);         //Запись в файл
//void fromFile(list*& p);       //Считывание из файла
//void menu(void);                //Вывод меню 

struct list
{
    double numb;
    list* next;
};

void insert(list*& p, double value, int& count1) //Добавление символа в начало списка
{
    list* newP = new list;
    if (newP != NULL)     //есть ли место?  
    {
        newP->numb = value;
        newP->next = p;
        p = newP;
        count1++;
    }
    else
        cout << "Операция добавления не выполнена" << endl;
}

void printList(list* p)  //Вывод списка 
{
    if (p == NULL)
        cout << "Список пуст" << endl;
    else
    {
        cout << "Список:" << endl;
        while (p != NULL)
        {
            cout << "-->" << p->numb;
            p = p->next;
        }
        cout << "-->NULL" << endl;
    }
}

void toFile(list*& p)
{
    list* temp = p;
    list buf;
    ofstream frm("zad12.dat");
    if (frm.fail())
    {
        cout << "\n Ошибка открытия файла";
        exit(1);
    }
    while (temp)
    {
        buf = *temp;
        frm.write((char*)&buf, sizeof(list));
        temp = temp->next;
    }
    frm.close();
    cout << "Список записан в файл zad12.dat\n";
}

void fromFile(list*& p, int& count1)          //Считывание из файла
{
    list buf, * first = nullptr;
    ifstream frm("zad12.dat");
    if (frm.fail())
    {
        cout << "\n Ошибка открытия файла";
        exit(1);
    }
    frm.read((char*)&buf, sizeof(list));
    while (!frm.eof())
    {
        insert(first, buf.numb, count1);
        cout << "-->" << buf.numb;
        frm.read((char*)&buf, sizeof(list));
    }
    cout << "-->NULL" << endl;
    frm.close();
    p = first;
    cout << "\nСписок считан из файла zad12.dat\n";
}

void menu(void)     //Вывод меню 
{
    cout << "Сделайте выбор:" << endl;
    cout << " 1 - Ввод числа" << endl;
    cout << " 2 - Запись списка в файл" << endl;
    cout << " 3 - Чтение списка из файла" << endl;
    cout << " 4 - Среднее арифметическое положительных чисел" << endl;
    cout << " 5 - Удаление элемента" << endl;
    cout << " 6 - Поиск элемента" << endl;
    cout << " 7 - Выход" << endl;
}

void avr(list* p)  // Среднее арифм
{
    float sm = 0;
    float result;
    int kolich = 0;
    if (p == NULL)
        cout << "Список пуст" << endl;
    else
    {
        while (p != NULL)
        {
            if (p->numb > 0) {
                sm += (p->numb);
                kolich++;
            }
            p = p->next;
        }
        result = sm / kolich;
        cout << "Среднее арифметическое = " << result << endl;
    }
}

float del(list*& p, double value)  // Удаление числа 
{
    list* previous, * current, * temp;
    if (value == p->numb)
    {
        temp = p;
        p = p->next;    // отсоединить узел 
        delete temp;      //освободить отсоединенный узел 
        return value;
    }
    else
    {
        previous = p;
        current = p->next;
        while (current != NULL && current->numb != value)
        {
            previous = current;
            current = current->next; // перейти к следующему 
        }
        if (current != NULL)
        {
            temp = current;
            previous->next = current->next;
            free(temp);
            return value;
        }
    }
    return 0;
}

void search(int& count1, list*& plist)
{
    
    cout << "Введите элемент : ";
    double num;
    cin >> num;
    list* host = plist;
    bool j = 0;//триггер
    for (int i = count1; host != NULL; i--)
    {
        if (host->numb == num)    // если наше число - то выводим его номер
        {
            cout << "Данный элемент находится под номером №" << i - 1 << endl; j = 1;
        }
        host = host->next;
    }
    if (j == 0)
    {
        cout << "Данный элемент не был найден в списке." << endl;
    }
    return;
}

int main()
{
    int count1 = 0;
    setlocale(LC_CTYPE, "Russian");
    list* first = nullptr;
    int choice; 
    double value;
    menu();    // вывести меню 
    cout << " ? ";
    cin >> choice;
    while (choice != 7)
    {
        switch (choice)
        {
        case 1:  	
            cout << "Введите число типа double: ";
            cin >> value;
            insert(first, value, count1);
            printList(first);
            break;
        case 2:    
            toFile(first);
            break;
        case 3:    
            fromFile(first, count1);
            break;
        case 4:
            avr(first);
            break;
        case 5:
            del(first, value);
            break;
        case 6:
            search(count1, first);
            break;
        default:   
            cout << "Неправильный выбор" << endl;
            menu(); 
            break;
        }
        cout << "?  ";
        cin >> choice;
    }
    return 0;
}

