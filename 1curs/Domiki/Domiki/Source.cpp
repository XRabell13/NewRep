#include <iostream>
#include <iomanip>
void main()
{
	setlocale(LC_CTYPE, "Russian");
	using namespace std;
	int a, b, p, q, r, s, w, e;
	cout << "������� ������� ������������� �������� ��� ���������: ";
	cin >> a >> b;
	if (a == b) 
	{
		cout << ("������� ������� ���������� ��������.");
		exit(0);
	}
	cout << "������� ������� ����: ";
	cin >> p >> q;
	cout << "������� ������� ����: ";
	cin >> r >> s; 
	w = a * b; //������� ��������
	e = (p * q)+(r * s); // ������� �����
	if (e <= w) cout << ("���� ���������� �� ������ ��������.");
	else cout << ("���� �� ���������� �� ������ ��������.");
}