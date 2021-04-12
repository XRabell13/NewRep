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

#include <windows.h>
#include <iostream>
#include <tchar.h>
#include <ctime> 
using namespace std;
clock_t ta1, ta2, tb1, tb2, t1, t2, tima = 0, timb = 0;

/*int S(int x)
{
	if (x >= 0)
	{
		if (x > 100) { x = x + 10; return x; }
		else S(S(x + 4));
	}
}

long int fact(int N)
{
	if (N < 0) 
		return 0; 
	if (N == 0) 
		return 1;
	else
		return N * fact(N - 1); 
}*/

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
		if (tima >= 1000) { cout << "factorial"<< i <<" = " << f << endl; tima = 0; }
	}
	return f;
}

DWORD WINAPI B(void* lpParameter)
{
	tb1 = clock();
	// преобразование значения из void  в int
	int* bp = new int();
	bp = (int*)lpParameter;
	int b = *bp, i1 = 1, i2 = 1, i;
	long double sum = 0;
//					Сумма чисел фибоначчи
	i = b;
	for (int k = 1; k <= b; k++)
	{
		//cout << " "<<fibonacciNumbers(k)<<" ";
		sum += fibonacciNumbers(k);
		timb = clock();
		if (timb >= 1000) { cout << "sum = " << sum << endl; timb = 0; }
	}
	cout << "sum = " << sum <<endl;
	cout << endl;
	tb2 = clock();
	return 0;
}
DWORD WINAPI A(void* lpParameter)
{
	ta1 = clock();
	// преобразование значения из void  в int
	int* ap = new int();
	ap = (int*)lpParameter;
	int x = *ap;
	long double u;
	
	//					Факториальная функция
	    u = factorial(x);
		cout << "\n y = " << u <<" "<<endl;
		//Sleep(100);
		ta2 = clock();

	return 0;
}
int main(int argc, _TCHAR* argv[])
{
	setlocale(LC_ALL, "Russian");
	int a = 0, b=0;

	cout << " a = "; cin >> a;// 37 
	cout << " b = "; cin >> b;// 42
	t1 = clock();
	DWORD myThreadID2;
    HANDLE myHandle2 = CreateThread(0, 0, B, (void*)& b, 0, &myThreadID2);
	DWORD myThreadID;
	HANDLE myHandle = CreateThread(0, 0, A, (void*)& a, 0, &myThreadID);
	
	Sleep(37000);
	
	//TerminateThread(myHandle, 0);
//	TerminateThread(myHandle2, 0);
	t2 = clock();
	cout << " Время А: " << (int)(ta2 - ta1) << " ticks\nВремя В:" << (int)(tb2 - tb1)<< " ticks\nВремя приложения: "<< (int)(t2-t1)<<" ticks\n";
	return 0;
}


//1000 тиков в 1 секунде в данной проге