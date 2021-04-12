#pragma once
const unsigned int NAME_SIZE = 30;
const unsigned int CITY_SIZE = 20;
const unsigned int NUMBER_SIZE = 15;
struct Address
{
	char name[NAME_SIZE];
	char city[CITY_SIZE];
	char number[NUMBER_SIZE];
	Address* next;
	Address* prev;
};
int menu(void);
void insert(Address* e, Address** phead, Address** plast);//Добавление в конец списка
Address* setElement();      // Создание элемента и ввод его значений с клавиатуры 
void outputList(Address** phead, Address** plast);      //Вывод списка на экран
void find(char name[NAME_SIZE], Address** phead);    // Поиск имени в списке
void delet(char name[NAME_SIZE], Address** phead, Address** plast);// Удаление имени 
void deleteX(int x, Address** phead, Address** plast);
