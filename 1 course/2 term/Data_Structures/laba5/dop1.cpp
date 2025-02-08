#include <iostream>
#include <fstream>
using namespace std;


//Скопировать из файла FILE1 в файл FILE2 все строки, которые содержат только одно слово. Найти слово, содержащее 5 символов, в файле FILE2.

void  main() {
	setlocale(LC_ALL, "ru");
	ofstream fa("FILE1(7.1).txt");
	ofstream fb("FILE2(7.1).txt");
	const char* mystr[] = { "hehe", "no no", "zeze", "hd dh pk" };
	for (int i = 0; i < sizeof(mystr) / sizeof(mystr[0]); i++) {
		fa << *(mystr + i) << endl;
	}

	fa.close();

	for (int i = 0; i < sizeof(mystr) / sizeof(mystr[0]); i++) {
		int kolichProbel = 0;
		for (int j = 0; i < 10; j++) {
			if ((*(*(mystr + i) + j) == NULL)) {
				break;
			}
			else if (*(*(mystr + i) + j) == ' ') {
				kolichProbel++;
			}
		}
		if (kolichProbel == 0) {
			for (int j = 0; j < 10; j++) {
				if (*(*(mystr + i) + j) == NULL) {
					break;
				}
				fb << *(*(mystr + i) + j);;
			}
			fb << endl;
		}
	}
	int numb = 0;
	for (int i = 0; i < sizeof(mystr) / sizeof(mystr[0]); i++) {
		for (int j = 0; j < 5; j++) {
			if ((* (*(mystr + i) + j) != ' ') && (*(*(mystr + i) + j) != NULL)) {
				numb++;
			}
			else if ((*(*(mystr + i) + j) == ' ') || (*(*(mystr + i) + j) == NULL)) {
				numb = 0;
			}
			else if (numb == 5) {
				cout << *(mystr + i);
			}
		}
	}
}