#include <iostream>
using namespace std;

//Вариант 1.11
int main() {
    int x = 10, x1, x2, k = 1, f;
    cout << "f = " << endl;
    cin >> f;
    while (x <= 99) {
        x1 = x / 10;
        x2 = x % 10;
        if (x1 + x2 == f) {
            cout << k << ". " << x1 << " + " << x2 << " = " << f << endl;
            k += 1;
        }
        x += 1;
    }
    cout << "k = " << k - 1;
}
//int main()
//{
//    setlocale(LC_CTYPE, "Russian");
//    float a = -4.2, i = 4, d, f, p;
//    double t;
//    for (p = 1; p < 6; p++) {
//        if (p == 1) {
//            t = 5;
//        }
//        else if (p == 2) {
//            t = 1;
//        }
//        else if (p == 3) {
//            t = -3;
//        }
//        else if (p == 4) {
//            t = 9;
//        }
//        else if (p == 5) {
//            t = -1;
//        }
//        d = i + 2 * t * (1 + sqrt(3 * pow(a, 2)));
//        cout << "t= " << t << endl;
//        cout << "d= " << d << endl;
//        if (d >= t * (t + i)) {
//            f = t * i;
//        }
//        else if (d < t * (t + i)) {
//            f = exp(t - d) + 9;
//        }
//        cout << "f= " << f << endl;
//        cout << " " << endl;
//    }
//}

//Вариант 1.2
//int main() {
//	setlocale(LC_CTYPE, "Russian");
//	double b = -0.05, a = 1.72, i = -5, d, z;
//	while (i <= 5) {
//		cout << "i= " << i << endl;
//		if (i > 3 * b) {
//			d = a + b * i;
//		}
//		else if (i <= 3 * b) {
//			d = tan(b) - a * i;
//		}
//		cout << "d= " << d << endl;
//		z = (d * a / 4) / (3 * a * b - exp(1 + d) / 100);
//		cout << "z= " << z << endl;
//		cout << " " << endl;
//		i = i + 2;
//	}
//
//}

//Задание 1.7
//int main() {
//	setlocale(LC_CTYPE, "Russian");
//	float a = 1.2, k = 3, x = 2.5, m = 4, w, v;
//	while (m <= 6) {
//		cout << "m= " << m << endl;
//		if (x < m / 2) {
//			w = sqrt(0.2 * x) * k;
//		}
//		else if (x >= m / 2) {
//			w = exp(2 * x * k);
//		}
//		cout << "w= " << w << endl;
//		v = sqrt(pow(w, 3) + abs(x - a)) / log(1 + a);
//		cout << "v= " << v << endl;
//		cout << " " << endl;
//		m = m + 0.2;
//	}
//}

//Задание 1.5
//int main() {
//	setlocale(LC_CTYPE, "Russian");
//	double y = 1.4e-3, x = 0.2, m = 4, j = 5, p, q;
//	while (j <= 11) {
//		cout << "j= " << j << endl;
//		p = exp(sin(j / x)) * log(x / y) * x;
//		cout << "p= " << p << endl;
//		if (p <= pow(y, 2)) {
//			q = sqrt(p / m);
//			cout << "q= " << q << endl;
//		}
//		else if (p > pow(y, 2)) {
//			q = sqrt(2 * x) / (j + p);
//			cout << "q= " << q << endl;
//		}
//		cout << " " << endl;
//		j = j + 2;
//	}
//}

//Задание 2.11
//int main() {
//	setlocale(LC_CTYPE, "Russian");
//	int a = 0, b = 0, k = 1, f, x, y;
//	cout << "Введите число от 0 до 1" << endl;
//	cin >> a;
//	if (a > 1) {
//		cout << "Неверные данные" << endl;
//		exit(1);
//	}
//	else if (a < 0) {
//		cout << "Неверные данные" << endl;
//		exit(1);
//	}
//	if (a == 0) {
//		cout << "Введите число от 0 до 9" << endl;
//		cin >> b;
//		if (b > 9) {
//			cout << "Неверные данные" << endl;
//			exit(1);
//		}
//		else if (b < 0) {
//			cout << "Неверные данные" << endl;
//			exit(1);
//		}
//	}
//	else if (a == 1) {
//		cout << "Введите число от 0 до 8" << endl;
//		cin >> b;
//		if (b > 8) {
//			cout << "Неверные данные" << endl;
//			exit(1);
//		}
//		else if (b < 0) {
//			cout << "Неверные данные" << endl;
//			exit(1);
//		}
//	}
//	f = 10 * a + b;
//	cout << "f= " << a << b << endl;
//	for (x = 0; x < 10; x++) {
//		for (y = 0; y < 10; y++) {
//			if (x + y == f) {
//				cout << k << ". " << x << " и " << y << endl;
//				k = k + 1;
//			}
//		}
//		y = 0;
//	}
//}

//Задание 2.2
//int main() {
//	setlocale(LC_CTYPE, "Russian");
//	int x = 3, sum = 0;
//	while (x < 200) {
//		sum = sum + x;
//		cout << "x= " << x << endl;
//		x = x + 3;
//	}
//	cout << "Sum= " << sum << endl;
//}
//Задание 2.3
//int main() {
//	setlocale(LC_CTYPE, "Russian");
//	int a, b, c, k = 0, n, x;
//	cout << "Введите n: " << endl;
//	cin >> n;
//	for (x = 100; x < 1000; x++) {
//		a = x / 100;
//		b = (x / 10) % 10;
//		c = (x % 100) % 10;
//		if (a + b + c == n) {
//			k = k + 1;
//			cout << k << ". " << a << " + " << b << " + " << c << " = " << n << endl;
//		}
//	}	
//}
//Задание 2.1
//int main() {
//	setlocale(LC_CTYPE, "Russian");
//	int x = 100, a, b, c, k = 1;
//	while (x < 1000) {
//		a = x / 100;
//		b = (x / 10) % 10;
//		c = (x % 100) % 10;
//		if (a != b && a != c && b != c) {
//			cout << k << ". " << a << b << c << endl;
//			k = k + 1;
//		}
//		x = x + 1;
//	}
//}
