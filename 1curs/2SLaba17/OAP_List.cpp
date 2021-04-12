#include "List.h"
#include <iostream>

using namespace std;
const int N = 10;
struct Person
{
	char name[20];
	int age;
	Person* next;
};

void print(void* b)       //Функция используется при выводе 
{
	Person* a = (Person*)b;
	cout << a->name << "  " << a->age << endl;
}

int main()
{
	int choice;
	setlocale(LC_CTYPE, "Russian");
	Person* A;
	do
	{
		cout << "Введите:" << endl;
		cout << "1-для удаления записи" << endl;
		cout << "2-для ввода новой записи" << endl;
		cout << "3-для вывода записи(ей)" << endl;
		cout << "4.Поиск по фамилии" << endl;
		cout << "5-выход" << endl;
		cout << "Введите номер операции: ";
		cin >> choice;

		switch (choice)
		{
		case 1:  A.Delete();	break;//удалить
		case 2:  enter_new();  break;// ввести новую строку
		case 3:  out();	break; //вывести
		case 4:  cout << "Введите фамилию: "; cin >> fio; find(fio);	break;//найти
		}

	} while (choice != 5);

/*
	Person a1 = { "Петров", 20 };
	Person a2 = { "Сидоров", 25 };
	Person a3 = { "Гончаров", 47 };
	bool rc;
	Object L1 = Create();   // создание списка с именем L1
	L1.Insert(&a1);
	L1.Insert(&a2);
	L1.Insert(&a3);
	L1.PrintList(print);
	Element* e = L1.Search(&a3);
	Person* aa = (Person*)e->Data;
	cout << "Найден элемент= " << aa->name << endl;
	rc = L1.Delete(&a2);
	if (rc == true) cout << "Удален элемент" << endl;
	cout << "Список:" << endl;
	L1.PrintList(print);*/
	return 0;
}
