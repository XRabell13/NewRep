#include "Hash.h"
#include <iostream>
#include <string>
using namespace std;
void main()
{
	setlocale(LC_ALL, "Russian");
	int size;
	cout << "Введите размер хэш-таблицы: "; cin >> size; cout << endl;

	HashTable* HT_1 = new HashTable(size);


	int choice = -1;
	while (choice)
	{
		cout << "\n------------------------------";
		cout << "\nМеню для работы с Хэш-таблицей" << endl;
		cout << "1 - добавление элемента" << endl;
		cout << "2 - вывод хэш-таблицы" << endl;
		cout << "3 - удаление элемента" << endl;
		cout << "4 - поиск элемента(-ов)" << endl;
		cout << "5 - процент заполнения" << endl;
		cout << "0 - выход" << endl;
		cout << "------------------------------\n\n";
		cout << "Ваш выбор: "; cin >> choice;
		cout << endl;
		switch (choice)
		{
		case 1:
		{
			HT_1->Insert();
			break;
		}
		case 2:
		{
			HT_1->PrintTable();
			break;
		}
		case 3:
		{
			HT_1->DeleteNode();
			break;
		}
		case 4:
		{
			HT_1->SearchNodes();
			break;
		}
		case 5:
		{
			HT_1->FillPercent();
			break;
		}
		case 0:
		{
			exit(0);
		}
		default:
		{
			cout << "\nТакого пункта не существует. Выберете снова.\n";
			break;
		}
		}

	}
}