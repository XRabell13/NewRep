#include <iostream>
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	float C1, C2;
	int i = 0;
	cout << "������� ������ � ������ ������: "; cin >> C1;
	cout << "������� ������ �o ������ ������: "; cin >> C2;
	for (int i=0; i <= 12; i++)
	{
		C2 = C2 + C1 * 0.5;
		C1 = C1 - 0.5 * C1;
		C1 = C1 + C2 * 0.5;
		C2 = C2 - 0.5 * C2;
	}
	cout << "���� ����� ����� 12-�� ����������� � ������ ������ " << C1 << ", �� ������ - " << C2;
}