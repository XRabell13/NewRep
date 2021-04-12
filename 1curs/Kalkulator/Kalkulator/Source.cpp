#include <iostream>
#include <iomanip>
#include <conio.h>
int main()
{
	using namespace std;
	setlocale(LC_CTYPE, "Russian");
	char operation;
	int a, b;
	float c;
	cout << "Выберите одну из операций: %, /, +, -, *"<<endl;
	cin >> operation;
	cout << "Введите числа a и b, над которыми будут выполняться действия: ";
	cin >> a >> b;
	switch (operation)
	{
	case '%': c = a % b; cout << a << "%" << b << "=" << c; break;
	case '/': c = a / b; cout << a << "/" << b << "=" << c; break;
	case '+': c = a + b; cout << a << "+" << b << "=" << c; break;
	case '-': c = a - b; cout << a << "-" << b << "=" << c; break;
	case '*': c = a * b; cout << a << "*" << b << "=" << c; break;
	default: puts("Некорретный выбор"); break;
	}
}