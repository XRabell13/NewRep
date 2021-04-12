#include <iostream>
void main()
{ 
setlocale(LC_CTYPE, "Russian");
double d, S;
std::cin >> d;
S = pow(d, 2) / 2;
std::cout << S;
}