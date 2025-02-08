#include <iostream>

int main() {
	setlocale(LC_ALL, "ru");
	FILE* fa;
	FILE* fb;
	FILE* fc;
	int arr1[10], arr2[10], arr3[20];
	int sum1 = 0, sum2 = 0, sum3 = 0;

	errno_t err;
	err = fopen_s(&fa, "fileA16.1.txt", "w");

	if (err) {
	perror("Невозможно создать файл!\n");
		return EXIT_FAILURE;
	}

	for (int i = 0; i < 10; i++) {
		sum1 += *(arr1 + i) = rand() % 7;
		fprintf(fa, "%d, ", *(arr1 + i));
	}

	printf("Данные записаны в файл fileA16.1.txt\n");
	fclose(fa);


	err = fopen_s(&fb, "fileB16.1.txt", "w");

	if (err) {
		perror("Невозможно создать файл!\n");
		return EXIT_FAILURE;
	}

	for (int i = 0; i < 10; i++) {
		sum2 += *(arr2 + i) = rand() % 7;
		fprintf(fb, "%d, ", *(arr2 + i));
	}

	printf("Данные записаны в файл fileB16.1.txt\n");
	fclose(fb);


	err = fopen_s(&fc, "fileC16.1.txt", "w");

	if (err) {
		perror("Невозможно создать файл!\n");
		return EXIT_FAILURE;
	}

	for (int i = 0; i < 20; i++) {
		if (i < 10) {
			fprintf(fc, "%d, ", *(arr1 + i));
		}
		else {
			fprintf(fc, "%d, ", *(arr2 + i - 10));
		}
	}

	printf("Данные записаны в файл fileC16.1.txt\n");
	fclose(fc);
}