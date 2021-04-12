// 8 вариант :с (работает... но не оч) 
/*#include <algorithm>
#include <iostream>
#include <sstream>
#include <string>
using namespace std;
int main()
{
	const string vowels = "aeiouy";
	int maxVowels = 0, curVowels = 0;
	string str;
	getline(cin, str);
	stringstream ss(str);
	string maxWord;
	while (ss >> str)
	{
		curVowels = count_if(str.begin(), str.end(), [vowels](const char& c)
			{
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
// 4 var

// 7 вар
//ƒаны два предложени€. Ќайти самое короткое из слов первого предложени€, которого нет во втором предложении.
/*#include <iostream>
#include <string>
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "RUS");
	char a[] = "I can speak englich", b[] = "Can you speak endlich";
	char c[20], u, cmin[20], inn[10]="I";
	int i = 0, j = 0, k = 0, jj=0, ii=0, imin=0, q=0, w=0;
	cout << a << "   " << b << endl;
	// сначала найдем самое короткое слово из первого предложени€ и сравним с массивом вторым, если там нет этого слова, то выводим 
	// если есть, то снова ищем короткое слово...
	k = strlen(a);
	imin = k;
	for (int i = 0; i <= k; i++)
	{
		if (a[i] == ' ')
		{
			i = k;
			for (int j = i; j != -1;)
				c[j--] = a[k--];
			if (imin > strlen(c))
			{
				for (int q = 0; q <= strlen(c); q++)
					cmin[q] = a[q]; u = 'I'; a[0] = u;
				imin = strlen(cmin);
			}
			inn[0]='I';
		}
	}
	cout << "—лово: " << inn;

}*/
//1 var
/*#define _CRT_SECURE_NO_WARNINGS
#include <string.h>
#include <cstdio>
#include <conio.h>
#include <iostream>


int main()
{
	using namespace std;
	char s[1000], m[10], buf[80], * p;
	int i, k, len;
	cout << "Vvedite stroku:\n";
	gets_s(s);
	cout << "\nVvedite masku:\n";
	gets_s(m); cout << "\n";
	len = strlen(s);
	i = 0;

	while (i < len)
	{
		while (s[i] == ' ' && i < len) i++;
		strcpy(buf, "");
		k = 0;
		while (s[i] != ' ' && i < len)
			buf[k++] = s[i++];
		buf[k] = '\0';
		p = strstr(buf, m);
		if (p) cout << buf << "\n";
		i++;
	}
	getch();
	return 0;
}*/
// хз
/*#include <stdafx.h>
int main(void)
{
	char s[100]; // =" ssd hel55leh myym mqw2wqm world";
	char a[10][100];
	int cnt = 0;
	int cnti = 0;
	int i, j, palindrom, maxpalindrom, index;

	printf_s("Vvod stroki: \n");
	gets_s(s);
	maxpalindrom = 0;
	index = -1;
	for (i = 0; s[i] != 0; i++)
	{
		if (s[i] == ' ')
		{
			if (cnti != 0)
			{
				a[cnt][cnti] = 0;
				// проверка на палиндром
				palindrom = 1;
				for (j = 0; j < (cnti - 1) / 2; j++)
				{
					if (a[cnt][j] != a[cnt][cnti - 1 - j]) { palindrom = 0; break; }
				}
				if (palindrom == 1) if (maxpalindrom < cnti - 1) { maxpalindrom = cnti - 1; index = cnt; }
				cnt++; cnti = 0;
			}
		}
		else { a[cnt][cnti++] = s[i]; }
	}
	if (cnti != 0) { a[cnt][cnti] = 0; }

	// ¬ывод всех слов
	for (i = 0; i < cnt; i++)
	{
		printf("%s\n", a[i]);
	};

	if (index != -1)
		printf("%s%s\n", "Max palindrom: ", a[index]);
	else printf("%s\n", "No palindroms");

	getchar();
	return 0;
}*/

// 1 вариант(–јЅќ“ј≈“)
#include <iostream>
int main()
{
	setlocale(LC_CTYPE, "RUS");
	using namespace std;
	const int N = 3;
	char arr[N][20] = { "Window", "Cat", "Door" };
	char post[10]; //ѕеременна€ в которую записываем окончание
	int raw = 0; // оличество совпадений
	cout << "¬ведите окончание: "; cin >> post;
	for (int i = 0; i < N; i++) {
		//k - ѕоследний символ текущего слова
		//countPost - последний символ окончани€
		//countPost >= 0 - ѕока не дойдем до первого символа окончан€
		for (int k = strlen(arr[i]) - 1, countPost = strlen(post) - 1; countPost >= 0; k--, countPost--) {
			if (arr[i][k] == post[countPost]) {
				//—вер€ем последний символ слова с последним символом окочани€, если одинаковые, то добавл€ем совпадени€
				//ƒальше свер€ем предпоследние символы и так далее, пока не закончатс€ символы в окончании
				raw++;
			}
		}
		if (raw == strlen(post))
		{
			cout << arr[i] << endl;
			//≈сли количество совпадений и количество символов в окончании равны, то выводим это слово
		}
		raw = 0;
	}
}

// наше предложение 
/*#include <iostream>
#include <string>

int main()
{
	using namespace std;
	char simvol[1];
	string slovo;
	string slovoMax;
	int maxkolvoglas = 0;
	int kolvoglas = 0;

	// вводим данные 
	for (int ns = 1; ns <= 100; ns++) {
		slovo = ""; //слово в предложении 
					// заполним любым значением 
		// перебираем все сиволы 
		// как только дойдем до пробела - слово закончилось 
		while (simvol != " ")
		{
			if (simvol = 'A') || (simvol = 'I') ||
				(simvol = 'E') || (simvol = 'O') || (simvol = 'U')
			{
				kolvoglas++;

			}

			slovo = slovo & simvol;

		}
		// если нашли слово в котором количество гласных больше чем уже было 
		// тогда мы нашли новое слово с максимальным количеством гласных 
		if (kolvoglas > maxkolvoglas) {
			maxkolvoglas = kolvoglas;
			slovoMax = slovo;
		}

	}

	using std::cout; slovoMax;
	using std::cout;  maxkolvoglas;
}
// вот что-то такое будет, надеюсь ничего не пропустил 
// отступы пропадают.... (((((*/
//не то
/*
#include <iostream>
using namespace std;
int main()
{
	const int STRLEN = 200;
	char s[STRLEN];
	cin.getline(s, STRLEN);

	size_t maxlen = 0;
	char* maxidx = nullptr;

	for (char* c = s; *c;)
	{
		while (*c == ' ') ++c;
		if (*c == 0) break;
		char* begin = c;
		while (*c && *c != ' ') ++c;
		if (maxlen < (c - begin))
		{
			maxlen = c - begin;
			maxidx = begin;
		}
	}
	if (maxlen == 0)
	{
		cout << "Empty line!\n";
		return 0;
	}
	else
	{
		*(maxidx + maxlen) = 0;
		cout << maxidx;
	}
}*/
