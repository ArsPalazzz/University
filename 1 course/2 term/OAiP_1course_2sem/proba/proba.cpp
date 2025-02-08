#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <iomanip>
#include <Windows.h>

const int MAX_SIZE = 20;

using namespace std;

struct DateOfPurchase
{
    unsigned int
        day,
        month,
        year;
};
struct Supplier
{
    int
        codeOfCloth,
        quantity,
        price;
    char
        type[50],
        kind[50],
        landOfManufacturing[50];
    DateOfPurchase
        date;
};


int input(int a, int b) { //ПРОВЕРКА НА ВВОД ОТ a ДО b
    int input;

    while (true) {
        cout << "--> ";
        cin >> input;
        if (cin.fail()) // ИСКЛЮЧЕНИЕ ПРИ ВВОДЕ СТРОКИ
        {
            cout << "\n <!> Ошибка, повторите ввод:" << endl;
            cin.clear();
            while (cin.get() != '\n');

        }
        else if (input<a || input>b) cout << "\n <!> Ошибка, повторите ввод:" << endl; // ПРОВЕРКА ПРЕДЕЛОВ
        else break;
    }

    return input;
}


int Menu()
{
    int choice;
    printf("---------------------------------------------\n");
    printf("|                   МЕНЮ                    |\n");
    printf("---------------------------------------------\n");
    printf("|       1) Добавить запись                  |\n");
    printf("|       2) Просмотр всех записей            |\n");
    printf("|       3) Удалить запись                   |\n");
    printf("|       4) Ткани, закупленные после даты    |\n");
    printf("|       5) Ткани белорусского производства  |\n");
    printf("|       6) Синтетические ткани              |\n");
    printf("|       0) Выход из программы               |\n");
    printf("---------------------------------------------\n");
    choice = input(0, 6);
    return choice;
}

int empty(int num) {
    if (num == 0) {
        cout << "Нет записей!\n";
        return 1;
    }
    else return 0;
}

void add(Supplier* temp, int& num) {
    cout << "ДОБАВЛЕНИЕ ЗАПИСИ:";
    if (num < MAX_SIZE) {
        cout << "Ткань #" << num + 1 << endl;

        cout << "Код ткани (число):" << endl;
        cin >> (temp + num)->codeOfCloth;

        cout << "Тип ткани:" << endl;
        cout << "1 - хлопок" << endl;
        cout << "2 - шерсть" << endl;
        cout << "3 - лён" << endl;
        cout << "4 - шёлк" << endl;
        cout << "5 - синтетика" << endl;
        int choice;

        choice = input(1, 5);
        switch (choice)
        {
        case 1:
            strcpy((temp + num)->type, "Cotton");
            break;
        case 2:
            strcpy((temp + num)->type, "Wool");
            break;
        case 3:
            strcpy((temp + num)->type, "Flax");
            break;
        case 4:
            strcpy((temp + num)->type, "Silk");
            break;
        case 5:
            strcpy((temp + num)->type, "Synthetics");
            break;
        }

        cout << "Вид ткани:" << endl;
        cout << "1 - атлас" << endl;
        cout << "2 - бязь" << endl;
        cout << "3 - гобелен" << endl;
        cout << "4 - брезент" << endl;
        cout << "5 - жаккард" << endl;

        choice = input(1, 5);
        switch (choice)
        {
        case 1:
            strcpy((temp + num)->kind, "Atlas");
            break;
        case 2:
            strcpy((temp + num)->kind, "Calico");
            break;
        case 3:
            strcpy((temp + num)->kind, "Tapestry");
            break;
        case 4:
            strcpy((temp + num)->kind, "Tarpaulin");
            break;
        case 5:
            strcpy((temp + num)->kind, "Jacquard");
            break;
        }

        cout << "Страна производства ( English, please :) ):" << endl;
        cin >> (temp + num)->landOfManufacturing;

        cout << "Дата закупки:" << endl;

        cout << "День:" << endl;
        (temp + num)->date.day = input(1, 31);
        cout << "Месяц:" << endl;
        (temp + num)->date.month = input(1, 12);
        cout << "Год:" << endl;
        (temp + num)->date.year = input(2000, 2030);

        cout << "Количество метров:" << endl;
        (temp + num)->quantity = input(0, 10000000);

        cout << "Цена за метр (BYN):" << endl;
        (temp + num)->price = input(0, 10000000);

        num++;

        return;
    }
    else cout << "\nМАССИВ ПЕРЕПОЛНЕН!\n" << endl;
}


