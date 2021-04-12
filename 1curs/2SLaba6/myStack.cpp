//программный модуль содержащий пользовательские функции 
#include <iostream>
#include "myStack.h"
#include <fstream>
using namespace std;
void push(int x, Stack* myStk)   //Добавление элемента х в стек	
{
	Stack* e = new Stack;    //выделение памяти для нового элемента
	e->data = x;             //запись элемента x в поле v 
	e->next = myStk->head;   //перенос вершины на следующий элемент 
	myStk->head = e;         //сдвиг вершины на позицию вперед
}
void nechpush(int x, nechStack* myStk)   //Добавление элемента х в стек	
{
	nechStack* e = new nechStack;    //выделение памяти для нового элемента
	e->nechet = x;             //запись элемента x в поле v 
	e->next = myStk->head;   //перенос вершины на следующий элемент 
	myStk->head = e;         //сдвиг вершины на позицию вперед
}
void chpush(int x, chStack* myStk)   //Добавление элемента х в стек	
{
	chStack* e = new chStack;    //выделение памяти для нового элемента
	e->chet = x;             //запись элемента x в поле v 
	e->next = myStk->head;   //перенос вершины на следующий элемент 
	myStk->head = e;         //сдвиг вершины на позицию вперед
}
int pop(Stack* myStk)   //Извлечение (удаление) элемента из стека
{
	if (myStk->head == NULL)
	{
		cout << "Стек пуст!" << endl;
		return -1;               //если стек пуст - возврат -1 
	}
	else
	{
		Stack* e = myStk->head;   //е - переменная для хранения адреса элемента
		int a = myStk->head->data;   //запись числа из поля data в переменную a 
		myStk->head = myStk->head->next; //перенос вершины
		delete e;                        //удаление временной переменной
		return a;                        //возврат значения удаляемого элемента
	}
}
void show(Stack* myStk)    //Вывод стека
{
	Stack* e = myStk->head;    //объявляется указатель на вершину стека
	int a;
	if (e == NULL)
		cout << "Стек пуст!" << endl;
	while (e != NULL)
	{
		a = e->data;          //запись значения в переменную a 
		cout << a << " ";
		e = e->next;
	}
	cout << endl;
}
int clear(Stack* myStk)
{
	if (myStk->head == NULL)
	{
		cout << "Стек пуст!" << endl;
		return -1;               //если стек пуст - возврат -1 
	}
	else
	{
		while (myStk->head != NULL)
		{
			Stack* e = myStk->head;   //е - переменная для хранения адреса элемента
			int a = myStk->head->data;   //запись числа из поля data в переменную a 
			myStk->head = myStk->head->next; //перенос вершины
			delete e;     //удаление временной переменной
		}
	}
}

void toFile(Stack* myStk)
{ 
	Stack* e = myStk->head;
	ofstream fstk("Stack.txt");
	int a;
	if (fstk.fail())
	{
		cout << "\n Ошибка открытия файла";
		exit(1);
	}
	else
	{
		if (e == NULL)
			cout << "Стек пуст!" << endl;
		while (e != NULL)
		{
			a = e->data;          //запись значения в переменную a 
			fstk << a << " ";
			e = e->next;
		}
		fstk.close();
		cout << "Стек записан в файл mList.txt\n";
	}


}

void fromFile()
{
	char bufstk[30];
	ifstream fstk("Stack.txt");
	if (fstk.fail())
	{
		cout << "\n Ошибка открытия файла";
		exit(1);
	}
	else
	{
			cout << "Стек из файла: ";
				fstk.getline(bufstk, 20);
				cout <<bufstk<<endl;
			fstk.close();
	}
	
}

void stkfunc(Stack* myStk, chStack* chStk, nechStack* nechStk)
{
	nechStack* nc = nechStk->head; //выделение памяти для стека    
	chStack* c = chStk->head; //выделение памяти для стека 
	int a=0;

	if (myStk == NULL)
		cout << "Стек пуст!" << endl;
	while (myStk != NULL)
	{
		a = pop(myStk);
		if (a == -1)
		{
			chStack* e = chStk->head;    //объявляется указатель на вершину стека
			int rstk;
			if (e == NULL)
				cout << "Стек пуст!" << endl;
			cout << "Стек с четными элементами: ";
			while (e != NULL)
			{
				rstk = e->chet;          //запись значения в переменную a 
				cout << rstk << " ";
				e = e->next;
			}
			cout << endl;
			cout << "Стек с нечетными элементами: ";
			nechStack* x = nechStk->head;    //объявляется указатель на вершину стека
			int rstk1;
			if (x == NULL)
				cout << "Стек пуст!" << endl;
			while (x != NULL)
			{
				rstk1 = x->nechet;          //запись значения в переменную a 
				cout << rstk1 << " ";
				x = x->next;
			}
			cout << endl;
			return;
		}

		if (a % 2 == 0)//запись значения в переменную a 
		{
			chpush(a, chStk);
		}
		else
		{
			nechpush(a, nechStk);
		}

	}
	cout << endl;
}
void stkdop(Stack* myStk, chStack* chStk, nechStack* nechStk)
{
	nechStack* nc = nechStk->head; //выделение памяти для стека    
	chStack* c = chStk->head; //выделение памяти для стека 
	int a = 0;

	if (myStk == NULL)
		cout << "Стек пуст!" << endl;
	while (myStk != NULL)
	{
		a = pop(myStk);
		if (a == -1)
		{
			chStack* e = chStk->head;    //объявляется указатель на вершину стека
			int rstk;
			if (e == NULL)
				cout << "Стек пуст!" << endl;
			cout << "Стек из элементов превышающих число 50: ";
			while (e != NULL)
			{
				rstk = e->chet;          //запись значения в переменную a 
				cout << rstk << " ";
				e = e->next;
			}

			cout << endl;
			cout << "Стек с оставшимися элементами: ";
			nechStack* x = nechStk->head;    //объявляется указатель на вершину стека
			int rstk1;
			if (x == NULL)
				cout << "Стек пуст!" << endl;
			while (x != NULL)
			{
				rstk1 = x->nechet;          //запись значения в переменную a 
				cout << rstk1 << " ";
				x = x->next;
			}
			cout << endl;
			return;
		}

		if (a > 50)//запись значения в переменную a 
		{
			chpush(a, chStk);
		}
		else
		{
			nechpush(a, nechStk);
		}

	}
	cout << endl;
}