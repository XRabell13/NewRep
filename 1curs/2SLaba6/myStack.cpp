//����������� ������ ���������� ���������������� ������� 
#include <iostream>
#include "myStack.h"
#include <fstream>
using namespace std;
void push(int x, Stack* myStk)   //���������� �������� � � ����	
{
	Stack* e = new Stack;    //��������� ������ ��� ������ ��������
	e->data = x;             //������ �������� x � ���� v 
	e->next = myStk->head;   //������� ������� �� ��������� ������� 
	myStk->head = e;         //����� ������� �� ������� ������
}
void nechpush(int x, nechStack* myStk)   //���������� �������� � � ����	
{
	nechStack* e = new nechStack;    //��������� ������ ��� ������ ��������
	e->nechet = x;             //������ �������� x � ���� v 
	e->next = myStk->head;   //������� ������� �� ��������� ������� 
	myStk->head = e;         //����� ������� �� ������� ������
}
void chpush(int x, chStack* myStk)   //���������� �������� � � ����	
{
	chStack* e = new chStack;    //��������� ������ ��� ������ ��������
	e->chet = x;             //������ �������� x � ���� v 
	e->next = myStk->head;   //������� ������� �� ��������� ������� 
	myStk->head = e;         //����� ������� �� ������� ������
}
int pop(Stack* myStk)   //���������� (��������) �������� �� �����
{
	if (myStk->head == NULL)
	{
		cout << "���� ����!" << endl;
		return -1;               //���� ���� ���� - ������� -1 
	}
	else
	{
		Stack* e = myStk->head;   //� - ���������� ��� �������� ������ ��������
		int a = myStk->head->data;   //������ ����� �� ���� data � ���������� a 
		myStk->head = myStk->head->next; //������� �������
		delete e;                        //�������� ��������� ����������
		return a;                        //������� �������� ���������� ��������
	}
}
void show(Stack* myStk)    //����� �����
{
	Stack* e = myStk->head;    //����������� ��������� �� ������� �����
	int a;
	if (e == NULL)
		cout << "���� ����!" << endl;
	while (e != NULL)
	{
		a = e->data;          //������ �������� � ���������� a 
		cout << a << " ";
		e = e->next;
	}
	cout << endl;
}
int clear(Stack* myStk)
{
	if (myStk->head == NULL)
	{
		cout << "���� ����!" << endl;
		return -1;               //���� ���� ���� - ������� -1 
	}
	else
	{
		while (myStk->head != NULL)
		{
			Stack* e = myStk->head;   //� - ���������� ��� �������� ������ ��������
			int a = myStk->head->data;   //������ ����� �� ���� data � ���������� a 
			myStk->head = myStk->head->next; //������� �������
			delete e;     //�������� ��������� ����������
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
		cout << "\n ������ �������� �����";
		exit(1);
	}
	else
	{
		if (e == NULL)
			cout << "���� ����!" << endl;
		while (e != NULL)
		{
			a = e->data;          //������ �������� � ���������� a 
			fstk << a << " ";
			e = e->next;
		}
		fstk.close();
		cout << "���� ������� � ���� mList.txt\n";
	}


}

void fromFile()
{
	char bufstk[30];
	ifstream fstk("Stack.txt");
	if (fstk.fail())
	{
		cout << "\n ������ �������� �����";
		exit(1);
	}
	else
	{
			cout << "���� �� �����: ";
				fstk.getline(bufstk, 20);
				cout <<bufstk<<endl;
			fstk.close();
	}
	
}

void stkfunc(Stack* myStk, chStack* chStk, nechStack* nechStk)
{
	nechStack* nc = nechStk->head; //��������� ������ ��� �����    
	chStack* c = chStk->head; //��������� ������ ��� ����� 
	int a=0;

	if (myStk == NULL)
		cout << "���� ����!" << endl;
	while (myStk != NULL)
	{
		a = pop(myStk);
		if (a == -1)
		{
			chStack* e = chStk->head;    //����������� ��������� �� ������� �����
			int rstk;
			if (e == NULL)
				cout << "���� ����!" << endl;
			cout << "���� � ������� ����������: ";
			while (e != NULL)
			{
				rstk = e->chet;          //������ �������� � ���������� a 
				cout << rstk << " ";
				e = e->next;
			}
			cout << endl;
			cout << "���� � ��������� ����������: ";
			nechStack* x = nechStk->head;    //����������� ��������� �� ������� �����
			int rstk1;
			if (x == NULL)
				cout << "���� ����!" << endl;
			while (x != NULL)
			{
				rstk1 = x->nechet;          //������ �������� � ���������� a 
				cout << rstk1 << " ";
				x = x->next;
			}
			cout << endl;
			return;
		}

		if (a % 2 == 0)//������ �������� � ���������� a 
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
	nechStack* nc = nechStk->head; //��������� ������ ��� �����    
	chStack* c = chStk->head; //��������� ������ ��� ����� 
	int a = 0;

	if (myStk == NULL)
		cout << "���� ����!" << endl;
	while (myStk != NULL)
	{
		a = pop(myStk);
		if (a == -1)
		{
			chStack* e = chStk->head;    //����������� ��������� �� ������� �����
			int rstk;
			if (e == NULL)
				cout << "���� ����!" << endl;
			cout << "���� �� ��������� ����������� ����� 50: ";
			while (e != NULL)
			{
				rstk = e->chet;          //������ �������� � ���������� a 
				cout << rstk << " ";
				e = e->next;
			}

			cout << endl;
			cout << "���� � ����������� ����������: ";
			nechStack* x = nechStk->head;    //����������� ��������� �� ������� �����
			int rstk1;
			if (x == NULL)
				cout << "���� ����!" << endl;
			while (x != NULL)
			{
				rstk1 = x->nechet;          //������ �������� � ���������� a 
				cout << rstk1 << " ";
				x = x->next;
			}
			cout << endl;
			return;
		}

		if (a > 50)//������ �������� � ���������� a 
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