#include <iostream>
#include <fstream>
#include <windows.h>
using namespace std;
struct list
{
	float number;
	list* next;
};
void insert(list*&, float); //������� ���������� ��������, ���������� ����� ����-�� � ������, ������� ����������� 
float del(list*&, float);   //������� ��������, ���������� ����� ������ � ������, ������� ��������� 
int IsEmpty(list*);         //�������, ������� ���������, ���� �� ������
void printList(list*);      //������� ������
void menu(void);     //�������, ������������ ����
void sum7(list*);//������� �������
void toFile(list*& p);//������� ������ � ����
void fromFile(list*& p);//������� ������ �� �����
void find(float valu, list*& p);//������� ������ �������� � ������

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	setlocale(LC_CTYPE, "Russian");
	list* first = NULL;
	int choice;
	float value;
	menu();    // ������� ���� 
	cout << " ? ";
	cin >> choice;
	while (choice != 8)
	{
		switch (choice)
		{
		case 1:  	cout << "������� ����� "; // �������� ����� � ������
			cin >> value;
			insert(first, value);
			break;
		case 2:   if (!IsEmpty(first)) // ������� ����� �� ������
		{
			cout << "������� ��������� ����� ";
			cin >> value;
			if (del(first, value))
			{
				cout << "������� ����� " << value << endl;
				printList(first);
			}
			else
				cout << "����� �� �������" << endl;
		}
				  else
			cout << "������ ����" << endl;
			break;
		case 3:   sum7(first);	// ���������� �����	
			break;
		case 4: 	printList(first); break;
		case 5: cout << "������� �������, ������� ������ �����: "; 
			cin >> value; 
			find(value, first); break;
		case 6: toFile(first); break;
		case 7: fromFile(first); break;
		default:  cout << "������������ �����" << endl;
			menu();
			break;
		}
		cout << "?  ";
		cin >> choice;
	}
	cout << "�����" << endl;
	return 0;
}

void menu(void)  //����� ���� 
{
	cout << "�������� �����:" << endl;
	cout << " 1 - ���� ��������" << endl;
	cout << " 2 - �������� ��������" << endl;
	cout << " 3 - ���������� �������� �������� ������������� ���������" << endl;
	cout << " 4 - ����� ������ � ���������� ����" << endl;
	cout << " 5 - ����� ��������" << endl;
	cout << " 6 - ������ ������ ��������� � ����" << endl;
	cout << " 7 - ���������� ������ ��������� �� �����" << endl;
	cout << " 8 - �����" << endl;
}
//���������� ��������, �������� ��������, ����� ��������, ����� ������ � ���������� ����, ������ ������ � ����, ���������� ������ �� �����. 

void insert(list*& p, float value) //���������� ����� value � ������ 
{
	list* newP = new list;// ��������� ������������ ����� ������ � ��������� �� ���� ������� ���������� ������
	if (newP != NULL)     //���� �� �����?  
	{
		newP->number = value;
		newP->next = p;
		p = newP;
	}
	else
		cout << "�������� ���������� �� ���������" << endl;
}
float del(list*& p, float value)  // �������� ����� 
{
	list* previous, * current, * temp;
	if (value == p->number)
	{
		temp = p;
		p = p->next;    // ����������� ���� 
		delete temp;      //���������� ������������� ���� 
		return value;
	}
	else
	{
		previous = p;
		current = p->next;
		while (current != NULL && current->number != value)
		{
			previous = current;
			current = current->next; // ������� � ���������� 
		}
		if (current != NULL)
		{
			temp = current;
			previous->next = current->next;
			free(temp);
			return value;
		}
	}
	return 0;
}

int IsEmpty(list* p) //������  ������? (1-��, 0-���) 
{
	return p == NULL;
}

void printList(list* p)  //����� ������ 
{
	if (p == NULL)
		cout << "������ ����" << endl;
	else
	{
		cout << "������:" << endl;
		while (p != NULL)
		{
			cout << "-->" << p->number;
			p = p->next;
		}
		cout << "-->NULL" << endl;
	}
}

void sum7(list* p)  // ������� �������� �������� ������������� �����
{
	float sm = 0, nom=0;
	if (p == NULL)
		cout << "������ ����" << endl;
	else
	{
		while (p != NULL)
		{
			if (p->number > 0)
			{
				sm = sm + (p->number);
				nom++;
			}
			p = p->next;
		}
		sm = sm / nom;
		cout << "������� ��������: " << sm << endl;
	}
}

void toFile(list*& p)
{
	list* temp = p;
	list buf;
	ofstream frm("mList.txt");
	if (frm.fail())
	{
		cout << "\n ������ �������� �����";
		exit(1);
	}
	while (temp)
	{
		buf = *temp;
		frm.write((char*)& buf, sizeof(list));
		temp = temp->next;
	}
	frm.close();
	cout << "������ ������� � ���� mList.txt\n";
}

void fromFile(list*& p)          //���������� �� �����
{
	list buf, * first = nullptr;
	ifstream frm("mList.txt");
	if (frm.fail())
	{
		cout << "\n ������ �������� �����";
		exit(1);
	}
	frm.read((char*)& buf, sizeof(list));
	while (!frm.eof())
	{
		insert(first, buf.number);
		cout << "-->" << buf.number;
		frm.read((char*)& buf, sizeof(list));
	}
	cout << "-->NULL" << endl;
	frm.close();
	p = first;
	cout << "\n������ ������ �� ����� mList.txt\n";
}

void find(float valu, list*& p)    // ����� ����� � ������
{
	
	list* t = p;
	int k = 0;
	for(int i=0; i<10; i++)
	{
		if (valu == (t->number))
		{
			k++;
			break;
		}
		t=t->next;
		if (t == NULL) break; 
	}
	if (!k)
		cout << "������� �� ������!" << endl;
	else
		cout << "������� " << t->number <<" ������������ � ������"<< endl;
}
