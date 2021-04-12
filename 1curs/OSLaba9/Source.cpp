//1.Изменение приоритета потока.
/*#include "tchar.h"
#include <windows.h>
#include <iostream>
#include "string.h"

DWORD WINAPI myThread(void* lpParameter)
{

	int* counterp = new int();
	counterp = (int*)lpParameter;
	int counter = *counterp;

	while (counter < 20)
	{
		Sleep(500);
		counter++;
		printf("\n Counter= %d", counter);
	}

	return 0;
}
int _tmain(int argc, _TCHAR* argv[])
{
	int z = 5;
	DWORD myThreadID;
	HANDLE myHandle = CreateThread(0, 0, myThread, (void*)& z, 0, &myThreadID);
	//int CurPr = GetPriorityClass(GetCurrentProcess());//получение приоритета запущенного на данный момент потока

	int   iPriority1 = GetThreadPriority(myHandle);// + CurPr; 
	printf("\n Priority is: %d", iPriority1);
	SetThreadPriority(myHandle, THREAD_PRIORITY_ABOVE_NORMAL);//установка первому потоку приоритета Нормал
	iPriority1 = GetThreadPriority(myHandle);// + CurPr;
	printf("\n After Change Priority is: %d", iPriority1);

	SetThreadPriority(myHandle, THREAD_PRIORITY_HIGHEST);//установка первому потоку высшего приоритета 
	iPriority1 = GetThreadPriority(myHandle);// + CurPr;
	printf("\nThe Highest Priority is: %d", iPriority1);

	SetThreadPriority(myHandle, THREAD_PRIORITY_LOWEST);//установка первому потоку низ приоритета 
	iPriority1 = GetThreadPriority(myHandle);// + CurPr;
	printf("\nThe Lowest Priority is: %d", iPriority1);

	Sleep(5000);
	printf("\n Main Process sagt Das ist Alles\n");
	TerminateThread(myHandle, 0);
	return 0;
}*/

//-----------------------------------------------------------------------------------------------
//2.Запуск потока на запись в файл.
/*#include <windows.h>
#include <iostream>
#include "string.h"
#include <tchar.h>
DWORD WINAPI myThread(void* lpParameter)
{
	TCHAR Buffer[256] = TEXT("HELLO!");
	HANDLE hOut;
	DWORD dwBytes;
	FILE* fp;

	TCHAR stdPath[30] = TEXT("e:\\work\\myfile.txt");
	hOut = CreateFile(stdPath, GENERIC_WRITE, 0, NULL, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);

	if (hOut == INVALID_HANDLE_VALUE)
	{
		printf("ERROR WRITING FILE");
		return 2;


	}
	else

	{
		WriteFile(hOut, Buffer, 256, &dwBytes, NULL);
		printf("Thread Written");
		CloseHandle(hOut);
	}
	return 0;

}

int _tmain(int argc, _TCHAR* argv[])
{

	int z = 0;
	DWORD myThreadID;
	HANDLE myHandle = CreateThread(0, 0, myThread, (void*)& z, CREATE_SUSPENDED, &myThreadID);

	BOOL b = SetThreadPriorityBoost(myHandle, false);
	if (b)
	{
		SetThreadPriority(myHandle, THREAD_PRIORITY_HIGHEST);
	}
	ResumeThread(myHandle);

	Sleep(2000);
	printf("\n Main Process sagt Das ist Alles");

	TerminateThread(myHandle, 0);
	getchar();

	return 0;
}*/

//-----------------------------------------------------------------------------------------------

