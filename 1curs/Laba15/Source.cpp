//������� ������
/*#include <iostream> 
float integ(float(*) (float), float, float, float);
float f(float); 

int main()
{
	float z;
	z = integ(f, (float)0.0, (float)10.0, (float)0.01);
	std::cout << "Integral=" << z;
}

float integ(float(*f) (float), float a, float b, float h)
{
	float n = 200, z, x, s;
	h = (b - a) / n; x = a; s = 0;
	while (x < (b - h))
	{
		s = s + h * ((pow(sin(x), 2) + 1) + ((pow(sin(x + h), 2) + 1)) / 2);
		x = x + h;
	}
	z = s;
	return z;
}

float f(float x)
{
	return (2 * x + 5);
}*/
// ������� ������
// ������� 16
//� ������ ������ �������� ��������� 1 � �������� ��������� � �������������� ������������ �������� ��� ������� �� ����-�������� ������ � 12. 
//������ ��������� � ��������� � ���, ����� ������������������ ������������� ���������� ��� ���������� ���������� ������� � ��� ����������� ���������� �������. 
#include <stdio.h>
#include <ctype.h>
#include <iostream>
using namespace std;
void letters(char* str);

int main(void)
{
	setlocale(LC_CTYPE, "RUS");
	char str[80];
	puts("������� ������: ");
	gets_s(str);
	letters(str);
	return 0;
}
void letters(char* str)
{
	setlocale(LC_CTYPE, "RUS");
	using namespace std;
	char b; int i = 0, j = 0, c, a, k;
	cout << endl;
	cout << "������� ������ ��� �������� ��� �� ������: ";
	cin >> b;
	cout << endl;
	c = strlen(str);
	for (; i <= c; i++)
		if (str[i] == b)
		{
			a = c - i;
			for (int j = i; j <= c; j++)
				str[j] = str[j + 1];
		}
	cout << "������ ��� ���������� �������: " << str;
}
