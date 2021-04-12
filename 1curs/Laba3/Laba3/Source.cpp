#include <iostream>
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	int A, B, C, k;
	cout << "Сколько сбито самолетов: ";	cin >> A;
	cout << "Сколько сбито ракет: "; cin >> B;
	cout << "Сколько сбито спутников: "; cin >> C;
	k = A * 50 + B * 100 + C * 200;
	cout << "Очки игрока: "; cout << k;
}
