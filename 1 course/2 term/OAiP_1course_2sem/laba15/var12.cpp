//#include <iostream>
//#define SIZE 6
//
////������ ������ �. � ������ � ����������� �������� ������� �, ������� ������ ������. ������ � ������������� �� �����������, 
////��������� ��������� ����������: ��������, ���������� �������
//
//void bubbleSort(int* arr);
//
//void main() {
//    setlocale(LC_ALL, "ru");
//    int* A = new int[SIZE];
//    int* B = new int[SIZE / 2];
//
//    for (int i = 0; i < SIZE; i++) {
//        *(A + i) = rand() % 20;
//    }
//
//    printf("������ A: ");
//
//    for (int i = 0; i < SIZE; i++) {
//        printf("%d\t", *(A + i));
//    }
//
//    int j = 0;
//    for (int i = 0; i < SIZE; i += 2) {
//        *(B + j) = *(A + i);
//        ++j;
//    }
//
//    printf("\n������ B: ");
//
//    for (int i = 0; i < SIZE / 2; i++) {
//        printf("%d\t", *(B + i));
//    }
//
//    bubbleSort(B);
//
//    printf("\n������ B ����� ����������: ");
//
//    for (int i = 0; i < SIZE / 2; i++) {
//        printf("%d\t", *(B + i));
//    }
//}
//
//void bubbleSort(int* arr) {
//    int i, j, t;
//    for (i = 1; i < SIZE / 2; i++)
//        for (j = (SIZE / 2) - 1; j >= i; j--)
//            if (arr[j - 1] > arr[j])
//            {
//                t = arr[j - 1];
//                arr[j - 1] = arr[j];
//                arr[j] = t;
//            }
//}