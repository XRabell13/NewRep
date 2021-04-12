/*
Создать стек с целочисленным информационным полем. 
Заполнить его длинами строк, считанных из файла. 
Распечатаьть на экране содержимое стека.
Указать номер и длину последней самой короткой строки файла.
*/
#include <iostream>
#include <cmath>
#include <cstring>
#include <fstream>

using namespace std;
struct fstr
{
	int ind;
	int nstr;
	fstr* next;
};
void zapis(fstr** begin, int n, int k)//запись в стек
{
	fstr* i = new fstr;
	i->ind = n;// количество символов в строке
	i->nstr = k;//номер строки
	i->next = *begin;
	*begin = i;
}

void vivod(fstr* begin)//вывод на экран
{
	fstr* i = begin;
	if (begin == NULL)
	{
		cout << "Spisok pust";
		return;
	}
	while (i != NULL)
	{
		cout << i->ind <<" ";
		i = i->next;
	}
}
void find(fstr* begin)
{
	fstr* i = begin;
	int j = 0, k = 0;
	if (begin == NULL)
	{
		cout << "Spisok pust";
		return;
	}
	j = i->ind;
	while (i != NULL)
	{
		if ((i->ind) <= j)
		{
			j = i->ind;
			k = i->nstr;
		}
		i = i->next;
	}
	cout << "Номер самой короткой строки: " << k << "\nКоличество символов в ней: " << j<<endl;
	return;
}

int main()
{
	setlocale(LC_CTYPE,"RUS");
	fstr* begin = NULL;
	ifstream in("Text.txt");
	char str[255];
	int n, k=0;


	while (!in.eof())
	{
		in.getline(str, 255);
		n = strlen(str);
		k++;
		zapis(&begin, n, k);
	}
	in.close();
	vivod(begin);
	cout << endl;
	find(begin);
	return 0;
}