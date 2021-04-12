//Решение 2 допзадачи
#include <iostream>
void main()
{
	setlocale(LC_CTYPE, "Russian");
	int T = 0, a = 0, b = 0, c = 0, d = 0, R = 100;
	for (int a=0; a <= 2; a++)
	{
		for (int b = 0; b <= 5; b++) 
		{
			for (int c = 0; c <= 20; c++) 
			{
				for (int d = 0; d <= 50; d++) 
				{
					if (R == (a * 50 + b * 20 + c * 5 + d * 2))
						T++;
				}
			}
		}
	}
	std::cout << "Способов: " << T;
}
//Нахождение натурального числа из 3-ех цифр, которое является полным квадратом (1)
/*#include <iostream> 
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	int i, a, b, c;
	for (int i = 121; i <= 999; i++)
	{
		a = i / 100; b = (i / 10) % 10; c = (i % 10)%10;
		if ((sqrt(i) == 13) | (sqrt(i) == 17))
			if (c > a > b)
			cout << " " << i;
		else cout << " Error";
	}
}*/
