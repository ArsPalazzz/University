#include <cmath>
#include <iostream>
#include <iomanip>
using namespace std;


//Задание 11.1
//int main() {
//    setlocale(LC_CTYPE, "Russian");
//    float a = -1.4, m = 16, j = 0, w, r, i;
//
//    for (i = 1; i <= 3; i++) {
//        if (i == 1) {
//            j = 0.5;
//        }
//        else if (i == 2) {
//            j = 9.1;
//        }
//        else if (i == 3) {
//            j = 5;
//        }
//
//        cout << "j = " << j << endl;
//        w = tan(a / 3) + exp(a / m);
//        r = 0.9 * sqrt(w + j) + abs(pow(a, 2) - 1);
//        cout << "w = " << w << endl;
//        cout << "r = " << r << endl;
//    }
//}

//Задание 11.2
//int main() {
//    setlocale(LC_CTYPE, "Russian");
//    float a = -1.4, m = 16, j = 1.8, w, r, i;
//
//    while (j < 3.1) {
//        cout << "j = " << j << endl;
//        w = tan(a / 3) + exp(a / m);
//        r = 0.9 * sqrt(w + j) + abs(pow(a, 2) - 1);
//        j = j + 0.2;
//
//        cout << "w = " << w << endl;
//        cout << "r = " << r << endl;
//    }
//}

//Задание 11.3
//int main() {
//    setlocale(LC_CTYPE, "Russian");
//    float a = 0, m = 16, j = 0, w, r, i;
//
//    for (i = 1; i <= 3; i++) {
//        if (i == 1) {
//            a = 0.2;
//        }
//        else if (i == 2) {
//            a = -4;
//        }
//        else if (i == 3) {
//            a = 0.6;
//        }
//        cout << "a = " << a << endl;
//        cout << "" << endl;
//        j = 0.1;
//        while (j <= 0.5) {
//            cout << "j = " << j << endl;
//            w = tan(a / 3) + exp(a / m);
//            r = 0.9 * sqrt(w + j) + abs(pow(a, 2) - 1);
//            j = j + 0.1;
//            cout << "w = " << w << endl;
//            cout << "r = " << r << endl;
//        }
//    }
//}

//Задание 5.1
//int main() {
//	setlocale(LC_CTYPE, "Russian");
//	float y = 1.6 * pow(10, -4), x = -1, k = 6, i = 0, c, d, b;
//
//	for (b = 1; b <= 3; b++) {
//		if (b == 1) {
//			i = 0.9;
//		}
//		else if (b == 2) {
//			i = 8.4;
//		}
//		else if (b == 3) {
//			i = 2;
//		}
//
//		cout << "i =" << i << endl;
//		c = (i / k) - (sqrt(y) / 0.4);
//		d = exp(1 - c) + 4.9 * (pow(x, 2) + 1);
//		cout << "c = " << c << endl;
//		cout << "d = " << d << endl;
//	}
//}

//Задание 5.2
//int main() {
// setlocale(LC_CTYPE, "Russian");
// float y = 1.6 * pow(10, -4), x = -1, k = 6, i, c, d, b;
// i = 0;
//
// while (i<3.1) {
// cout << "i = " << i << endl;
// c = (i / k) - (sqrt(y) / 0.4);
// d = exp(1 - c) + 4.9 * (pow(x, 2) + 1);
// i = i + 0.5;
// cout << "c = " << c << endl;
// cout << "d = " << d << endl;
// }
//}

//Задание 5.3
int main()
{
 setlocale(LC_CTYPE, "Russian");
 float y = 1.6 * pow(10, -4), x = 0, k = 6, i, c, d, b;
 i = 0;
 for (b = 1; b <= 3; b++) {
 if (b == 1) {
 i = 1.3;
 }
 else if (b == 2) {
 i = -8;
 }
 else if (b == 3) {
 i = 0.2;
 }
 cout << "i= " << i << endl;
 cout << " " << endl;
 x = 1;
 while (x <= 2.1) {
 cout << "x = " << x << endl;
 c = (i / k) - (sqrt(y) / 0.4);
 d = exp(1 - c) + 4.9 * (pow(x, 2) + 1);
 x = x + 0.1;

 cout << "c = " << c << endl;
 cout << "d = " << d << endl;
    }
  }
}


