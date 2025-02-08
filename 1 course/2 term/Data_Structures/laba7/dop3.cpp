#include <iostream>

void main() {
	setlocale(LC_ALL, "ru");
	const char* myArr[] = { "a?", "yes", "no", "hohoho?" };
	
	printf("Все строки:\n");

	for (int i = 0; i < sizeof(myArr) / sizeof(myArr[0]); i++) {
		printf("%s\n", myArr[i]);
	}

	printf("Вопросительные предложения:\n");

	for (int i = 0; i < sizeof(myArr) / sizeof(myArr[0]); i++) {
		for (int j = 0; j < sizeof(*(myArr + j)); j++) {
			if (*(*(myArr + i) + j - 1) == '?') {
				printf("%s\n", myArr[i]);
			}
		}
	}
}