//3.Теперь передадим записываемую строку в качестве параметра в поток
/*#include <windows.h>
#include <iostream>
#include "string.h"
#include <tchar.h>

DWORD WINAPI myThread(void* lpPar)
{
	TCHAR* b = new TCHAR();
	b = (TCHAR*)lpPar;

	HANDLE hOut;
	DWORD dwBytes;

	TCHAR stdPath[30] = TEXT("e:\\work\\myfile1.txt");
	hOut = CreateFile(stdPath, GENERIC_WRITE, 0, NULL, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);

	if (hOut == INVALID_HANDLE_VALUE)
	{
		printf("ERROR WRITING FILE");
		return 2;
	}
	else
	{
		WriteFile(hOut, b, 256, &dwBytes, NULL);
		printf("Thread Written");
		CloseHandle(hOut);
	}
	return 0;

}

int _tmain(int argc, _TCHAR* argv[])
{
	DWORD myThreadID;
	TCHAR Buff[256] = TEXT("HELLO! Students");
	HANDLE myHandle = CreateThread(0, 0, myThread, (void*)Buff, CREATE_SUSPENDED, &myThreadID);
	BOOL b = SetThreadPriorityBoost(myHandle, false);

	if (b)
	{
		SetThreadPriority(myHandle, THREAD_PRIORITY_HIGHEST);
	}
	ResumeThread(myHandle);
	Sleep(2000);
	printf("\n Main Process sagt Das ist Alles");

	TerminateThread(myHandle, 0);

	getchar();

	return 0;
}
*/

//-----------------------------------------------------------------------------------------------

//4.	Теперь в главной программе дождемся завершения работы потока
/*
#include <windows.h>
#include <iostream>
#include "string.h"
#include <tchar.h>

DWORD WINAPI myThread(void* lpPar)
{
	TCHAR* b = new TCHAR();
	b = (TCHAR*)lpPar;

	HANDLE hOut;
	DWORD dwBytes;
	FILE* fp;

	TCHAR stdPath[30] = TEXT("e:\\work\\myfile2.txt");
	hOut = CreateFile(stdPath, GENERIC_WRITE, 0, NULL,
		CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);

	if (hOut == INVALID_HANDLE_VALUE)
	{
		printf("ERROR WRITING FILE");
		return 2;
	}
	else
	{
		WriteFile(hOut, b, 256, &dwBytes, NULL);
		printf("Thread Written");
		CloseHandle(hOut);

	}
	return 0;
}
int _tmain(int argc, _TCHAR* argv[])
{
	int z = 0;

	DWORD myThreadID;

	TCHAR Buff[256] = TEXT("HELLO! Students 2");

	HANDLE myHandle = CreateThread(0, 0, myThread, (void*)Buff, CREATE_SUSPENDED, &myThreadID);

	BOOL b = SetThreadPriorityBoost(myHandle, false);

	if (b) 
		SetThreadPriority(myHandle, THREAD_PRIORITY_HIGHEST);
	
	ResumeThread(myHandle);

	WaitForSingleObject(myHandle, 10000); //заставляет ждать завершения потока либо 10000 миллисекунд(что раньше)
	
	printf("\n Main Process sagt Das ist Alles");
	
	TerminateThread(myHandle, 0);

	return 0;
}*/
//Здесь использована команда   WaitForSingleObject(myHandle, 10000);
//которая заставляет ждать завершения потока либо 10000 миллисекунд(что раньше).

//-----------------------------------------------------------------------------------------------

//5.	Теперь синхронизируем работу потока с файлом с помощью механизма семафоров(критических зон).Обратить внимание на использование команд

//EnterCriticalSection(&cs);  -вход в критическую секцию
//LeaveCriticalSection(&cs);  -выход из критической секции
/*
#include <windows.h>
#include <iostream>
#include "string.h"
#include <tchar.h>

CRITICAL_SECTION cs;

DWORD WINAPI myThread(void* lpPar)
{
	TCHAR* b = new TCHAR();
	b = (TCHAR*)lpPar;

	HANDLE hOut;
	DWORD dwBytes;
	FILE* fp;

	TCHAR stdPath[30] = TEXT("e:\\work\\myfile4.txt");

	EnterCriticalSection(&cs);

	hOut = CreateFile(stdPath, GENERIC_WRITE, 0, NULL, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);

	if (hOut == INVALID_HANDLE_VALUE)
	{
		printf("ERROR WRITING FILE");
		return 2;
	}
	else
	{
		WriteFile(hOut, b, 256, &dwBytes, NULL);
		printf("Thread Written");
		CloseHandle(hOut);
	}
	LeaveCriticalSection(&cs);
	return 0;

}
int _tmain(int argc, _TCHAR* argv[])
{

	int z = 0;

	DWORD myThreadID;

	TCHAR Buff[256] = TEXT("HELLO! Students 3");


	InitializeCriticalSection(&cs);

	HANDLE myHandle = CreateThread(0, 0, myThread, (void*)Buff, CREATE_SUSPENDED, &myThreadID);


	BOOL b = SetThreadPriorityBoost(myHandle, false);

	if (b)
	{
		SetThreadPriority(myHandle, THREAD_PRIORITY_HIGHEST);
	}
	ResumeThread(myHandle);

	WaitForSingleObject(myHandle, 10000);

	printf("\n Main Process sagt Das ist Alles");

	TerminateThread(myHandle, 0);

	return 0;
}*/

