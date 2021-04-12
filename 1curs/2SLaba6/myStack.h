#pragma once
struct Stack
{
	int data;             //�������������� �������
	Stack* head;		 //������� ����� 
	Stack* next;		 //��������� �� ��������� �������
};

struct chStack
{
	int chet;             //�������������� �������
	chStack* head;		 //������� ����� 
	chStack* next;		 //��������� �� ��������� �������
};

struct nechStack
{
	int nechet;             //�������������� �������
	nechStack* head;		 //������� ����� 
	nechStack* next;		 //��������� �� ��������� �������
};

void show(Stack* myStk);         //��������
int pop(Stack* myStk);           //��������
void push(int x, Stack* myStk);  //��������
int clear(Stack* myStk);                //��������
void toFile(Stack* myStk);       //��������
void fromFile();       //��������
void stkfunc(Stack* myStk, chStack* chStk,nechStack* nechStk);
void nechpush(int x, nechStack* myStk);
void chpush(int x, chStack* myStk);
void stkdop(Stack* myStk, chStack* chStk, nechStack* nechStk);