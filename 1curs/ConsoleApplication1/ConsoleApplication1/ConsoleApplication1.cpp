#include <iostream>
int main()
{
	double y = 0.956, a = 5 * pow(10, -6), n = 4, t, u, s;
	t = 1 / sqrt(y) + 14 * a;
	u = (t + 1) / (a + 2);
	s = log(2 * n / 3) + exp(-n) / u;
	std::cout << "t=" << t;
	std::cout << "u=" << u;
	std::cout << "s=" << s;
}
