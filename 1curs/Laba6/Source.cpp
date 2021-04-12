#include <iostream>
using namespace std;
void main()
{
	double x = -4 * pow(10, -3), s = 1.1, j = 4, b, z;
	while (j<7)
	{
		b = 12 * s - exp(-s/2) * (x - j);
		if (b < 1.5) z = sqrt(-2 * x * j) + b;
		else z = abs(13 * x * j) + b;
		cout << endl <<"b = "<< b << endl << "z = "<< z;
		j = j + 0.5;
	}	
}