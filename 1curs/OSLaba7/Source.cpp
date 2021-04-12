//////////////////////////////////1A
//Поиск файла, имя которого надо изменить
/*
#include "windows.h"
#include <tlhelp32.h>
#include "string.h"
#include <iostream>
#include "tchar.h"
int _tmain(int argc, _TCHAR* argv[])
{
//
	WIN32_FIND_DATA FindFileData;
	HANDLE hFind = INVALID_HANDLE_VALUE;
//
//TCHAR directorySearch[] = TEXT("*.txt");
	TCHAR filesearch[] = TEXT("*.txt");
	// Find the first file in the directory.
	hFind = FindFirstFile(filesearch, &FindFileData);
//
	if (hFind == INVALID_HANDLE_VALUE)
	{
		printf("Invalid file handle. Error is %u.\n", GetLastError());
	}
	else
	{
				std::wcout << "Found: " << FindFileData.cFileName << '\n';
//
// List all the other files in the directory.
		while (FindNextFile(hFind, &FindFileData) != 0)
		{
			std::wcout << "Found: " << FindFileData.cFileName << '\n';
		}
		FindClose(hFind);
	}
//
getchar();
	return 0;
}*/



///////////////////1Б Запуск внешнего приложения через CREATEPROCESS 
/*
#include <windows.h>
#include <iostream>
#include "string.h"
#include <tchar.h>

int _tmain(int argc, _TCHAR* argv[])
{
	STARTUPINFO cif;
	ZeroMemory(&cif, sizeof(STARTUPINFO));
	PROCESS_INFORMATION pi;
	TCHAR buf[] = TEXT("mspaint.exe");
	if (!(CreateProcess(NULL, buf, NULL, NULL, FALSE, 0,
		NULL, NULL, &cif, &pi)))
		std::wcout << "Error " << '\n';
	return 0;
	/*CreateProcessA(
    _In_opt_ LPCSTR lpApplicationName,
    _Inout_opt_ LPSTR lpCommandLine,
    _In_opt_ LPSECURITY_ATTRIBUTES lpProcessAttributes,
    _In_opt_ LPSECURITY_ATTRIBUTES lpThreadAttributes,
    _In_ BOOL bInheritHandles,
    _In_ DWORD dwCreationFlags,
    _In_opt_ LPVOID lpEnvironment,
    _In_opt_ LPCSTR lpCurrentDirectory,
    _In_ LPSTARTUPINFOA lpStartupInfo,
    _Out_ LPPROCESS_INFORMATION lpProcessInformation
    );

}*/

/*ЗАДАЧА. ОБЪЕДИНИТЬ 1А и 1Б. НАЙТИ ФАЙЛ EXE И ЗАПУСТИТЬ ЕГО НА ВЫПОЛНЕНИЕ.*/
/*#include "windows.h"
#include <tlhelp32.h>
#include "string.h"
#include <iostream>
#include "tchar.h"
int _tmain(int argc, _TCHAR* argv[])
{
	//
	WIN32_FIND_DATA FindFileData;
	HANDLE hFind = INVALID_HANDLE_VALUE;
	
	TCHAR filesearch[] = TEXT("e:\\Мое\\XRabell\\Новая папка\\Construct 2\\Construct2.exe");
	STARTUPINFO cif;
	ZeroMemory(&cif, sizeof(STARTUPINFO));
	PROCESS_INFORMATION pi;
	// Find the first file in the directory.
	hFind = FindFirstFile(filesearch, &FindFileData);//найденный датафайл в FindFileData (буффер данных), а в hFind результат операции
	//
	if (hFind == INVALID_HANDLE_VALUE)
	{
		printf("Invalid file handle. Error is %u.\n", GetLastError());
	}
	else
	{
		std::wcout << "Found: " << FindFileData.cFileName << '\n';
		FindClose(hFind);
		if (CreateProcess(NULL, filesearch, NULL, NULL, FALSE, 0, NULL, NULL, &cif, &pi)) std::cout << "Create process!";
		else
			std::wcout << "Error " << '\n';
	}
	getchar();
	return 0;
}*/


//////////////1B Запуск процесса с выводом на консоль его системного номера (заголовка)

/*#include <windows.h>
#include <iostream>
#include "string.h"
#include <tchar.h>

int _tmain(int argc, _TCHAR* argv[])
{

	DWORD processID;
	STARTUPINFO cif;
	ZeroMemory(&cif, sizeof(STARTUPINFO));
	PROCESS_INFORMATION pi;
	TCHAR buf[] = TEXT("mspaint.exe");
	processID = CreateProcess(NULL, buf, NULL, NULL, FALSE, 0, NULL, NULL, &cif, &pi);

	std::wcout << "Running  with PID:" << pi.dwProcessId << '\n';

	HANDLE hProcess = GetCurrentProcess(); 
	OpenProcess( PROCESS_QUERY_INFORMATION | PROCESS_VM_READ, FALSE, processID );
  // Get the process name.
	if (hProcess!=NULL)
	{
		Sleep(2000);
		BOOL result = TerminateProcess(hProcess, 0);
		CloseHandle(hProcess);
	}
	else

	{
		std::wcout << "Error when terminating " << '\n';
	}
	getchar();
	return 0;
}*/


