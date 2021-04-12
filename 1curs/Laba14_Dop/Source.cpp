#include <iostream>
#include <ctime>
#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
#include <time.h>
using namespace std;
void zadanie16_1();
void zadanie16_2();
void zadanie14_1();
void zadanie12_1();
void zadanie12_2();
void zadanie2_1();

int main(void)
{
	setlocale(LC_CTYPE, "Russian");
	int c;
	do
	{
		cout << endl;
		cout << "Введите: " << endl;
		cout << "1 - 16.1" << endl;
		cout << "2 - 16.2" << endl;
		cout << "3 - 14.1" << endl;
		cout << "4 - 12.1" << endl;
		cout << "5 - 12.2" << endl;
		cout << "6 - 2.1" << endl;
		cout << "7 - выход" << endl;
		cin >> c;
		switch (c)
		{
		case 1: zadanie16_1(); break;
		case 2: zadanie16_2(); break;
		case 3: zadanie14_1(); break;
		case 4: zadanie12_1(); break;
		case 5: zadanie12_2(); break;
		case 6: zadanie2_1(); break;
		case 7: break;
		}
	} while (c != 6);
}

void zadanie16_1()
{
	int  i, size, f1 = 0, f2 = 0, l = 0;
	float* mas; float sum = 0, min;
	cout << "Введите размер массива: "; cin >> size;
	srand(time(NULL));
	mas = new float[size];
	for (i = 0; i < size; i++)
	{
		mas[i] = (float)(rand() % 300 - 150) / 10;
		cout << mas[i] << " ";
		if ((l==0) && ((*(mas + i)) > 0))
		{
			f1 = i;
			l++;
		}
		if ((l > 0) && ((*(mas + i)) > 0)) f2 = i;
	}
	min = *(mas+0);
	for (i = 0; i < size; i++) 
		if (*(mas+i) < min) min=*(mas+i);
	for (; f1 < f2; f1++) sum += mas[f1];
	cout << "\n" << "Минимальное число: " << min;
	cout << "\n" << "Сумма всех чисел между первым и последним положительным элементом: " << sum << endl;
	delete[] mas;
}

void zadanie16_2()
{
	double** A;
	int i, j, k, n, m, find = -1;

	cout << "Введите n, m:  ";
	cin >> n >> m;
	A = new double* [n];
	for (i = 0; i < n; i++)
		A[i] = new double[m];
	srand(time(NULL));
	for (i = 0; i < n; i++)
	{
		cout << "\n";
		for (j = 0; j < m; j++)
		{
			A[i][j] = rand() % 100 - 10;
			cout << A[i][j] << " ";
		}
	}
	for (i = 0; i < n; i++)
		for (j = 0; j < m; j++)
		{
			if (A[i][j] < 0)
			{
				cout << "\n Строка = " << i + 1 << " Столбец = " << j + 1 << " Число = " << A[i][j] << "\n";
				find = j;
				break;
			}
			if (find>=0)
				break;
		}
	for (k = 0; k < n; k++)
	{
		if (find>=0)
			A[k][find] /= 2;
	}
	cout << endl;
	cout << "Новая матрица:\n";
	for (i = 0; i < n; i++)
	{
		cout << "\n";
		for (j = 0; j < m; j++)
			cout << A[i][j] << " ";
	}
	cout << endl;
		delete[]A;
}

void zadanie14_1()
{
	int C, i, size, ch = 0, f = 0, a;
	float* mas; float proiz = 1, max;
	cout << "Введите размер массива: "; cin >> size;
	cout << "Введите число С: "; cin >> C;
	srand(time(NULL));
	mas = new float[size];
	for (i = 0; i < size; i++)
	{
		mas[i] = (float)(rand() % 300 - 20) / 10;
		cout << mas[i] << " ";
		if (*(mas + i) > C) ch++;
	}
	max = *mas;
	for (i = 0; i < size; i++)
	{
		if (*(mas + i) > max)
		{
			max = *(mas + i);
			f = i+1;
		}
	}
	for (; f < size; f++)
	 proiz*= (*(mas+f));
	cout << "\n" << "Количество чисел больше " << C << ": " << ch;
	cout << "\n" << "Произведение всех значений после максимального "<< max <<" числа: " << proiz << endl;
	delete[] mas;
}

void zadanie12_1()
{
	int  i, size, f1 = 0, f2 = 0, l = 0;
	int* mas; int sum = 0, max;
	cout << "Введите размер массива: "; cin >> size;
	srand(time(NULL));
	mas = new int[size];
	for (i = 0; i < size; i++)
	{
		mas[i] = rand() % 30;
		cout << mas[i] << " ";
		
	}
	max = *(mas + 0);
	for (i = 0; i < size; i++)
		if (*(mas + i) > max) max = *(mas + i);
	for (i = 0; i < size; i++)
		if (*(mas + i) == max) f1++;

	cout << "\n" << "Максимальное число: " << max;
	cout << "\n" << "Встречается " << f1 <<" разa"<< endl;
	delete[] mas;
}

void zadanie12_2()
{
	int** A;
	int i, j, k, n, m, find = -1;

	cout << "Введите n, m:  ";
	cin >> n >> m;
	A = new int* [n];
	for (i = 0; i < n; i++)
		A[i] = new int[m];
	srand(time(NULL));
	for (i = 0; i < n; i++)
	{
		cout << "\n";
		for (j = 0; j < m; j++)
		{
			A[i][j] = rand() % 100 - 60;
			cout << A[i][j] << " ";
		}
	}
	for (i = 0; i < n; i++)
		for (j = 0; j < m; j++)
		{
			if (A[i][j] > 0)
			{
				cout << "\n Строка = " << i + 1 << " Столбец = " << j+1 << " Число = " << A[i][j] << "\n";
				find = i;
				break;
			}
			if (find >= 0)
				break;
		}

	if (find!=0)
	{
		for (k = 0; k < n; k++)
		{
			if (find >= 0)
				A[find - 1][k] *= -1;
		}
	}
	cout << endl;
	cout << "Новая матрица:\n";
	for (i = 0; i < n; i++)
	{
		cout << "\n";
		for (j = 0; j < m; j++)
			cout << A[i][j] << " ";
	}
	cout << endl;
	delete[]A;
}

void zadanie2_1()
{
	int  i, size, f1 = 0, k = 0, l = 0;
	int* mas;
	cout << "Введите размер массива: "; cin >> size;
	srand(time(NULL));
	mas = new int[size];
	for (i = 0; i < size; i++)
	{
		mas[i] = rand() % 30-10;
		cout << mas[i] << " ";
		if (*(mas + i) < 0) l++;
	}
	if (l)
	{
		f1 = k;
		for (k = 0; k < size; k++)
		{
			if (*(mas + k) < 0 && f1 < k) f1 = k;
		}
	}
	if (l)
	{
		cout << "\n" << "Есть отрицательные числа" <<endl;
		cout << "\n" << "Максимальное k: " << f1+1;
	}
	else cout << "Нет отрицательных чисел!"<< endl;
	delete[] mas;
}