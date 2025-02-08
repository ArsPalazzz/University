#include <iostream>
using namespace std;

//Задание 11.1
//Дан массив размерностью N x M. Найти максимальный элемент и его позицию
//Если максимальных элементов несколько, то вывести их все. Найти сумму элементов ниже главной диагонали

int dynamic(int M, int N, int** A);

void main() {
	setlocale(LC_ALL, "ru");
	int N, M;
	cout << "Введите количество строк в массиве: ";
	cin >> M;
	cout << "\nВведите количество столбцов в массиве: ";
	cin >> N;
	int** A = new int*[M];
	int maxIr, maxIc;
	int sum = 0;
	dynamic(M, N, A);
	int maxE = A[0][0];
	for (int i = 0; i < M; i++) {
		for (int j = 0; j < N; j++) {
			A[i][j] = rand() % 30;
			if (maxE < A[i][j]) {
				maxE = A[i][j];
				maxIr = i;
				maxIc = j;
			}
		}
	}
	cout << "Исходный массив:\n";
	for (int i = 0; i < M; i++) {
		for (int j = 0; j < N; j++) {
			cout << "A[" << i << ", " << j << "] = " << A[i][j] << "\t";
		}
		cout << endl;
	}
	cout << "Максимальный элемент имеет значение " << maxE << " и находится на " << maxIr << " строчке и " << maxIc << " столбце" << endl;
	for (int i = 1; i < M; i++) {
		for (int j = 0; j < i; j++) {
			sum += A[i][j];
		}
	}
	cout << "Сумма элементов ниже главной оси: " << sum;
	for (int i = 0; i < M; i++) {
		delete[] A[i];
	}
	delete[] A;
}

int dynamic(int M, int N, int** A) {
	for (int i = 0; i < M; i++) {
		A[i] = new int[N];
	}
	return **A;
}

//Задание 11.2
//Преобразовать строку: после каждой буквы c добавить символ *

//void main() {
//	setlocale(LC_ALL, "ru");
//	char* pStr;
//	char c = 'c', * pc;
//	int length;
//	cout << "Введите размерность строки: ";
//	cin >> length;
//	pStr = new char[length + 1];
//	cout << "Введите строку:\n";
//	cin >> pStr;
//	pc = &c;
//	for (int i = 0; i < length; i++) {
//		cout << pStr[i];
//		if (pStr[i] == *pc) {
//			cout << "*";
//		}
//	}
//	delete[] pStr;
//}

//Вариант 9.1
//Дан двумерный массив, состоящий из N строк и М столбцов, а также число number. Проверить, находится ли это число  на главной диагонали

//void nw(int** A, int N, int M);
//
//int main() {
//	setlocale(LC_ALL, "ru");
//	int N, M, number;
//	cout << "Введите количество строк: ";
//	cin >> N;
//	cout << "\nВведите количество столбцов: ";
//	cin >> M;
//	cout << "Введите number: ";
//	cin >> number;
//	cout << endl;
//	int** A = new int*[N];
//	nw(A, N, M);
//	for (int i = 0; i < N; i++) {
//		for (int j = 0; j < M; j++) {
//			A[i][j] = rand() % 10;
//		}
//	}
//	cout << "Наш массив:\n";
//	for (int i = 0; i < N; i++) {
//		for (int j = 0; j < M; j++) {
//			cout << "A[" << i << ", " << j << "] = " << A[i][j] << "\t";
//		}
//		cout << endl;
//	}
//	for (int i = 0, j = 0; i < M; i++, j++) {
//		if (number == A[i][j]) {
//			cout << "Число number находится на главной диагонали\n";
//			break;
//		}
//		else if (i == M - 1) {
//			cout << "Числа number нет на главной диагонали\n";
//		}
//	}
//	for (int i = 0; i < N; i++) {
//		delete[] A[i];
//	}
//	delete[] A;
//}
//
//void nw(int** A, int N, int M) {
//	for (int i = 0; i < N; i++) {
//		A[i] = new int[M];
//	}
//}

//Задание 10.1
//Дан двумерный массив, состоящий из N строк и М столбцов, а также число k. Найти столбец, содержащий это число

//void nw(int** A, int N, int M);
//
//int main() {
//	setlocale(LC_ALL, "ru");
//	int N, M, k, myR, myC;
//	cout << "Введите количество строк: ";
//	cin >> N;
//	cout << "\nВведите количество столбцов: ";
//	cin >> M;
//	cout << "\nВведите k: ";
//	cin >> k;
//	int** A = new int *[N];
//	nw(A, N, M);
//	for (int i = 0; i < N; i++) {
//		for (int j = 0; j < M; j++) {
//			A[i][j] = rand() % 40;
//		}
//	}
//	for (int i = 0; i < N; i++) {
//		for (int j = 0; j < M; j++) {
//			cout << "A[" << i << ", " << j << "] = " << A[i][j] << "\t";
//		}
//		cout << endl;
//	}
//	for (int i = 0; i < N; i++) {
//		for (int j = 0; j < M; j++) {
//			if (A[i][j] == k) {
//				myR = i;
//				myC = j;
//				cout << "Число k находится в ячейке под номером: [" << myR << ", " << myC << "]\n";
//				for (int i = 0; i < N; i++) {
//					delete[] A[i];
//				}
//				delete[] A;
//				return 0;
//			}
//			else if (i == N - 1 && j == M - 1) {
//				cout << "Числа k нет в массиве\n";
//			}
//		}
//	}
//	for (int i = 0; i < N; i++) {
//		delete[] A[i];
//	}
//	delete[] A;
//}
//
//void nw(int** A, int N, int M) {
//	for (int i = 0; i < N; i++) {
//		A[i] = new int[M];
//	}
//}

//Задание 7.1
//Дан двумерный массив, состоящий из N строк и М столбцов, а также число d. Найти строку, содержащую число d

//void nw(int** A, int N, int M);
//
//int main() {
//	setlocale(LC_ALL, "ru");
//	int N, M, d;
//	cout << "Введите количество строк: ";
//	cin >> N;
//	cout << "\nВведите количество столбцов: ";
//	cin >> M;
//	cout << "\nВведите число d: ";
//	cin >> d;
//	int** A = new int* [N];
//	nw(A, N, M);
//	for (int i = 0; i < N; i++) {
//		for (int j = 0; j < M; j++) {
//			A[i][j] = rand() % 15;
//		}
//	}
//	for (int i = 0; i < N; i++) {
//		for (int j = 0; j < M; j++) {
//			cout << "A[" << i << ", " << j << "] = " << A[i][j] << "\t";
//		}
//		cout << endl;
//	}
//	for (int i = 0; i < M; i++) {
//		for (int j = 0; j < N; j++) {
//			if (A[i][j] == d) {
//				cout << "Число d находится в строке, под индексом " << i;
//				for (int i = 0; i < N; i++) {
//					delete[] A[i];
//				}
//				delete[] A;
//				return 0;
//			}
//			else if (i == M - 1 && j == N - 1) {
//				cout << "Числа d нет в массиве";
//			}
//		}
//	}
//	for (int i = 0; i < N; i++) {
//		delete[] A[i];
//	}
//	delete[] A;
//}
//
//void nw(int** A, int N, int M) {
//	for (int i = 0; i < N; i++) {
//		A[i] = new int[M];
//	}
//}