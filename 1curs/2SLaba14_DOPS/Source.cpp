#include <iostream>
#include <ctime>
using namespace std;
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
int* sortHoar(int A[], int sm, int em)/*«десь A[] Ц исходный массив чисел,
									  sm Ц  индекс первого элемента массива,
									  em Ц  индекс по-следнего (последний элемент правой части).*/
{
	if (sm < em)
	{
		int hb = getHoarBorder(A, sm, em);
		sortHoar(A, sm, hb);
		sortHoar(A, hb + 1, em);
	}
	return A;
};
int _getHoarBorder(int A[], int sm, int em)
{
	int i = sm - 1, j = em + 1;
	int brd = A[sm];
	int buf;
	while (i < j)
	{
		while (A[--j] > brd);//по возрастанию
		while (A[++i] < brd);//по возрастанию
		if (i < j)
		{
			buf = A[j];
			A[j] = A[i];
			A[i] = buf;
		};
	}
	return j;
}
int* _sortHoar(int A[], int sm, int em)/*«десь A[] Ц исходный массив чисел,
									  sm Ц  индекс первого элемента массива,
									  em Ц  индекс по-следнего (последний элемент правой части).*/
{
	if (sm < em)
	{
		int hb = _getHoarBorder(A, sm, em);
		_sortHoar(A, sm, hb);
		_sortHoar(A, hb + 1, em);
	}
	return A;
};
int getRandKey(int reg = 0)     // генераци€ случайных ключей
{
	if (reg > 0)
		srand((unsigned)time(NULL));
	int rmin = -5;
	int rmax = 5;
	return (int)(((double)rand() / (double)RAND_MAX) * (rmax - rmin) + rmin);
}
int main()
{
	setlocale(LC_ALL, "Rus");
	srand((unsigned int)time(NULL));
	int size, i, max, imax, mini, imini, choise;
	const int N = 15;
	int A[100], B[10], C[N], n;
	for (;;) {
		cout << "1 - ƒоп2\n2 - ƒоп3\n3 - ƒоп4\n";
		cout << "¬ыбор: ";
		cin >> choise;
		switch (choise) {
		case 1: 	
			cout << " оличество элементов = ";
			cin >> size;
			for (i = 0; i < size; i++)
			{
				cout << " ";
				A[i] = (rand() % 10000);
				cout << A[i];
			}
			cout << endl;
			max = A[0]; mini = A[0];
			for (i = 0; i < size; i++) {
				if (mini > A[i]) { mini = A[i]; imini = i; }
				if (max < A[i]) { max = A[i]; imax = i; }
			}
			cout << "Max: " << max << ";\nimax: " << imax << ";\nMini: " << mini << ";\nimini: " << imini << ".\n\n";
			break;
		case 2: 
			for (i = 0; i < 10; i++)
			{
				cout << " ";
				B[i] = (rand() % 100);
				cout << B[i];
			}
			sortHoar(B, 7, 10);
			_sortHoar(B, 0, 3);
			cout << "\nMassiv: ";
			for (i = 0; i < 10; i++) cout << B[i] << " ";
			cout << endl;
			break;
		case 3: n = N;
			for (i = 0; i < n; i++) C[i] = getRandKey();
			cout << "\nMassiv: ";
			for (i = 0; i < n; i++) cout << C[i] << " ";
			cout << endl;
			for (int i = 0; i <  n-1; i++)
				for (int j = i + 1; j < n; j++)
					if (C[i] == C[j])
					{
						for (int k = j; k < n; k++)
							C[k] = C[k + 1];
						n--;
						j--;
					}
			cout << "\nMassiv2: ";
			for (i = 0; i < n; i++) cout << C[i] << " ";
			cout << endl;
			i = 0;
			break;
		default: exit(0);
		}
	}
}