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

void print(void* b)       //������� ������������ ��� ������ 
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
	Object L1 = Create();   // �������� ������ � ������ L1
	while (true)
	{
		cout << "\t\t\t\tMeny" << endl;
		cout << "-----------------------------------------------------------------------------" << endl;
		cout << "1. ���� ������" << endl;
		cout << "2. ����� �� �������� �����������" << endl;
		cout << "3. ����� �� �����" << endl;
		cout << "4. ������� �������" << endl;
		cout << "5. �������� ������" << endl;
		cout << "6. ������� ���������� ��������� � ������" << endl;
		cout << "����� �����, ������� �� ����� ������ ������..." << endl;
		cout << "-----------------------------------------------------------------------------" << endl;
		cout << "��� �����: "; cin >> choice;
		switch (choice)
		{
		case 1: 	

			cout << "���� ����������" << endl;
				cout << "������ ����� ";
				cout << current_size + 1;
				cout << endl << "����������� " << endl;
				cin >> list_of_gos[current_size].gosname;
				cout << "�������" << endl;
				cin >> list_of_gos[current_size].stolica;
				cout << " ����������� ���������" << endl;
				cin >> list_of_gos[current_size].chislennost;
				cout << " �������" << endl;
				cin >> list_of_gos[current_size].ploscha;
				cout << " ������� ����������" << endl;
				cin >> list_of_gos[current_size].famprezident;
				L1.Insert(&list_of_gos[current_size]);
				current_size++;
			break;
		case 2: cout << "������� �������� �����������: "; 
			cin >> gosud; 
			x = current_size;
			for (; x>=0; x--)
			{ 
				if (strcmp(gosud, list_of_gos[x].gosname) == 0) break; 
				
			};
			if (x == -1)
			{	
			cout << "������ �������� ���!\n";
			break;
			}
		    e = L1.Search(&list_of_gos[x]);
			aa = (Gosudarstvo*)e->Data;
			cout << "������ �������: "<<  aa->gosname << "  " << aa->stolica << " " << aa->famprezident << "  " << aa->chislennost << "  " << aa->ploscha << endl;
			
			break;
		case 3: L1.PrintList(print);
			break;
		case 4:cout << "������� �������� �����������: ";
			cin >> gosud;
			x = current_size;
			for (; x >= 0; x--)
			{
				if (strcmp(gosud, list_of_gos[x].gosname) == 0) break;

			};
			if (x == -1)
			{
				cout << "������ �������� ���!\n";
				break;
			}
			rc = L1.Delete(&list_of_gos[x]);
			if (rc == true) cout << "������ �������" << endl;
			cout << "������:" << endl;
			L1.PrintList(print);
				break;
		case 5: L1.DeleteList();
			break;
		case 6: x = L1.CountList();
			cout << "���������� ��������� ������: " << x << endl; break;
		default: cout<<endl << "\t\t\t\tGoodbye!\n\n"; exit(0);
		}
	}
	return 0;
}
