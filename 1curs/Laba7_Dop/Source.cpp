/* 3 dop
#include <iostream>
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	int n, i = 1, k = 0, g=0;
	float a, min, max;
	cout << "���������� ���������: "; cin >> n;
	cout << "min = "; cin >> min;
	cout << "max = "; cin >> max;
	cout << "������������������: "<<endl;
	for (int i = 1; i <= n; i++)
	{
		cout << "a" << i << " = "; cin >> a;
		if ((a <= max) && (min <= a)) g++;
	}
	cout << "���������� ��������� �� " << min << " �� " << max << ": "<<g; 
}*/

/*2 dop
#include <iostream>
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	int n, a, i=1, k=0, q=0;
	cout << "n = "; cin >> n;
	cout << "������������������: ";
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
	cout << "���������� ����� �������������� �����: " << q << endl;
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
	cout << "����� ������ �����: " << sum;
}*/