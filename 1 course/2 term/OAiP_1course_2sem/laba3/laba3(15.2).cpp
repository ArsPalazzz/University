//#include <iostream>
//#include <fstream>
//#define MAXSLOV 6
//#define MAXBYKVVSLOVE 5
//using namespace std;
//
////. ������ � ���������� ������ ��������, ��������� �� ����, ����������� ���������, � �������� �� � ����. 
////��������� �� ����� ������ � ������� ��� �����, ������� �������� ����� �x�.
//
//void main() {
//	setlocale(LC_ALL, "RU");
//	char* mystr = new char [40];
//	gets_s(mystr, 40);
//	char** allstr = new char* [MAXSLOV];
//
//	for (int i = 0; i < 6; i++) {
//		*(allstr + i) = new char[MAXBYKVVSLOVE];
//	}
//	int iformystr = 0;
//	int kolichslov = 1;
//
//	ofstream of("file15.2.txt");
//
//	for (int i = 0; i < MAXSLOV; i++) {
//		for (int j = 0; j < MAXBYKVVSLOVE; j++) {
//			if (*(mystr + iformystr) == ' ') {
//				of << "\n";
//				++iformystr;
//				++kolichslov;
//				break;
//			}
//			if (*(mystr + iformystr) == NULL) {
//				break;
//			}
//			*(*(allstr + i) + j) = *(mystr + iformystr);
//			of << *(*(allstr + i) + j);
//			++iformystr;
//		}
//	}
//
//	of.close();
//	cout << "������ �������� � ���� file15.2.txt" << endl;
//
//	for (int i = 0; i < kolichslov; i++) {
//		for (int j = 0; j < MAXBYKVVSLOVE; j++) {
//			if (*(*(allstr + i) + j) == 'x') {
//				for (j = 0; j < MAXBYKVVSLOVE; j++) {
//					if (*(*(allstr + i) + j) == NULL) {
//						break;
//					}
//					cout << *(*(allstr + i) + j);
//				}
//				cout << endl;
//			}
//		}
//	}
//
//	for (int i = 0; i < 6; i++) {
//		delete[] * (allstr + i);
//	}
//
//	delete[] allstr;
//	
//}