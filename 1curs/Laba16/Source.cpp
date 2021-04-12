//Проверить, все ли столбцы матрицы содержат хотя бы один положительный элемент.
// Если нет, то в пер-вом столбце, не удовлетворяющем условию, заменить отрицательные элементы их модулями.

//15.2

/*#include <iostream>
#include <math.h>
using namespace std;
int bla(int n, ...)
{
	int bin = 0, u = 0, k=0; int* p = &n;
	u = n;
	for (int i = 0; i<u; i++)
	{
		k = *(p+i);
		bin = 0;
		for (int j = 0; k != 0; j++)
		{
			bin = bin + (k % 2) * pow(10.0, j);
			k = k/2;
		}
		cout << bin << endl;
	}
	cout << endl;
	return 0;
}
int main()
{
	bla(6, 4, 5, 1, 2, 3);
	bla(3, 4, 5);
	bla(4, 4, 5, 1);

}*/

// 15.1
#include<cstdio>
#include<cmath>
#include<iostream>
const int MAXN = 10;
using namespace std;
int a[MAXN][MAXN], n, m, f = 0;

int &func1(int &f, int &i)
{
	for (int j = 0; j < n; ++j) if (a[j][i] > 0) f = 0;
	return f;
}

int main()
{
	scanf_s("%d %d", &n, &m); // n - строка m - столбец
	for (int i = 0; i < n; ++i)
		for (int j = 0; j < m; ++j)
		{
			scanf_s("%d", &a[i][j]); // заполнение массива
		}

	for (int i1 = 0; i1 < n; ++i1)
	{
		for (int j1 = 0; j1 < m; ++j1)
		{
			printf("%d ", a[i1][j1]);
		}
		printf("\n");
	}
	cout << endl;//вывод начального массива

	for (int i = 0; i < m; ++i)
	{
		f = 1;
		f=func1(f,i); // ищем в столбце положительные элементы, если есть, то ф=0 и не будет ниже выполняться условие

		if (f == 1)
		{
			for (int i1 = 0; i1 < n; ++i1) if (a[i1][i] < 0) a[i1][i] = -a[i1][i];
			for (int i1 = 0; i1 < n; ++i1)
			{
				for (int j1 = 0; j1 < m; ++j1)
				{
					printf("%d ", a[i1][j1]);
				}
				printf("\n");
			}
			return 0;
		}
	}
	
	return 0;
}



