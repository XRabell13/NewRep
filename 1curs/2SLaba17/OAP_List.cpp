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

void print(void* b)       //������� ������������ ��� ������ 
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
		cout << "�������:" << endl;
		cout << "1-��� �������� ������" << endl;
		cout << "2-��� ����� ����� ������" << endl;
		cout << "3-��� ������ ������(��)" << endl;
		cout << "4.����� �� �������" << endl;
		cout << "5-�����" << endl;
		cout << "������� ����� ��������: ";
		cin >> choice;

		switch (choice)
		{
		case 1:  A.Delete();	break;//�������
		case 2:  enter_new();  break;// ������ ����� ������
		case 3:  out();	break; //�������
		case 4:  cout << "������� �������: "; cin >> fio; find(fio);	break;//�����
		}

	} while (choice != 5);

/*
	Person a1 = { "������", 20 };
	Person a2 = { "�������", 25 };
	Person a3 = { "��������", 47 };
	bool rc;
	Object L1 = Create();   // �������� ������ � ������ L1
	L1.Insert(&a1);
	L1.Insert(&a2);
	L1.Insert(&a3);
	L1.PrintList(print);
	Element* e = L1.Search(&a3);
	Person* aa = (Person*)e->Data;
	cout << "������ �������= " << aa->name << endl;
	rc = L1.Delete(&a2);
	if (rc == true) cout << "������ �������" << endl;
	cout << "������:" << endl;
	L1.PrintList(print);*/
	return 0;
}