void print(Supplier* temp, int num) {
    if (empty(num))return;
    printf("\nALL ENTRIES:");
    printf(" \n ---------------------------------------------------------------------------------------------------------\n");
    printf(" | №| Fabric code |    Type     |    Kind    |    Country    |     Date    |   m   | BYN/m  | Total cost |\n");
    printf(" |--+----------------------------------------------------------------------------------------------------|\n");

    for (int i = 0; i < num; i++)
    {
        printf(" |%2d|%11d  |%12s | %10s |%14s |  %2d/%2d/%4d |%6d | %6d |%10d  |\n", i + 1, (temp + i)->codeOfCloth, (temp + i)->type, (temp + i)->kind, (temp + i)->landOfManufacturing, (temp + i)->date.day, (temp + i)->date.month, (temp + i)->date.year, (temp + i)->quantity, (temp + i)->price, (temp + i)->quantity * (temp + i)->price);
        printf(" |--+----------------------------------------------------------------------------------------------------|\n");

    }
    printf(" ---------------------------------------------------------------------------------------------------------\n");

}

void printBelarusian(Supplier* temp, int num) {
    if (empty(num))return;

    int flag = 0;
    for (int j = 0; j < num; j++) { // проверка на наличие
        if (strcmp("Belarus", (temp + j)->landOfManufacturing) == 0) flag++;
    }
    if (flag == 0) {
        cout << "Тканей белорусского производства нет!\n";
        return;
    }
    printf("\nBELARUSIAN FABRICS:");
    printf(" \n ---------------------------------------------------------------------------------------------------------\n");
    printf(" | №| Fabric code |    Type     |    Kind    |    Country    |     Date    |   m   | BYN/m  | Total cost |\n");
    printf(" |--+----------------------------------------------------------------------------------------------------|\n");

    for (int i = 0; i < num; i++)
    {
        if (strcmp("Belarus", (temp + i)->landOfManufacturing) == 0) {
            printf(" |%2d|%11d  |%12s | %10s |%14s |  %2d/%2d/%4d |%6d | %6d |%10d  |\n", i + 1, (temp + i)->codeOfCloth, (temp + i)->type, (temp + i)->kind, (temp + i)->landOfManufacturing, (temp + i)->date.day, (temp + i)->date.month, (temp + i)->date.year, (temp + i)->quantity, (temp + i)->price, (temp + i)->quantity * (temp + i)->price);
            printf(" |--+----------------------------------------------------------------------------------------------------|\n");

        }
    }
    printf(" ---------------------------------------------------------------------------------------------------------\n");

}

void printSynthetics(Supplier* temp, int num) {
    if (empty(num))return;

    int flag = 0;
    for (int j = 0; j < num; j++) { // проверка на наличие
        if (strcmp("Synthetics", (temp + j)->type) == 0) flag++;
    }
    if (flag == 0) {
        cout << "Синтетических тканей нет!\n";
        return;
    }
    printf("\nSYNTHETIC FABRICS:");
    printf(" \n ---------------------------------------------------------------------------------------------------------\n");
    printf(" | №| Fabric code |    Type     |    Kind    |    Country    |     Date    |   m   | BYN/m  | Total cost |\n");
    printf(" |--+----------------------------------------------------------------------------------------------------|\n");

    for (int i = 0; i < num; i++)
    {
        if (strcmp("Synthetics", (temp + i)->type) == 0) {
            printf(" |%2d|%11d  |%12s | %10s |%14s |  %2d/%2d/%4d |%6d | %6d |%10d  |\n", i + 1, (temp + i)->codeOfCloth, (temp + i)->type, (temp + i)->kind, (temp + i)->landOfManufacturing, (temp + i)->date.day, (temp + i)->date.month, (temp + i)->date.year, (temp + i)->quantity, (temp + i)->price, (temp + i)->quantity * (temp + i)->price);
            printf(" |--+----------------------------------------------------------------------------------------------------|\n");

        }
    }
    printf(" ---------------------------------------------------------------------------------------------------------\n");

}


