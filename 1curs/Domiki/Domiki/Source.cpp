#include <iostream>
#include <iomanip>
void main()
{
	setlocale(LC_CTYPE, "Russian");
	using namespace std;
	int a, b, p, q, r, s, w, e;
	cout << "Введите размеры прямоугольной площадки для постройки: ";
	cin >> a >> b;
	if (a == b) 
	{
		cout << ("Введены размеры квадратной площадки.");
		exit(0);
	}
	cout << "Размеры первого дома: ";
	cin >> p >> q;
	cout << "Размеры второго дома: ";
	cin >> r >> s; 
	w = a * b; //площадь площадки
	e = (p * q)+(r * s); // площади домов
	if (e <= w) cout << ("Дома поместятся на данной площадке.");
	else cout << ("Дома НЕ поместятся на данной площадке.");
}