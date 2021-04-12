////Поток выполняет последовательный счет, но через пять секунд обрывается основным процессом.
/*#include <tchar.h>
#include <windows.h>
#include <iostream>
#include "string.h"


DWORD WINAPI myThread(LPVOID lpParameter)
{
	unsigned int counter = 0;

	while (counter < 20)
	{
		Sleep(1000);
		counter++;
		printf("\n Counter= %d", counter);
	}

	return 0;
}

int _tmain(int argc, _TCHAR* argv[])
{
	unsigned int myCounter = 0;
	DWORD myThreadID;
	HANDLE myHandle = CreateThread(0, 0, myThread, &myCounter, 0, &myThreadID);
	Sleep(5000);
	printf("\n Main Process sagt");
	TerminateThread(myHandle, 0);

	return 0;
}*/

///////////////////////////////////////////////////////////////////////////////////////////////////////////
//передача целочисленного параметра z
/*#include <windows.h>
#include <iostream>
#include "string.h"
#include <tchar.h>

DWORD WINAPI myThread(void* lpParameter)
{

	int* counterp = new int();
	counterp = (int*)lpParameter;
	int counter = *counterp;

	while (counter < 20)
	{
		Sleep(1000);
		counter++;
		printf("\n Counter= %d", counter);
	}

	return 0;
}

int _tmain(int argc, _TCHAR* argv[])
{

	int z = 5;
	unsigned int myCounter = 0;
	DWORD myThreadID;
	HANDLE myHandle = CreateThread(0, 0, myThread, (void*)& z, 0, &myThreadID);
	Sleep(5000);
	printf("\n Main Process sagt");
	TerminateThread(myHandle, 0);
	return 0;
}*/


/////////////////////////ZADANIE1////////////////////////////////////////////////////////////////////////
//2 потока, которые выполняют вывод чисел на консоль вперемежку
/*#include <windows.h>
#include <iostream>
#include "string.h"
#include <tchar.h>

DWORD WINAPI myThread2(void* lpParameter)
{
	int* counterp = new int();
	counterp = (int*)lpParameter;
	int counter = *counterp;

	while (counter < 70)
	{
	    Sleep(100);
		counter++;
		printf("\n Counter2= %d", counter);
	}

	return 0;
}
DWORD WINAPI myThread(void* lpParameter)
{

	int* counterp = new int();
	counterp = (int*)lpParameter;
	int counter = *counterp;

	while (counter < 20)
	{
		Sleep(100);
		counter++;
		printf("\n Counter1= %d", counter);
	}

	return 0;
}
int _tmain(int argc, _TCHAR* argv[])
{
	int z = 0, f=50;
	DWORD myThreadID;
	HANDLE myHandle = CreateThread(0, 0, myThread, (void*)& z, 0, &myThreadID);
	DWORD myThreadID2;
	HANDLE myHandle2 = CreateThread(0, 0, myThread2, (void*)& f, 0, &myThreadID2);

	Sleep(4000);
	printf("\n Main Process sagt");
	TerminateThread(myHandle2, 0);
	TerminateThread(myHandle, 0);

	return 0;
}*/



///////////////////////////////////////////ZADANIE2//////////////////////////////////
/*#include <windows.h>
#include <iostream>
#include "string.h"
#include "tchar.h"
#include <iomanip>

int a = 0;
HANDLE myHandle;
// потоки писатель/читатель
DWORD WINAPI myThread2(void* lpParameter)//writer
{
	//записывает в ячеку глобальную переменную
	while (a < 10)
	{
		a++;
		ResumeThread(myHandle);
		Sleep(300);
	}
	return 0;
}
//после того, как писатель записал число, он запускает читателя, который считывает число и выдает его на консоль 
DWORD WINAPI myThread(void* lpParameter)//reader
{
	SuspendThread(myHandle);
	while (true)
	{
		printf("Number: %d\n", a);
		SuspendThread(myHandle);
	}
	return 0;
}

int main()
{
	DWORD myThreadID;
    myHandle = CreateThread(0, 0, myThread, 0, 0, &myThreadID);//reader
	DWORD myThreadID2;
	HANDLE myHandle2 = CreateThread(0, 0, myThread2, 0, 0, &myThreadID2);//writer

	Sleep(2700);
	printf("\n\n Main Process sagt\n");
	TerminateThread(myHandle2, 0);
	TerminateThread(myHandle, 0);

	return 0;
}
*/