#include "List.h"
#include <iostream>
#include <tchar.h>
#define size 15
using namespace std;
const int str_len = 30;
struct Gosudarstvo
{

	char gosname[str_len];
	char stolica[str_len];
	char famprezident[str_len];
	char chislennost[str_len];
	char ploscha[str_len];

} GOS;

void print(void* b)       //Функция используется при выводе 
{
	Gosudarstvo* a = (Gosudarstvo*)b;
	cout << a->gosname << "  " << a->stolica <<" "<< a->famprezident << "  " << a->chislennost<<"  " << a->ploscha << endl;
}

int _tmain(int argc, _TCHAR* argv[])
{
	setlocale(LC_ALL, "Russian");
	bool rc;
	int x, choice, current_size=0;
	struct Gosudarstvo list_of_gos[size];
	Gosudarstvo spis;
	Gosudarstvo* aa;
	Element* e;
	char gosud[16];
	Object L1 = Create();   // создание списка с именем L1
	while (true)
	{
		cout << "\t\t\t\tMeny" << endl;
		cout << "-----------------------------------------------------------------------------" << endl;
		cout << "1. Ввод данных" << endl;
		cout << "2. Поиск по названию государства" << endl;
		cout << "3. Вывод на экран" << endl;
		cout << "4. Удалить элемент" << endl;
		cout << "5. Удаление списка" << endl;
		cout << "6. Подсчет количества элементов в списке" << endl;
		cout << "Чтобы Выйти, нажмите на любую другую кнопку..." << endl;
		cout << "-----------------------------------------------------------------------------" << endl;
		cout << "Ваш выбор: "; cin >> choice;
		switch (choice)
		{
		case 1: 	

			cout << "Ввод информации" << endl;
				cout << "Строка номер ";
				cout << current_size + 1;
				cout << endl << "Государство " << endl;
				cin >> list_of_gos[current_size].gosname;
				cout << "Столица" << endl;
				cin >> list_of_gos[current_size].stolica;
				cout << " Численность населения" << endl;
				cin >> list_of_gos[current_size].chislennost;
				cout << " Площадь" << endl;
				cin >> list_of_gos[current_size].ploscha;
				cout << " Фамилия президента" << endl;
				cin >> list_of_gos[current_size].famprezident;
				L1.Insert(&list_of_gos[current_size]);
				current_size++;
			break;
		case 2: cout << "Введите название государства: "; 
			cin >> gosud; 
			x = current_size;
			for (; x>=0; x--)
			{ 
				if (strcmp(gosud, list_of_gos[x].gosname) == 0) break; 
				
			};
			if (x == -1)
			{	
			cout << "Такого элемента нет!\n";
			break;
			}
		    e = L1.Search(&list_of_gos[x]);
			aa = (Gosudarstvo*)e->Data;
			cout << "Найден элемент: "<<  aa->gosname << "  " << aa->stolica << " " << aa->famprezident << "  " << aa->chislennost << "  " << aa->ploscha << endl;
			
			break;
		case 3: L1.PrintList(print);
			break;
		case 4:cout << "Введите название государства: ";
			cin >> gosud;
			x = current_size;
			for (; x >= 0; x--)
			{
				if (strcmp(gosud, list_of_gos[x].gosname) == 0) break;

			};
			if (x == -1)
			{
				cout << "Такого элемента нет!\n";
				break;
			}
			rc = L1.Delete(&list_of_gos[x]);
			if (rc == true) cout << "Удален элемент" << endl;
			cout << "Список:" << endl;
			L1.PrintList(print);
				break;
		case 5: L1.DeleteList();
			break;
		case 6: x = L1.CountList();
			cout << "Количество элементов списка: " << x << endl; break;
		default: cout<<endl << "\t\t\t\tGoodbye!\n\n"; exit(0);
		}
	}
	return 0;
}
