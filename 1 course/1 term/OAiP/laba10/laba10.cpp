#include <iostream>
#include <ctime> 
using namespace std;

//Задание 11.1
int main() {
	setlocale(LC_ALL, "Russian");
    int i, size, arr[20];
    cout << "Введите размерность массива(не более 20): " << endl;
    cin >> size;
    cout << "Исходные элементы массива: " << endl;
    for (i = 0; i < size; i++) {
        arr[i] = rand() % size;
        cout << arr[i] << endl;
    }
    cout << "После удаления 5 элементов" << endl;
    for (i = 0; i < size; i++) {
        if (i < 10) {
            if (i % 2 == 1) {
                cout << arr[i] << endl;
          }
        }
        else {
            cout << arr[i] << endl;
        }
    }
    cout << "Добавляем 3 нулевых элемента: " << endl;
    for (i = 0; i < size + 3; i++) {
        if (i < 10) {
            if (i % 2 == 1) {
                cout << arr[i] << endl;
            }
        }
        else if(i < size) {
            cout << arr[i] << endl;
        }
        else {
            cout << "0" << endl;
        }
    }
}
// Задание 11.2
//int main() {
//	setlocale(LC_ALL, "Russian");
//	int i, arr[20], k, l;
//	cout << "Введите размерность массива: " << endl;
//	cin >> k;
//	cout << "Исходный массив: " << endl;
//	for (i = 0; i < k; i++) {
//		arr[i] = rand() % k;
//		cout << arr[i] << endl;
//	}
//	cout << "Конечный массив: " << endl;
//	for (i = 0; i < k; i++) {
//
//	}
// }









// //задание 12-1
//int main()
//{
//    setlocale(LC_CTYPE, "Russian");
//    int i, n, t[20], min;
//    cout << "Введите размерность массива(не более 20): " << endl;
//    cin >> n;
//    cout << "Элементы массива до замены: " << endl;
//    for (i = 0; i <= n; i++)
//    {
//        t[i] = rand() % n + 1;
//        cout << t[i] << endl;
//    }
//    min = t[0];
//    for (int i = 0; i < n; i++)
//    {
//        if (t[i] < min)
//        {
//            min = t[i];
//            cout << "Минимальный элемент массива: " << min << endl;
//        }
//    }
//    cout << "После: " << endl;
//    for (i = 0; i < n; i++)
//    {
//        if (i % 2 == 0)
//        {
//            t[i] = min;
//        }
//        cout << t[i] << endl;
//    }
//}
 
//////задание 2-1
//int main()
//{
//  setlocale(LC_ALL, "Russian");
//  int n, k[99];
//  cout << "Введите кол-во элементов массива n" << endl;
//  cin >> n;
//  srand((unsigned)time(NULL));
//  cout << "Массив K(n): ";
//  for (int i = 0; i < n; i++) {
//    k[i] = rand() % 99;
//    cout << k[i] << ' ';
//  }
//  cout << endl << "Массив L(n), состоящий из четных элементов массива K(n): ";
//  for (int j = 1; j < n; j = j + 2) {
//    cout << k[j] << ' ';
//  }
//  cout << endl << "Массив M(n), состоящий из нечетных элементов массива K(n): ";
//  for (int a = 0; a < n; a = a + 2) {
//    cout << k[a] << ' ';
//  }
//}
//задание 2-2
//int main()
//{
//  setlocale(LC_ALL, "Russian");
//  int k, n, A[99];
//  cout << "Введите кол-во элементов массива k" << endl;
//  cin >> k;
//  srand((unsigned)time(NULL));
//  cout << "Массив А(k): ";
//  for (int i = 0; i < k; i++) {
//    A[i] = rand() % 99;
//    cout << A[i] << " ";
//  }
//  cout << endl << "На сколько позиций вправо хотите переместить элементы массива?" << endl;
//  cin >> n;
//  cout << "Наш новый массив: " << endl;
//  for (int j = 0; j < k; j++) {
//    if (j + n < k) {
//      cout << A[j + n] << " ";
//    }
//    else {
//      cout << A[j + n - k] << " ";
//    }
//  }
//}

//задание 16-1
//int main(){
//  setlocale(LC_ALL, "Russian");
//  srand((unsigned)time(NULL));
//  int a[100], k;
//  cout << "Введите кол-во элементов массива" << endl;
//  cin >> k;
//  cout << "Исходный массив: ";
//  for (int i = 0; i < k; i++) {
//    a[i] = rand() % 100;
//    cout << a[i] << " ";
//  }
//  int max = 0;
//  for (int i = 0; i < k; i++) {
//    if (a[i] > max) 
//    max = a[i];
//  }
//  cout << endl << "max is " << max << endl;
//  int min = 100;
//  for (int i = 0; i < k; i++) {
//    if (a[i] < min)
//    min = a[i];
//  }
//  cout << "min is " << min << endl;
//}
//задание 10-1
//int main() {
//  setlocale(LC_ALL, "Russian");
//    srand((unsigned)time(NULL));
//    int a[100], k, avr = 0;
//    cout << "Введите кол-во элементов массива" << endl;
//    cin >> k;
//    cout << "Исходный массив: ";
//    for (int i = 0; i < k; i++) {
//      a[i] = rand() % 100;
//      cout << a[i] << " ";
//    }
//    avr = (a[k - 1] + a[k - 2] + a[k - 3]) / 3;
//    cout << endl << "avr = " << avr << endl;
//    for (int i = 0; i < k; i++) {
//      if (a[i] == avr) cout << "Элемент " << a[i] << " равен среднему арифметическому трех последних элементов массива." << endl;
//
//      else
//        cout << "Такого элемента нету."; break;
//}
//    
//}
