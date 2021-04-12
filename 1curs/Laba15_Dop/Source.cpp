// вариант 10
// Написать программу, которая записывает строку в обратном порядке.
/*#include <stdio.h>
#include <ctype.h>
#include <cstring>
#include <iostream>
void letters(char* str);

int main(void)
{
	char str[80];
	puts("Input char");
	gets_s(str);
	letters(str);
	return 0;
}
void letters(char* str)
{
	int k = 0;
	k = strlen(str);
	std::cout << "Stroka: ";
	for (int i = 0; (k+1) != i; k--)
	{
		std::cout << str[k];
	}
}*/

// вариант 3 В строке есть два символа *. Получить все символы между первым и вторым символом *. 

/*#include <stdio.h>
#include <ctype.h>
#include <cstring>
#include <iostream>
void letters(char* str);

int main(void)
{
	char str[80]="World qwerty I love *you are help...* me";
	puts(str);
	letters(str);
	return 0;
}
void letters(char* str)
{
	int a1=0, a2=0, k = 0, l=0;
	
	std::cout << "Stroka: ";
	for (int i = 0;  i< strlen(str); i++)
	{
		if ((str[i] == '*') && (l == 0))
		{
			a1 = i; l++;
		}
		if ((str[i] == '*') && (l == 1))
		{
			a2 = i; l++;
		}
	}

	for (; a1 < a2; a1++)
	{
		std::cout << "/n" << str[a1];
	}
}*/

/*#include <stdio.h>
#include <ctype.h>
#include <cstring>
#include <iostream>
int main(void)
{
	char str[80] = "World qwerty I love *you are help...* me";
	puts(str);
	letters(str);
	return 0;
}

void letters(char* str)
{
	setlocale(LC_ALL, "Russian");
	int c = 0;
	for (int i = 0; i < strlen(str); i++) {
		if (c == 0) {
			if (str[i] == '*') c++;
		}
		else
			if (str[i] == '*') break;
			else std::cout << str[i];
	}
	std::cout << '\n';
	system("pause");
}*/


#include<iostream>
using namespace std;
void letters(char* str);
int main()
{
	char s[100]="Hello! *What do you do?* Go to sleep";
	letters(s);
}
void letters(char* s)
{
	int i = 0, c = 0, k = 0;
	k = strlen(s);
	for (int h = 0; s[h] != '\0'; h++) cout << s[h];
	cout << endl;
	for (int i = 0; s[i] != '\0'; ++i)
		if (s[i] == '*')
		{
			for (++i; s[i] != '\0' && s[i] != '*'; ++i) cout << s[i];
			break;
		}
	cout << endl;
}