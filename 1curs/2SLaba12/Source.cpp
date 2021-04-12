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
		rc = heap::GREAT;//���� ���� �������� �� �������� � �������� ����� less ������� 1
	else
		if (A2->x > A1->x)
			rc = heap::LESS;
	return rc;
#undef A2
#undef A1 
}
//-------------------------------
/*� ������ �������� ��������� �������: �������� ������������ extractMin;
�������� i-��� �������� extractI;
��������-��� unionHeap ���� ��� � ����. */
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
		cout << "1 - ����� ���� �� �����" << endl;
		cout << "2 - �������� �������(��� 4)" << endl;
		cout << "3 - ������� ������������ �������(��� 3: �������� �������)" << endl;
		//-------------------------------------------------------------------
		cout << "4 - ������� ����������� �������" << endl;
		cout << "5 - ������� i-�� �������" << endl;
		cout << "6 - ���������� ��� ���� � ����" << endl;
		cout << "7 - ����� �������� �������(��� 5)" << endl;
		cout << "0 - �����" << endl;
		cout << "�������� �����" << endl;  cin >> choice;
		switch (choice)
		{
		case 0:  exit(0);
		case 1:  cout << "����� ����(1 ��� 2): ";cin >> k;
			if (k == 1) h1.scan(0);
			else if (k == 2) h2.scan(0);
			else cout << "�������� �����\n";
			break;
		case 2: {	AAA* a = new AAA;
			cout << "����� ����(1 ��� 2): "; cin >> k;
			if (k == 1) 
			{
				cout << "������� ����" << endl;
				cin >> k;
				a->x = k;
				h1.insert(a); 
			}
			else if (k == 2) {
				cout << "������� ����" << endl;
				cin >> k;
				a->x = k;
				h2.insert(a);
			}
			else cout << "�������� �����\n";
			
		}
				break;
		case 3:  cout << "����� ����(1 ��� 2): "; cin >> s;
			if (s == 1) h1.extractMax();
			else if (s == 2) h2.extractMax();
			else cout << "�������� �����\n";
			break;
			//----------------------------------------------------------------
		case 4:   h1.extractMin(); break;
		case 5: cout << "������� ����� ���������� ��������"; cin >> k; 
			cout << "����� ����(1 ��� 2): "; cin >> s;
			if (s == 1) h1.extractI(k);
			else if (s == 2) h2.extractI(k);
			else cout << "�������� �����\n";
			break;
		case 6:  h3.unionHeap(h1, h2, h3);
		 break;
		case 8: cout << "����� ����(1 ��� 2): "; cin >> k;
			if (k == 1) h1.iscan(0);
			else if (k == 2) h2.iscan(0);
			else cout << "�������� �����\n";
			break;
		case 7: cout << "����� ����(1 ��� 2): "; cin >> k;
			cout << "������� �������: "; cin >> s;
			if (k == 1) cout<<"Num: "<<h1.find(s)<<endl;
			else if (k == 2) cout<<"Num: "<<h2.find(s)<<endl;
			else cout << "�������� �����\n";
			break;
		default:  cout << endl << "������� �������� �������!" << endl;
		}
	} return 0;
}
