#pragma once
struct Symbole
{
	char info;
	Symbole* next;
};
void create(Symbole** begin, Symbole** end, char p); //формирование элементов очереди
void view(Symbole* begin); //функция вывода элементов очереди 
Symbole* minElem(Symbole* begin); //функция определения минимального элемента 
void clear(Symbole** begin); //функция удаления до минимального элемента 
int siz(Symbole* begin);//функция вывода размера очереди
void meny();