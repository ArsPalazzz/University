#include <iostream>
#include <fstream>
#include <ctime>
#include <vector>
#include <conio.h>
#include "HemmingUtils.h"

using namespace std;

const char MSG_FILE_PATH[] = "D:\\Study\\Encryption\\lab4\\message.txt";

int main() {
    srand(static_cast<unsigned>(time(nullptr)));
    setlocale(LC_CTYPE, "Ru");

    ifstream inputFile(MSG_FILE_PATH, ios::binary);
    if (!inputFile) {
        cerr << "Ошибка открытия файла для чтения" << endl;
        return 1;
    }

    inputFile.seekg(0, ios::end);
    long file_sz = inputFile.tellg();
    inputFile.seekg(0, ios::beg);

    vector<unsigned char> flbuff(file_sz);
    inputFile.read(reinterpret_cast<char*>(flbuff.data()), file_sz);

    if (inputFile.gcount() != file_sz) {
        cerr << "Не все данные файла прочитаны" << endl;
        return 1;
    }

    cout << "Данные из файла успешно прочитаны (" << file_sz << " байт)" << endl;
    cout << "---------------------------------------------" << endl;
    cout << "Исходное сообщение из текстового файла: " << endl << endl;

    vector<char> binbuff(file_sz * 8 + 1, 0);
    HemmingUtils::printBits(file_sz, flbuff.data(), binbuff.data());
    cout << binbuff.data() << endl;

    int k = strlen(binbuff.data());
    int r = static_cast<int>(log2(k)) + 1;
    int n = k + r;

    cout << "k = " << k << endl;
    cout << "r = " << r << endl;
    cout << "n = " << n << endl;
    cout << "---------------------------------------------" << endl;

    vector<vector<char>> A(r, vector<char>(k, '0'));
    HemmingUtils::generateHemmingMatrix(k, r, A);

    cout << "Проверочная матрица Хемминга: " << endl;
    for (const auto& row : A) {
        for (char val : row) {
            cout << val;
        }
        cout << endl;
    }
    cout << "---------------------------------------------" << endl;

    vector<vector<char>> I(r, vector<char>(r, '0'));
    HemmingUtils::generateIMatrix(r, I);

    cout << "Подматрица I: " << endl;
    for (const auto& row : I) {
        for (char val : row) {
            cout << val;
        }
        cout << endl;
    }
    cout << "---------------------------------------------" << endl;

    vector<char> XrBuff(r + 1, 0);
    HemmingUtils::calculateXr(r, k, binbuff.data(), XrBuff.data(), A);
    cout << "Последовательность избыточных символов: " << XrBuff.data() << endl;

    vector<char> Y0_buff(k + 1, 0), Y1_buff(k + 1, 0), Y2_buff(k + 1, 0);
    HemmingUtils::introduceErrors(0, binbuff.data(), Y0_buff.data());
    HemmingUtils::introduceErrors(1, binbuff.data(), Y1_buff.data());
    HemmingUtils::introduceErrors(2, binbuff.data(), Y2_buff.data());

    cout << "Принято сообщение без ошибок: " << Y0_buff.data() << endl;
    cout << "Принято сообщение с одной ошибкой: " << Y1_buff.data() << endl;
    cout << "Принято сообщение с двумя ошибками: " << Y2_buff.data() << endl;

    vector<char> Yr0Buff(r + 1, 0), Yr1Buff(r + 1, 0), Yr2Buff(r + 1, 0);
    HemmingUtils::calculateYr(r, k, Y0_buff.data(), Yr0Buff.data(), A);
    HemmingUtils::calculateYr(r, k, Y1_buff.data(), Yr1Buff.data(), A);
    HemmingUtils::calculateYr(r, k, Y2_buff.data(), Yr2Buff.data(), A);

    cout << "Избыточные символы для принятого сообщения без ошибки: " << Yr0Buff.data() << endl;
    cout << "Избыточные символы для принятого сообщения с одной ошибкой: " << Yr1Buff.data() << endl;
    cout << "Избыточные символы для принятого сообщения с двумя ошибками: " << Yr2Buff.data() << endl;

    vector<char> Syndrome_0(r + 1, 0), Syndrome_1(r + 1, 0), Syndrome_2(r + 1, 0);
    HemmingUtils::calculateSyndrome(XrBuff.data(), Yr0Buff.data(), Syndrome_0.data());
    HemmingUtils::calculateSyndrome(XrBuff.data(), Yr1Buff.data(), Syndrome_1.data());
    HemmingUtils::calculateSyndrome(XrBuff.data(), Yr2Buff.data(), Syndrome_2.data());

    cout << "Синдром для принятого сообщения без ошибки: " << Syndrome_0.data() << endl;
    cout << "Синдром для принятого сообщения с одной ошибкой: " << Syndrome_1.data() << endl;
    cout << "Синдром для принятого сообщения с двумя ошибками: " << Syndrome_2.data() << endl;

    int err_idx = 0;
    for (int i = 0; i < k; ++i) {
        bool compare_res = true;
        for (int j = 0; j < r; ++j) {
            compare_res = compare_res && (A[j][i] == Syndrome_1[j]);
        }
        if (compare_res) {
            err_idx = i;
            break;
        }
    }

    cout << "Для случая с одной ошибкой - ошибка в " << (err_idx + 1) << " бите" << endl;

    vector<char> E(n + 1, '0');
    E[err_idx] = '1';
    E[n] = '\0';
    cout << n << " - разрядный вектор ошибки: " << E.data() << endl;

    vector<char> XCorrected(k + 1, 0);
    for (int i = 0; i < k; ++i) {
        int Yn = Y1_buff[i] == '0' ? 0 : 1;
        int En = E[i] == '0' ? 0 : 1;
        XCorrected[i] = (Yn ^ En) == 0 ? '0' : '1';
    }
    cout << "СКОРРЕКТИРОВАННОЕ СООБЩЕНИЕ: " << XCorrected.data() << endl;

    inputFile.close();
    cout << "Нажмите любую клавишу для завершения работы программы...";
    _getch();

    return 0;
}
