
// Дополнительное задание номер 2

#include <iostream>
using namespace std;
int main()
{
	setlocale(LC_ALL, "Russian");
	double p;
	int q, n=1;
	using namespace std;
	cout << "Выручка в первый день: ";
		cin >> p; 
		cout << "Конечное значение: ";
	cin >> q;
	do
	{
		n = n + 1;
		p = p + 0.003 * p;
	} while (p < q);
	cout << "Выручка фирмы в последний день: " << p << endl;
	cout << "День: " << n;
}