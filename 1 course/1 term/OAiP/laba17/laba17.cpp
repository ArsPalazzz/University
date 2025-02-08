//#include <iostream>
//using namespace std;

//Задание 11.1
//Изменить одномерный массив, вычеркнув из него нечетные элементы

//void udal(int N, int*A);
//
//int main() {
//	setlocale(LC_ALL, "ru");
//	int N;
//	cout << "Введите размерность массива: ";
//	cin >> N;
//	int* A = new int[N];
//	for (int i = 0; i < N; i++) {
//		A[i] = rand() % 10;
//	}
//	cout << "Исходный массив:\n" << "A[";
//	for (int i = 0; i < N; i++) {
//		if (i == N - 1) {
//			cout << A[i] << "]\n";
//		}
//		else {
//			cout << A[i] << ", ";
//		}
//	}
//	cout << "Конечный массив:\n" << "A[";
//	udal(N, A);
//	delete[] A;
//}
//
//void udal(int N, int *A) {
//	for (int i = 0; i < N; i++) {
//		if (i % 2 == 1) {
//			if (i == N - 1  || i == N - 2){
//				cout << A[i] << "]";
//			}
//			else {
//				cout << A[i] << ", ";
//			}
//		}
//	}
//}

//Задание 11.2
//Дана целочисленная квадратная матрица. Если она не содержат отрицательных элементов, то определить сумму элементов в тех строках, где отрицательные элементы отсутствуют

//void nw(int N, int** A);
//
//int main() {
//	setlocale(LC_ALL, "ru");
//	int N, sum = 0;
//	cout << "Введите количество строк и столбцов строки: ";
//	cin >> N;
//	cout << endl;
//	int** A = new int* [N];
//	nw(N, A);
//	for (int i = 0; i < N; i++) {
//		for (int j = 0; j < N; j++) {
//			A[i][j] = rand() % 15;
//		}
//	}
//	for (int i = 0; i < N; i++) {
//		for (int j = 0; j < N; j++) {
//			cout << "A[" << i << ", " << j << "] = " << A[i][j] << "\t";
//		}
//		cout << endl;
//	}
//	for (int i = 0; i < N; i++) {
//		for (int j = 0; j < N; j++) {
//			if (A[i][j] < 0) {
//				for (int i = 0; i < N; i++) {
//					delete[] A[i];
//				}
//				delete[] A;
//				cout << "\nВ массиве присутствуют отрицательные элементы\n";
//			}
//			else {
//				sum += A[i][j];
//			}
//		}
//	}
//	cout << "\nСумма элементов в строках, где отсутствуют отрицательные элементы: " << sum << endl;
//	for (int i = 0; i < N; i++) {
//		delete[] A[i];
//	}
//	delete[] A;
//}
//
//void nw(int N, int**A) {
//	for (int i = 0; i < N; i++) {
//		A[i] = new int[N];
//	}
//}

//Задание 6.1
//Найти сумму минимального и максимального элементов одномерного массива

//int minE(int size, int* A);
//int maxE(int size, int* A, int max);
//
//int main() {
//	setlocale(LC_ALL, "ru");
//	int size;
//	cout << "Введите размерность массива: ";
//	cin >> size;
//	int* A = new int[size];
//	for (int i = 0; i < size; i++) {
//		A[i] = rand() % 10;
//	}
//	int max = A[0];
//	cout << "\nИсходный массив:\n\nA[";
//	for (int i = 0; i < size; i++) {
//		if (i == size - 1) {
//			cout << A[i] << "]\n";
//		}
//		else {
//			cout << A[i] << ", ";
//		}
//	}
//	cout << "Минимальный элемент нашего массива: " << minE(size, A) << endl << endl;
//	cout << "Максимальный элемент нашего массива: " << maxE(size, A, max) << endl << endl;
//	cout << "Их сумма: " << minE(size, A) + maxE(size, A, max);
//	delete[] A;
//}
//
//int minE(int size, int *A) {
//	int i, j = 0;
//	for (i = 1; i < size; i++) {
//		if (A[j] > A[i]) {
//			j = i;
//		}
//	}
//	return A[j];
//}
//
//int maxE(int size, int *A, int max) {
//	for (int i = 0; i < size; i++) {
//		if (A[i] > max) {
//			max = A[i];
//		}
//	}
//	return max;
//}

