//#include <iostream>
//#include <stdio.h>
//
////Создать текстовый файл F1 не менее, чем из 5 строк, и записать в него информацию. 
////Скопировать в файл F2 только строки из F1, которые не содержат цифр. 
//int main() {
//	setlocale(LC_ALL, "ru");
//	FILE* ff;
//	FILE* sf;
//	bool chislo = false;
//
//	const char* str[] = { "hello", "su4", "dude", "2b", "maaan"};
//	errno_t err;
//	err = fopen_s(&ff, "fileA10.2.txt", "w");
//
//	if (err) {
//		perror("Невозможно создать файл!\n");
//		return EXIT_FAILURE;
//	}
//
//	for (int i = 0; i < sizeof(str)/sizeof(str[0]); i++)
//	{
//		fputs(*(str + i), ff);
//		fprintf(ff, "\n");
//	}
//
//	printf("Данные записаны в файл fileA10.2.txt\n");
//	fclose(ff);
//
//	const char* str2[sizeof(str)];
//	err = fopen_s(&sf, "fileB10.2.txt", "w");
//
//	if (err) {
//		perror("Невозможно создать файл!\n");
//		return EXIT_FAILURE;
//	}
//
//	for (int i = 0; i < sizeof(str) / sizeof(str[0]); i++) {
//		for (int j = 0; j < 6; j++) {
//			if ((( * (*(str + i) + j)) >= '0') && ((*(*(str + i) + j)) <= '9')) {
//				chislo = true;
//			}
//		}
//		if (chislo == false) {
//			fputs(*(str + i), sf);
//			fprintf(sf, "\n");
//		}
//		chislo = false;
//	}
//
//	printf("Данные записаны в файл fileB10.2.txt\n");
//	fclose(sf);
//
//}
