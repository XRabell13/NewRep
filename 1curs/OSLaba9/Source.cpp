//1.��������� ���������� ������.
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
	//int CurPr = GetPriorityClass(GetCurrentProcess());//��������� ���������� ����������� �� ������ ������ ������

	int   iPriority1 = GetThreadPriority(myHandle);// + CurPr; 
	printf("\n Priority is: %d", iPriority1);
	SetThreadPriority(myHandle, THREAD_PRIORITY_ABOVE_NORMAL);//��������� ������� ������ ���������� ������
	iPriority1 = GetThreadPriority(myHandle);// + CurPr;
	printf("\n After Change Priority is: %d", iPriority1);

	SetThreadPriority(myHandle, THREAD_PRIORITY_HIGHEST);//��������� ������� ������ ������� ���������� 
	iPriority1 = GetThreadPriority(myHandle);// + CurPr;
	printf("\nThe Highest Priority is: %d", iPriority1);

	SetThreadPriority(myHandle, THREAD_PRIORITY_LOWEST);//��������� ������� ������ ��� ���������� 
	iPriority1 = GetThreadPriority(myHandle);// + CurPr;
	printf("\nThe Lowest Priority is: %d", iPriority1);

	Sleep(5000);
	printf("\n Main Process sagt Das ist Alles\n");
	TerminateThread(myHandle, 0);
	return 0;
}*/

//-----------------------------------------------------------------------------------------------
//2.������ ������ �� ������ � ����.
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

//3.������ ��������� ������������ ������ � �������� ��������� � �����
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

//4.	������ � ������� ��������� �������� ���������� ������ ������
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

	WaitForSingleObject(myHandle, 10000); //���������� ����� ���������� ������ ���� 10000 �����������(��� ������)
	
	printf("\n Main Process sagt Das ist Alles");
	
	TerminateThread(myHandle, 0);

	return 0;
}*/
//����� ������������ �������   WaitForSingleObject(myHandle, 10000);
//������� ���������� ����� ���������� ������ ���� 10000 �����������(��� ������).

//-----------------------------------------------------------------------------------------------

//5.	������ �������������� ������ ������ � ������ � ������� ��������� ���������(����������� ���).�������� �������� �� ������������� ������

//EnterCriticalSection(&cs);  -���� � ����������� ������
//LeaveCriticalSection(&cs);  -����� �� ����������� ������
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

//6.	�������, ������� ������������������ ������ � ������ � ���� �� ����� ����� �������� ����������� ������ �� ������� ���� �������.
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
�������.

�������� ��������� � ����� ��������.���� ����� � ����, ������ ������ �� ���� �� �����.��������� ������������� ������� ���� �������� ����������� ���.

����� �������, ��� ����� - �������� ����� �����.��� �������������� ����� � ������ ��������� ����� �����������

char* u = new char();
itoa(25, u, 10);

������ u �������� �������� 25 � 10 - ������ �������.����� ����� ������������ ���������� ����� :
*/
/*�������� ��������� � ����� ��������.
���� ����� � ����, ������ ������ �� ���� �� �����.
��������� ������������� ������� ����� �������� ����������� ���.*/
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
			hOut = CreateFile(stdPath, GENERIC_WRITE, 0, NULL, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);// �������, � �� ���������, ����� ���������� �����������
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
/*������ ����������, �� �������� �� �������� ��-�� ����, ��� ���� �� ��� ����, � ��� �� ����� ��������� �� ����� ��������� 
����� ��������� ��� �� �����, ��������� ����� WaitForSingleObject()*/
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