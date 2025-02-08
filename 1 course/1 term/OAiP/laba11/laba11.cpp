#include <iostream>
using namespace std;

//Вариант 2.1
void main()
{
 setlocale(LC_CTYPE, "Russian");
 char tmp[33];
 int A, B, maskA = 124; //A = 158 = 10011110, maskA = 124 = 01111100;
 int maskB = 7; //B = 135 = 10000111, maskB = 00000111;
 cout << "Первое число А = "; cin >> A;
 cout << "Второе число В = "; cin >> B;
 _itoa_s(A, tmp, 2);
 cout << "A=" << tmp << endl;
 _itoa_s(B, tmp, 2);
 cout << "B=" << tmp << endl;
 _itoa_s(maskA, tmp, 2);
 cout << "Маска для А: " << tmp << endl;
 _itoa_s((A & maskA) >> 2, tmp, 2);
 cout << "Выделенные биты(с 2ого по 6ой) А: " << tmp << endl; 
 /*(& - операция умножения) *10011110
 01111100
 00011100>>2=111
 */
 _itoa_s(maskB, tmp, 2);
 cout << "Маска для В: " << tmp << endl;
 _itoa_s(B & maskB, tmp, 2);
 cout << "Число B после очистки первых 5 битов: " << tmp << endl; 
 /* *10000111
 00000111
 00000111
 */
 _itoa_s(((B & maskB) | ((A & maskA) << 1)), tmp, 2);
 cout << "Результат B=" << tmp << endl; 
 /* +00000111
 00111000
 00111111
 */
}

//Вариант 2.2
//int main()
//{
// setlocale(LC_CTYPE, "Russian");
// int A, position, n, razn;
// char tmp[33];
// cout << "Введите A = ";
// cin >> A;
// _itoa_s(A, tmp, 2);
// cout << "Число A в двоичном представлении = " << tmp << endl;
// cout << "Введите начальную позицию p = ";
// cin >> position;
// cout << "Введите число битов n = ";
// cin >> n;
// razn = position - n;
// while (position > razn)
// {
// A = A | 1 << position;
// _itoa_s(A, tmp, 2);
// position--;
// }
//
// cout << "Итоговый результат числа А = " << tmp << endl;
//}
//Вариант 15.1
//int main() {
//	setlocale(LC_ALL, "Russian");
//	unsigned int A;
//	cout << "Введите A" << endl;
//	cin >> A;
//	if ((A & 1) == 0) {
//		cout << "Число кратно 2";
//		}
//		else {
//			cout << "Число не кратно 2";
//		}
//	}
// 
//Вариант 11.1
//int main() {
//	setlocale(LC_ALL, "Russian");
//	unsigned int A;
//	cout << "Введите A" << endl;
//	cin >> A;
//	if ((A & 15) == 0) {
//		cout << "Число кратно 16";
//	}
//	else {
//		cout << "Число не кратно 16";
//	}
//}
//Вариант 9.2
//int main() {
//	setlocale(LC_CTYPE, "Russian");
//	char num[33];
//	cout << "Введите число A: ";
//	int a, n, position = 0;
//	cin >> a;
//
//	_itoa_s(a, num, 2);
//	cout << "В двоичном формате= " << num << '\n';
//
//	cout << "Сколько битов ты хочешь заменить на '0': ";
//	cin >> n;
//	while (position < 1)
//	{
//		cout << "с какой позиции ты хочешь заменить: ";
//		cin >> position;
//	}
//	unsigned int mask = (1 << n) - 1;
//	a = a & ~(mask << (position - 1));
//	_itoa_s(a, num, 2);
//	cout  <<"\nA В двоичном формате после всех приобразований: " << num;
//}


