#ifndef HEMMING_UTILS_H
#define HEMMING_UTILS_H

#include <iostream>
#include <vector>
#include <cstring>
#include <cmath>

class HemmingUtils {
public:
    static void printBits(size_t const size, void const* const ptr, char* binbuff);
    static int fact(int n);
    static int binom(int wt, int r);
    static void generateHemmingMatrix(int k, int r, std::vector<std::vector<char>>& A);
    static void generateIMatrix(int r, std::vector<std::vector<char>>& I);
    static void calculateXr(int r, int k, const char* buff, char* XrBuff, const std::vector<std::vector<char>>& A);
    static void introduceErrors(int n, const char* buff, char* Yn_buff);
    static void calculateYr(int r, int k, const char* Yn_buff, char* YrBuff, const std::vector<std::vector<char>>& A);
    static void calculateSyndrome(const char* XrBuff, const char* YrNbufcalc, char* Syndrome);
};

#endif // HEMMING_UTILS_H
