//---------------------------------------------------------------------------

#pragma hdrstop

//---------------------------------------------------------------------------

#pragma argsused
#include <stdlib.h>
#include <stdio.h>
#include <conio.h>
#include <windows.h>
#include<ctime>

#define BufferSize 2
#define Producers 5
#define Consumers 5

int Buffer[BufferSize];
bool Trans;
HANDLE hFull, hEmpty, hMutex;

DWORD WINAPI Producer(void* pValue)
{
	int SleepInterval, Value, i, Count, Written;
	Trans = true;
	Count = 15;
	while (Count > 0)
	{
		Count--;
		srand((unsigned)time(NULL));
		Value = rand() % 100;
		WaitForSingleObject(hEmpty, INFINITE);
		WaitForSingleObject(hMutex, INFINITE);

		if (Buffer[BufferSize - 1] != 0)
			printf("Producer: %d | Value %d losted\n", Value, Buffer[BufferSize - 1]);
		else
			printf("Producer: %d\n", Value);
		for (i = BufferSize - 2; i >= 0; i--)
			Buffer[i + 1] = Buffer[i];
		Buffer[0] = Value;

		ReleaseSemaphore(hMutex, 1, NULL);
		ReleaseSemaphore(hFull, 1, NULL);
		srand((unsigned)time(NULL));
		SleepInterval = (rand() % 100)+2000;
		Sleep(SleepInterval);
	}
	return 0;
}

DWORD WINAPI Consumer(void* pValue)
{
	int SleepInterval, Value, i, Count, Written;
	while (Trans)
	{
		Written = 0;
		WaitForSingleObject(hFull, INFINITE);
		WaitForSingleObject(hMutex, INFINITE);
		for (i = BufferSize - 1; i >= 0; i--)
			if (Buffer[i] != 0)
			{
				Written = i;
				break;
			}
		Value = Buffer[Written];
		//Sleep(random(21));//??
		Buffer[Written] = 0;
		if (Value == 0)
			printf("\t\t\t\tConsumer: %d | The value is wrong!\n", Value);
		else
			printf("\t\t\t\tConsumer: %d\n", Value);

		ReleaseSemaphore(hMutex, 1, NULL);
		ReleaseSemaphore(hEmpty, 1, NULL);
		SleepInterval = (rand() % 100) + 1000;
		Sleep(SleepInterval);
	}
}

int main(void)
{
	HANDLE hThreads[Producers + Consumers];
	DWORD ThreadId;
	int i;
//	randomize();
	hMutex = CreateSemaphore(NULL, 1, 1, "Mutex");
	hFull = CreateSemaphore(NULL, 0, BufferSize, "Full");
	hEmpty = CreateSemaphore(NULL, BufferSize, BufferSize, "Empty");

	for (i = 0; i < BufferSize; i++) Buffer[i] = 0;

	for (i = 0; i < Producers; i++)
		hThreads[i] = CreateThread(0, 0, Producer, 0, 0, &ThreadId);

	for (i = Producers; i < Producers + Consumers; i++)
		hThreads[i] = CreateThread(0, 0, Consumer, 0, 0, &ThreadId);

	WaitForMultipleObjects(Producers, hThreads, true, INFINITE);

	Trans = false;

	WaitForMultipleObjects(Producers + Consumers, hThreads, true, INFINITE);

	for (i = 0; i < Producers + Consumers; i++)
		CloseHandle(hThreads[i]);
	CloseHandle(hMutex);
	CloseHandle(hFull);
	CloseHandle(hEmpty);

	getchar();
	return 0;
}

//---------------------------------------------------------------------------