#include <iostream>
using namespace std;

// Задание 5-11//
 /*int main()
{
    setlocale(LC_CTYPE, "Russian");
    int k;
    cout << "Введите число от 1 до 9" << endl;
    cin >> k;
    switch (k) {
    case 1: cout << "Мне 1 год"; break;
    case 2: case 3: case 4: cout << "Мне " << k << " года"; break;
    case 5: case 6: case 7: case 8: case 9: cout << "Мне " << k << " лет"; break;
    default: cout << "Неверные данные"; break;
    }
}*/ 
/*Задание 5-3*/
/*int main()
{
    setlocale(LC_CTYPE, "Russian");
    int a, b, c, p, SrAri, SrGeo;
    cout << "Введите a" << endl;
    cin >> a;
    cout << "Введите b" << endl;
    cin >> b;
    cout << "Введите c" << endl;
    cin >> c;
    p = a * b * c;
    SrGeo = pow( p, 1.0/3);
    SrAri = (a + b + c) / 3;
    cout << "Среднее геометрическое: " << SrGeo << endl;
    cout << "Среднее арифметическое: " << SrAri << endl;
}*/
//Задание 5-4//
/*int main()
{
    setlocale(LC_CTYPE, "Russian");
    int m;
    cout << "Введите номер месяца" << endl;
    cin >> m;
    switch(m) {
    case 1: case 2: case 12: cout << "Зима"; break;
    case 3: case 4: case 5: cout << "Весна"; break;
    case 6: case 7: case 8: cout << "Лето"; break;
    case 9: case 10: case 11: cout << "Осень"; break;
    default: cout << "Неверные данные"; break;
    }
}*/
//Задание 5-7//
/*int main()
{
    setlocale(LC_CTYPE, "Russian");
    int y;
    cout << "Введите год" << endl;
    cin >> y;
    if (y % 4 == 0) {
        cout << "Год високосный" << endl;
    }
    else {
        cout << "Год не високосный" << endl;
    }

}*/
//Задание 6//
/*int main()
{
    setlocale(LC_ALL, "Russian");
    string i;
    int c;
    cout << "Введите свое кодовое имя" << endl;
    cin >> i;
    cout << "Здравствуйте, " << i << ", как вы себя чувствуете?(1-отлично; 2-бывало и лучше; 3-плохо" << endl;
    cin >> c;
    switch (c) {
    case 1: {cout << "Прекрасно! Были ли какие-нибудь осложнения(1-да; 2-нет)" << endl;
        cin >> c;
        switch (c) {
        case 1: cout << "Употребляйте эти таблетки еще несколько дней, организм должен привыкнуть" << endl; break;
        case 2: cout << "Отлично, мы не будем прописывать вам новые таблетки" << endl; break;
        }
        break;
    }
    case 2: {cout << "Это из-за таблеток?(1-да; 2-нет)" << endl;
        cin >> c;
        switch (c) {
        case 1: cout << "Употребляйте эти таблетки еще несколько дней, организм должен привыкнуть" << endl; break;
        case 2: cout << "Мы запишем вас на прием к психологу" << endl; break;
        }
        break;
    }
    case 3: {cout << "Это из-за таблеток?(1-да; 2-нет)" << endl;
        cin >> c;
        switch (c) {
        case 1: cout << "Мы пропишем вам новые таблетки" << endl; break;
        case 2: cout << "Мы запишем вас на прием к психологу" << endl; break;
            break;
        }
        break;
    }
    default: cout << "Неверные данные" << endl; break;
    }
    cout << "С вас 100 рублей" << endl;
}*/