//Задание 9.1
//Создать одномерный массив, содержащий 15 элементов, наполнить его случайными значениями в интервале от 1 до 200.
//Определить произведение элементов массива с индексами от 2 до 7

//int main() {
//	setlocale(LC_ALL, "ru");
//	int A[15], mult = 1;
//	for (int i = 0; i < 15; i++) {
//		A[i] = rand() % 200 + 1;
//	}
//	cout << "Исходный массив:\nA[";
//	for (int i = 0; i < 15; i++) {
//		if (i == 14) {
//			cout << A[i] << "]\n";
//		}
//		else {
//			cout << A[i] << ", ";
//		}
//	}
//	for (int i = 2; i < 8; i++) {
//		mult *= A[i];
//	}
//	cout << "Произведение элементов массива с индексами от 2 до 7: " << mult << endl;
//}

//Задание 1.2
//Даны две квадратные целочисленные матрицы. Если все числа положительны, то определить произведение этих матриц

//int main() {
//	setlocale(LC_ALL, "ru");
//	int size;
//	cout << "Введите размерность двух квадратных матриц: ";
//	cin >> size;
//	int** A = new int*[size];
//	for (int i = 0; i < size; i++) {
//		A[i] = new int[size];
//	}
//	int** B = new int* [size];
//	for (int i = 0; i < size; i++) {
//		B[i] = new int[size];
//	}
//	for (int i = 0; i < size; i++) {
//		for (int j = 0; j < size; j++) {
//			A[i][j] = rand() % 10 + 1;
//			if (A[i][j] <= 0) {
//				cout << "В массиве A есть отрицательное(ые) число(а) или ноль(нули)";
//				for (int i = 0; i < size; i++) {
//					delete[] A[i];
//				}
//				for (int i = 0; i < size; i++) {
//					delete[] B[i];
//				}
//				delete[] A;
//				delete[] B;
//				return 0;
//			}
//		}
//	}
//	for (int i = 0; i < size; i++) {
//		for (int j = 0; j < size; j++) {
//			B[i][j] = rand() % 10 + 1;
//			if (B[i][j] <= 0) {
//				cout << "В массиве B есть отрицательное(ые) число(а) или ноль(нули)";
//				for (int i = 0; i < size; i++) {
//					delete[] A[i];
//				}
//				for (int i = 0; i < size; i++) {
//					delete[] B[i];
//				}
//				delete[] A;
//				delete[] B;
//				return 0;
//			}
//		}
//	}
//	cout << "Массив A:\n";
//	for (int i = 0; i < size; i++) {
//		for (int j = 0; j < size; j++) {
//			cout << "A[" << i << ", " << j << "] = " << A[i][j] << "\t";
//		}
//		cout << endl;
//	}
//	cout << "Массив B:\n";
//	for (int i = 0; i < size; i++) {
//		for (int j = 0; j < size; j++) {
//			cout << "B[" << i << ", " << j << "] = " << B[i][j] << "\t";
//		}
//		cout << endl;
//	}
//	int** C = new int* [size];
//	for (int i = 0; i < size; i++) {
//		C[i] = new int[size];
//	}
//	for (int i = 0; i < size; i++) {
//		for (int j = 0; j < size; j++) {
//			C[i][j] = A[i][j] * B[i][j];
//		}
//	}
//	cout << "Конечный массив:\n";
//	for (int i = 0; i < size; i++) {
//		for (int j = 0; j < size; j++) {
//			cout << "C[" << i << ", " << j << "] = " << C[i][j]  << "\t";
//		}
//		cout << endl;
//	}
//	for (int i = 0; i < size; i++) {
//		delete[] C[i];
//	}
//	for (int i = 0; i < size; i++) {
//		delete[] B[i];
//	}
//	for (int i = 0; i < size; i++) {
//		delete[] A[i];
//	}
//	delete[] C;
//	delete[] B;
//	delete[] A;
//}

#include <stdio.h>
#include <string.h>
#include <iostream>
#include <cstdio>


int main(void)
{
	char L[80];
	int i;
	puts("Enter ");
	gets_s(L);
	if (strlen(L) < 10) {
		for (i = 0; i < strlen(L); i++)
		{
			if (!(L[i] >= 'A' && L[i] <= 'Z'))
				printf("%c", L[i]);
		}
	}
	else printf("Length is %d", strlen(L));
	return 0;
}