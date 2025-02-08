#include <iostream>
#include <Windows.h>



int main()
{
	int pid = GetCurrentProcessId();
	HANDLE mutex = OpenMutex(SYNCHRONIZE, FALSE, L"OS07_03");
	//SYNCHRONIZE - права доступа к мьютексу, SYNCHRONIZE указывает, что поток должен иметь право на выполнение операции синхронизации, такой как ожидание мьютекса
	//FALSE - Этот параметр указывает, что функция не должна создавать новый мьютекс, если он не существует

	for (int i = 1; i <= 90; ++i)
	{
		if (i == 30) 
			WaitForSingleObject(mutex, INFINITE);
		
		else if (i == 60) 
			ReleaseMutex(mutex);

		printf("[OS07_03B]\t%d.  PID = %d\n", i, pid);
		Sleep(100);
	}

	CloseHandle(mutex);
}