#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <iostream>
#include <windows.h>
#include <time.h>
#include <tchar.h>

using namespace std;
//const int N = 100;  // razmer bufera
typedef int semaphore; // semafor celochislenniy
semaphore mutex = 1;   // vzaimoisklucheniya dlja kriticheskoy situacii
semaphore N = 100;   // semafor empty
semaphore full = 0;    // semafor full
int buf[1];


void randomize(void) {
	srand((unsigned int)time(NULL));
}

int random(int max_) {
	return rand() % max_;
};

void producer() //proizvoditel
{
	int item;
	while (N)
	{
		randomize();
		item = random(100);  // generiruem proizvolnoe chislo ot 1 do 99
		N--; //umenshaem semafor empty
		mutex--; //umenshaem semafor mutex
		buf[N] = item; // pomeshaem chilo v bufer
		mutex++; //uvelichivaem snachala mutex
		full++;  //zatem full
	}
}


void consumer() //potrebitel
{
	int item;
	int a = 0;
	while (full)
	{
		full--; //umenshem full
		mutex--; //zatem mutex
		item = buf[full]; // zabiraem informaciju iz bufera
		mutex++; //uvelichivaem mutex
		N++; //uvelichivaem empty
		a = a + item; // uvelichivaem peremennuju a na chislo vzatoe iz bufera
	}
	//vivodim na ekran summu chisel
	cout << endl << "summa=" << endl << a;
}
/*
int main()
{
	//clrscr();
	producer();
	consumer();
	getchar();
	return 0;
}*/
/*#include <windows.h>
#include <iostream>
#include "string.h"
#include <tchar.h>*/

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
	/*CreateThread(
    _In_opt_ LPSECURITY_ATTRIBUTES lpThreadAttributes,
    _In_ SIZE_T dwStackSize,
    _In_ LPTHREAD_START_ROUTINE lpStartAddress,
    _In_opt_ __drv_aliasesMem LPVOID lpParameter,
    _In_ DWORD dwCreationFlags,
    _Out_opt_ LPDWORD lpThreadId
    );*/
	Sleep(5000);
	printf("\n Main Process sagt");
	TerminateThread(myHandle, 0);

	return 0;
}


