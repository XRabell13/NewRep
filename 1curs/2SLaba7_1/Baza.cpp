/*
������� ������� ��� �������� � ������� ��� �����, ������, �������� � ����������� ������� �������.
������ ������� � ������ � �������.
� ������ ���������� ��������� ������� � ������ ��������� ������� ������� ������� � �� ������.

����������� ���� � ����������� ��� �������� � �������� ����� �������. ������������ ������ ������� ������ � ����������.
*/

#include "myQueue.h"
#include <iostream>
#include <tchar.h>
using namespace std;

struct myQue
{
	int a;
	char b;
};

void printQueue(Queue& s)    // ����� �� ����� � �������� �������    
{
	while (!(s.isEmpty()))
	{
		cout << ((myQue*)peekQueue(s))->a << "  " << ((myQue*)peekQueue(s))->b << endl;
		delQueue(s);
	}
}

int main()
{
	setlocale(LC_CTYPE, "RUS");
	int choice, razmer, number = 0;
	char sim;

	cout << "������� ������ �������: "; cin >> razmer;
	Queue q1 = createQueue(razmer);
	myQue* a4 = new myQue;

	for (;;)
	{
		cout << "�������� �������:" << endl;
		cout << "1 - ���� �������� � �������" << endl;
		cout << "2 - ���������� �������� �� �������" << endl;
		cout << "3 - ����� �������" << endl;
		cout << "4 - ������� �������" << endl;
		cout << "9 - �����" << endl;
		cin >> choice;
		switch (choice)
		{
		case 1: cout << "������� �������: " << endl;
			cin >> sim;

			enQueue(q1, a4);
			break;
	/*	case 2: choice = pop(myStk);
			if (choice != -1)
				cout << "����������� �������: " << choice << endl;
			break;*/
		case 3: cout << "���� ����: " << endl;
			printQueue(q1);
			break;
			/*
		case 4: clear(myStk); cout << "���� ������!";
			break;
		case 7: stkfunc(myStk, chStk, nechStk); break;
		case 8: stkdop(myStk, chStk, nechStk); break;*/
		case 2: return 0;
			break;
		default: cout << "�������� ��������!"; break;
		}
	}
}