//-----------------------------------------------------------------------------------------------

//6.	Наконец, сделаем синхронизированный доступ к одному и тому же файлу через механизм критических секций со стороны двух потоков.
/*
#include "tchar.h"
#include <windows.h>
#include <iostream>
#include "string.h"

CRITICAL_SECTION cs;

DWORD WINAPI myThread(void* lpPar)
{
	TCHAR* b = new TCHAR();
	b = (TCHAR*)lpPar;

	HANDLE hOut;
	DWORD dwBytes;
	FILE* fp;

	TCHAR stdPath[30] = TEXT("e:\\work\\myfile.txt");

	EnterCriticalSection(&cs);

	hOut = CreateFile(stdPath, GENERIC_WRITE, 0, NULL, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);

	if (hOut == INVALID_HANDLE_VALUE)
	{
		printf("ERROR WRITING FILE");
		return 2;
	}
	else
	{
		WriteFile(hOut, b, 256, &dwBytes, NULL);
		printf("Thread  1 Written\n");
		CloseHandle(hOut);
	}
	LeaveCriticalSection(&cs);
	return 0;

}
DWORD WINAPI myThread2(void* lpPar)
{
	TCHAR* b = new TCHAR();
	b = (TCHAR*)lpPar;

	HANDLE hOut;
	DWORD dwBytes;
	FILE* fp;

	TCHAR stdPath[30] = TEXT("e:\\work\\myfile5.txt");

	EnterCriticalSection(&cs);

	hOut = CreateFile(stdPath, GENERIC_WRITE, 0, NULL,
		CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);

	if (hOut == INVALID_HANDLE_VALUE)
	{
		printf("ERROR WRITING FILE");
		return 2;
	}
	else

	{
		WriteFile(hOut, b, 256, &dwBytes, NULL);
		printf("Thread  2 Written\n");
		CloseHandle(hOut);

	}
	LeaveCriticalSection(&cs);
	return 0;

}
int _tmain(int argc, _TCHAR* argv[])
{
	int z = 0;

	DWORD myThreadID;
	DWORD myThreadID2;

	TCHAR Buff[256] = TEXT("HELLO! Students 5");
	TCHAR Buff2[256] = TEXT("Gut Abend Liber Kollegen");

	InitializeCriticalSection(&cs);

	HANDLE myHandle = CreateThread(0, 0, myThread, (void*)Buff, CREATE_SUSPENDED, &myThreadID);

	BOOL b = SetThreadPriorityBoost(myHandle, false);

	if (b)
	{
		SetThreadPriority(myHandle, THREAD_PRIORITY_HIGHEST);
	}

	HANDLE myHandle2 = CreateThread(0, 0, myThread2, (void*)Buff2, CREATE_SUSPENDED, &myThreadID2);

	ResumeThread(myHandle);
	ResumeThread(myHandle2);
	WaitForSingleObject(myHandle, 10000);
	WaitForSingleObject(myHandle2, 10000);

	printf("\n Main Process sagt Das ist Alles\n");

	TerminateThread(myHandle, 0);
	TerminateThread(myHandle2, 0);

	return 0;
}
*/
//-----------------------------------------------------------------------------------------------

