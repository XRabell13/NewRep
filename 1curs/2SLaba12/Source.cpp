#include "Heap.h"
#include <iostream>
#include <tchar.h>
using namespace std;
heap::CMP cmpAAA(void* a1, void* a2)  
{
#define A1 ((AAA*)a1)
#define A2 ((AAA*)a2)
	heap::CMP
		rc = heap::EQUAL;
	if (A1->x > A2->x)
		rc = heap::GREAT;//чтбы куча строілась от меньшего к большему нужно less сделать 1
	else
		if (A2->x > A1->x)
			rc = heap::LESS;
	return rc;
#undef A2
#undef A1 
}
//-------------------------------
/*В проект добавить следующие функции: удаление минимального extractMin;
удаление i-ого элемента extractI;
объедине-ние unionHeap двух куч в одну. */
int _tmain(int argc, _TCHAR* argv[])
{
	setlocale(LC_ALL, "rus");
	int k, s, choice;
	heap::Heap h1 = heap::create(30, cmpAAA);
	heap::Heap h2 = heap::create(30, cmpAAA);
	heap::Heap h3 = heap::create(80, cmpAAA);

/*	AAA* b = new AAA;
	b->x = 5;
	h1.insert(b);
	b->x = 4;
	h1.insert(b);
	b->x = 6;
	h1.insert(b);
	b->x = 3;
	h1.insert(b);*/

	for (;;)
	{
		cout << "1 - вывод кучи на экран" << endl;
		cout << "2 - добавить элемент(доп 4)" << endl;
		cout << "3 - удалить максимальный элемент(доп 3: удаление вершины)" << endl;
		//-------------------------------------------------------------------
		cout << "4 - удалить минимальный элемент" << endl;
		cout << "5 - удалить i-ый элемент" << endl;
		cout << "6 - обьединить две кучи в одну" << endl;
		cout << "7 - найти заданный элемент(доп 5)" << endl;
		cout << "0 - выход" << endl;
		cout << "сделайте выбор" << endl;  cin >> choice;
		switch (choice)
		{
		case 0:  exit(0);
		case 1:  cout << "Номер кучи(1 или 2): ";cin >> k;
			if (k == 1) h1.scan(0);
			else if (k == 2) h2.scan(0);
			else cout << "Неверный номер\n";
			break;
		case 2: {	AAA* a = new AAA;
			cout << "Номер кучи(1 или 2): "; cin >> k;
			if (k == 1) 
			{
				cout << "введите ключ" << endl;
				cin >> k;
				a->x = k;
				h1.insert(a); 
			}
			else if (k == 2) {
				cout << "введите ключ" << endl;
				cin >> k;
				a->x = k;
				h2.insert(a);
			}
			else cout << "Неверный номер\n";
			
		}
				break;
		case 3:  cout << "Номер кучи(1 или 2): "; cin >> s;
			if (s == 1) h1.extractMax();
			else if (s == 2) h2.extractMax();
			else cout << "Неверный номер\n";
			break;
			//----------------------------------------------------------------
		case 4:   h1.extractMin(); break;
		case 5: cout << "Введите номер удаляемого элемента"; cin >> k; 
			cout << "Номер кучи(1 или 2): "; cin >> s;
			if (s == 1) h1.extractI(k);
			else if (s == 2) h2.extractI(k);
			else cout << "Неверный номер\n";
			break;
		case 6:  h3.unionHeap(h1, h2, h3);
		 break;
		case 8: cout << "Номер кучи(1 или 2): "; cin >> k;
			if (k == 1) h1.iscan(0);
			else if (k == 2) h2.iscan(0);
			else cout << "Неверный номер\n";
			break;
		case 7: cout << "Номер кучи(1 или 2): "; cin >> k;
			cout << "Искомый элемент: "; cin >> s;
			if (k == 1) cout<<"Num: "<<h1.find(s)<<endl;
			else if (k == 2) cout<<"Num: "<<h2.find(s)<<endl;
			else cout << "Неверный номер\n";
			break;
		default:  cout << endl << "Введена неверная команда!" << endl;
		}
	} return 0;
}
