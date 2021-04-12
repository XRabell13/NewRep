//Вариант 2
/*#include <iostream>
void main()
{
	setlocale(LC_CTYPE, "Russian");
	using namespace std;
	int i=0, A[] = { 1, 5, 6, 3, 8, 15, -3 }, B[] = { 3, 2, 8, 1, 10, 5, 3 }, S[7];
	int* s;
	s = &i;
	cout << "A[] = { 1, 5, 6, 3, 8, 15, -3 }"<<endl;
	cout << "B[] = { 3, 2, 8, 1, 10, 5, 3 }" << endl;
	for (; i < 7; i++)
	{
		S[i] = A[i] + B[i];
	}
	*s = 0;
	cout << "Массив сумм: ";
	for (; *s < 7; (*s)++) 
	{
		cout << S[*s]<<" ";
	}
}*/
// 5 вариант
/*#include <stdio.h>
#include <locale.h>
#include <iostream>
int main()
{
	using namespace std;
	setlocale(LC_ALL, "Rus");
	int A[50], B[50], i = 0, n, j, max, t=0;
	int* ii;
	cout << "Введите количество элементов массива A: ";
	cin >> n;
	cout << "Введите количество элементов массива B: ";
	cin >> j;
	cout << "Массив A: " << endl;
	ii = &i;
	for (; *ii < n; (*ii)++)
	{
		A[*ii] = (rand() % 30);
		cout << A[*ii] << " ";
	}
	cout << endl;
	*ii = 0;
	cout << "Массив B: " << endl;
	for (; *ii < j; (*ii)++)
	{
		B[*ii] = (rand() % 30) - 10;
		cout << B[*ii] << " ";
	}
	cout << endl;
	*ii = 0;
	//поиск наибольшего элемента из массива А
	max = A[0];
	for (; *ii < n; (*ii)++)
	{
		if (max < A[i]) max = A[i];
	}
	cout << "Максимальный элемент в массиве А: " << max<<endl;
	*ii = 0;
	for (; *ii << 0; (*ii)++)
	{
		if (max == B[*ii])
		{
			cout << "Элемент " << max << " содержится в массива В.";
			t++;
		}
	}
	if (t==0) cout << "Элемент " << max << " не содержится в массива В.";
}*/
// 14 вариант
/*#include <iostream>
void main()
{
	setlocale(LC_CTYPE, "Russian");
	using namespace std;
	int i = 0, X[] = { 1, 5, 6, 3, 8, 15, -3 }, Y[] = { 3, 2, 8, 1, 10, 5, 3 }, S[7], f=0, j;
	int* s;
	s = &f;
	cout << "X[] = { 1, 5, 6, 3, 8, 15, -3 }" << endl;
	cout << "Y[] = { 3, 2, 8, 1, 10, 5, 3 }" << endl;
	for (i = 0; i < 7; i++) {
		for (j = 0; j < 7; j++) {
			if (X[i]==Y[j]) (*s)++;
		}
	}
	cout << "В массиве " << *s << " пар одинаковых значений.";
}*/

#include<iostream>
using namespace std;
int main()
{
	setlocale(LC_CTYPE, "RUS");
	int x;
	cin >> x;
	switch (x)
	{
	case 1: cout<<"Понедельник"; break;
	case 2: cout<<"Вторник"; break;
	default: cout<< "Ты лох" ; break;
	}
}