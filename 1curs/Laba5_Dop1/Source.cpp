
// �������������� ������� ����� 2

#include <iostream>
using namespace std;
int main()
{
	setlocale(LC_ALL, "Russian");
	double p;
	int q, n=1;
	using namespace std;
	cout << "������� � ������ ����: ";
		cin >> p; 
		cout << "�������� ��������: ";
	cin >> q;
	do
	{
		n = n + 1;
		p = p + 0.003 * p;
	} while (p < q);
	cout << "������� ����� � ��������� ����: " << p << endl;
	cout << "����: " << n;
}