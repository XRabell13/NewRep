//y=cosx+cos2x+...+cosnx
/*#include <iostream>
using namespace std;
float y=0;
float binPrn(float num, float x)
{
	if (num > 0) 
	{
		num--;
		y += cos(num * x);
		binPrn(num, x);
	}
    return y;
}
int main()
{
	float x, n;
	setlocale(LC_CTYPE, "RUS");
	cout << "n = "; cin >> n;
	cout << "x = "; cin >> x;
	cout<<"y = "<<binPrn(n, x);
	return 0;
}*/
/*����������� ���������, �����-������ ����������� ������� f(x, n),
����������� �������� xn/n! ��� ����� ������������ x � ��-��� ��������������� ����� n.
��� ���������� xn-1/(n-1)! ���� ���������� ���������� � f(x, n-1),
� ����� ���������� �������� �������� �� x/n, ����� �������� �������� f(x, n).
������� f(x, n) ��������� ��������� ���:
*/
#include <iostream>
using namespace std;
float y = 0;
float f(float x, float n)
{
	if (n == 0) return 1;
	else if (n == 1) return x;
	else return ((x*x/n)/(n-1)*f(x, n - 1));
}
int main()
{
	float x, n, u;
	setlocale(LC_CTYPE, "RUS");
	for (;;)
	{
		cout << "n = "; cin >> n;
		if (n < 0) break;
		u = n;
		cout << "x = "; cin >> x;
		cout << "y = " << f(x, n);
		cout << "\n";
	}
	return 0;
}
/*����������� ���������, �����-������ �����������
�������� ���������� �������� S(x) ��� ��-��� ����� �� ������������� �����-��� x.*/
/*#include <iostream>
using namespace std;
int y = 0;
int S(int x)
{
	if (x >= 0)
	{
		if (x > 100) { x = x + 10; return x; }
		else S(S(x + 4));
	}
}
int main()
{
	int x, n, u;
	setlocale(LC_CTYPE, "RUS");
	cout << "x = "; cin >> x;
	u = S(x);
	cout << "y = " << u;
	return 0;
}*/
