#include <iostream>
using namespace std;

//Задание 11
//Метод трапеции
//int main()
//{
//    setlocale(LC_CTYPE, "Russian");
//    double a = 1, b = 3, n = 200, h, x, s;
//    h = (b - a) / n; x = a; s = 0;
//    while (x <= (b - h)) {
//        s = s + h * ((sin(x) + 1) + (sin(x + h) + 1)) / 2;
//        x = x + h;
//    }
//    cout << "Метод трапеции: " << endl;
//    cout << "s= " << s << endl;
//}
//Метод парабол
//int main() {
//	setlocale(LC_CTYPE, "Russian");
//	double a = 1, b = 3, n = 200, h, x, s1, s2, i, s;
//	h = (b - a) / (2 * n); x = a + 2 * h; s1 = 0; s2 = 0; i = 1;
//	while (i < n) {
//		s2 = s2 + (sin(x) + 1);
//		x = x + h;
//		s1 = s1 + (sin(x) + 1);
//		x = x + h;
//		i = i + 1;
//	}
//	s = (h / 3) * ((sin(a) + 1) + 4 * (sin(a + h) + 1) + 4 * s1 + 2 * s2 + (sin(b) + 1));
//	cout << "Метод парабол: " << endl;
//	cout << "s= " << s << endl;
//}
//Метод дихотомии
//int main() {
//	setlocale(LC_CTYPE, "Russian");
//	double a, b, x, e = 0.0001;
//	cout << "a= " << endl;
//	cin >> a;
//	cout << "b= " << endl;
//	cin >> b;
//	while (abs(a - b) > 2 * e) {
//		x = (a + b) / 2;
//		if ((2 * x + pow(x, 3) + -7) * (2 * a + pow(a, 3) - 7) <= 0) {
//			b = x;
//		}
//		else {
//			a = x;
//		}
//	}
//	cout << "x= " << x << endl;
//}
////Задание 1
////Метод трапеции
//int main()
//{
// setlocale(LC_CTYPE, "Russian");
// double a = 1, b = 3, n = 200, x, s, h, s1, s2, i;
// h = (b - a) / n; x = a; s = 0;
// while (x < (b - h)) {
// s = s + h * ((pow(x, 3) - 3) + (pow(x, 3) - 3)) / 2;
// x = x + h;
// }
// cout << "Метод трапеции" << endl;
// cout << "s = " << s << endl << endl;
// //Метод парабол
// h = (b - a) / (2 * n);
// x = a + 2 * h;
// s1 = 0; s2 = 0; i = 1;
// while (i < n) {
// s2 = s2 + (pow(x, 3) - 3);
// x = x + h;
// s1 = s1 + (pow(x, 3) - 3);
// x = x + h;
// i = i + 1;
// }
// s = h / 3 * ((pow(x, 3) - 3) + 4 * (pow(a + h, 3) - 3) + 4 * s1 + 2 * s2 + pow(x, 3) - 3);
// cout << "Метод парабол" << endl;
// cout << "s = " << s << endl;
//}
////Метод дихотомии
//int main() {
// double a, b, e = 0.0001, x = 0;
// cout << "a = " << endl;
// cin >> a;
// cout << "b = " << endl;
// cin >> b;
// while (abs(a - b) > 2 * e) {
// x = (a + b) / 2;
// if ((pow(x, 3) + x - 3) * (pow(a, 3) + a - 3) <= 0) {
// b = x;
// }
// else {
// a = x;
// }
// }
// cout << "x = " << x << endl;
//}
//Задание 2
////Метод трапеции
//int main()
//{
// setlocale(LC_CTYPE, "Russian");
// double a=4, b=7, n = 200, x, s, h, s1, s2, i;
// h = (b - a) / n; x = a; s = 0;
// while (x < (b - h)) {
// s = s + h * (pow(cos(x), 3) + pow(cos(x + h), 3)) / 2;
// x = x + h;
// }
// cout << "Метод трапеции" << endl;
// cout << "s = " << s << endl << endl;
////Метод парабол
// h = (b - a) / (2*n);
// x = a + 2*h;
// s1 = 0; s2 = 0; i = 1;
// while (i < n) {
// s2 = s2 + pow(cos(x), 3);
// x = x + h;
// s1 = s1 + pow(cos(x), 3);
// x = x + h;
// i = i + 1;
// }
// s = h / 3 * (pow(cos(a), 3) + 4 * pow(cos(a + h), 3) + 4 * s1 + 2 * s2 + pow(cos(b), 3));
// cout << "Метод парабол" << endl;
// cout << "s = " << s << endl;
//}
//Метод дихотомии
//int main() {
//	setlocale(LC_CTYPE, "Russian");
// double a, b, e = 0.0001, x;
// cout << "a = " << endl;
// cin >> a;
// cout << "b = " << endl;
// cin >> b;
// while (abs(a - b) > 2 * e) {
// x = (a + b) / 2;
// if ((cos(x) + x - 7)*(cos(a) + a - 7) <= 0) {
// b = x;
// }
// else {
// a = x;
// }
// }
// cout << "x = " << x << endl;
//}
////Задание 3
//Метод трапеции
//int main()
//{
// setlocale(LC_CTYPE, "Russian");
// double a = 1, b = 6, n = 200, x, s, h, s1, s2, i;
// h = (b - a) / n; x = a; s = 0;
// while (x < (b - h)) {
// s = s + h * ((pow(x, 3) + 1) + (pow(x, 3) + 1)) / 2;
// x = x + h;
// }
// cout << "Метод трапеции" << endl;
// cout << "s = " << s << endl << endl;
// //Метод парабол
// h = (b - a) / (2 * n);
// x = a + 2 * h;
// s1 = 0; s2 = 0; i = 1;
// while (i < n) {
// s2 = s2 + (pow(x, 3) + 1);
// x = x + h;
// s1 = s1 + (pow(x, 3) + 1);
// x = x + h;
// i = i + 1;
// }
// s = h / 3 * ((pow(x, 3) + 1) + 4 * (pow(a + h, 3) + 1) + 4 * s1 + 2 * s2 + pow(x, 3) + 1);
// cout << "Метод парабол" << endl;
// cout << "s = " << s << endl;
//}
//Метод дихотомии
//int main() {
// double a, b, e = 0.0001, x = 0;
// cout << "a = " << endl;
// cin >> a;
// cout << "b = " << endl;
// cin >> b;
// while (abs(a - b) > 2 * e) {
// x = (a + b) / 2;
// if ((pow(x, 3) + 2 * x - 1) * (pow(a, 3) + 2 * a - 1) <= 0) {
// b = x;
// }
// else {
// a = x;
// }
// }
// cout << "x = " << x << endl;
//}
