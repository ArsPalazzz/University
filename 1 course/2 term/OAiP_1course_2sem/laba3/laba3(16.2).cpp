//#include <iostream>
//#include <fstream>
//using namespace std;
//
////Ввести с клавиатуры строку символов, состоящую из цифр и слов, разделенных пробелами, и записать ее в файл. 
////Прочитать из файла данные и вывести четные числа строки.
//
//void main() {
//	char mystr[50];
//	ofstream f("file16.2.txt");
//	gets_s(mystr);
//	f << mystr;
//
//	for (int i = 0; i < 50; i++) {
//		if (*(mystr + i) == NULL) {
//			break;
//		}
//		else if (* (mystr + i) == '0' || *(mystr + i) == '2' || *(mystr + i) == '4' || *(mystr + i) == '6' || *(mystr + i) == '8') {
//			cout << *(mystr + i);
//		}
//	}
//}