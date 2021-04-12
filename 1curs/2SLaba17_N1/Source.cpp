#include <iostream>
using namespace std;

double dihotomia1(double a, double b, double x)
{
	double e = 0.0001;
	while (abs(a - b) > (2 * e))
	{
		x = (a + b) / 2;
		if (((2*a + pow(a,3) - 7 ) * (2 * x + pow(x, 3) - 7)) <= 0) b = x;
		else a = x;
	}
	return x;
}
double dihotomia2(double a, double b, double x)
{
	double e = 0.0001;
	while (abs(a - b) > (2 * e))
	{
		x = (a + b) / 2;
		if (((exp(a)+2*a) * (exp(x) + 2 * x)) <= 0) b = x;
		else a = x;
	}
	return x;
}
double dihotomia3(double a, double b, double x)
{
	double e = 0.0001;
	while (abs(a - b) > (2 * e))
	{
		x = (a + b) / 2;
		if (((5*a - 1 + pow(a,3)) * (5 * x - 1 + pow(x, 3)) <= 0)) b = x;
		else a = x;
	}
	return x;
}
double dihotomia4(double a, double b, double x)
{
	double e = 0.0001;
	while (abs(a - b) > (2 * e))
	{
		x = (a + b) / 2;
		if (((pow(a,2)+(1/a)) * ((pow(x, 2) + (1 / x)))) <= 0) b = x;
		else a = x;
	}
	return x;
}
double dihotomia5(double a, double b, double x)
{
	double e = 0.0001;
	while (abs(a - b) > (2 * e))
	{
		x = (a + b) / 2;
		if (((exp(a) + a - 4) * (exp(x) + x - 4)) <= 0) b = x;
		else a = x;
	}
	return x;
}
double dihotomia6(double a, double b, double x)
{
	double e = 0.0001;
	while (abs(a - b) > (2 * e))
	{
		x = (a + b) / 2;
		if (((pow(a,2)-4) * (pow(x, 2) - 4)) <= 0) b = x;
		else a = x;
	}
	return x;
}
double dihotomia7(double a, double b, double x)
{
	double e = 0.0001;
	while (abs(a - b) > (2 * e))
	{
		x = (a + b) / 2;
		if (((pow(a,3)+a-2) * (pow(a, 3) + a - 2)) <= 0) b = x;
		else a = x;
	}
	return x;
}
double dihotomia8(double a, double b, double x)
{
	double e = 0.0001;
	while (abs(a - b) > (2 * e))
	{
		x = (a + b) / 2;
		if (((sin(a)+0.3) * (sin(a) + 0.3)) <= 0) b = x;
		else a = x;
	}
	return x;
}

void COUT(double a, double b, double x, double(*f)(double a, double b, double x))
{
	cout << " орень: " << f(a, b, x)<<endl;
}
int main()
{
	double a, b, x=0;
	int choice;
	setlocale(LC_CTYPE, "RUS");
	do {
		cout << "\n¬ведите a: "; cin >> a;
		cout << "\n¬ведите b: "; cin >> b;
		x = 0;
		cout << "¬ыберите уравнение: \n1 - '2x + x^3 Ц 7' \n2 - 'e^x + 2x' \n3(13) - '5x Ц 1 + x^3'\n4(13) - 'x^2 + 1 / x'\n5(14) 'e^x + x - 4' \n6(14) - 'x^2 Ц 4'";
		cout << "\n7(15) - '2x + x^3 Ц 7' \n8(15) - 'e^x + 2x' \n";
		cin >> choice;
		
		switch (choice)
		{
		case 1:  COUT(a, b, x, dihotomia1); break;
		case 2:  COUT(a, b, x, dihotomia2); break;
		case 3:  COUT(a, b, x, dihotomia3); break;
		case 4:  COUT(a, b, x, dihotomia4); break;
		case 5:  COUT(a, b, x, dihotomia5); break;
		case 6:  COUT(a, b, x, dihotomia6); break;
		case 7:  COUT(a, b, x, dihotomia7); break;
		case 8:  COUT(a, b, x, dihotomia8); break;
		case 0L: exit(0);
		default: cout << "Ќеверный ввод";
			break;
		}
	} while (choice);
	return 0;
}