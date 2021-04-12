#include <iomanip> 
#include <iostream>
void main()
{
	setlocale(LC_CTYPE, "Russian");
	using namespace std;
	char c, probel; probel = ' ';
	cout << "Введите символ "; cin >> c;
	cout << setw(35) << setfill(probel) << probel;
	cout << setw(1) << setfill(c) << c << endl;
	cout << setw(34) << setfill(probel) << probel;
	cout << setw(3) << setfill(c) << c << endl;
	cout << setw(33) << setfill(probel) << probel;
	cout << setw(5) << setfill(c) << c << endl;
}