#include <iostream>
void main()
{
	using namespace std;
	setlocale(LC_CTYPE, "Russian");
	float r, p, q, t;
	cout << ("������: "); cin >> r;
	cout << ("���������: "); cin >> p >> q;
	t = sqrt((p * p) + (q * q)) / 2;
	if (r <= t) puts("��� ������� ����� ��������� �����!");
	else puts("��� �� ������� ����� ��������� �����!");
}