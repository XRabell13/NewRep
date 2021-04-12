#include "myQueue.h"
#include <iostream>
using namespace std;

void create(Symbole** begin, Symbole** end, char p) //������������ ��������� �������
{
	Symbole* t = new Symbole;
	t->next = NULL;
	if (*begin == NULL)
		* begin = *end = t;
	else
	{
		t->info = p;
		(*end)->next = t;
		*end = t;
	}
}
Symbole* minElem(Symbole* begin) //���������� ������������ ��������
{
	Symbole* t = begin, * mn = NULL;
	int min;
	if (t == NULL)
	{
		cout << "Number is empty\n"; return 0;
	}
	else
	{
		min = t->info;
		while (t != NULL)
		{
			if (t->info <= min)
			{
				min = t->info;
				mn = t;
			}
			t = t->next;
		}
	}
	return mn;
}
void clear(Symbole** begin) //�������� �� ������������ �������� 
{
	Symbole* t;
	t = new Symbole;
	while (*begin != NULL)
	{
		t = *begin;
		*begin = (*begin)->next;
		delete t;
	}
	
}
void view(Symbole* begin) //����� ��������� ������� 
{
	Symbole* t = begin;
	int size = 0;
	if (t == NULL)
	{
		cout << "Number is empty\n";
		return;
	}
	else
		while (t != NULL)
		{
			cout << t->info << " ";
			t = t->next;
		}
	cout << '\n';
}
int siz(Symbole* begin)
{
	Symbole* t;
	int siz=0;
	t = new Symbole;
	t = begin;
	while (t != NULL)
	{
		siz++;
		t = t->next;
	}
	return siz;
}
void meny()
{
		cout << "�������� �������:" << endl;
		cout << "1 - ���� �������� � �������" << endl;
		cout << "2 - ������ ������ �������" << endl;
		cout << "3 - ����� �������" << endl;
		cout << "4 - ������� �������" << endl;
		cout << "5 - �����" << endl;		
}