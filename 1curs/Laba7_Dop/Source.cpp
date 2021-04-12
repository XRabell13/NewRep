/* 3 dop
#include <iostream>
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	int n, i = 1, k = 0, g=0;
	float a, min, max;
	cout << "Количество элементов: "; cin >> n;
	cout << "min = "; cin >> min;
	cout << "max = "; cin >> max;
	cout << "Последовательность: "<<endl;
	for (int i = 1; i <= n; i++)
	{
		cout << "a" << i << " = "; cin >> a;
		if ((a <= max) && (min <= a)) g++;
	}
	cout << "Количество элементов от " << min << " до " << max << ": "<<g; 
}*/

/*2 dop
#include <iostream>
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	int n, a, i=1, k=0, q=0;
	cout << "n = "; cin >> n;
	cout << "Последовательность: ";
	for (int i = 1; i <= n; i++)
	{
		cin >> a;
		if (a < 0)
		while (k == 0)
		{
			q = i;
			k = ++k;
		}
	}
	cout << "Порядковый номер отрицательного числа: " << q << endl;
}*/

/* 1 dop
#include <iostream>
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	int n, a, i, sum=0;
	cout << "n = "; cin >> n;
	for (int i = 1; i <= n; i++)
	{
		cout << "a" << i << " = "; cin >> a;
		if (a % 2 == 0) sum += a;
	}
	cout << "Сумма четных чисел: " << sum;
}*/