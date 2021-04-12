// 6 задание
/*#include <iostream>
using namespace std;
void main()
{
	float a=2, b=7, n=200, z, h, x, s;
	h = (b - a) / n; x = a; s = 0;
	while (x < (b - h))
	{
		s = s + h * ((pow(sin(x), 2) + 1) + ((pow(sin(x + h), 2) + 1)) / 2);
		x = x + h;
	}
	z = s;
	cout << "Integral: " << z;
}*/

/*#include <iostream>
using namespace std;
void main()
{
	float a = 2, b = 7, n = 200, z, h, x, s1=0, s2=0, i=1;
	h = (b - a) / (2 * n);
	x = a + 2 * h;
	while (i < n)
	{
		s2 = s2 + (pow(sin(x), 2) + 1);
		s1 = s1 + (pow(sin(x), 2) + 1);
		i = i + 1;
		x = x + h;
	}
	z = (h / 3) * ((pow(sin(a), 2) + 1) + 4 * (pow(sin(a + h), 2) + 1) + 4 * s1 + 2 * s2 + (pow(sin(b), 2) + 1));
	cout << "Integral: " << z;
}*/

// 7 задание

// метод касательных

/*#include <iostream>
using namespace std;
void main()
{
	double a = 0, b = -2, n = 200, x1, x=0, e=0.0001;
	if ((sin(a) + 2 + a) * (-sin(a)) > 0) x1 = a;
	else x1 = b;
	while (abs(x1 - x) > e)
	{
		x = x1;
		x1 = x - ((sin(x) + 2 + x)) / (cos(x) + 1);
	}
	cout << "x1 = " << x1;
}*/

//метод дихотомии

/*#include <iostream>
using namespace std;
void main()
{
	double a = 0, b = -2, n = 200, x1, x = 0, e = 0.0001;
	while (abs(a - b) > (2 * e))
	{
		x = (a + b) / 2;
		if (((sin(a) + 2 + a) * (sin(x) + 2 + x)) <= 0) b = x;
		else a = x;
	}
	cout << "x = " << x;
}*/
