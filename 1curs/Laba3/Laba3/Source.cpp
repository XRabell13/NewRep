#include <iostream>
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	int A, B, C, k;
	cout << "������� ����� ���������: ";	cin >> A;
	cout << "������� ����� �����: "; cin >> B;
	cout << "������� ����� ���������: "; cin >> C;
	k = A * 50 + B * 100 + C * 200;
	cout << "���� ������: "; cout << k;
}
