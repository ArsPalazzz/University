#include <iostream>

//Вариант 10

//int F(int m, int n) {
//    if (m == 0 || n == 0) {
//        ++n;
//    }
//    else {
//        F(m - 1, F(m, n - 1));
//    }
//    return n;
//}
//
//int main()
//{
//    setlocale(LC_ALL, "ru");
//    int m, n;
//    while(true) {
//        printf("Введите целое неотрицательное число m: ");
//        scanf_s("%d", &m); if (m < 0) { continue; }
//        printf("Введите целое неотрицательное число n: ");
//        scanf_s("%d", &n); if (n < 0) { continue; }
//        printf("Результат: %d\n", F(m, n));
//    }
//}

//Вариант 16

//int F(int n, int m) {
//	if (n == 0)
//		return 1;
//	else if (n < m)
//		return -1;
//	else
//		return 2 * F(n - 1, m);
//}
//
//int main() {
//	setlocale(LC_ALL, "ru");
//	int n, m;
//	while (true) {
//		printf("Введите целое неотрицательное число n: ");
//		scanf_s("%d", &n); if (n < 0) { continue; }
//		printf("Введите целое неотрицательное число m: ");
//		scanf_s("%d", &m); if (m < 0) { continue; }
//		printf("Результат: %d\n", F(n, m));
//	}
//}

//Вариант 15

int S(int x) {
	if (x > 100)
		x += 10;
	else
		return S(S(x + 4));
}

int main() {
	setlocale(LC_ALL, "ru");
	int x;
	while (true) {
		printf("Введите целое неотрицательное число x: ");
		scanf_s("%d", &x); if (x < 0) { continue; }
		printf("Результат: %d\n", S(x));
	}
}

//Вариант 1

//int P(int m, int n) {
//	if (n == 1 || m == 1)
//		return 1;
//	else if (n > m)
//		P(m, m);
//	else if (m == n)
//		P(m, m - 1);
//	else if (n < m)
//		return P(m, n - 1) + P(m - n, n);
//}
//
//int main() {
//	setlocale(LC_ALL, "ru");
//	int m, n;
//	while (true) {
//		printf("Введите целое неотрицательное число m: ");
//		scanf_s("%d", &m); if (m < 0) { continue; }
//		printf("Введите целое неотрицательное число m: ");
//		scanf_s("%d", &n); if (n < 0) { continue; }
//		printf("Результат: %d\n", P(m, n));
//	}
//}