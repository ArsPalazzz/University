//#include <iostream>
//#define SIZE 8
//
////������ ������ �, � ������ � ����������� ��� �������� ������� �, ������� ������ ��������. 
////������ � ������������� �� �����������, ��������� ��������� ����������: ���������� �����, ���������� �������
//
//void selectSort(int* arr, int size);
//
//void main() {
//	setlocale(LC_ALL, "ru");
//	int A[SIZE];
//	int B[SIZE];
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
//
//   int j = 0;
//   for (int i = 0; i < SIZE; i++) {
//	   if (*(A + i) % 2 == 0) {
//		   *(B + j) = *(A + i);
//		   ++j;
//	   }
//   }
//
//   printf("\n������ B: ");
//
//   for (int i = 0; i < j; i++) {
//	   printf("%d\t", *(B + i));
//   }
//
//   selectSort(B, j);
//
//   printf("\n������ B ����� ����������: ");
//
//   for (int i = 0; i < j; i++) {
//	   printf("%d\t", *(B + i));
//   }
//}
//
//void selectSort(int *arr, int size)
//{
//	int k, i, j;
//	for (i = 0; i < 5 - 1; i++)
//	{
//		for (j = i + 1, k = i; j < size; j++)
//			if (arr[j] < arr[k])
//				k = j;
//		int c = arr[k];
//		arr[k] = arr[i];
//		arr[i] = c;
//	}
//}

