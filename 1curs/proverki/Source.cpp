#include <iostream>
#include <ctime>
using namespace std;
int fibonacciNumbers(int number)
{
	if (number < 3)
	{

		return 1;
	}
	else
		return (fibonacciNumbers(number - 1) + fibonacciNumbers(number - 2));
}


void main()
{
	time_t t1, t2;
	unsigned int long sum = 0;
	int b;
	cout << "b: "; cin >> b;
	//					Сумма чисел фибоначчи
	t1 = clock();
	for (int k = 1; k <= b; k++)
	{
		//cout << " "<<fibonacciNumbers(k)<<" ";
		sum += fibonacciNumbers(k);
	}
	t2 = clock();
	cout << "sum = " << sum << endl;
	cout << "\n Time: " << t2-t1;
	cout << endl;
	//tb2 = clock();
}
