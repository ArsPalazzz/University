﻿#include <iostream>
#include <ctime>
#include <Windows.h>

#define SECOND 10000000

int main()
{
    clock_t start = clock();

    DWORD pid = GetCurrentProcessId();
    std::cout << "Main PID: " << pid << std::endl;

    long long it = -60 * SECOND;
    HANDLE htimer = CreateWaitableTimer(NULL, FALSE, L"OS08_04");
    if (!SetWaitableTimer(htimer, (LARGE_INTEGER*)&it, 60000, NULL, NULL, FALSE)) {
        throw "Error SrtWaitableTimer";
    }

    LPCWSTR an = L"..\\x64\\Debug\\OS08_04X.exe";
    PROCESS_INFORMATION pi1, pi2;
    pi1.dwThreadId = 1;  pi2.dwThreadId = 2;

    STARTUPINFO si;
    ZeroMemory(&si, sizeof(STARTUPINFO));
    si.cb = sizeof(STARTUPINFO);
    CreateProcess(an, NULL, NULL, NULL, FALSE, CREATE_NEW_CONSOLE, NULL, NULL, &si, &pi1) ?
        std::cout << "Process OS08_04xA created \n" : std::cout << "Process OS08_04xA not created \n";
    CreateProcess(an, NULL, NULL, NULL, FALSE, CREATE_NEW_CONSOLE, NULL, NULL, &si, &pi2) ?
        std::cout << "Process OS08_04xB created \n" : std::cout << "Process OS08_04xB not created \n";

    WaitForSingleObject(pi1.hProcess, INFINITE);
    WaitForSingleObject(pi2.hProcess, INFINITE);
    CancelWaitableTimer(htimer);

    std::cout << "time: " << clock() - start << std::endl;

    system("pause");
    return 0;
}










// как выполнятеся условие: первый поток выполнялся минуту а второй две
// создается таймер который идет 60 сек и повторяется каждые 60с 
// в каждом из потоков стоит opentimer как только первый поток выполниться через 60сек
// второй поток завладеет таймером и тоже будет выполнятся 60сек