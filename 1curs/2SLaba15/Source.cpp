#include "Hash.h"
#include <iostream>
#include <ctime>
using namespace std;
struct AAA
{
	int key;
	char* mas;
	AAA(int k, char* z)
	{
		key = k;  mas = z;
	} AAA() {}
};
//-------------------------------
int key(void* d)
{
	AAA* f = (AAA*)d;  
	return f->key;
}
//-------------------------------
void AAA_print(void* d)
{
	cout << " ���� " << ((AAA*)d)->key << " - " << ((AAA*)d)->mas << endl;
}
//-------------------------------
int main()
{
	setlocale(LC_ALL, "rus");
	//AAA a1(1, "one"), a2(2, "two"), a3(4, "three"), a4(2, "fo");
	int siz, choice, k, u;
	cout << "������� ������ ���-�������" << endl; 	cin >> siz;
	Object H = create(siz, key);
	Object E = create(siz, key);
	clock_t  t1, t2;
	for (;;)
	{
		cout << "1 - ����� ���-�������" << endl;
		cout << "2 - ���������� ��������" << endl;
		cout << "3 - �������� ��������" << endl;
		cout << "4 - ����� ��������" << endl;
		cout << "5 - ��������������" << endl;
		cout << "0 - �����" << endl;
		cout << "�������� �����" << endl;   cin >> choice;
		switch (choice)
		{
		case 0:  exit(0);
		case 1: H.scan(AAA_print);  break;
		case 2: { AAA* a = new AAA;
			char* str = new char[20];
			/*if ((H.N + 1) / 2 == siz / 2)
			{
				cout << "! ";
				newcreate(H, E);
				delete H.data;
				cout << "! ";
				siz = siz * 2;
				H = create(siz, key);
				cout << "! \n";
				for (int i = 0; i < siz; i++)
				{
					cout << " ! "<< i;
					if (E.data[i] == NULL) continue;
					a =  ((AAA*)E.data[i]);
					H.insert(a);
				}
			}
				cout << "������� ����" << endl;	cin >> k;
				a->key = k;
				cout << "������� ������" << endl; cin >> str;
				a->mas = str;
				if (H.N == H.size)
					cout << "������� ���������" << endl;
				else H.insert(a);
			} */ 
			if (H.N == siz / 2)//������� ����������
			{
				u = H.N;
			
				for (int i = 0; i < H.size; i++)
				{
					if (H.data[i] == NULL) continue;
					E.data[i] = H.data[i];
					
				}
				delete H.data;
				
				siz = siz * 2;
				H = create(siz, key);
				H.N = u;
				for(int i=0; i<E.size; i++)
				{
					if (E.data[i] == NULL) continue;
					H.data[i] = E.data[i];

				}
				delete E.data;
				E = create(siz, key);
			}
			cout << "������� ����" << endl;	cin >> k;
			a->key = k;
			cout << "������� ������" << endl; cin >> str;
			a->mas = str;
			if (H.N == H.size)
				cout << "������� ���������" << endl;
			else H.insert(a);
		} break;
		case 3: {  cout << "������� ���� ��� ��������" << endl;
			cin >> k;
			H.deleteByKey(k);
		}  break;
		case 4: {  cout << "������� ���� ��� ������" << endl;
			cin >> k;
			if (H.search(k) == NULL)
				cout << "������� �� ������" << endl;
			else
			{
				t1 = clock();
				AAA_print(H.search(k));
				t2 = clock();
				cout << "\n������ " << t2 - t1 << " ������ �������" << endl << endl;
				
			}
			}  break;
		}
		}
		return 0;
	}

