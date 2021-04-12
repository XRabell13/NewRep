#include <iostream>
void main()
{
	using namespace std;
	setlocale(LC_CTYPE, "Russian");
	float r, p, q, t;
	cout << ("Радиус: "); cin >> r;
	cout << ("Диагонали: "); cin >> p >> q;
	t = sqrt((p * p) + (q * q)) / 2;
	if (r <= t) puts("Шар пройдет через отверстие ромба!");
	else puts("Шар не пройдет через отверстие ромба!");
}