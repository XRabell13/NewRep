#include <iostream>
#include <iomanip>
void main()
{
	setlocale(LC_CTYPE, "Russian");
	int a, b, c, r, s, t, k, h;
	using namespace std;
	printf_s ("Введите размеры коробки: ");
	cin >> a >> b >> c;
	printf_s("Введите размеры посылки: ");
	cin >> r >> s >> t;
	k = a * b * c;
	h = r * s * t;
	if (k <= h)
		printf_s("Коробка вмещается в посылку!");
	else printf_s("Коробка не вмещается в посылку.");
}