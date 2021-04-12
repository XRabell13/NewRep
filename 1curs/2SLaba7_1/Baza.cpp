/*
Создать очередь для символов и функции для ввода, вывода, удаления и определения размера очереди.
Ввести символы с экрана в очередь.
В случае совпадения вводимого символа с первым элементом очереди вывести очередь и ее размер.

Разработать меню и реализовать все операции с очередью через функции. Максимальный размер очереди ввести с клавиатуры.
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

void printQueue(Queue& s)    // Вывод на экран с очисткой очереди    
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

	cout << "Введите размер очереди: "; cin >> razmer;
	Queue q1 = createQueue(razmer);
	myQue* a4 = new myQue;

	for (;;)
	{
		cout << "Выберите команду:" << endl;
		cout << "1 - Ввод элемента в очередь" << endl;
		cout << "2 - Извлечение элемента из очереди" << endl;
		cout << "3 - Вывод очереди" << endl;
		cout << "4 - Очистка очереди" << endl;
		cout << "9 - Выход" << endl;
		cin >> choice;
		switch (choice)
		{
		case 1: cout << "Введите элемент: " << endl;
			cin >> sim;

			enQueue(q1, a4);
			break;
	/*	case 2: choice = pop(myStk);
			if (choice != -1)
				cout << "Извлеченный элемент: " << choice << endl;
			break;*/
		case 3: cout << "Весь стек: " << endl;
			printQueue(q1);
			break;
			/*
		case 4: clear(myStk); cout << "Стек очищен!";
			break;
		case 7: stkfunc(myStk, chStk, nechStk); break;
		case 8: stkdop(myStk, chStk, nechStk); break;*/
		case 2: return 0;
			break;
		default: cout << "Неверное значение!"; break;
		}
	}
}
