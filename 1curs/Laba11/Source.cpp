// если число меньше нуля, то выполнить замену на предыдущее и так перебирать по несколько раз 
// 15 вариант
/*#include <stdio.h>
#include <locale.h>
#include <iostream>
int main()
{
	using namespace std;
	setlocale(LC_ALL, "Rus");
	int a[100], i=0, n, j, temp = 0;
	int* ii;
	cout<<"Введите количество элементов массива: ";
	cin >> n;
	cout<<"Массив: "<< endl;
	ii = &i;
	for (; *ii < n; (*ii)++)
	{
		a[*ii] = (rand() % 30)-10;
		cout << a[*ii] << " ";
	}
	cout << endl;
	ii = 0;
	for (j = 0; j < n; j++)
	{
		for (i=0; i < n - 1; i++)
		{
			if (a[i] < a[i + 1])
			{
				temp = a[i];
				a[i] = a[i + 1];
				a[i + 1] = temp;
			}
		}
	}
	cout << "Упорядоченный массив: " ;
	cout << endl;
	for (i=0; i < n; i++)
	{
	cout<< a[i]<<" ";
	}*/
}
// если кью-суммачисел=0, то они одинаковы, значит, надо массив сделать с результатами сумм чисел, а потом сравнивать их между собой
// ища минимальное значение
// если складываем те значения, что за пределами, то не складываем значения, а заполням не суммой, а числом из массива, где число есть
#include <iostream>
#include <time.h>
using namespace std;
int main()
{
	setlocale(LC_CTYPE, "Russian");
	using namespace std;
	const int N = 150;
	int i, j, n, X[N], Y[N], S[N], rmx = 20, k, b, u, t, h, q, min;
	int* ii, *jj;

	// формирование массивов
	cout << "Введите размер массива Y: ";
	cin >> n;
	cout << "Введите размер массива X: ";
	cin >> k;
	cout << "Массив X:" << endl;
	srand((unsigned)time(NULL));
	for (int i = 0; i < k; i++)
	{
		X[i] = (rand() % rmx);
		cout << X[i] << " ";
	}
	cout << endl;

	cout << "Массив Y:" << endl;
	srand((unsigned)time(NULL));
	for (int i = 0; i < n; i++)
	{
	Y[i] = (rand() % rmx)+11;
		cout << Y[i] << " ";
	}
	cout << endl;
	cout << "Введите число q: " << endl; cin >> q;
	cout << "ААААА: " << X[0] << endl;
	S[0] = Y[0]+X[0];
	cout << "FFF: " << S[0]<<endl;
	// создание массива с суммой элементов массивов
    // если один массив больше другого, то количество итераций  в верхнем цикле равно колву лменетов большего массива
	if (n > k) 
	{
		ii = &n;// колво итераций в основном цикле
		jj = &k;//значения, что будут прогоняться i раз в цикле
	}
	// i>j
	else
	{
		ii = &k;
		jj = &n;
	}
	if (n == k)
	{
		ii = &k; jj = &n;
	}
	i = 0; j = 0; t = 0;
	cout << "Массив S: ";
	h = *jj;
	for ( ; *jj > 0; *jj = (*jj) - 1)
	{
		S[t] = X[i] + Y[j];
		t++; i++; j++;
	}
 	// массив с суммами 
	u = t; t = 0;
	
	for (; u > t; t++)
		cout << S[t] << " ";

	min = abs(S[0] - q);
	for (int i = 1; i < h; i++)
	{
		b = abs(S[i] - q);
		if (min > b)
		{
			min = b;
			u = S[i];
		}
	}
	cout << endl;
	cout << "Самое близкое значение к " << q << ": " <<u;
}

	

