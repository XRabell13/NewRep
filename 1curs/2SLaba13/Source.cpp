#include <iostream>
#include <ctime>
using namespace std;
void bubbleSort(int a[], int n)
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
	cout << "!";
}
void main()
{
	setlocale(LC_ALL, "Rus");
	srand((unsigned int)time(NULL));
	int size, i, k=0, choise; 
	int B[500], A[1000];
	cout << "Количество элементов = ";
	cin >> size;
	for (int i = 0; i < size; i++)
	{
		cout << " ";
		A[i] = (rand()%1000);
		cout << A[i];
	}
	cout << endl;

	for (i = 0; i < k; i++)
		if (i % 2 == 0) B[k++] = A[i];

	cout << "B-массив: ";
	for (i = 0; i < k; i++)
		cout << B[i] << " ";

	cout << endl;

	for (i = 0; i < k; i++)
	cout << B[i] << " ";


	for (;;) {
		cout << "1 - Сортировка пузырьком\n2 - Сортировка по выбору\n";
		cout << "Выбор: ";
		cin >> choise;
		switch (choise) {
		case 1: 	bubbleSort(B, k);
			cout << "Результирующий массив сортированный пузырьком: ";
			for (i = 0; i < k; i++)
				cout << B[i] << " ";
			cout << endl;
			break;
		case 2:
			selectSort(B, k);
			cout << "Результирующий массив сортированный по выбору: ";
			for (i = 0; i < k; i++)
				cout << B[i] << " ";
			cout << endl;
			break;
		default: exit(0);
		}
	}
}