void afterTheDate(Supplier* temp, int num) {
    if (empty(num))return;
    int day, month, year;

    cout << "Введите дату:\n";
    cout << "День:" << endl;
    day = input(1, 31);
    cout << "Месяц:" << endl;
    month = input(1, 12);
    cout << "Год:" << endl;
    year = input(2000, 2030);
    int TIME = day + month * 31 + year * 365;

    int flag = 0;
    for (int j = 0; j < num; j++) { // проверка на наличие
        if ((temp + j)->date.day + (temp + j)->date.month * 31 + (temp + j)->date.year * 365 > TIME) flag++;
    }
    if (flag == 0) {
        cout << "Записей после этой даты нет!\n";
        return;
    }
    printf("\nAFTER %2d/%2d/%4d:", day, month, year);
    printf(" \n ---------------------------------------------------------------------------------------------------------\n");
    printf(" | №| Fabric code |    Type     |    Kind    |    Country    |     Date    |   m   | BYN/m  | Total cost |\n");
    printf(" |--+----------------------------------------------------------------------------------------------------|\n");

    for (int i = 0; i < num; i++)
    {
        if ((temp + i)->date.day + (temp + i)->date.month * 31 + (temp + i)->date.year * 365 > TIME) {
            printf(" |%2d|%11d  |%12s | %10s |%14s |  %2d/%2d/%4d |%6d | %6d |%10d  |\n", i + 1, (temp + i)->codeOfCloth, (temp + i)->type, (temp + i)->kind, (temp + i)->landOfManufacturing, (temp + i)->date.day, (temp + i)->date.month, (temp + i)->date.year, (temp + i)->quantity, (temp + i)->price, (temp + i)->quantity * (temp + i)->price);
            printf(" |--+----------------------------------------------------------------------------------------------------|\n");

        }
    }
    printf(" ---------------------------------------------------------------------------------------------------------\n");

}

void del(Supplier* temp, int& num)
{
    if (empty(num))return;
    print(temp, num);
    int choice;
    cout << "Введите поярдковый номер записи, которую хотите удалить: ";
    choice = input(1, num);
    choice--;
    for (int i = choice; i <= num; i++) {
        temp[i] = temp[i + 1];
    }
    cout << "Удаление завершено!" << endl;
    num--;
}



void read(FILE* fp, Supplier temp[MAX_SIZE], int& num) { // чтение с бинарного

    fp = fopen("info.txt", "rb");
    if (!(fp = fopen("info.txt", "rb")))
    {
        fp = fopen("info.txt", "w+b"); // создание нового файла, если файл не найден
        fclose(fp);
        num = 0;
        return;
    }

    else {
        fread(temp, sizeof(struct Supplier), MAX_SIZE, fp);
        num = (int)(ftell(fp)) / sizeof(struct Supplier); // количество записей в бинраном файле ( положение указателя в файле делить на размер структуры)
    }
    fclose(fp);
}

void rewrite(FILE* fp, Supplier* temp, int num) { // запись в бинарный

    fp = fopen("info.txt", "w+b");
    int i = 0;
    while (i < num) {
        fwrite((temp + i), sizeof(*temp), 1, fp);
        i++;
    }
    fclose(fp);
}




int main() {

    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    FILE* fp = nullptr;
    int num = 0;
    Supplier* arrsupp = new Supplier[MAX_SIZE];
    read(fp, arrsupp, num); // чтение с файла
    while (1) {
        switch (Menu()) {
        case 1:
            add(arrsupp, num); // добавление
            break;
        case 2:
            print(arrsupp, num); // вывод всех записей
            break;
        case 3:
            del(arrsupp, num); // удаление
            break;
        case 4:
            afterTheDate(arrsupp, num); // вывод после даты
            break;
        case 5:
            printBelarusian(arrsupp, num); // вывод белорусских
            break;
        case 6:
            printSynthetics(arrsupp, num); // вывод синтетических
            break;
        case 0:
            rewrite(fp, arrsupp, num); // запись в файл
            delete[] arrsupp;
            cout << "Программа завершена!\n";
            return 0;
        }
    }

}