#include "Auxil.h"                            // вспомогательные функции 
#include <iostream>
#include <ctime>
#include <locale>
#include <stdlib.h>

using namespace std;
//#define CYCLE 100

//Начало функции нахождения факториала

//Конец функции нахождения факториала



long double fact(int N)
{
	if (N < 0) // если пользователь ввел отрицательное число
		return 0; // возвращаем ноль
	if (N == 0) // если пользователь ввел ноль,
		return 1; // возвращаем факториал от нуля - не удивляетесь, но это 1 =)
	else // Во всех остальных случаях
		return N * fact(N - 1); // делаем рекурсию.
}

int main()
{
	/*int N = 21;*/

	double  av1 = 0, av2 = 0;
	clock_t  t1 = 0, t2 = 0;

	setlocale(LC_ALL, "rus");
	auxil::start();                          // старт генерации 
	t1 = clock();                            // фиксация времени 

	
	int N;
	setlocale(0, ""); // Включаем кириллицу
	cout << "Введите число для вычисления факториала: ";
	cin >> N;
	cout << "Факториал для числа " << N << " = " << fact(N) << endl << endl; // fact(N) - функция для вычисления факториала.

	t2 = clock();                            // фиксация времени 


	std::cout << std::endl << "продолжительность (у.е):   " << (t2 - t1);
	std::cout << std::endl << "                  (сек):   " << ((double)(t2 - t1)) / ((double)CLOCKS_PER_SEC);
	std::cout << std::endl;
	system("pause");
	return 0;
}