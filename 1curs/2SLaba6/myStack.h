#pragma once
struct Stack
{
	int data;             //информационный элемент
	Stack* head;		 //вершина стека 
	Stack* next;		 //указатель на следующий элемент
};

struct chStack
{
	int chet;             //информационный элемент
	chStack* head;		 //вершина стека 
	chStack* next;		 //указатель на следующий элемент
};

struct nechStack
{
	int nechet;             //информационный элемент
	nechStack* head;		 //вершина стека 
	nechStack* next;		 //указатель на следующий элемент
};

void show(Stack* myStk);         //прототип
int pop(Stack* myStk);           //прототип
void push(int x, Stack* myStk);  //прототип
int clear(Stack* myStk);                //прототип
void toFile(Stack* myStk);       //прототип
void fromFile();       //прототип
void stkfunc(Stack* myStk, chStack* chStk,nechStack* nechStk);
void nechpush(int x, nechStack* myStk);
void chpush(int x, chStack* myStk);
void stkdop(Stack* myStk, chStack* chStk, nechStack* nechStk);