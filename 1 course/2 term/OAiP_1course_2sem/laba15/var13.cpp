//#include <iostream>
//#define SIZE 12
//
////������ ������ �, � ������ � ��������� ��� �������� ������� �, ������� ������ ������������� �������� � ������� ������ ������. 
////������ � ������������� �� ��������, ��������� ��������� ����������: ��������, ���������� �����.
//
//void bubbleSort(int* arr, int myI);
//
//void main() {
//	setlocale(LC_ALL, "ru");
//	int* A = new int[SIZE];
//	int* B = new int[SIZE];
//
//	for (int i = 0; i < SIZE; i++) {
//		*(A + i) = rand() % 14;
//	}
//
//	printf("������ A: ");
//
//   for (int i = 0; i < SIZE; i++) {
//        printf("%d\t", *(A + i));
//   }
//   int max = 0, myI;
//   for (int i = 0; i < SIZE; i++) {
//	   if (*(A + i) > max) {
//		   max = *(A + i);
//		   myI = i;
//	   }
//   }
//
//   int j = 0;
//   for (int i = myI + 1; i < SIZE; i++) {
//	   if (i % 2 == 0) {
//		   *(B + j) = *(A + i);
//		   ++j;
//	   }
//   }
//
//   printf("\n������ B: ");
//
//   for (int i = 0; i < (SIZE - myI - 1) / 2; i++) {
//	   printf("%d\t", *(B + i));
//   }
//
//   bubbleSort(B, myI);
//
//   printf("\n������ B ����� ����������: ");
//
//   for (int i = 0; i < (SIZE - myI - 1) / 2; i++) {
//	   printf("%d\t", *(B + i));
//   }
//}
//
//void bubbleSort(int* arr, int myI) {
//	int n = (SIZE - myI - 1) / 2;
//	for (int i = 0; i < n; i++) {
//		for (int j = i + 1; j < n; j++) {
//			if (arr[i] < arr[j]) {
//				//������ ������� ��������
//				std::swap(arr[i], arr[j]);
//			}
//		}
//	}
//}
