#include <iostream>
#include <iomanip>
void main()
{
	setlocale(LC_CTYPE, "Russian");
	int a, b, c, r, s, t, k, h;
	using namespace std;
	printf_s ("������� ������� �������: ");
	cin >> a >> b >> c;
	printf_s("������� ������� �������: ");
	cin >> r >> s >> t;
	k = a * b * c;
	h = r * s * t;
	if (k <= h)
		printf_s("������� ��������� � �������!");
	else printf_s("������� �� ��������� � �������.");
}