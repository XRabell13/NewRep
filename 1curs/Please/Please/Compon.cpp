# include <iostream>
int main()
{
	setlocale(LC_CTYPE, "Russian");
	double L, S;
	std::cin >> L;
	S = pow(L, 2) / (4 * 3.14);
	std::cout << "Площадь круга: ";
	std::cout << S;
}