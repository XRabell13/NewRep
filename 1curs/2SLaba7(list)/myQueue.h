#pragma once
struct Symbole
{
	char info;
	Symbole* next;
};
void create(Symbole** begin, Symbole** end, char p); //������������ ��������� �������
void view(Symbole* begin); //������� ������ ��������� ������� 
Symbole* minElem(Symbole* begin); //������� ����������� ������������ �������� 
void clear(Symbole** begin); //������� �������� �� ������������ �������� 
int siz(Symbole* begin);//������� ������ ������� �������
void meny();