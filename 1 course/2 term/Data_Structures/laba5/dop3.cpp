//#include <iostream>
//#include <fstream>
//using namespace std;
//
//
////����������� �� ����� FILE1 � ���� FILE2 ��� ������, ������� �������� ������ ���� �����. ���������� ���������� �������� � ����� FILE2.
//
//void  main() {
//	setlocale(LC_ALL, "ru");
//	ofstream fa("FILE1(10.1).txt");
//	ofstream fb("FILE2(10.1).txt");
//	int kolichchrvf2 = 0;
//	const char* mystr[] = { "hello", "no no", "zeze", "hd dh pk" };
//	for (int i = 0; i < sizeof(mystr) / sizeof(mystr[0]); i++) {
//		fa << *(mystr + i) << endl;
//	}
//
//	fa.close();
//
//	for (int i = 0; i < sizeof(mystr) / sizeof(mystr[0]); i++) {
//		int kolichProbel = 0;
//		for (int j = 0; i < 10; j++) {
//			if ((*(*(mystr + i) + j) == NULL)) {
//				break;
//			}
//			else if (*(*(mystr + i) + j) == ' ') {
//				kolichProbel++;
//			}
//		}
//		if (kolichProbel == 0) {
//			for (int j = 0; j < 10; j++) {
//				if (*(*(mystr + i) + j) == NULL) {
//					break;
//				}
//				fb << *(*(mystr + i) + j);
//				kolichchrvf2++;
//			}
//			fb << endl;
//		}
//	}
//
//	cout << "���������� �������� � ����� fileB " << kolichchrvf2;
//}