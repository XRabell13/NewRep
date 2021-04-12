/*
#include <windows.h>
#include <stdlib.h>
#include <time.h>
#include <sstream>
#include <iostream>

#define BUFF_SIZE 10

using namespace std;

HANDLE hEventProd;
HANDLE hEventCons;
HANDLE hEventFull;
HANDLE hEventEmpty;
HANDLE hEventSingle;
HANDLE hEventAccess;
HANDLE hEventSize;

HANDLE aThread[5];

typedef struct node {
	int number;
	struct node* next;
} node;

typedef struct {
	node* start;
	node* end;
} list;

int capacity;

list* BUFFER;

void Producer();
void Consumer();
int createthreads();

node* CreateNode(int);
list* CreateList();

void Push();
void Pop();

int main() {

	BUFFER = CreateList();
	createthreads();

	SetEvent(hEventProd);
	SetEvent(hEventCons);
	SetEvent(hEventAccess);
	SetEvent(hEventSize);

	WaitForMultipleObjects(5, aThread, TRUE, INFINITE);

	return 0;
}



void Producer() {

	srand(time(NULL));
	for (; ;)
	{
		WaitForSingleObject(hEventProd, INFINITE);
		if (capacity == BUFF_SIZE) WaitForSingleObject(hEventFull, INFINITE);


		WaitForSingleObject(hEventAccess, INFINITE);
		if (capacity == 1)
		{
			Push();
			SetEvent(hEventAccess);
		}
		else
		{
			SetEvent(hEventAccess);
			Push();
		}


		if (capacity == 1) SetEvent(hEventEmpty);


		SetEvent(hEventProd);
		Sleep(300 + rand() % 1000);
	}
}


void Consumer() {

	srand(time(NULL));
	for (; ; )
	{
		WaitForSingleObject(hEventCons, INFINITE);


		if (capacity == 0)  WaitForSingleObject(hEventEmpty, INFINITE);


		WaitForSingleObject(hEventAccess, INFINITE);
		if (capacity == 1)
		{
			Pop();
			SetEvent(hEventAccess);
		}
		else
		{
			SetEvent(hEventAccess);
			Pop();
		}

		if (capacity == BUFF_SIZE - 1)  SetEvent(hEventFull);


		SetEvent(hEventCons);
		Sleep(700 + rand() % 1000);
	}
}

int createthreads() {
	hEventProd = CreateEvent(NULL, FALSE, FALSE, NULL);
	hEventCons = CreateEvent(NULL, FALSE, FALSE, NULL);
	hEventFull = CreateEvent(NULL, FALSE, FALSE, NULL);
	hEventEmpty = CreateEvent(NULL, FALSE, FALSE, NULL);
	hEventSingle = CreateEvent(NULL, FALSE, FALSE, NULL);
	hEventAccess = CreateEvent(NULL, FALSE, FALSE, NULL);
	hEventSize = CreateEvent(NULL, FALSE, FALSE, NULL);

	aThread[0] = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)Producer, NULL, 0, NULL);
	aThread[1] = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)Consumer, NULL, 0, NULL);
	aThread[2] = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)Consumer, NULL, 0, NULL);
	aThread[3] = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)Producer, NULL, 0, NULL);
	aThread[4] = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)Consumer, NULL, 0, NULL);


	stringstream message;
	message << "Two threads have been created" << endl;
	cerr << message.str();

	return 0;
}


node* CreateNode(int number) {
	node* nd = (node*)malloc(sizeof(node));
	nd->number = number;
	nd->next = NULL;
	return nd;
}

list* CreateList() {
	list* buffer = (list*)malloc(sizeof(list));
	buffer->end = NULL;
	buffer->start = NULL;
	capacity = 0;
	return buffer;
}

void Push() {

	node* nd = CreateNode(400);

	if (capacity == 0) {
		BUFFER->start = nd;
		BUFFER->end = nd;
	}
	else {
		nd->next = BUFFER->start;
		BUFFER->start = nd;
	}

	WaitForSingleObject(hEventSize, INFINITE);

	capacity++;
	stringstream message;
	message << "(Push)Elemets in buffer -> " << capacity << endl;
	cerr << message.str();

	SetEvent(hEventSize);



}

void Pop() {

	if (capacity == 1) {
		free(BUFFER->start);
		BUFFER->start = NULL;
		BUFFER->end = NULL;
	}
	else {
		node* temp = BUFFER->start;
		while (temp->next != BUFFER->end) temp = temp->next;
		free(BUFFER->end);
		BUFFER->end = temp;
		temp->next = NULL;
	}

	WaitForSingleObject(hEventSize, INFINITE);

	capacity--;
	stringstream message;
	message << "(Pop)Elemets in buffer -> " << capacity << endl;
	cerr << message.str();

	SetEvent(hEventSize);
}*/
#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <conio.h>
#include <windows.h>
#define MAX_PRODUCERS 6
#define SIZE_BUF 25
//#define READ_OUTPUT
 
