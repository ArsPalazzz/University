#include <iostream>
#include <fstream>
using namespace std;

 
//������� ������, ���������� �������� ������������� ����. ����� ������� �������� ������������� ���������.
 
//void insert(list*& p, char value); //���������� ������� � ������ ������
//void printList(list* p);       //����� ������ 
//void toFile(list*& p);         //������ � ����
//void fromFile(list*& p);       //���������� �� �����
//void menu(void);                //����� ���� 

struct list
{
    double numb;
    list* next;
};

void insert(list*& p, double value, int& count1) //���������� ������� � ������ ������
{
    list* newP = new list;
    if (newP != NULL)     //���� �� �����?  
    {
        newP->numb = value;
        newP->next = p;
        p = newP;
        count1++;
    }
    else
        cout << "�������� ���������� �� ���������" << endl;
}

void printList(list* p)  //����� ������ 
{
    if (p == NULL)
        cout << "������ ����" << endl;
    else
    {
        cout << "������:" << endl;
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
        cout << "\n ������ �������� �����";
        exit(1);
    }
    while (temp)
    {
        buf = *temp;
        frm.write((char*)&buf, sizeof(list));
        temp = temp->next;
    }
    frm.close();
    cout << "������ ������� � ���� zad12.dat\n";
}

void fromFile(list*& p, int& count1)          //���������� �� �����
{
    list buf, * first = nullptr;
    ifstream frm("zad12.dat");
    if (frm.fail())
    {
        cout << "\n ������ �������� �����";
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
    cout << "\n������ ������ �� ����� zad12.dat\n";
}

void menu(void)     //����� ���� 
{
    cout << "�������� �����:" << endl;
    cout << " 1 - ���� �����" << endl;
    cout << " 2 - ������ ������ � ����" << endl;
    cout << " 3 - ������ ������ �� �����" << endl;
    cout << " 4 - ������� �������������� ������������� �����" << endl;
    cout << " 5 - �������� ��������" << endl;
    cout << " 6 - ����� ��������" << endl;
    cout << " 7 - �����" << endl;
}

void avr(list* p)  // ������� �����
{
    float sm = 0;
    float result;
    int kolich = 0;
    if (p == NULL)
        cout << "������ ����" << endl;
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
        cout << "������� �������������� = " << result << endl;
    }
}

float del(list*& p, double value)  // �������� ����� 
{
    list* previous, * current, * temp;
    if (value == p->numb)
    {
        temp = p;
        p = p->next;    // ����������� ���� 
        delete temp;      //���������� ������������� ���� 
        return value;
    }
    else
    {
        previous = p;
        current = p->next;
        while (current != NULL && current->numb != value)
        {
            previous = current;
            current = current->next; // ������� � ���������� 
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
    
    cout << "������� ������� : ";
    double num;
    cin >> num;
    list* host = plist;
    bool j = 0;//�������
    for (int i = count1; host != NULL; i--)
    {
        if (host->numb == num)    // ���� ���� ����� - �� ������� ��� �����
        {
            cout << "������ ������� ��������� ��� ������� �" << i - 1 << endl; j = 1;
        }
        host = host->next;
    }
    if (j == 0)
    {
        cout << "������ ������� �� ��� ������ � ������." << endl;
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
    menu();    // ������� ���� 
    cout << " ? ";
    cin >> choice;
    while (choice != 7)
    {
        switch (choice)
        {
        case 1:  	
            cout << "������� ����� ���� double: ";
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
            cout << "������������ �����" << endl;
            menu(); 
            break;
        }
        cout << "?  ";
        cin >> choice;
    }
    return 0;
}

