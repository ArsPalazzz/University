//-- Auxil.cpp   
//#include "stdafx.h"
#include "Auxil.h" 
#include <ctime>

//void main() {
//    auxil::start();
//    auxil::dget(7.4, 13.87);
//    auxil::iget(5, 65);
//}

namespace auxil
{
    void start()                          // старт  генератора сл. чисел
    {
        srand((unsigned)time(NULL));
    };
    double dget(double rmin, double rmax) // получить случайное число
    {
        return ((double)rand() / (double)RAND_MAX) * (rmax - rmin) + rmin;
    };
    int iget(int rmin, int rmax)         // получить случайное число

    {
        return (int)dget((double)rmin, (double)rmax);
    };
}

