#include <iostream>
int main()
{
	double y = 0.5, c = 1.4, x = 2 * pow(10, -4), z, u;
	z = exp(c * x) / y + 3;
	u = sqrt(pow(z, 3) - 0.1 * z);
	std::cout << "z = " << z;
	std::cout << " u = " << u;
}