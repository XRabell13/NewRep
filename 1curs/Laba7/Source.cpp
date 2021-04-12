/*6 вариант
#include <iostream>
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	float a=0, b=1, x, n=5, c;
	int i = 1;
	for (int i = 1; i <= n; i++)
	{
		cout << "x" << i << " = "; cin >> x;
		if (x > 0) a += x;
		else b = b*x;
	}
	cout << "a = " << a << endl;
	cout << "b = " << b;
}
*/
//14 вариант
#include <iostream>
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	float y, z, c=10.1;
	int i = 1;
	for (int i = 1; i <= 6; i++)
	{
		cout << "¬ведите у" << i << ":"; cin >> y;
		y = y + y;
	}
	if (y > c) z = pow(sin(c), 2);
	else z = pow(cos(c), 2);
	cout << "" << z;
}

/* 15 вариант
#include <iostream>
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	double t = 0.45, q=0, x;
	int i = 1;
	for (int i=1; i <= 6; i++)
	{
		cout << "¬ведите х" << i << ":"; cin >> x;
		q = q + (t + ((x+1)/ x));
	}
	cout << "g = " << q;
}
*/
