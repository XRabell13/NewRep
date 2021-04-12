/*deleteX (int x) Ц функци€ удалени€ первого встречающегос€ элемента с заданным значением x.*/
#include <iostream>
#include <fstream>
#include "Spis.h"
using namespace std;
int main(void)
{
	Address* head = NULL;
	Address* last = NULL;
	int y;
	setlocale(LC_CTYPE, "Rus");
	while (true)
	{
		switch (menu())
		{
		case 1: insert(setElement(), &head, &last); 
			break;
		case 2:	 
			char dname[NAME_SIZE];
			cout << "¬ведите им€: ";
			cin.getline(dname, NAME_SIZE - 1, '\n');
			cin.ignore(cin.rdbuf()->in_avail());
			cin.sync();//синхронизаци€  с введенными ресурсами
			delet(dname, &head, &last);
				break;
		case 3:  outputList(&head, &last);
			break;
		case 4: {	  char fname[NAME_SIZE];
			cout << "¬ведите им€: ";
			cin.getline(fname, NAME_SIZE - 1, '\n');
			cin.ignore(cin.rdbuf()->in_avail());
			cin.sync();
			find(fname, &head);
		}
				break;
		case 5:  cout << "¬ведите номер: ";
			cin >> y;
			cin.ignore(cin.rdbuf()->in_avail());
			cin.sync();
			deleteX(y, &head, &last);
			cin.ignore(cin.rdbuf()->in_avail());
			cin.sync();
			outputList(&head, &last);
			break;
		default: exit(0);
		}
	}
	return 0;
}
