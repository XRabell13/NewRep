// 15 вариант
// с индексами
/*#include <iostream>
#include <ctime>
#include <iomanip>

using namespace std;

int main() {
	srand(time(0));
	const int n = 3, m = 3;
	int matrix[n][m];
	int sum1=0, sum2=0;
	for (int i = 0; i < n; ++i) {
		for (int j = 0; j < m; ++j) {
			matrix[i][j] = rand() % 16;
			cout << setw(4) << matrix[i][j];
			if (j > i) sum1 += matrix[i][j];
			if (j < i) sum2 += matrix[i][j];
		}
		cout << "\n";
	}
	cout << endl;
	cout << "sum1 = " << sum1 << endl;
	cout << "sum2 = " << sum2 << endl;
	cout << endl;
	return 0;
}*/
// с указателями
/*#include <iostream>
#include <ctime>
#include <iomanip>

using namespace std;

int main() {
	srand(time(0));
	const int n = 3, m = 3;
	int matrix[n][m];
	int sum1 = 0, sum2 = 0;
	for (int i = 0; i < n; ++i) {
		for (int j = 0; j < m; ++j) {
			*(*(matrix + i) + j) = rand() % 16;
			cout << setw(4) << *(*(matrix + i) + j);
			if (j > i) sum1 += *(*(matrix + i) + j);
			if (j < i) sum2 += *(*(matrix + i) + j);
		}
		cout << "\n";
	}
	cout << endl;
	cout << "sum1 = " << sum1 << endl;
	cout << "sum2 = " << sum2 << endl;
	cout << endl;
	return 0;
}*/

//1 вариант
//с индексами
#include <iostream>
#include <ctime>
#include <iomanip>
using namespace std;
int main() {
	setlocale(LC_CTYPE, "Rus");
	srand(time(0));
	const int n = 3, m = 5;
	int matrix[n][m];
	int max = 0, ii = 0, jj = 0;
	for (int i = 0; i < n; ++i) {
		for (int j = 0; j < m; ++j) {
			matrix[i][j] = rand() % 30;
			cout << setw(4) << matrix[i][j];
		}
		cout << "\n";
	}
	max = matrix[0][0];
	for (int i = 0; i < n; ++i) {
		for (int j = 0; j < m; ++j) {
			if (max < matrix[i][j])
			{
				max = matrix[i][j];
				ii = i;
				jj = j;
			}
		}
	}
	cout << endl;
	cout << "Максимальный элемент матрицы " << max << " находится на пересечении " << ii << " строки и " << jj << " столбца (номерация идет от 0)" << endl;
}
// с указателями
/*#include <iostream>
#include <ctime>
#include <iomanip>
using namespace std;
int main() {
	setlocale(LC_CTYPE, "Rus");
	srand(time(0));
	const int n = 3, m = 5;
	int matrix[n][m];
	int max = 0, ii = 0, jj = 0;
	for (int i = 0; i < n; ++i) {
		for (int j = 0; j < m; ++j) {
			*(*(matrix + i) + j) = rand() % 30;
			cout << setw(4) << *(*(matrix + i) + j);
		}
		cout << "\n";
	}
	max = matrix[0][0];
	for (int i = 0; i < n; ++i) {
		for (int j = 0; j < m; ++j) {
			if (max < matrix[i][j])
			{
				max = *(*(matrix + i) + j);
				ii = i;
				jj = j;
			}
		}
	}
	cout << endl;
	cout << "Максимальный элемент матрицы " << max << " находится на пересечении " << ii << " строки и " << jj << " столбца (номерация идет от 0)" << endl;
}*/