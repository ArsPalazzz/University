// Main      
//#include "stdafx.h"
#include <stdio.h>
#include <iostream>
#include "Combi.h"
#include "Combi2.h"
#include "Combi3.h"
#include "Combi4.h"
#include "Knapsack.h"
#include <time.h>
#include <iomanip> 
#define NN 18
#define NNN (sizeof(c2)/sizeof(int) - 4)
#define N (sizeof(AA4)/2)
#define M 3


int main()
{
    setlocale(LC_ALL, "rus");
    char  AA[][2] = { "A", "B", "C", "D" };
    std::cout << std::endl << " - Генератор множества всех подмножеств -";
    std::cout << std::endl << "Исходное множество: ";
    std::cout << "{ ";
    for (int i = 0; i < sizeof(AA) / 2; i++)
        std::cout << AA[i] << ((i < sizeof(AA) / 2 - 1) ? ", " : " ");
    std::cout << "}";
    std::cout << std::endl << "Генерация всех подмножеств  ";
    combi::subset s1(sizeof(AA) / 2);         // создание генератора   
    int  n = s1.getfirst();                // первое (пустое) подмножество    
    while (n >= 0)                          // пока есть подмножества 
    {
        std::cout << std::endl << "{ ";
        for (int i = 0; i < n; i++)
            std::cout << AA[s1.ntx(i)] << ((i < n - 1) ? ", " : " ");
        std::cout << "}";
        n = s1.getnext();                   // cледующее подмножество 
    };
    std::cout << std::endl << "всего: " << s1.count() << std::endl;
    system("pause");




        int V = 300,                // вместимость рюкзака              
            v[NN],     // размер предмета каждого типа  
            c[NN];     // стоимость предмета каждого типа 
        short m[NN];                // количество предметов каждого типа  {0,1}  

        for (int i = 0; i < NN; i++)
        {
            v[i] = 10 + rand() % 290;
        }

        for (int i = 0; i < NN; i++)
        {
            c[i] = 5 + rand() % 50;
        }

        int maxcc = knapsack_s(

            V,   // [in]  вместимость рюкзака 
            NN,  // [in]  количество типов предметов 
            v,   // [in]  размер предмета каждого типа  
            c,   // [in]  стоимость предмета каждого типа     
            m    // [out] количество предметов каждого типа  
        );

        std::cout << std::endl << "-------- Задача о рюкзаке --------- ";
        std::cout << std::endl << "- количество предметов : " << NN;
        std::cout << std::endl << "- вместимость рюкзака  : " << V;
        std::cout << std::endl << "- размеры предметов    : ";
        for (int i = 0; i < NN; i++) std::cout << v[i] << " ";
        std::cout << std::endl << "- стоимости предметов  : ";
        for (int i = 0; i < NN; i++) std::cout << c[i] << " ";
        std::cout << std::endl << "- оптимальная стоимость рюкзака: " << maxcc;
        std::cout << std::endl << "- вес рюкзака: ";
        int s = 0; for (int i = 0; i < NN; i++) s += m[i] * v[i];
        std::cout << s;
        std::cout << std::endl << "- выбраны предметы: ";
        for (int i = 0; i < NN; i++) std::cout << " " << m[i];
        std::cout << std::endl << std::endl;

        system("pause");





    //// Установить начальную точку генерирования последовательности
    //// использовать функцию time(NULL)
    //srand(time(NULL));
    //    int V = 300,                // вместимость рюкзака              
    //        v[18],     // размер предмета каждого типа  
    //        c[18];     // стоимость предмета каждого типа 
    //    short m[NN];                // количество предметов каждого типа  {0,1}   

    //    int maxcc = knapsack_s(

    //        V,   // [in]  вместимость рюкзака 
    //        NN,  // [in]  количество типов предметов 
    //        v,   // [in]  размер предмета каждого типа  
    //        c,   // [in]  стоимость предмета каждого типа     
    //        m    // [out] количество предметов каждого типа  
    //    );

    //    for (int i = 0; i < NN; i++)
    //    {
    //        v[i] = 10 + rand() % 290;
    //    }

    //    for (int i = 0; i < NN; i++)
    //    {
    //        c[i] = 5 + rand() % 50;
    //    }



    //    std::cout << std::endl << "-------- Задача о рюкзаке --------- ";
    //    std::cout << std::endl << "- количество предметов : " << NN;
    //    std::cout << std::endl << "- вместимость рюкзака  : " << V;
    //    std::cout << std::endl << "- размеры предметов    : ";
    //    for (int i = 0; i < NN; i++) std::cout << v[i] << " ";
    //    std::cout << std::endl << "- стоимости предметов  : ";
    //    for (int i = 0; i < NN; i++) std::cout << c[i] << " ";
    //    std::cout << std::endl << "- оптимальная стоимость рюкзака: " << maxcc;
    //    std::cout << std::endl << "- вес рюкзака: ";
    //    int s = 0; for (int i = 0; i < NN; i++) s += m[i] * v[i];
    //    std::cout << s;
    //    std::cout << std::endl << "- выбраны предметы: ";
    //    for (int i = 0; i < NN; i++) std::cout << " " << m[i];
    //    std::cout << std::endl << std::endl;

    //    system("pause");  






        // задача о рюкзаке
            int V2 = 600,              // вместимость рюкзака              
                v2[] = { 25, 56, 67, 40, 20, 27, 37, 33, 33, 44, 53, 12,
                       60, 75, 12, 55, 54, 42, 43, 14, 30, 37, 31, 12 },
                c2[] = { 15, 26, 27, 43, 16, 26, 42, 22, 34, 12, 33, 30,
                       12, 45, 60, 41, 33, 11, 14, 12, 25, 41, 30, 40 };
            short m2[NNN];
            int maxcc2 = 0;
            clock_t t1, t2;
            std::cout << std::endl << "-------- Задача о рюкзаке --------- ";
            std::cout << std::endl << "- вместимость рюкзака  : " << V2;
            std::cout << std::endl << "-- количество ------ продолжительность -- ";
            std::cout << std::endl << "    предметов          вычисления  ";
            for (int i = 12; i <= NNN; i++)
            {
                t1 = clock();
                maxcc = knapsack_s(V2, i, v2, c2, m2);
                t2 = clock();
                std::cout << std::endl << "       " << std::setw(2) << i
                    << "               " << std::setw(5) << (t2 - t1);
            }
            std::cout << std::endl << std::endl;
            system("pause");



            // сочетания
            char  AA2[][2] = { "A", "B", "C", "D", "E" };
            std::cout << std::endl << " --- Генератор сочетаний ---";
            std::cout << std::endl << "Исходное множество: ";
            std::cout << "{ ";
            for (int i = 0; i < sizeof(AA2) / 2; i++)

                std::cout << AA2[i] << ((i < sizeof(AA2) / 2 - 1) ? ", " : " ");
            std::cout << "}";
            std::cout << std::endl << "Генерация сочетаний ";
            combi::xcombination xc(sizeof(AA2) / 2, 3);
            std::cout << "из " << xc.n << " по " << xc.m;
            int  n2 = xc.getfirst();
            while (n2 >= 0)
            {

                std::cout << std::endl << xc.nc << ": { ";

                for (int i = 0; i < n2; i++)


                    std::cout << AA2[xc.ntx(i)] << ((i < n2 - 1) ? ", " : " ");

                std::cout << "}";

                n2 = xc.getnext();
            };
            std::cout << std::endl << "всего: " << xc.count() << std::endl;
            system("pause");




            // перестановка
                char  AA3[][2] = { "A", "B", "C", "D" };
                std::cout << std::endl << " --- Генератор перестановок ---";
                std::cout << std::endl << "Исходное множество: ";
                std::cout << "{ ";
                for (int i = 0; i < sizeof(AA3) / 2; i++)

                    std::cout << AA3[i] << ((i < sizeof(AA3) / 2 - 1) ? ", " : " ");
                std::cout << "}";
                std::cout << std::endl << "Генерация перестановок ";
                combi::permutation p(sizeof(AA3) / 2);
                __int64  n3 = p.getfirst();
                while (n3 >= 0)
                {
                    std::cout << std::endl << std::setw(4) << p.np << ": { ";

                    for (int i = 0; i < p.n; i++)

                        std::cout << AA[p.ntx(i)] << ((i < p.n - 1) ? ", " : " ");

                    std::cout << "}";

                    n3 = p.getnext();
                };
                std::cout << std::endl << "всего: " << p.count() << std::endl;
                system("pause");





                // размещение
                char  AA4[][2] = { "A", "B", "C", "D" };
                std::cout << std::endl << " --- Генератор размещений ---";
                std::cout << std::endl << "Исходное множество: ";
                std::cout << "{ ";
                for (int i = 0; i < N; i++)

                    std::cout << AA4[i] << ((i < N - 1) ? ", " : " ");
                std::cout << "}";
                std::cout << std::endl << "Генерация размещений  из  " << N << " по " << M;
                combi::accomodation s2(N, M);
                int  n4 = s2.getfirst();
                while (n4 >= 0)
                {

                    std::cout << std::endl << std::setw(2) << s2.na << ": { ";

                    for (int i = 0; i < 3; i++)

                        std::cout << AA[s2.ntx(i)] << ((i < n - 1) ? ", " : " ");

                    std::cout << "}";

                    n4 = s2.getnext();
                };
                std::cout << std::endl << "всего: " << s2.count() << std::endl;
                system("pause");



    return 0;
}
