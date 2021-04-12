// 7 вариант, 3 і 8, возможно... 
// 8 вариант
/*#include <iostream>
using namespace std;
int main()
{
	setlocale(LC_CTYPE, "Russian");
	using namespace std;
	char s1[] = "мадам щука акка таня ", s2[30], s3[30], sl, sn;
	int i = 0, j = 0, k, c=0, dmax=0, smax=0;
	cout << "Массив: " << s1 << endl;
	k = strlen(s1);
	for (; i <= k; i++)
	{
		if (s1[i] != ' ')
		{

			s2[c] = s1[i];
			c++;
		}
		else
		{
			c = 0;
			dmax = strlen(s2);
			if (dmax % 2 == 0)
			{
				int i = 0, j = dmax - 1;
				while (i < dmax || j > 0)
				{
					s3[i] = s2[j];   
					j--;
					i++;
				}
			}
			if(s2==s3 || smax<strlen(s3))	
			smax = strlen(s3);
		}

	}
	cout << endl;
	cout << "Конечный массив: " << s3;
}*/

//8 вар(РАБОТАЕТ)
/*#include <algorithm>
#include <iostream>
#include <sstream>
#include <string>

int main()
{
	const std::string vowels = "aeiouy";

	std::string str;
	std::getline(std::cin, str);

	std::stringstream ss(str);

	std::string maxWord;

	int maxVowels = 0;
	int curVowels = 0;

	while (ss >> str)
	{
		curVowels = std::count_if(str.begin(), str.end(), [vowels](const char& c) {
			return (vowels.find(c) != std::string::npos);
			});

		if (curVowels > maxVowels) {
			maxVowels = curVowels;
			maxWord = str;
		}
	}

	std::cout << maxWord << std::endl;

	return 0;
}*/
// 4 вариант. Из заданного предложения удалить те слова, которые уже встречались в предложении раньше
/*#include <iostream>
using namespace std;
int main()
{
	setlocale(LC_CTYPE, "Russian");
	using namespace std;
	char s1[] = "Вчера было холодно ", s2[]="Сегодня было жарко ", s3[30], sl, sn;
	int i = 0, j = 0, k, c = 0, dmax = 0, smax = 0;
	cout << "Массив1: " << s1 << endl;
	cout << "Массив2: " << s2 << endl;
	k = strlen(s1);
	for (; i <= k; i++)
	{
		if (s1[i] != ' ')
		{
			s2[c] = s1[i];
			c++;
			cout << s2[c];
		}
	}
}*/
// 5 вариант 5(ВРОДЕ СДЕЛАНО)нет...
/*
#include <algorithm>
#include <iostream>
#include <iterator>

int main(int argc, char* argv[])
{
	setlocale(LC_CTYPE, "Russian");
	std::cout << "Введите предложение.." << std::endl;

	for (auto it = std::istream_iterator<std::string>(std::cin); it != std::istream_iterator<std::string>(); std::advance(it, 2))
	{
		std::string word = *it;
		std::reverse(word.begin(), word.end());
		std::cout << word << " ";
	}
	std::cout << std::endl;

	return 0;
}*/
// удаляя из него все слова с нечетными номерами и переворачивая слова с четными номерами. Пример: HOW DO YOU DO -> OD OD.
/*#include <iostream>
using namespace std;
int main()
{
	setlocale(LC_CTYPE, "Russian");
	using namespace std;
	char s1[] = "HOW DO YOU DO", s2[10], s3[10], sl, sn;
	int i = 0, j = 0, k=0, col=1, c=0, u=0, ii=0, jj=0;
	cout << "Массив: " << s1 << endl;

	k = strlen(s1);
	for (; i <= k; i++)
	{
		if (s1[i] != ' ')
		{
			s2[j] = s1[i]; // записываем слово в другой массив, пока не встретим пробел
			j++;
		}
		else 
		{
			if (col % 2 != 0) // встретив пробел проверяем, четный или нечетный он по счету
			{
				continue; // с нечетным пропускаем слово
			}
			else // если четный, то выводим его с конца
			{
				c = strlen(s2);
				u = c;
				for (int ii = 0; ii <= c; ii++)
					cout << s2[u--];
			}
			col++;
		}

	}
	cout << s2;
	*/

// 7 7.	Даны два предложения. Найти самое короткое из слов первого предложения, которого нет во втором предложении
/*#define _CRT_SECURE_NO_WARNINGS
#include <iostream> 
#include <stdio.h> 
#include <string.h>

using namespace std;

int main()
{
	char  str1[255], str2[255];
	char* word1;
	char* word2;
	char* wordArr1[20];
	char* wordArr2[20];
	int   ind1 = 0;
	int   ind2 = 0;

	int   maxLen = 0;
	int   out = -1;
	int   i, j, len;

	cout << "Vvedit 1 ryadok: " << endl;
	cin >> str1;

	cout << "Vvedit 2 ryadok: " << endl;
	cin >> str2;

	word1 = strtok(str1, " ,");
	wordArr1[ind1++] = word1;


	while (word1)
	{
		word1 = strtok(NULL, " ,");
		wordArr1[ind1++] = word1;
	}

	word2 = strtok(str2, " ,");
	wordArr2[ind2++] = word2;

	while (word2)
	{
		word2 = strtok(NULL, " ,");
		wordArr2[ind2++] = word2;
	}


	for (i = 0; i < ind1 - 1; i++) {
		for (j = 0; j < ind2 - 1; j++) {

			if (!strcmp(wordArr2[j], wordArr1[i])) {
				len = strlen(wordArr1[i]);
				if (len > maxLen) {
					maxLen = len;
					out = i;
				}
			}
		}
	}

	cout << "Znaydene slovo: " << endl;
	if (out >= 0) {
		cout << wordArr1[out] << endl;
	}
	else {
		cout << "Nema" << endl;
	}

	return 0;
}*/
//1 1.	В заданной последовательности слов найти все слова, имеющие заданное окончание.
/*#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <cstdio>
#include <cstring>
using namespace std;
int main()
{
	setlocale(LC_ALL, "rus");
	char s[255], d[255];
	cout << "Введите текст: " << endl;
	cin>>s;  //Вводим строку содержащую слова
	cout << "Введите окончание для слова: " << endl;
	cin >> d;  //Вводим окончание
	char* p = strtok(s, " ");
	while (p != NULL)
	{
		if (strstr(s, d) != 0)
		{
			cout << p << endl;
			p = strtok(NULL, " ");
		}
		
	}
}*/
