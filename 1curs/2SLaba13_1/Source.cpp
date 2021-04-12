#include <iostream>
#include <ctime>
using namespace std;
void bubbleSort(int a[], int n)// по возрастанию
{
	int i, j, t;
	for (i = 1; i < n; i++)
		for (j = n - 1; j >= i; j--)
			if (a[j - 1] > a[j])
			{
				t = a[j - 1];
				a[j - 1] = a[j];
				a[j] = t;
			}
}
void _bubbleSort(int a[], int n)//по убыванию
{
	int i, j, t;
	for (i = 1; i < n; i++)
		for (j = n - 1; j >= i; j--)
			if (a[j - 1] < a[j])
			{
				t = a[j - 1];
				a[j - 1] = a[j];
				a[j] = t;
			}
}
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

int* shell(int m[], int lm)
{
	int buf;
	bool sort;
	for (int g = lm / 2; g > 0; g /= 2)
		do
		{
			sort = false;
			for (int i = 0, j = g; j < lm; i++, j++)
				if (m[i] < m[j])
				{
					sort = true;
					buf = m[i];
					m[i] = m[j];
					m[j] = buf;
				}
		} while (sort);
		return m;
}
void main()
{
	setlocale(LC_ALL, "Rus");
	srand((unsigned int)time(NULL));
	int size, i, k = 0, choise, max, imax;
	int B[1000], A[1000], C[1500];
	for (;;) {
		cout << "\nКоличество элементов = ";
		cin >> size;
		if (size <= 0) exit(0);
		for (i = 0; i < size; i++)
		{
			cout << " ";
			A[i] = (rand() % 1000);
			cout << A[i];
		}
		cout << endl;
		
		cout << "\n1 - Сортировка пузырьком по возрастанию\n2 - Сортировка по выбору\n\n3 - Сортировка Хоара по убыванию(доп13)";
		cout << "\n4 - Сортировка пузырьком по убыванию(доп13)\n\n5 - Сортировка Шелла(доп14)";
		cout<<"\n6 - Сортировка пузырьком по убыванию(доп14)\n\n7 - Сортировка пузырьком по убыванию(доп15)\n8 - Сортировка Хоара по убывнаию(доп15)\n";
		cout << "Выбор: ";
		cin >> choise;
		switch (choise) {
		case 1:
			k = 0;
			for (i = 0; i < size; i++)
				if (i % 2 == 0) B[k++] = A[i];
			cout << "\nB-массив: ";
			for (i = 0; i < k; i++)
				cout << B[i] << " ";
			bubbleSort(B, k);
			cout << "\nРезультирующий массив сортированный пузырьком: ";
			for (i = 0; i < k; i++)
				cout << B[i] << " ";
			cout << endl;
			break;
		case 2:
			k = 0;
			for (i = 0; i < size; i++)
				if (i % 2 == 0) B[k++] = A[i];
			cout << "\nB-массив: ";
			for (i = 0; i < k; i++)
				cout << B[i] << " ";
			selectSort(B, k);
			cout << "\nРезультирующий массив сортированный по выбору: ";
			for (i = 0; i < k; i++)
				cout << B[i] << " ";
			cout << endl;
			break;
		case 3:
			k = 0; max = A[0];
			for (i = 0; i < size; i++)
				if (A[i] >= max) {
					max = A[i];
					imax = i;
				}
			cout << "\nMax element: " << max << "\nindex: " << imax << endl;
			for (i = imax; i < size; i++)
				if (i % 2 == 0) B[k++] = A[i];
			cout << "\n\nB-массив: ";
			for (i = 0; i < k; i++)
				cout << B[i] << " ";
			i = 0;
			sortHoar(B, i, k);
			cout << "\n\nB-массив после сортировки Хоара: ";
			for (i = 0; i < k; i++)
				cout << B[i] << " ";
			cout << endl;
			break;
		case 4:
			k = 0; max = A[0];
			for (i = 0; i < size; i++)
				if (A[i] >= max) {
					max = A[i];
					imax = i;
				}
			cout << "\nMax element: " << max << "\nindex: " << imax << endl;
			for (i = imax; i < size; i++)
				if (i % 2 == 0) B[k++] = A[i];
			cout << "\n\nB-массив: ";
			for (i = 0; i < k; i++)
				cout << B[i] << " ";
			_bubbleSort(B, k);
			cout << "\nРезультирующий массив сортированный пузырьком: ";
			for (i = 0; i < k; i++)
				cout << B[i] << " ";
			cout << endl;
			break;

		case 5:
			k = 0;
			cout << "\n\nМассив В: ";
			for (i = 0; i < size; i++)
			{
				cout << " ";
				B[i] = (rand() % 1000);
				cout << B[i];
			}
			for (i = 0; i < size; i++)
				if (A[i] % 2 != 0) C[k++] = A[i];
			for (i = 0; i < size; i++)
				if (B[i] % 2 == 0) C[k++] = B[i];
			cout << "\n\nC-массив: ";
			for (i = 0; i < k; i++)
				cout << C[i] << " ";
			
			cout << "\n\nC-массив: ";
			shell(C,k);
			for (i = 0; i < k; i++)
				cout << C[i] << " ";
			break;
		case 6: 
			k = 0;
			cout << "\n\nМассив В: ";
			for (i = 0; i < size; i++)
			{
				cout << " ";
				B[i] = (rand() % 1000);
				cout << B[i];
			}
			for (i = 0; i < size; i++)
				if (A[i] % 2 != 0) C[k++] = A[i];
			for (i = 0; i < size; i++)
				if (B[i] % 2 == 0) C[k++] = B[i];
			cout << "\n\nC-массив: ";
			for (i = 0; i < k; i++)
				cout << C[i] << " ";

			cout << "\n\nC-массив: ";
			_bubbleSort(C, k);
			for (i = 0; i < k; i++)
				cout << C[i] << " ";
		case 7: 
			cout << "\n\nМассив В: ";
			for (i = 0; i < size; i++)
			{
				cout << " ";
				B[i] = (rand() % 1000);
				cout << B[i];
			}
			k = 0; max = B[0];
			for (i = 0; i < size; i++)
				if (B[i] >= max) {
					max = B[i];
					imax = i;
				}
			cout << "\nMax element: " << max << "\nindex: " << imax << endl;
			for (i = 0; i < size; i++)
				if (A[i] < max) C[k++] = A[i];
			cout << "\n\nC-массив: ";
			for (i = 0; i < k; i++)
				cout << C[i] << " ";
			cout << "\n\nC-массив: ";
			_bubbleSort(C, k);
			for (i = 0; i < k; i++)
				cout << C[i] << " ";
			break;
		case 8:
			cout << "\n\nМассив В: ";
			for (i = 0; i < size; i++)
			{
				cout << " ";
				B[i] = (rand() % 1000);
				cout << B[i];
			}
			k = 0; max = B[0];
			for (i = 0; i < size; i++)
				if (B[i] >= max) {
					max = B[i];
					imax = i;
				}
			cout << "\nMax element: " << max << "\nindex: " << imax << endl;
			for (i = 0; i < size; i++)
				if (A[i] < max) C[k++] = A[i];
			cout << "\n\nC-массив: ";
			for (i = 0; i < k; i++)
				cout << C[i] << " ";
			cout << "\n\nC-массив: ";
			i = 0;
			sortHoar(C, i, k);
			for (i = 0; i < k; i++)
				cout << C[i] << " ";
			break;
		default: exit(0);
			for (i = 0; i < k; i++) B[i] = NULL;
			for (i = 0; i < size; i++) A[i] = NULL;	
		}
	}
}
