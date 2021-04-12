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
	cout << "������� ������ ���-�������: "; cin >> size; cout << endl;

	HashTable* HT_1 = new HashTable(size);


	int choice = -1;
	while (choice)
	{
		cout << "\n------------------------------";
		cout << "\n���� ��� ������ � ���-��������" << endl;
		cout << "1 - ���������� ��������" << endl;
		cout << "2 - ����� ���-�������" << endl;
		cout << "3 - �������� ��������" << endl;
		cout << "4 - ����� ��������(-��)" << endl;
		cout << "5 - ������� ����������" << endl;
		cout << "6 - Hash" << endl;
		cout << "0 - �����" << endl;
		cout << "------------------------------\n\n";
		cout << "��� �����: "; cin >> choice;
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
			cout << "\n������ " << t2 - t1 << " ������ �������" << endl << endl;
		
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
			cout << "\n������ ������ �� ����������. �������� �����.\n";
			break;
		}
		}

	}
}