//#include <iostream>
//#include <Windows.h>
//
////Меняю цвет текста
//
//void main() {
//	HANDLE handle = GetStdHandle(STD_OUTPUT_HANDLE);
//
//	enum Colors {
//		BLACK,
//		BLUE,
//		GREEN,
//		GOLYBOI,
//		RED,
//		LILOVIY,
//		YELLOW,
//		WHITE,
//		GRAY
//	} color;
//
//	printf("Your color is ...?(0-8)\n");
//	scanf_s("%d", &color);
//	SetConsoleTextAttribute(handle, color);
//
//	switch (color) {
//		case BLACK:
//			printf("Your color is black");
//			break;
//		case BLUE:
//			printf("Your color is blue");
//			break;
//		case GREEN:
//			printf("Your color is green");
//			break;
//		case GOLYBOI:
//			printf("Your color is golyboi");
//			break;
//		case RED:
//			printf("Your color is red");
//			break;
//		case LILOVIY:
//			printf("Your color is liloviy");
//			break;
//		case YELLOW:
//			printf("Your color is yellow");
//			break;
//		case WHITE:
//			printf("Your color is white");
//			break;
//		case GRAY:
//			printf("Your color is gray");
//			break;
//		default: printf("Error");
//	}
//	SetConsoleTextAttribute(handle, 7);
//}
//
