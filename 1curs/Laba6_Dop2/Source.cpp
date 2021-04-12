#include <iostream>
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	float C1, C2;
	int i = 0;
	cout << "Сколько литров в первом сосуде: "; cin >> C1;
	cout << "Сколько литров вo втором сосуде: "; cin >> C2;
	for (int i=0; i <= 12; i++)
	{
		C2 = C2 + C1 * 0.5;
		C1 = C1 - 0.5 * C1;
		C1 = C1 + C2 * 0.5;
		C2 = C2 - 0.5 * C2;
	}
	cout << "Воды стало после 12-ти переливаний в первом сосуде " << C1 << ", во втором - " << C2;
}