///////////////////////////////////////////////////////////////////2
//Запуск процесса из консоли с удалением консольного окна через 0.2 секунды.
//////////////////////////////////////////////////////////////////
/*
#include <windows.h>
#include <iostream>
#include "string.h"
#include <tchar.h>

int _tmain(int argc, _TCHAR* argv[])
{
	DWORD processID;
	STARTUPINFO cif;
	ZeroMemory(&cif, sizeof(STARTUPINFO));
	PROCESS_INFORMATION pi;
	TCHAR buf[] = TEXT("mspaint.exe");
	if (!(processID = CreateProcess(NULL, buf, NULL, NULL, FALSE, 0,
		NULL, NULL, &cif, &pi)))
		std::wcout << "Running " << '\n';

//	HANDLE hProcess = GetCurrentProcess(); //получаем pID консольного приложен.

	if (NULL != GetCurrentProcess())
	{
	Sleep(200);
	BOOL result = TerminateProcess(GetCurrentProcess(), 0);
	CloseHandle(GetCurrentProcess());
	}
	else
	{
		std::wcout << "Error when terminating " << '\n';
	}
}
*/


//////////////////////////////////////3 ВЫВОД ИМЕН ВСЕХ ЗАПУЩЕННЫХ ПРОЦЕССОВ
/*#include <tchar.h>
#include "windows.h"
#include <tlhelp32.h>
#include "string.h"
#include <iostream>


int _tmain(int argc, _TCHAR* argv[])
{

	HANDLE hStdout = GetStdHandle(STD_OUTPUT_HANDLE);

	SetConsoleTextAttribute(hStdout, FOREGROUND_BLUE | FOREGROUND_GREEN | FOREGROUND_INTENSITY | BACKGROUND_BLUE); //background - фон за символами, foreground - цвет самих символов 
	// берется цве символов самый ервый, который записан
	HANDLE hSnapshot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);
	if (hSnapshot) {
		PROCESSENTRY32 pe32;
		pe32.dwSize = sizeof(PROCESSENTRY32);
		if (Process32First(hSnapshot, &pe32)) {
			do {

				std::wcout << "Running  ProcName :" << pe32.szExeFile << '\n';
			} while (Process32Next(hSnapshot, &pe32));
		}
		CloseHandle(hSnapshot);
	}
	return 0;
}*/


////////////////////////////////////////////4
//ПРОВЕРЯЕТ, ВЫПОЛНЯЕТСЯ ЛИ ПРОЦЕСС
//#include "pch.h"
//#include "windows.h"
//#include <tlhelp32.h>
//#include "string.h"
//#include <iostream>
//#include "tchar.h"
//#define STRLEN(x) (sizeof(x)/sizeof(TCHAR) - 1)
//
//
//bool AreEqual(const TCHAR *a, const TCHAR *b)
//{
//	while (*a == *b)
//	{
//		if (*a == _TEXT('\0'))return true;
//		a++; b++;
//	}
//	return false;
//}
//
//
//
//bool IsProcessRun()
//{
//	bool RUN;
//	TCHAR buf[] = TEXT("GetProcessName.exe");
//
//
//	HANDLE hSnapshot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);
//
//	PROCESSENTRY32 pe;
//	pe.dwSize = sizeof(PROCESSENTRY32);
//	Process32First(hSnapshot, &pe);
//
//	if (AreEqual(pe.szExeFile, buf))
//	{
//		RUN = true;
//		return RUN;
//	}
//	else
//		RUN = false;
//	while (Process32Next(hSnapshot, &pe))
//	{
//		if (AreEqual(pe.szExeFile, buf))
//		{
//			RUN = true;
//			return RUN;
//		}
//		else
//			RUN = false;
//	}
//	return RUN;
//}
//
//int _tmain(int argc, _TCHAR* argv[])
//{
//
//	HANDLE hStdout = GetStdHandle(STD_OUTPUT_HANDLE);
//
//	SetConsoleTextAttribute(hStdout, FOREGROUND_BLUE | FOREGROUND_GREEN | FOREGROUND_INTENSITY | BACKGROUND_BLUE);
//
//
//
//	if (IsProcessRun())
//	{
//
//		std::wcout << "Running" << '\n';
//	}
//	else
//
//	{
//		std::wcout << "NOT Running" << '\n';
//	}
//
//	getchar();
//
//	return 0;
//}
/*#include "windows.h"
#include <tlhelp32.h>
#include "string.h"
#include <iostream>
#include <tchar.h>
#define STRLEN(x) (sizeof(x)/sizeof(TCHAR) - 1)
bool AreEqual(const TCHAR* a, const TCHAR* b)
{
	while (*a == *b)
	{
		if (*a == _TEXT('\0'))return true;
		a++; b++;
	}
	return false;
}



bool IsProcessRun()
{
	bool RUN;
	TCHAR buf[] = TEXT("GetProcessName.exe");


	HANDLE hSnapshot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);

	PROCESSENTRY32 pe;
	pe.dwSize = sizeof(PROCESSENTRY32);
	Process32First(hSnapshot, &pe);

	if (AreEqual(pe.szExeFile, buf))
	{
		RUN = true;
		return RUN;
	}
	else
		RUN = false;
	while (Process32Next(hSnapshot, &pe))
	{
		if (AreEqual(pe.szExeFile, buf))
		{
			RUN = true;
			return RUN;
		}
		else
			RUN = false;
	}
	return RUN;
}

int _tmain(int argc, _TCHAR* argv[])
{

	HANDLE hStdout = GetStdHandle(STD_OUTPUT_HANDLE);

	SetConsoleTextAttribute(hStdout, FOREGROUND_BLUE | FOREGROUND_GREEN | FOREGROUND_INTENSITY | BACKGROUND_BLUE);



	if (IsProcessRun())
	{

		std::wcout << "Running" << '\n';
	}
	else

	{
		std::wcout << "NOT Running" << '\n';
	}

	getchar();

	return 0;
}
*/



