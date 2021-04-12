# include <iostream>
void main()
{
	double b = 40, x = 1.1, a = 5 * pow(10, -6), w, v;
	w = (a + b) * tan(x) / (x + 1);
	v = 1 / 2 * b - sqrt(w - a * b);
	std::cout << "w = " << w;
	std::cout << "v = " << v;
}