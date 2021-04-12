// ���� 14
// ������� � ������� � 10:30 �������������� �����< 102-4 �������, ������ ��� ���
/*# include <iostream>
#include <ctime>
using namespace std;
void massiv();
void matrix();

int main(void)
{
	setlocale(LC_CTYPE, "Russian");
	int c;
	do
	{
		cout << endl;
		cout << "�������" << endl;
		cout << "1-���������� ������" << endl;
		cout << "2-������ � ��������" << endl;
		cout << "3-�����" << endl;
		cin >> c;
		switch (c)
		{
		case 1: massiv(); break;
		case 2: matrix(); break;
		case 3: break;
		}
	} while (c != 3);
}


void massiv()
{
	int C, i, size, ch = 0, f=0, a;
	float* mas; float sum = 0, b;
	cout << "������� ������ �������: "; cin >> size;
	cout << "������� ����� �: "; cin >> C;
	srand(time(NULL));
		mas = new float[size];
		for (i = 0; i < size; i++)
		{
			mas[i] = (float)(rand()%300-20)/10;
			cout << mas[i]<<" ";
			if (*(mas+i) < C) ch++;
			if (*(mas+i) < 0) f = i;
		}
		for (; f < size; f++)
		{
			b = *(mas + f); a = (int)(*(mas + f));
			if (a==b) sum += mas[f];
		}
		cout << "\n"<<"���������� ����� ������ " << C << ": " << ch;
		cout << "\n"<< "����� ���� ����� �������� ����� ���������� �������������� �����: " << sum << endl;
		delete[] mas;
}

void matrix()
{
	int* mas, row, colum, i, j;
	int d=0, h=0;
	cout << "������� ����� ����� �������: ";
	cin >> row;
	cout << "������� ��c�� ��������: ";
	cin >> colum;
	mas = new int[row * colum];
	srand(time(NULL));
	for (i = 0; i < row; i++)
		for (j = 0; j < colum; j++)
		{
			*(mas + i * colum + j) = (rand() % 15-5);
			cout << *(mas + i * colum + j)<<" ";
			d++;
			if (d / colum == 1)
			{
				d = 0; 
				cout << endl;
			}
			if (*(mas + i * colum + j) == 0) h++;
		}
	cout << endl;
	if (h / row != 1)
	{
		for (i = 0; i < row; i++)
			for (j = 0; j < colum; j++)
			{
				if (*(mas + i * colum + j) < 0) (*(mas + i * colum + j)) = 0;
				cout << *(mas + i * colum + j) << " ";
				d++;
				if (d / colum == 1)
				{
					d = 0;
					cout << endl;
				}
			}
	}
	
	delete[] mas;
}*/

#define _CRT_SECURE_NO_WARNINGS
#include<cstdio>
#include<cmath>
#include<iostream>
#include <time.h>
using namespace std;
int a15_1(int mas, int &row, int &colum);

int main()
{
	setlocale(LC_CTYPE, "RUS");
	const int MAXN = 5;
	int mas[MAXN][MAXN], row, colum, f = -1, d = 0, j=0, i=0;
	cout << "������� ����� ����� �������: ";
	cin >> row;
	cout << "������� ��c�� ��������: ";
	cin >> colum;
	srand(time(NULL));
	for (int i = 0; i < row; i++)
		for (int j = 0; j < colum; j++)
		{
			mas[i][j] = (rand() % 15 - 13);
			cout << mas[i][j] << " ";
			d++;
			if (d / colum == 1)
			{
				d = 0;
				cout << endl;
			}
		}
	cout << endl;

	for (int i = 0; i < colum; ++i)
	{
		f = 1;
		for (int j = 0; j < row; ++j) if (*(mas + i * colum + j) > 0) f = 0;//��������� ������ �� ������� ������������� ���������

		if (f == 1)
		{
			for (int i1 = 0; i1 < row; ++i1) if (mas[i1][j] < 0) mas[i1][j] = -mas[i1][j];
			for (int i1 = 0; i1 < row; ++i1)
			{
				for (int j1 = 0; j1 < colum; ++j1)
				{
					cout << mas[i1][j1] << " ";
				}
				printf("\n");
			}
		}
	}
	for (int i1 = 0; i1 < row; ++i1)
	{
		for (int j1 = 0; j1 < colum; ++j1)
		{
			cout << mas[i1][j1] << " ";
		}
		printf("\n");
	}

}

int a15_1(int mas[], int& row, int& colum)
{
	int f = 1, d = 0, j = 0, i = 0;
	for (int i = 0; i < colum; ++i)
	{
		for (int j = 0; j < row; ++j) if (*(mas+i*colum+j) > 0) f = 0;

		if (f == 1)
		{
			for (int i1 = 0; i1 < row; ++i1) if (*(mas + i1 * colum + j) < 0)* (mas + i1 * colum + j) = -(*(mas + i1 * colum + j));
			for (int i1 = 0; i1 < row; ++i1)
			{
				for (int j1 = 0; j1 < colum; ++j1)
				{
					cout << *(mas + i1 * colum + j1) << " ";
				}
				printf("\n");
			}
		}
	}
	for (int i1 = 0; i1 < row; ++i1)
	{
		for (int j1 = 0; j1 < colum; ++j1)
		{
			cout << *(mas + i1 * colum + j1) << " ";
		}
		printf("\n");
	}
	return 0;
}