/////////////////////////////////////////////////////ЗАДАНИЕ/////////////////////////
//На основании представленных программок создать собственную программу, 
//которая отыскивает exe - файл по части имени, 
//запускает его на выполнение, затем проверяет, выполняется ли он, и выдает соответствующее сообщение.

#include "windows.h"
#include <tlhelp32.h>
#include "string.h"
#include <iostream>
#include "tchar.h"
#define STRLEN(x) (sizeof(x)/sizeof(TCHAR) - 1)

bool AreEqual(const TCHAR* a, const TCHAR* b)
{
	while (*a == *b)
	{
		if (*a == _TEXT('\0'))return true;
		a++; b++;
	}
	return false;
}
bool IsProcessRun()
{
	bool RUN;
	TCHAR buf[] = TEXT("e:\\Мое\\XRabell\\Новая папка\\Construct 2\\Cons*.exe");// mspaint

	HANDLE hSnapshot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);//запущенные процессы

	PROCESSENTRY32 pe;
	pe.dwSize = sizeof(PROCESSENTRY32);
	Process32First(hSnapshot, &pe);//принимает хэндл, полученный от CreateToolhelp32Snapshot и указатель на структуру PROCESSENTRY32

	if (AreEqual(pe.szExeFile, buf))
	{
		RUN = true;
		return RUN;
	}
	else
		RUN = false;
	while (Process32Next(hSnapshot, &pe))
		if (AreEqual(pe.szExeFile, buf))
		{
			RUN = true;
			return RUN;
		}
		else
			RUN = false;
	return RUN;
}

int _tmain(int argc, _TCHAR* argv[])
{
	WIN32_FIND_DATA FindFileData;//описывает файл, найденный функцией FindFirstFile
	HANDLE hFind = INVALID_HANDLE_VALUE;

	TCHAR filesearch[] = TEXT("e:\\Мое\\XRabell\\Новая папка\\Construct 2\\Construct2.exe");

	hFind = FindFirstFile(filesearch, &FindFileData);

	if (hFind == INVALID_HANDLE_VALUE)
		printf("Invalid file handle. Error is %u.\n", GetLastError());
	else
	{
		std::wcout << "Found: " << FindFileData.cFileName << '\n';
		// List all the other files in the directory.
		while (FindNextFile(hFind, &FindFileData) != 0)
			std::wcout << "Found: " << FindFileData.cFileName << '\n';
		FindClose(hFind);
	}

	STARTUPINFO cif;
	ZeroMemory(&cif, sizeof(STARTUPINFO));
	PROCESS_INFORMATION pi;
	//TCHAR buf[] = TEXT("mspa.exe");
	if (!(CreateProcess(NULL, filesearch, NULL, NULL, FALSE, 0,
		NULL, NULL, &cif, &pi)))//&cif-указатель на структуру STARTUPINFO,  &pi-указатель на структуру PROCESS_INFORMATION
		std::wcout << "Error " << '\n';

	HANDLE hStdout = GetStdHandle(STD_OUTPUT_HANDLE);//извлекает дескриптор для вывода

	SetConsoleTextAttribute(hStdout, FOREGROUND_INTENSITY);

	if (IsProcessRun())
		std::wcout << "NOT Running" << '\n';
	else
		std::wcout << "Running" << '\n';

	getchar();
	return 0;
}