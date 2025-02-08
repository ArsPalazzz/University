#include <iostream>
#define iMAX 4
#define jMAX 6
using namespace std;

void main() {
	setlocale(LC_ALL, "ru");
	int j = 1;
	for (int i = 1; i < iMAX; i++) {
		if (i == 2)
			continue;
		printf("\n%d. Виды", i);
		j = 1;
		while (j < jMAX) {
			if (j == 4)
				break;
			printf("\n%d.%d. Подвиды", i, j);
			j++;
		}
	}
}

