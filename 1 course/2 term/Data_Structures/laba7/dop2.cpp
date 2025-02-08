//#include <iostream>
//#include <iomanip>
//#include <windows.h>
//using namespace std;
//
//void main()
//{
//    setlocale(LC_CTYPE, "Russian");
//    HANDLE handle = GetStdHandle(STD_OUTPUT_HANDLE);
//    char c, p = ' ';
//    cout << "Введите символ: ";
//    cin >> c;
//    SetConsoleTextAttribute(handle, 2);
//    cout << endl;
//    cout << setw(37) << setfill(p) << p << setw(1) << setfill(c) << c << endl;
//    cout << setw(36) << setfill(p) << p << setw(3) << setfill(c) << c << endl;
//    cout << setw(35) << setfill(p) << p << setw(5) << setfill(c) << c << endl;
//    cout << setw(34) << setfill(p) << p << setw(7) << setfill(c) << c << endl;
//    cout << setw(33) << setfill(p) << p << setw(9) << setfill(c) << c << endl;
//    cout << setw(32) << setfill(p) << p << setw(11) << setfill(c) << c << endl;
//    cout << setw(31) << setfill(p) << p << setw(13) << setfill(c) << c << endl;
//    cout << setw(30) << setfill(p) << p << setw(15) << setfill(c) << c << endl;
//    cout << setw(29) << setfill(p) << p << setw(17) << setfill(c) << c << endl;
//    cout << setw(28) << setfill(p) << p << setw(19) << setfill(c) << c << endl;
//    cout << setw(27) << setfill(p) << p << setw(21) << setfill(c) << c << endl;
//    cout << setw(26) << setfill(p) << p << setw(23) << setfill(c) << c << endl;
//    cout << setw(25) << setfill(p) << p << setw(25) << setfill(c) << c << endl;
//    cout << setw(24) << setfill(p) << p << setw(27) << setfill(c) << c << endl;
//    cout << setw(25) << setfill(p) << p << setw(25) << setfill(c) << c << endl;
//    cout << setw(26) << setfill(p) << p << setw(23) << setfill(c) << c << endl;
//    cout << setw(27) << setfill(p) << p << setw(21) << setfill(c) << c << endl;
//    cout << setw(28) << setfill(p) << p << setw(19) << setfill(c) << c << endl;
//    cout << setw(29) << setfill(p) << p << setw(17) << setfill(c) << c << endl;
//    cout << setw(30) << setfill(p) << p << setw(15) << setfill(c) << c << endl;
//    cout << setw(31) << setfill(p) << p << setw(13) << setfill(c) << c << endl;
//    cout << setw(32) << setfill(p) << p << setw(11) << setfill(c) << c << endl;
//    cout << setw(33) << setfill(p) << p << setw(9) << setfill(c) << c << endl;
//    cout << setw(34) << setfill(p) << p << setw(7) << setfill(c) << c << endl;
//    cout << setw(35) << setfill(p) << p << setw(5) << setfill(c) << c << endl;
//    cout << setw(36) << setfill(p) << p << setw(3) << setfill(c) << c << endl;
//    cout << setw(37) << setfill(p) << p << setw(1) << setfill(c) << c << endl;
//    SetConsoleTextAttribute(handle, 7);
//}