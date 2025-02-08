#include <iostream>
using namespace std;

//Задание 11.1
//int main() {
//	setlocale(LC_CTYPE, "Russian");
//	double a = 5.45, n = 5, y[] = { 2.1, 7.7, -4, 5, 9 }, s, q, mult = 1;
//	for (int i = 0; i < 5; i++) {
//		mult = mult * (y[i] / (pow(i, 2) + 1));
//	}
//	q = 4 * mult;
//	s = 2 * a + q * sin(a);
//	cout << "q= " << q << endl;
//	cout << "s= " << s << endl;
//}
//Задание 11.2
//int main() {
//	setlocale(LC_CTYPE, "Russian");
//	double y[] = { 1.3, 1, 0.9, 0.5, 8 }, n = 5, k, mult = 1, min;
//	min = y[0];
//	for (int i = 0; i < 5; i++) {
//		if (y[i] < min) {
//			min = y[i];
//		}
//	}
//	for (int p = 0; p < 5; p++) {
//		mult = mult * (y[p] + min);
//	}
//	k = mult;
//	cout << "k= " << k << endl;
//}
////задание 1.1
//int main() {
//	setlocale(LC_CTYPE, "Russian");
// double n = 5, d = 12.5e-4, a[] = { 0.8, 4, -7, 2, 0.91 }, h = 0, sum = 0;
// for (int i = 0; n < 5; i++) {
// sum = sum + pow(a[i], 2);
// }
// h = sum + d;
// cout << "h = " << h << endl;
//}
//Задание 1.2
//int main() {
//	setlocale(LC_CTYPE, "Russian");
// double x[] = { 1, 2.7, 4.7, 6, 10 }, z, y = 0, max, sum = 0;
//	max = x[0];
//	for (int i = 0; i < 5; i++) {
//		if (x[i] > max) {
//			max = x[i];
//		}
//	}
//	z = max;
//	for (int n = 0; n < 5; n++) {
//		sum = y + pow(x[n], 2);
//	}
//	y = sum * z;
//	cout << "z = " << z << endl;
//	cout << "y = " << y << endl;
//}
//задание 2.1
//int main()
//{
//	setlocale(LC_CTYPE, "Russian");
// double m = 4, c = -0.045, b[] = { 0.9, 0.5, -2, -0.1 }, g = 1;
//	for (int j = 0; j < m; j++) {
//		g = g * pow((b[j] + 1), 2);
//	}
//	g = g * c;
//	cout << "g = " << g << endl;
//}
//задание 2.2
//int main() {
//	setlocale(LC_CTYPE, "Russian");
// double y[] = { 6, 2, 0.9, 0.1, 5 }, t, q = 1, min;
//	min = y[0];
//	for (int i = 0; i < 5; i++) {
//		if (y[i] < min) {
//			min = y[i];
//		}
//	}
//	t = min;
//	for (int n = 0; n < 3; n++) {
//		q *= y[n] + t;
//	}
//	cout « "t = " « t « endl;
//	cout « "q = " « q « endl;
//}
//Задание 3.1
//int main() {
//	setlocale(LC_CTYPE, "Russian");
//	double m = 5, x[] = { -2, 6 , 1.1, 2.7, 4 }, sum = 0, z;
//	for (int i = 0; i < 5; i++) {
//		sum = sum + pow((x[i] - 2), 2);
//	}
//	z = 8 * x[3] + sum;
//	cout << "z= " << z << endl;
//}
//Задание 3.2
//int main() {
//	setlocale(LC_CTYPE, "Russian");
//	double x[] = { 9, 2.7, 4.1, 6, 12 }, max, y, p, sum = 0, n;
//	for (int i = 0; i < 5; i++) {
//		sum = sum + pow(x[i], 2) + 1;
//	}
//	y = sum;
//	max = x[0];
//	for (int n = 0; n < 5; n++) {
//		if (x[n] > max) {
//			max = x[n];
//		}
//	}
//	p = y + max;
//	cout << "y= " << y << endl;
//	cout << "p " << p << endl;
//}