// доп 4
/*#include <iostream>
#include <cmath>
#include <stdlib.h>
#include <ctime>
using namespace std;
int main() {
	setlocale(LC_ALL, "Russian");
	int n;
	cout << "Введите порядок квадратной матрицы ";
	cin >> n;
	int Mass[17][17], d = n, k, count = 1, i, j, p;

	for (p = 0; count <= pow(n, 2); p++) {

		for (k = p; k < d; k++)
			Mass[p][k] = count++;

		for (k = p + 1; k < d - 1; k++)
			Mass[k][n - (p + 1)] = count++;

		for (k = n - (p + 1); k >= p; k--)
			Mass[n - (p + 1)][k] = count++;

		for (k = n - (p + 2); k > p; k--)
			Mass[k][p] = count++;

		d--;
	}
	if (n % 2 == 1)
		Mass[n / 2][n / 2] = pow(n, 2);
	cout << endl;
	for (i = 0; i < n; i++) {
		for (j = 0; j < n; j++) {
			cout << Mass[i][j] << " ";
		}
		cout << endl;
	}
}*/
// 2 доп
/*#include <iostream>
using namespace std;

int main()
{
	int const n=5;
	int sq[n][n];
	for (int i = 0; i < n; i++) 
	{
		int a = i + 1;
		for (int j = 0; j < n; j++)
		{
			sq[i][j] = a;
			a++;
			if (a > n) a = 1;
		}
	}

	for (int i = 0; i < n; i++) 
	{
		for (int j = 0; j < n; j++)
			cout << sq[i][j] << ' ';
		cout << endl;
	}
	return 0;
}*/
// 5 доп
#include <iostream>
#include <iomanip>

int main()
{
	setlocale(LC_CTYPE, "Rus");
	int n;
	std::cout << "Введите размер матрицы: ";
	std::cin >> n;
	float** arr = new float* [n];
	float max;
	int i_max, j_max;
	std::cout << "Введите элементы массива: ";
	for (int i = 0; i < n; ++i)
	{
		arr[i] = new float[n];
		for (int j = 0; j < n; ++j)
		{
			std::cin >> arr[i][j];
			if (((!i) && (!j)) || (arr[i][j] > max))
			{
				max = arr[i][j];
				i_max = i;
				j_max = j;
			}
		}
	}
	arr[i_max][j_max] = arr[0][0];
	arr[0][0] = max;
	for (int count = 1; count < n; ++count)
	{
		max = arr[0][1];
		for (int i = 0; i < n; ++i)
			for (int j = 0; j < n; ++j)
				if (((i != j) || ((i >= count) && (j >= count))) && (arr[i][j] > max))
				{
					max = arr[i][j];
					i_max = i;
					j_max = j;
				}
		arr[i_max][j_max] = arr[count][count];
		arr[count][count] = max;
	}
	std::cout << "Полученный массив: \n";
	for (int i = 0; i < n; ++i)
	{
		for (int j = 0; j < n; ++j)
			std::cout << std::setw(5) << arr[i][j];
		std::cout << std::endl;
	}
}