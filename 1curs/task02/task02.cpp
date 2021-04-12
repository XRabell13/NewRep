/*#include <iostream>
using namespace std;
int main()
{
	setlocale(LC_ALL, "Rus");
	int number=12092020, sum=0;
	for (; number; number /= 10)
		if (number % 2 == 0) sum += number % 10;
	cout << sum;
	return 0;
}*/
#include <iostream>
using namespace std;
long int factorial(long);
int main()
{
	int count = 1;
	while (count < 31) {
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