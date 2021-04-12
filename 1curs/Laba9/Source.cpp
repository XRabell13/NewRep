/* Вариант 1
#include <iostream>
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	int i, k, size = 7;
	int A[14] = { 5, 4, 17, 9, 2, 3, 7, 12 };
	cout << "Введите номер(индекс) элемента (от 0 до 4) ";
	cin >> k;
	for (i = k; i <= size; i++)
		A[i] = A[i + 1];
	size--;
	cout << "Массив 1: ";
	for (i = 0; i <= size; i++)
		cout << A[i] <<" ";
	cout <<endl<< "Массив 2: ";
	for (int i = 0; i <= size; i++)
	{
		cout << A[i] << " ";
		if (A[i] % 2 == 0) cout << 0 << " ";
	}
}*/
//Вариант 15
#include <locale>
#include <iostream>
using namespace std;
int main()
{
	setlocale(LC_ALL, "rus");
	const int size = 10;
	int i, a[size] = {1,10,2,9,3,8,4,7,5,6};
	for (i = 0; i < size; i++)
	{

		cout << a[i] << " ";
	}
	cout << endl <<"Конечный массив: ";

}