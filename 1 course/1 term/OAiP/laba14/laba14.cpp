#include <iostream>
#include <ctime>
using namespace std;
//Задание 11.1
//Найти наибольший элемент главной диагонали матрицы A(n, n) и вывести на печать всю строку, в которой он находится
//int main() {
//	const int n = 3;
//	int A[n][n];
//	setlocale(LC_ALL, "ru");
//	srand((unsigned)time(NULL));
//	int strI = 0;
//	for (int i = 0; i < n; i++) {
//		for (int j = 0; j < n; j++) {
//			A[i][j] = rand() % 10;
//		}
//	}
//	cout << "Исходный массив: " << endl;
//	for (int i = 0; i < n; i++) {
//		for (int j = 0; j < n; j++) {
//			cout << "A[" << i << ", " << j << " ] = " << A[i][j] << "\t";
//		}
//		cout << endl;
//	}
//	int max = A[0][0];
//	cout << "Элементы главной диагонали:\n";
//	for (int i = 0, j = 0; i < 3, j < 3; i++, j++) {
//		if (A[i][j] > max) {
//			max = A[i][j];
//			strI = i;
//		}
//		cout << A[i][j] << "\t";
//	}
//	cout << "\nМаксимальный элемент массива: " << max << endl;
//	for (int j = 0; j < 3; j++) {
//		cout << "A[ " << strI << ", " << j << " ] = " << A[strI][j] << "\t";
//	}
//}
//Задание 11.2
//Определить в матрице первый столбец, все элементы которого отрицательны, и среднее арифметическое этих элементов. Вычесть полученное значение из всех элементов матрицы
int main() {
	setlocale(LC_ALL, "ru");
	int A[3][3], avr;
	for (int i = 0; i < 3; i++) {
		for (int j = 0; j < 3; j++) {
			A[i][j] = rand() % 10 - 5;
		}
	}
	cout << "Исходный массив:\n";
	for (int i = 0; i < 3; i++) {
		for (int j = 0; j < 3; j++) {
			cout << "A[" << i << ", " << j << "] = " << A[i][j] << "\t";
		}
		cout << endl;
	}
	for (int j = 0; j < 3; j++) {
		for (int i = 0; i < 3; i++) {
			if (*(A[0] + j) < 0 && *(A[1] + j) < 0 && *(A[2] + j) < 0) {
				avr = (*(A[0] + j) + *(A[1] + j) + *(A[2] + j)) / 3;
				return;
			}
		}
	}
	cout << "Среднее арифметическое: " << avr;
	cout << "\nКонечный массив:\n";
	for (int i = 0; i < 3; i++) {
		for (int j = 0; j < 3; j++) {
			cout << "A[" << i << ", " << j << "] = " << A[i][j] - avr << "\t";
		}
		cout << endl;
	}
}
// 
//Задание 15.1
//В заданном массиве A(n, n) вычислить две суммы элементов, расположенных выше и ниже главной диагонали
//int main() {
//	const int n = 3;
//	int A[n][n];
//	setlocale(LC_ALL, "ru");
//	srand((unsigned)time(NULL));
//	for (int i = 0; i < n; i++) {
//		for (int j = 0; j < n; j++) {
//			A[i][j] = rand() % 10;
//		}
//	}
//	cout << "Исходный массив:\n";
//	for (int i = 0; i < n; i++) {
//		for (int j = 0; j < n; j++) {
//			cout << "A[ " << i << ", " << j << " ] = " << A[i][j] << "\t";
//		}
//		cout << endl;
//	}
//	int sumD = 0;
//	int sumU = 0;
//	for (int i = 0; i < n; i++) {
//		for (int j = 0; j < n; j++) {
//			if ((i == 1 && j == 0) || (i == 2 && j == 0) || (i == 2 && j == 1)) {
//				sumD += A[i][j];
//			}
//			else if ((i == 0 && j == 1) || (i == 0 && j == 2) || (i == 1 && j == 2)) {
//				sumU += A[i][j];
//			}
//		}
//	}
//	cout << "Сумма элементов под главной диагональю: " << sumD << endl;
//	cout << "Сумма элементов над главной диагональю: " << sumU;
//}
//Вариант 8.2
//Проверить, есть ли в матрице хотя бы одна строка, содержащая отрицательный элемент, и найти ее номер. Все элементы столбца с таким же номером уменьшить вдвое
//int main() {
//	const int n = 3, m = 3;
//	int A[n][m];
//	setlocale(LC_ALL, "ru");
//	for (int i = 0; i < n; i++) {
//		for (int j = 0; j < m; j++) {
//			A[i][j] = rand() % 10 - 1;
//		}
//	}
//	int otrEl;
//	for (int i = 0; i < n; i++) {
//		for (int j = 0; j < m; j++) {
//			cout << "A[ " << i << ", " << j << " ] = " << A[i][j] << "\t";
//			if (A[i][j] < 0) {
//				otrEl = i + 1;
//			}
//		}
//		cout << endl;
//	}
//	cout << "\nНомер строки с отрицательным элементом: " << otrEl << endl;
//	cout << "\nМассив, после уменьшения строчки элементов вдвое:\n";
//	for (int i = 0; i < n; i++) {
//		for (int j = 0; j < m; j++) {
//			if (i == otrEl - 1) {
//				cout << "A[ " << i << ", " << j << " ] = " << A[i][j] / 2 << "\t";
//			}
//			else {
//				cout << "A[ " << i << ", " << j << " ] = " << A[i][j] << "\t";
//			}
//		}
//		cout << endl;
//	}
//}
//Вариант 13.1
//Найти наименьший элемент главной диагонали матрицы С(n, n) и вывести на печать столбец, в котором он находится
//int main() {
//	const int n = 3;
//	int C[n][n];
//	int ik, jk;
//	setlocale(LC_ALL, "ru");
//	srand((unsigned)time(NULL));
//	for (int i = 0; i < n; i++) {
//		for (int j = 0; j < n; j++) {
//			C[i][j] = rand() % 10;
//		}
//	}
//	for (int i = 0; i < n; i++) {
//		for (int j = 0; j < n; j++) {
//			cout << "C[ " << i << ", " << j << " ] = " << C[i][j] << "\t";
//		}
//		cout << endl;
//	}
//	int min = C[0][0];
//	ik = 0;
//	jk = 0;
//	for (int i = 1, j = 1; i < 3, j < 3; i++, j++) {
//		if (C[i][j] < min) {
//			min = C[i][j];
//			ik = i;
//			jk = j;
//		}
//	}
//	cout << "Минимальный элемент главной диагонали: C[ " << ik << ", " << jk << " ] = " << C[ik][jk] << endl;
//	cout << "Столбец, в котором находится минимальный элемент:\n";
//	for (int i = 0; i < 3; i++) {
//		cout << "C[" << i << ", " << jk << "] = " << C[i][jk] << endl;
//	}
//}





