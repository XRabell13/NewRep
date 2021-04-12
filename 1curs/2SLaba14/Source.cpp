#include <ctime>             
#include <stdlib.h>
#include <iostream>

using namespace std;

/////////////////СОРТИРОВКА ВЫБОРОМ////////////////////////
void selectSort(int A[], int size)
{
	int k, i, j;
	for (i = 0; i < size - 1; i++)
	{
		for (j = i + 1, k = i; j < size; j++)
			if (A[j] < A[k])
				k = j;
		int c = A[k];
		A[k] = A[i];
		A[i] = c;
	}
}
/////////////////СОРТИРОВКА ХОАРА////////////////////////
int getHoarBorder(int A[], int sm, int em)
{
	int i = sm - 1, j = em + 1;
	int brd = A[sm];
	int buf;
	while (i < j)
	{
		while (A[--j] < brd);//по убыванию
		while (A[++i] > brd);//по убыванию
		if (i < j)
		{
			buf = A[j];
			A[j] = A[i];
			A[i] = buf;
		};
	}
	return j;
}
int* sortHoar(int A[], int sm, int em)/*Здесь A[] – исходный массив чисел,
									  sm –  индекс первого элемента массива,
									  em –  индекс по-следнего (последний элемент правой части).*/
{
	if (sm < em)
	{
		int hb = getHoarBorder(A, sm, em);
		sortHoar(A, sm, hb);
		sortHoar(A, hb + 1, em);
	}
	return A;
};
/////////////////ПИРАМИДАЛЬНАЯ СОРТИРОВКА////////////////////////
void heapify(int A[], int pos, int n)
{
	int t, tm;
	while (2 * pos + 1 < n)
	{
		t = 2 * pos + 1;
		if (2 * pos + 2 < n && A[2 * pos + 2] >= A[t])
			t = 2 * pos + 2;
		if (A[pos] < A[t])
		{
			tm = A[pos];
			A[pos] = A[t];
			A[t] = tm;
			pos = t;
		}
		else break;
	}
}
void piramSort(int A[], int n)
{
	for (int i = n - 1; i >= 0; i--)
		heapify(A, i, n);
	while (n > 0)
	{
		int tm = A[0];
		A[0] = A[n - 1];
		A[n - 1] = tm;
		n--;
		heapify(A, 0, n);
	}
}

//------------------------------
int getRandKey(int reg = 0)     // генерация случайных ключей
{
	if (reg > 0)
		srand((unsigned)time(NULL));
	int rmin = 0;
	int rmax = 100000;
	return (int)(((double)rand() / (double)RAND_MAX) * (rmax - rmin) + rmin);
}
//------------------------------

int main()
{
	setlocale(LC_CTYPE, "Russian");
	const int N = 10000;
	int k[N], f[N];
	clock_t  t1, t2;
	getRandKey(1);
	for (int i = 0; i < N; i++)
		f[i] = getRandKey(0);
	for (int n = 10000; n <= N; n += 10000)
	{
		cout << "n = " << n << endl;

		cout << "Пирамидальная сортировка: ";
		memcpy(k, f, n * sizeof(int));
		t1 = clock();
		piramSort(k, n);
		t2 = clock();
		cout << "Прошло " << t2 - t1 << " тактов времени" << endl<<endl;

		cout << "Сортировка Хоара: ";
		memcpy(k, f, n * sizeof(int));
		t1 = clock();
		sortHoar(k, 0, n);
		t2 = clock();
		cout << "Прошло " << t2 - t1 << " тактов времени" << endl << endl;

		cout << "Сортировка выбором: ";
		memcpy(k, f, n * sizeof(int));
		t1 = clock();
		selectSort(k, n);
		t2 = clock();
		cout << "Прошло " << t2 - t1 << " тактов времени" << endl << endl;
	}
	return 0;
}
