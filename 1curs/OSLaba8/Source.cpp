////����� ��������� ���������������� ����, �� ����� ���� ������ ���������� �������� ���������.
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
//�������� �������������� ��������� z
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


/////////////////////////ZAD!////////////////////////////////////////////////////////////////////////
//2 ������, ������� ��������� ����� ����� �� ������� ����������
#include <windows.h>
#include <iostream>
#include "string.h"
#include <tchar.h>

DWORD WINAPI myThread2(void* lpParameter)
{

	HANDLE* h = new HANDLE();
	h = (HANDLE*)lpParameter;
	HANDLE hh = *h;
	printf("\n Thread 2 tries to suspend thread1");
	SuspendThread(hh);
	printf("\n Thread1 is suspended for 2 seconds");
	Sleep(2000);
	ResumeThread(hh);
	printf("\n Thread is resumed");
	return 0;
}
DWORD WINAPI myThread(void* lpParameter)
{

	int* counterp = new int();
	counterp = (int*)lpParameter;
	int counter = *counterp;

	while (counter < 30)
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
	Sleep(3000);
	DWORD myThreadID2;
	HANDLE myHandle2 = CreateThread(0, 0, myThread2, (void*)& myHandle, 0, &myThreadID2);

	Sleep(12000);
	printf("\n Main Process sagt");
	TerminateThread(myHandle2, 0);
	TerminateThread(myHandle, 0);


	return 0;
}


///////////////////////////////////////////ZAD2//////////////////////////////////
#include <windows.h>
#include <iostream>
#include "string.h"
#include "tchar.h"
#include <iomanip>
volatile int a, b, c;
// ������ ��������/��������
DWORD WINAPI myThread2(void* lpParameter)//writer
{
	HANDLE* h = new HANDLE();
	h = (HANDLE*)lpParameter;
	HANDLE hh = *h;//��������� ������
	//���������� � ����� ���������� ����������
	a = 1;
	SuspendThread(hh);
	Sleep(300); //������������ ������ ����� �������� �����
	ResumeThread(hh);
	b = 2;
	SuspendThread(hh);
	Sleep(300);
	ResumeThread(hh);
	c = 3;
	SuspendThread(hh);
	Sleep(300);
	ResumeThread(hh);
	return 0;
}

//����� ����, ��� �������� ������� �����, �� ��������� ��������, ������� ��������� ����� � ������ ��� �� ������� 
DWORD WINAPI myThread(void* lpParameter)//reader
{
	Sleep(300);
	printf("\n a = %d", a);
	Sleep(300);
	printf("\n b = %d", b);
	Sleep(300);
	printf("\n c = %d", c);
	return 0;
}

int _tmain(int argc, _TCHAR* argv[])
{
	DWORD myThreadID;
	HANDLE myHandle = CreateThread(0, 0, myThread, 0, 0, &myThreadID);
	
	DWORD myThreadID2;
	HANDLE myHandle2 = CreateThread(0, 0, myThread2, (void*)&myHandle, 0, &myThreadID2);

	Sleep(3000);
	printf("\n\n Main Process sagt\n");
	TerminateThread(myHandle2, 0);
	TerminateThread(myHandle, 0);

	return 0;
}
*/