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
	cout << "�������� ���� �� ��������: %, /, +, -, *"<<endl;
	cin >> operation;
	cout << "������� ����� a � b, ��� �������� ����� ����������� ��������: ";
	cin >> a >> b;
	switch (operation)
	{
	case '%': c = a % b; cout << a << "%" << b << "=" << c; break;
	case '/': c = a / b; cout << a << "/" << b << "=" << c; break;
	case '+': c = a + b; cout << a << "+" << b << "=" << c; break;
	case '-': c = a - b; cout << a << "-" << b << "=" << c; break;
	case '*': c = a * b; cout << a << "*" << b << "=" << c; break;
	default: puts("����������� �����"); break;
	}
}