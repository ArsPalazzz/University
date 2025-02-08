#include <iostream>
using namespace std;
// Задание 11.1
//int main() {
//	setlocale(LC_ALL, "ru");
//	int n, min = 1, *pmin, a, *pa;
//	pa = &a;
//	pmin = &min;
//	cout << "Введите количество натуральных чисел: ";
//	cin >> n;
//	srand((unsigned)time(NULL));
//	cout << "Наши натуральные числа:\n";
//	for (int i = 0; i < n; i++) {
//		*pa = rand() % 99 + 1;
//		cout << *pa << endl;
//	}
//	for (*pmin; *pmin < 100; (*pmin)++) {
//		for (int i=0; i < n; i++) {
//			if (i = *pmin) {
//				cout << "Минимальное отсутсвующее натуральное число: " << *pmin;
//				return 0;
//			}
//		}
//	}
//}
// Задание 11.2
//void arr1(int size, int a, int z) {
//	int k1=0;
//	cout << "Элементы первого массива:\n";
//	for (int i = 0; i < size; i++) {
//		a = rand() % 10;
//		cout << a << endl;
//		if (z > a) {
//			k1 += 1;
//		}
//	}
//	cout << "Количество элементов первого массива, которые меньше z: " << k1 << endl;;
//}
//void arr2(int size, int b, int z) {
//	int k2 = 0;
//	cout << "Элементы второго массива:\n";
//	for (int i = 0; i < size; i++) {
//		b = rand() % 15;
//		cout << b << endl;
//		if (z > b) {
//			k2 += 1;
//		}
//	}
//	cout << "Количество элементов второго массива, которые меньше z: " << k2 << endl;
//}
//
//int main() {
//	setlocale(LC_ALL, "ru");
//	int z, size=15, a=0, b=0, k1=0, k2=0;
//	cout << "Введите значение z: ";
//	cin >> z;
//	srand((unsigned)time(NULL));
//		arr1(size, a, z);
//		arr2(size, b, z);
//		if (k1 < k2) {
//			cout << "В первом массиве элементов, меньших z, меньше, чем во втором массиве";
//		}
//		else {
//			cout << "В первом массиве элементов, меньших z, больше, чем во втором массиве";
//		}
//		
//	   
//}
//Задание 1.1
//int main() {
//	setlocale(LC_ALL, "ru");
//	int N, m, arr[5], a, *pa, b, *pb, c, *pc, d, *pd, e, *pe;
//	pa = &a;
//	pb = &b;
//	pc = &c;
//	pd = &d;
//	pe = &e;
//	cout << "Введите число N(до 99999): "; //65913
//	cin >> N;
//	cout << "Введите число m: ";
//	cin >> m;
//	*pa = N / 10000; //число десятков тысяч - 6
//	*pb = (N / 1000) % 10; //число тысяч - 5
//	*pc = (N / 100) % 10; //число сотен - 9
//	*pd = (N % 100) / 10;  //число десятков - 1
//	*pe = N % 10; //число единиц - 3
//	if (*pa % m == 0) {
//		arr[0] = *pa;
//	}
//	if (*pb % m == 0) {
//		arr[1] = *pb;
//	}
//	if (*pc % m == 0) {
//		arr[2] = *pc;
//	}
//	if (*pd % m == 0) {
//		arr[3] = *pd;
//	}
//	if (*pe % m == 0) {
//		arr[4] = *pe;
//	}
//	cout << "[";
//	for (int i = 0; i < 5; i++) {
//		if (i == 4) {
//			cout << arr[i] << "]";
//		}
//		else {
//			cout << arr[i] << " ,";
//		}
//	}
//}
//Задание 7.2
//int main() {
//	setlocale(LC_ALL, "ru");
//		int N, k, arr[5], a, *pa, b, *pb, c, *pc, d, *pd, e, *pe;
//		pa = &a;
//		pb = &b;
//		pc = &c;
//		pd = &d;
//		pe = &e;
//		cout << "Введите число N(до 99999): "; //65913
//		cin >> N;
//		cout << "Введите число k: ";
//		cin >> k;
//		*pa = N / 10000; //число десятков тысяч - 6
//		*pb = (N / 1000) % 10; //число тысяч - 5
//		*pc = (N / 100) % 10; //число сотен - 9
//		*pd = (N % 100) / 10;  //число десятков - 1
//		*pe = N % 10; //число единиц - 3
//		if (*pa % k == 0) {
//			arr[0] = *pa;
//		}
//		if (*pb % k == 0) {
//			arr[1] = *pb;
//		}
//		if (*pc % k == 0) {
//			arr[2] = *pc;
//		}
//		if (*pd % k == 0) {
//			arr[3] = *pd;
//		}
//		if (*pe % k == 0) {
//			arr[4] = *pe;
//		}
//		cout << "[";
//		for (int i = 0; i < 5; i++) {
//			if (i == 4) {
//				cout << arr[i] << "]";
//			}
//			else {
//				cout << arr[i] << " ,";
//			}
//		}
//}
//Задание 2.1
//int main()
//{
// setlocale(LC_ALL, "ru");
// int A[99], B[99], S[99], n;
// srand((unsigned)time(NULL));
// cout << "Введите количество n элементов массива: ";
// cin >> n;
// cout << "A = ";
// for (int i = 0; i < n; i++) {
// *(A + i) = rand() % 99;
// cout << *(A + i) << " ";
// }
// cout << endl;
//
// cout << "B = ";
// for (int i = 0; i < n; i++) {
// *(B + i) = rand() % 99;
// cout << *(B + i) << " ";
// }
// cout << endl;
//
// cout << "S = ";
// for (int i = 0; i < n; i++) {
// *(S + i) = *(A + i) + *(B + i);
// cout << *(S + i) << " ";
// }
//}

