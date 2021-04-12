/*#include <windows.h>
#include <iostream>
#include "string.h"
#include <tchar.h>

int _tmain(int argc, _TCHAR* argv[])
{
	STARTUPINFO cif;
	ZeroMemory(&cif, sizeof(STARTUPINFO));
	PROCESS_INFORMATION pi;
	TCHAR buf[] = TEXT("c:/Users/hp/source/repos/OSLaba7/Debug/OSLaba7.exe");
	if (!(CreateProcess(NULL, buf, NULL, NULL, FALSE, 0,
		NULL, NULL, &cif, &pi)))
		std::wcout << "Error " << '\n';
	if (!(CreateProcess(NULL, buf, NULL, NULL, FALSE, 0,
		NULL, NULL, &cif, &pi)))
		std::wcout << "Error " << '\n';
	//return 0;
	CreateProcessA(
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

/*#include <iostream>
#include <ctime>

int fibonacciNumbers(int number);

int main()
{
	clock_t t1, t2;
	int num = 0;
	std::cin >> num;

	for (int i = 1; i <= num; i++)
		std::cout << fibonacciNumbers(i) << " ";
	std::cout << std::endl;

	system("pause");
	return 0;
}

int fibonacciNumbers(int number)
{
	if (number < 3)
		return 1;
	else
		return (fibonacciNumbers(number - 1) + fibonacciNumbers(number - 2));
}*/

/*#include <iostream>
using namespace std;
int y = 0;






int S(int x)
{
	if (x >= 0)
	{
		if (x > 100) { x = x + 10; return x; }
		else S(S(x + 4));
	}
}

int main()
{
	int x = 1, u;
	while (x!= 0)
	{
		cout << "\nx = "; cin >> x;
		u = S(x);
		cout << "\ny = " << u;
		u = 0;
	}
	return 0;
}*/

/*
#include <windows.h>
#include <iostream>
#include <tchar.h>
#include <ctime> 
using namespace std;
clock_t ta1, ta2, tb1, tb2, t1, t2, tima = 0, timb = 0;

int fibonacciNumbers(int number)
{
	if (number < 3)
	{

		return 1;
	}
	else
		return (fibonacciNumbers(number - 1) + fibonacciNumbers(number - 2));
}

long double factorial(int n)
{
	long double f = 1;
	int i;

	for (i = 2; i <= n; ++i)
	{
		f *= i;
		Sleep(300);
		tima = clock();
		if (tima >= 1000) { cout << "factorial" << i << " = " << f << endl; tima = 0; }
	}
	return f;
}

int main(int argc, _TCHAR* argv[])
{
	setlocale(LC_ALL, "Russian");
	int a = 0, b = 0;
	long double u, sum=0;

	cout << " a = "; cin >> a;// 37 
	cout << " b = "; cin >> b;// 42
	t1 = clock();

	tb1 = clock();
	u = factorial(a);
	cout << "\n FinalFactorial = " << u << " " << endl;
	tb2 = clock();
	
	ta1 = clock();
	for (int k = 1; k <= b; k++)
	{
		//cout << " "<<fibonacciNumbers(k)<<" ";
		sum += fibonacciNumbers(k);
	    cout << "Sum = " << sum << endl; 
	}
	cout << "FinalSum = " << sum << endl;
	ta2 = clock();

	t2 = clock();
	cout << " Время А: " << (int)(ta2 - ta1) << " ticks\nВремя В:" << (int)(tb2 - tb1) << " ticks\nВремя приложения: " << (int)(t2 - t1) << " ticks\n";
	return 0;
}
*/

//1000 тиков в 1 секунде в данной проге