/*
ЗАДАНИЕ.

НАПИСАТЬ ПРОГРАММУ С ДВУМЯ ПОТОКАМИ.ОДИН ПИШЕТ В ФАЙЛ, ДРУГОЙ ЧИТАЕТ ИЗ ТОГО ЖЕ ФАЙЛА.ПРОДУМАТЬ СИНХРОНИЗАЦИЮ ДОСТУПА ЧЕРЕ МЕХАНИЗМ КРИТИЧЕСКИХ ЗОН.

Будем считать, что поток - писатель пишет числа.Для преобразования чисел в строки применить такую конструкцию

char* u = new char();
itoa(25, u, 10);

Строка u получает значение 25 в 10 - ричной системе.Также может понадобиться соединение строк :
*/
/*НАПИСАТЬ ПРОГРАММУ С ДВУМЯ ПОТОКАМИ.
ОДИН ПИШЕТ В ФАЙЛ, ДРУГОЙ ЧИТАЕТ ИЗ ТОГО ЖЕ ФАЙЛА.
ПРОДУМАТЬ СИНХРОНИЗАЦИЮ ДОСТУПА ЧЕРЕЗ МЕХАНИЗМ КРИТИЧЕСКИХ ЗОН.*/
#include <windows.h>
#include <iostream>
#include "string.h"
#include <fstream>

using namespace std;

bool flag = false;

CRITICAL_SECTION cs;
TCHAR stdPath[30] = TEXT("e:\\work\\NewMyFile.txt");
char* u = new char(2);

DWORD WINAPI myThread(void* lpPar)//writer
{
	HANDLE* h = new HANDLE();
	h = (HANDLE*)lpPar;
	HANDLE hh = *h;
	HANDLE hOut;
	DWORD dwBytes;

	for (int i = 0; i < 10; i++)
	{
			EnterCriticalSection(&cs);
			hOut = CreateFile(stdPath, GENERIC_WRITE, 0, NULL, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);// создаем, а не открываем, чтобы содержимое обновлялось
			_itoa_s(i, u, 2, 10);
			WriteFile(hOut, u, 2, &dwBytes, NULL);
			printf("Thread  1 Written\n");
			CloseHandle(hOut);
			LeaveCriticalSection(&cs);
			//ResumeThread(hh);
			Sleep(1000);
			//SuspendThread(hh);
	}
	return 0;

}
DWORD WINAPI myThread2(void* lpPar)//reader
{
	HANDLE hIn;
	DWORD dwNumberOfBytes;
	while (true)
	{
			EnterCriticalSection(&cs);
			hIn = CreateFile(stdPath, GENERIC_READ, 0, NULL,OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);
			if (hIn == INVALID_HANDLE_VALUE) {
				printf("ERROR %x \n", GetLastError());
				return 2;
			}
			else
			{
				ReadFile(hIn, u, 1, &dwNumberOfBytes, NULL);
				std::wcout << "\nRead: " << u << '\n'; //+ 
			}
			CloseHandle(hIn);
			LeaveCriticalSection(&cs);
			Sleep(1000);
	}
	return 0;
}
/*Сейчас всерабоает, но возмлжно не работало из-за того, что файл не был пуст, а так же чтобы читатетль не читал последнее 
число несколько раз из файла, уменьшили время WaitForSingleObject()*/
int main()
{
	DWORD myThreadID;
	DWORD myThreadID2;

	InitializeCriticalSection(&cs);

	HANDLE myHandle2 = CreateThread(0, 0, myThread2, NULL, CREATE_SUSPENDED, &myThreadID2);//reader
	HANDLE myHandle = CreateThread(0, 0, myThread, (void*)& myHandle2, NULL, &myThreadID);//writer

	BOOL b = SetThreadPriorityBoost(myHandle, false);
	if (b)
	{
		SetThreadPriority(myHandle, THREAD_PRIORITY_HIGHEST);
		
	}

	ResumeThread(myHandle2);
	WaitForSingleObject(myHandle, 5000);
	WaitForSingleObject(myHandle2, 5000);

	printf("\n Main Process sagt Das ist Alles");

	TerminateThread(myHandle, 0);
	TerminateThread(myHandle2, 0);

	return 0;
}