#include <iostream>
using namespace std;

long int factorial(long);

int main()
{
	setlocale(LC_ALL, "Rus");
	int count = 1;
	while (count < 31) {
		cout << "¬ведите целое число: ";
		cin >> count;
		cout << factorial(count) << endl;
	}

	return 0;
}

long int factorial(long x)
{
	if (x == 0 || x == 1)
		return 1;
	return x * factorial(x - 1);
}
