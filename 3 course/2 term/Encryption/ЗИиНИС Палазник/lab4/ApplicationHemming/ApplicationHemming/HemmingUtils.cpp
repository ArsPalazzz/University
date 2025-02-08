#include "HemmingUtils.h"

void HemmingUtils::printBits(size_t const size, void const* const ptr, char* binbuff) {
    unsigned char* b = (unsigned char*)ptr;
    unsigned char bit;
    for (size_t i = 0; i < size; i++) {
        for (int j = 7; j >= 0; j--) {
            bit = (b[i] >> j) & 1;
            sprintf(binbuff, "%d", bit);
            binbuff++;
        }
    }
    *binbuff = 0;
}

int HemmingUtils::fact(int n) {
    return (n == 0) ? 1 : n * fact(n - 1);
}

int HemmingUtils::binom(int wt, int r) {
    return fact(wt) / (fact(r) * fact(wt - r));
}

void HemmingUtils::generateHemmingMatrix(int k, int r, std::vector<std::vector<char>>& A) {
    int pow2 = 0, pow2prev = 0;
    for (int i = 0; i < k; i++) {
        if (i == pow2) {
            pow2prev = pow2;
            pow2 = (pow2 + 1) * 2 - 1;
            continue;
        }
        int quotient = i + 1;
        for (int j = r - 1; j >= 0; j--) {
            int remainder = quotient % 2;
            quotient = quotient / 2;
            A[j][i - pow2prev] = remainder == 0 ? '0' : '1';
        }
    }
}

void HemmingUtils::generateIMatrix(int r, std::vector<std::vector<char>>& I) {
    for (int i = 0; i < r; i++) {
        I[i][i] = '1';
    }
}

void HemmingUtils::calculateXr(int r, int k, const char* buff, char* XrBuff, const std::vector<std::vector<char>>& A) {
    for (int i = 0; i < r; i++) {
        int res = 0;
        for (int j = 0; j < k; j++) {
            int AInt = A[i][j] == '0' ? 0 : 1;
            int BInt = buff[j] == '0' ? 0 : 1;
            res += AInt * BInt;
        }
        res = res % 2;
        XrBuff[i] = res == 0 ? '0' : '1';
    }
    XrBuff[r] = '\0';
}

void HemmingUtils::introduceErrors(int n, const char* buff, char* Yn_buff) {
    strcpy(Yn_buff, buff);
    for (int i = 0; i < n; i++) {
        int err_bit = rand() % strlen(buff);
        Yn_buff[err_bit] = Yn_buff[err_bit] == '0' ? '1' : '0';
    }
}

void HemmingUtils::calculateYr(int r, int k, const char* Yn_buff, char* YrBuff, const std::vector<std::vector<char>>& A) {
    for (int i = 0; i < r; i++) {
        int res = 0;
        for (int j = 0; j < k; j++) {
            int AInt = A[i][j] == '0' ? 0 : 1;
            int BInt = Yn_buff[j] == '0' ? 0 : 1;
            res += AInt * BInt;
        }
        res = res % 2;
        YrBuff[i] = res == 0 ? '0' : '1';
    }
    YrBuff[r] = '\0';
}

void HemmingUtils::calculateSyndrome(const char* XrBuff, const char* YrNbufcalc, char* Syndrome) {
    for (size_t i = 0; i < strlen(XrBuff); i++) {
        int XrN = XrBuff[i] == '0' ? 0 : 1;
        int YrN = YrNbufcalc[i] == '0' ? 0 : 1;
        Syndrome[i] = (XrN ^ YrN) == 0 ? '0' : '1';
    }
    Syndrome[strlen(XrBuff)] = '\0';
}
