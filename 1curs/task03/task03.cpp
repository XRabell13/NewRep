#include <iostream>
using namespace std;

int main()
{
	setlocale(LC_ALL, "Rus");
	unsigned int i=1;
	do {
		cout << i << '\n';
	} while ((++i)!=257);

	return 0;
}