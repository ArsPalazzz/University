#pragma warning(disable : 4996)

#include <iostream>
#include <windows.h>
#include <string>
#include <sstream>

#define HTPATH L"C:/storage/HTspace.ht"

#include "../OS15_HTCOM_LIB/pch.h"
#include "../OS15_HTCOM_LIB/OS15_HTCOM_LIB.h"

#ifdef _WIN64
#pragma comment(lib, "../x64/Debug/OS15_HTCOM_LIB.lib")
#else
#pragma comment(lib, "../Debug/OS15_HTCOM_LIB.lib")
#endif

using namespace std;

string intToString(int number);
int charToInt(char* str);
string incrementPayload(char* str);
SECURITY_ATTRIBUTES getSecurityAttributes();
HANDLE createStopEvent(const wchar_t* stopEventName);
wchar_t* getWC(const char* c)
{
	wchar_t* wc = new wchar_t[strlen(c) + 1];
	mbstowcs(wc, c, strlen(c) + 1);

	return wc;
}


int main(int argc, char* argv[])
{
	HANDLE hStopEvent = createStopEvent(HTPATH);
	setlocale(LC_ALL, "Russian");
	PWCHAR
		username = argc >= 2 ? getWC(argv[1]) : NULL,
		password = argc >= 3 ? getWC(argv[2]) : NULL;

	try
	{
		cout << "Инициализация компонента:" << endl;
		OS15_HTCOM_HANDEL h = OS15_HTCOM::Init();

		ht::HtHandle* ht;
		if (username == NULL || password == NULL)
			ht = OS15_HTCOM::HT::open(h, HTPATH, true);
		else
			ht = OS15_HTCOM::HT::open(h, HTPATH, username, password, true);

		if (ht)
			cout << "-- open: success" << endl;
		else
			throw "-- open: error";

		while (WaitForSingleObject(hStopEvent, 0) == WAIT_TIMEOUT) {
			int numberKey = rand() % 50;
			string key = intToString(numberKey);
			cout << key << endl;

			ht::Element* element = OS15_HTCOM::HT::get(h, ht, OS15_HTCOM::Element::createGetElement(h, key.c_str(), key.length() + 1));
			if (element)
			{
				cout << "-- get: success" << endl;
				string newPayload = incrementPayload((char*)element->payload);

				if (OS15_HTCOM::HT::update(h, ht, element, newPayload.c_str(), newPayload.length() + 1))
					cout << "-- update: success" << endl;
				else
					cout << "-- update: error" << endl;
			}
			else
				cout << "-- get: error" << endl;

			Sleep(1000);
		}

		OS15_HTCOM::HT::close(h, ht);

		cout << endl << "Удалить компонент и выгрузить dll, если можно:" << endl;
		OS15_HTCOM::Dispose(h);
	}
	catch (const char* e) { cout << e << endl; }
	catch (int e) { cout << "HRESULT: " << e << endl; }

}

string intToString(int number)
{
	stringstream convert;
	convert << number;

	return convert.str();
}

int charToInt(char* str)
{
	stringstream convert;
	convert << str;
	int num;
	convert >> num;

	return num;
}

string incrementPayload(char* str)
{
	int oldNumberPayload = charToInt(str);
	int newNumberPayload = oldNumberPayload + 1;
	string newPayload = intToString(newNumberPayload);

	return newPayload;
}

SECURITY_ATTRIBUTES getSecurityAttributes()
{
	const wchar_t* sdd = L"D:"
		L"(D;OICI;GA;;;BG)" //Deny guests
		L"(D;OICI;GA;;;AN)" //Deny anonymous
		L"(A;OICI;GA;;;AU)" //Allow read, write and execute for Users
		L"(A;OICI;GA;;;BA)"; //Allow all for Administrators
	SECURITY_ATTRIBUTES SA;
	ZeroMemory(&SA, sizeof(SA));
	SA.nLength = sizeof(SA);
	ConvertStringSecurityDescriptorToSecurityDescriptor(
		sdd,
		SDDL_REVISION_1,
		&SA.lpSecurityDescriptor,
		NULL);

	return SA;
}

HANDLE createStopEvent(const wchar_t* stopEventName)
{
	std::wstring closeEventName = L"Global\\"; closeEventName += stopEventName; closeEventName += L"-stopEvent";
	SECURITY_ATTRIBUTES SA = getSecurityAttributes();

	HANDLE hStopEvent = CreateEvent(
		&SA,
		TRUE, //FALSE - автоматический сброс; TRUE - ручной
		FALSE,
		closeEventName.c_str());

	return hStopEvent;
}