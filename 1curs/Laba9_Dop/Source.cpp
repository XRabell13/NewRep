//Dop 1: ������
/*#include <locale>
#include <iostream>
#include <math.h>
void main()
{
	setlocale(LC_ALL, "rus");
	using namespace std;
	const int maxSize = 40;
	int n, i, a[maxSize], kmax = 0, j, k;
	cout << "������� ���� ������ ���������: " << endl;
	cin >> n;
	if (n > 40) return;
	srand((unsigned)time(NULL));
	for (i = 0; i < n; i++)
	{
		a[i] = (rand() % 300)+200;
		cout << a[i] << " ";
	}
	cout << endl;
	for (i = 1; i < n; i++)
		if (a[i] > a[kmax])
			kmax = i;
		k = ceil(round(kmax+1) / 7);
		if (k == 0) k = 1;
	cout << "������������ ���-�� ������� " << a[kmax] << endl;
	cout << "������: "<<k;
}*/
// Dop 3: ���������� ���������� ��� ��������� � ����������� ����������
/*#include <locale>
#include <iostream>
#include <ctime>
void main()
{
	using namespace std;
	setlocale(LC_CTYPE, "Russian");
	const int size = 20;
	int n = 0, MAS[size], i;
	srand((unsigned)time(NULL));
	cout << "������: ";
	for (int i = 0; i < 20; i++)
	{
		MAS[i] = rand() % 10;
		cout << MAS[i] << " ";
	}
	for (int i = 0; i < size - 1; i++)
		if (MAS[i] == MAS[i + 1]) n++;
	cout << endl <<"���������� ���� ������������� �����: " << n;
}*/
// Dop 6: ���������� ���� �� ����� ���������
#include <locale>
#include <iostream>
void main()
{
	setlocale(LC_ALL, "rus");
	using namespace std;
	const int maxSize = 100;
	int n, i, a[maxSize], k=0;
	srand((unsigned)time(NULL));
	for (i = 0; i < maxSize; i++)
	{
		a[i] = rand() % 10;
		cout << a[i] << " ";
	}
	for (int i = 0; i < maxSize - 1; i++)
	{
		if (a[i] + a[i + 1] == a[i + 2]) k++;
	}
	if (k > 0)
		cout << endl <<"���� ����� ��������� � ����������: "<<k;
	else cout << "��� ����� ���������.";
}
