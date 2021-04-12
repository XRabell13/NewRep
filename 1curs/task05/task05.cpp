#include <iostream>
using namespace std;
int main()
{
	setlocale(LC_CTYPE, "RUS");
	unsigned int year;
	cout << "¬ведите год: ";
	cin >> year;
	if ((year % 4 == 0) & (year%400!=0)) cout<<year<<" - високосный год\n";
	else cout << year << " - невисокосный год\n";
	system("Pause");
}
