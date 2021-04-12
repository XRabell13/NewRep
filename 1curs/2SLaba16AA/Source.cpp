#include <iostream>
#include <string>
#include "Hash.h"
#include <ctime>
using namespace std;

void main()
{
	setlocale(LC_ALL, "Russian");
	int size;
	char num[50];
	clock_t  t1, t2;
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
		cout << "6 - Hash" << endl;
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
			t1 = clock();
			HT_1->SearchNodes();
			t2 = clock();
			cout << "\nПрошло " << t2 - t1 << " тактов времени" << endl << endl;
		
			break;
		}
		case 5:
		{
			HT_1->FillPercent();
			break;
		}
		case 6:
		{
			cin >> num;
			cout << "!!!! " << HT_1->HashFunc(num, strlen(num)) << endl;
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