//#include <iostream>
//#include <fstream>
//#include <string>
//using namespace std;
//
//int main()
//{
//    setlocale(LC_ALL, "ru");
//    char myf[25];
//    char* mytext = new char[100];
//    char* buff = new char[100];
//    const char* go = ".txt";
//    printf("Введите название файла(без расширения): ");
//    gets_s(myf, 25);
//    strcat_s(myf, go);
//
//    ofstream fout(myf);
//
//    printf("Что вы хотите записать в файл: ");
//    gets_s(buff, 100);
//    fout << buff;
//    fout.close();
//
//    ifstream fin(myf);
//    printf("Чтение файла: ");
//    fin.getline(buff, 50);
//    fin.close();
//    cout << buff << endl;
//
//    printf("Хотите ли вы удалить содержимое файла? 0 - Нет\t1 - Да\n");
//    int choise;
//    scanf_s("%d", &choise);
//    if (choise == 1) {
//        fout.open(myf, ios::trunc | ios::out);
//        fout.close();
//        printf("Содержимое файла очищено\n");
//    }
//    printf("Хотите ли вы удалить файл?\t0 - Нет\t1 - Да\n");
//    scanf_s("%d", &choise);
//    if (choise == 1) {
//        remove(myf);
//    }
//}