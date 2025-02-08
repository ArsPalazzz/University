#include <iostream>
#include <iomanip>
#include <stdio.h> //файл используется для форматированного ввода-вывода данных
#include <conio.h> //файл поддерживает функцию _getch, которая ожидает нажатие клавишы на клавиатуре
using namespace std;

/*Задание 11.1
void main()
{
    setlocale(LC_CTYPE, "Russian"); //оператор для вывода русского текста
    char c, p = ' '; 
    cout << "Введите символ : ";
    cin >> c; //стандартный поток ввода с клавиатуры
    cout << endl << endl;
    cout << setw(20) << setfill(p) << p << setw(16) << setfill(c) << c << endl; //setw - ширина поля вывода 
    cout << setw(20) << setfill(p) << p << setw(16) << setfill(c) << c << endl; //заполнитель
    cout << setw(20) << setfill(p) << p << setw(16) << setfill(c) << c << endl;
    cout << setw(20) << setfill(p) << p << setw(16) << setfill(c) << c << endl;
    cout << setw(20) << setfill(p) << p << setw(16) << setfill(c) << c << endl;
    cout << setw(20) << setfill(p) << p << setw(16) << setfill(c) << c << endl;
    cout << setw(20) << setfill(p) << p << setw(16) << setfill(c) << c << endl;
}*/
/*Задание 11.2
int main()
{
    setlocale(LC_CTYPE, "Russian");
    int h;
    cout << "Введите значение высоты: " << endl;
    cin >> h;
    int a = 2 * h;
    int P = 2 * (a + h);
    int S = a * h;

    cout << "Основание: " << a << endl;
    cout << "Площадь и Периметр: " << S << endl;
    return 0;
  }*/
/* Задание 1.1
void main()
{
    setlocale(LC_CTYPE, "Russian");
    char c, p = ' ';
    cout << "Введите символ: " << endl;
    cin >> c;
    cout << endl << endl;
    cout << setw(28) << setfill(p) << p << setw(4) << setfill(c) << c << endl;
    cout << setw(27) << setfill(p) << p << setw(5) << setfill(c) << c << endl;
    cout << setw(26) << setfill(p) << p << setw(6) << setfill(c) << c << endl;
    cout << setw(25) << setfill(p) << p << setw(7) << setfill(c) << c << endl;
    cout << setw(24) << setfill(p) << p << setw(8) << setfill(c) << c << endl;
    cout << setw(23) << setfill(p) << p << setw(9) << setfill(c) << c << endl;
    cout << setw(22) << setfill(p) << p << setw(10) << setfill(c) << c << endl;
    cout << setw(21) << setfill(p) << p << setw(11) << setfill(c) << c << endl;
    cout << setw(20) << setfill(p) << p << setw(12) << setfill(c) << c << endl;
    cout << setw(20) << setfill(p) << p << setw(12) << setfill(c) << c << endl;
    cout << setw(21) << setfill(p) << p << setw(11) << setfill(c) << c << endl;
    cout << setw(22) << setfill(p) << p << setw(10) << setfill(c) << c << endl;
    cout << setw(23) << setfill(p) << p << setw(9) << setfill(c) << c << endl;
    cout << setw(24) << setfill(p) << p << setw(8) << setfill(c) << c << endl;
    cout << setw(25) << setfill(p) << p << setw(7) << setfill(c) << c << endl;
    cout << setw(26) << setfill(p) << p << setw(6) << setfill(c) << c << endl;
    cout << setw(27) << setfill(p) << p << setw(5) << setfill(c) << c << endl;
    cout << setw(28) << setfill(p) << p << setw(4) << setfill(c) << c << endl;
}*/  
  /*Задание 1.2
int main()
{
    setlocale(LC_CTYPE, "Russian");
    int d;
    cout << "Введите значение диагонали квадрата" << endl;
    cin >> d;
    int S = 0.5 * pow(d, 2);

    cout << "Площадь:" << S << endl;
    return 0;
}*/
/*Задание 4.1
int main()
{
    setlocale(LC_CTYPE, "Russian");
    char c, p = ' ';
    cout << "Введите символ: " << endl;
    cin >> c;
    cout << endl << endl;
    cout << setw(30) << setfill(p) << p << setw(4) << setfill(c) << c << endl;
    cout << setw(28) << setfill(p) << p << setw(8) << setfill(c) << c << endl;
    cout << setw(26) << setfill(p) << p << setw(12) << setfill(c) << c << endl;
    cout << setw(24) << setfill(p) << p << setw(16) << setfill(c) << c << endl;
    cout << setw(22) << setfill(p) << p << setw(20) << setfill(c) << c << endl;
    cout << setw(20) << setfill(p) << p << setw(24) << setfill(c) << c << endl;
    cout << setw(20) << setfill(p) << p << setw(24) << setfill(c) << c << endl;
    cout << setw(20) << setfill(p) << p << setw(24) << setfill(c) << c << endl;
    cout << setw(22) << setfill(p) << p << setw(20) << setfill(c) << c << endl;
    cout << setw(24) << setfill(p) << p << setw(16) << setfill(c) << c << endl;
    cout << setw(26) << setfill(p) << p << setw(12) << setfill(c) << c << endl;
    cout << setw(28) << setfill(p) << p << setw(8) << setfill(c) << c << endl;
    cout << setw(30) << setfill(p) << p << setw(4) << setfill(c) << c << endl;
}*/
/*Задание 4.2
 int main()
 {
 setlocale(LC_CTYPE, "Russian");
 int x;
 cout << "Введите x" << endl;
 cin >> x;
 int y;
 cout << "Введите y" << endl;
 cin >> y;
int z;
 cout << "Введите z" << endl;
 cin >> z;
 int A = (x + y + z) / 3;
 int G = sqrt(x * y * z);
 cout << "Средняя арифметическая: " << A << endl;
 cout << "Средняя геометрическая: " << G <<endl;
 }*/
/*Задание 7.1
int main()
{
    setlocale(LC_CTYPE, "Russian");
    char c, p = ' ';
    cout << "Введите символ: " << endl;
    cin >> c;
    cout << endl << endl;
    cout << setw(20) << setfill(p) << p << setw(10) << setfill(c) << c << endl;
    cout << setw(20) << setfill(p) << p << setw(11) << setfill(c) << c << endl;
    cout << setw(20) << setfill(p) << p << setw(12) << setfill(c) << c << endl;
    cout << setw(20) << setfill(p) << p << setw(13) << setfill(c) << c << endl;
    cout << setw(20) << setfill(p) << p << setw(14) << setfill(c) << c << endl;
    cout << setw(20) << setfill(p) << p << setw(15) << setfill(c) << c << endl;
    cout << setw(20) << setfill(p) << p << setw(16) << setfill(c) << c << endl;
    cout << setw(20) << setfill(p) << p << setw(17) << setfill(c) << c << endl;
}*/
/*Задание 7.2
int main()
{
setlocale(LC_CTYPE, "Russian");
    int x;
    cout << "Введите значение длины окружности(в пи радиан): " << endl;
    cin >> x;
    int y = x / 2;
    int S = pow(y, 2);
    cout << "Площадь круга(в пи радиан): " << S << endl;
}*/