using namespace std;
 
DWORD uThrProdID[MAX_PRODUCERS], uThrConsID;
 
HANDLE hEventWrite, hEventRead, hEventBuf;
HANDLE hThrProdArray[MAX_PRODUCERS], hThrCons;
 
void ProducerThread(char name[11]);
void ConsumerThread(void *pParams);
 
int cycleBuf[SIZE_BUF];
int tail = 0;
int head = 0;
int count1 = 0;
 
void FlushBuf(void);
void PutChar(int sym);
int GetChar(void);
 
FILE *fw;
 
int main()
{
	fw = fopen("bufw.txt", "w");
    FlushBuf();
 
    hEventWrite = CreateEvent(NULL, FALSE, FALSE, NULL);
    hEventBuf = CreateEvent(NULL, FALSE, TRUE, NULL);
    hEventRead = CreateEvent(NULL, FALSE, TRUE, NULL);
 
    for ( int i = 0; i < MAX_PRODUCERS; i++ )
    {
        char* prod = new char[11];
        sprintf(prod, "Producer %d", i+1);//запись в символьный массив
        hThrProdArray[i] = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)ProducerThread, prod, 0, &uThrProdID[i]);
    }
 
    hThrCons = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)ConsumerThread, NULL, 0, &uThrConsID);
 
    getchar();
 
    fclose(fw);
 
    CloseHandle(hEventBuf);
    CloseHandle(hEventRead);
    CloseHandle(hEventWrite);
 
    for ( int i = 0; i < MAX_PRODUCERS; i++ )
        CloseHandle(hThrProdArray[i]);
 
    CloseHandle(hThrCons);
    return 0;
}
 
void ProducerThread(char name[11])
{

    while(1)
    {
        WaitForSingleObject(hEventRead, INFINITE);
        Sleep(rand()%500);
        if (count1 < SIZE_BUF)
        {
            for ( int i = 0; i < 3; i++ )
            {
                PutChar(name[9]);
                putc(name[9], fw);
            }
            putc(13, fw);
        }
        cout<<name << ": There are " << count1 << " symbols in buf" << endl << endl;
        SetEvent(hEventWrite);
    }
}
 
void ConsumerThread(void *pParams)
{
	
    WaitForSingleObject(hEventWrite, INFINITE);
    while(1)
    {
        Sleep(rand()%50);
        if (count1 == 0)
        {
            SetEvent(hEventRead);
            WaitForSingleObject(hEventWrite, INFINITE);
        }

        cout << "Consumer: I've read one symbol. There are " << count1 << " symbols in buf now. " << endl << endl;
        SetEvent(hEventRead);
    }
}
 
void FlushBuf(void)
{
    tail = 0;
    head = 0;
    count1 = 0;
}
 
void PutChar(int sym)
{
	
    WaitForSingleObject(hEventBuf, INFINITE);
    if (count1 < SIZE_BUF)
    {
        cycleBuf[tail] = sym;
        count1++;
        tail++;
        if (tail == SIZE_BUF) tail = 0;
    }
    SetEvent(hEventBuf);
}
/*
int GetChar(void)
{
    int sym = 0;
    if (count1 > 0)
    {
        sym = cycleBuf[head];
        count1--;
        head++;
        if (head == SIZE_BUF) head = 0;
    }
    return sym;
}*/
//---------------------------------------------------------------------------


//---------------------------------------------------------------------------
/*
#include <stdlib.h>
#include <stdio.h>
#include <conio.h>
#include<ctime>
#include <windows.h>

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
		Value = (rand() % 100)+1;
		//Value = random(10) + 1;
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
		SleepInterval = (rand() % 2000) + 2000;
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
		srand((unsigned)time(NULL));
		Sleep(rand() % 21);
		Buffer[Written] = 0;
		if (Value == 0)
			printf("\t\t\t\tConsumer: %d | The value is wrong!\n", Value);
		else
			printf("\t\t\t\tConsumer: %d\n", Value);

		ReleaseSemaphore(hMutex, 1, NULL);
		ReleaseSemaphore(hEmpty, 1, NULL);
		srand((unsigned)time(NULL));
		SleepInterval = (rand() % 2000) + 1000;
		Sleep(SleepInterval);
	}
	return 0;
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
*/

