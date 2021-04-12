/*
3. N �������  �������������  �� �����.  ����� ������ �� �������, ������� ������� k-��, ������ ���� ����� ��������. 
���������� ������� �������� ����� �� �����. ������������ �������� ������.(�������... ��� ���������?)
*/
/*
#include <iostream>
#include <conio.h>
using namespace std;

struct  Node
{
	int x;
	Node* Next;
};

struct List
{
	Node* Head, * Tail; //������ ������� � ��� ��� ���������
	int size; //����� ��������� � ������
	List():Head(NULL), Tail(NULL), size(0) {}; //������������� ��������� � ���� � ������� ������������
	void Add(int x); //������� ���������� ��������� � ������
	bool del(int k, int n);    //������� �������� ��������� �� ������
	void Show(int size); //������� ����������� ��������� ������
	int Count(); //������� ������������ ����� ��������� � ������
};

int List::Count()
{
	return size; //���������� ����� ��������� ������
}

void List::Add(int x)
{
	size++; //��� ������ ���������� �������� ����������� ����� ��������� � ������
	Node* temp = new Node; //��������� ������ ��� ������ �������� ������
	temp->Next = Head; //��������� �������. ��������� ������� - ��� ������ ������ 
	temp->x = x; //���������� � ���������� ������ ������ �������� x 

	if (Head != NULL) //� ��� ������ ���� ������ �� ������
	{
		Tail->Next = temp; //������ ������ � ��������� �� ��������� ��������� ����
		Tail = temp; //��������� �������� �������=������ ��� ���������.
	}
	else Head = Tail = temp;//���� ������ ���� �� ��������� ������ �������.
}

bool List::del(int k, int n)   //������� ������� � �������� �������
{

	Node* temp = Tail;
	int rt = -1;
	while (rt < n)//Head!=Tail
	{
		rt++;
		if (Head == NULL) {
			cout << "������ ����" << endl;
			return false;
		}
		for (int i = 1; i < k; i++)//temp ��� ��������� �� ��������� �������, ������� ���������� �������� -1
			temp = temp->Next;
		Node* buf = temp->Next;
		cout << buf->x << " ";
		if (buf == Head) Head = buf->Next;
		if (buf == Tail) Tail = temp;
		temp->Next = buf->Next;
		delete buf;
	}
	return true;
}

void List::Show(int temp)
{
	Node* tempHead = Head; //��������� �� ������

	temp = size; //��������� ���������� ������ ����� ��������� � ������
	while (temp != 0) //���� �� �������� ������� ������� �� ����� ������
	{
		cout << tempHead->x << " "; //��������� ������� ������ �� ����� 
		tempHead = tempHead->Next; //���������, ��� ����� ��������� �������
		temp--; //���� ������� ������, ������ �������� �� ���� ������ 
	}
}

void main()
{
	setlocale(LC_ALL, "Russian");
	int n, k;
	List lst;
	cout << "������� ���-�� ��������� � ������" << endl;
	cin >> n;
	for (int i = 1; i < (n+1); i++)
	{
		lst.Add(i);
	}
	cout << "������:" << endl;
	lst.Show(lst.Count());  //���������� ������ �� ������.
	cout << endl;
	cout << "������� k:" << endl;
	cin >> k;
	lst.del(k, n);
	cout << endl;
	getchar();
}*/
#include <iostream>
#include <conio.h>
using namespace std;

struct  Node
{
	int x;
	Node* Next;
};

struct List
{
	Node* Head=NULL, * Tail=NULL; 
	int size=0; 

	void Add(int x); //������� ���������� ��������� � ������
	bool del(int k, int n);    //������� �������� ��������� �� ������
	void Show(int size); //������� ����������� ��������� ������
	int Count(); //������� ������������ ����� ��������� � ������
};

int List::Count()
{
	return size; //���������� ����� ��������� ������
}

void List::Add(int x)
{
	size++; 
	Node* temp = new Node; 
	temp->Next = Head;
	temp->x = x; 

	if (Head != NULL) 
	{
		Tail->Next = temp;
		Tail = temp; 
	}
	else Head = Tail = temp;
}

bool List::del(int k, int n)   //������� ������� � �������� �������
{
	int rt=0;
	Node* temp = Tail;
	while (rt<n)
	{
		rt++;
		if (Head == NULL) {
			cout << "������ ����" << endl;
			return false;
		}
		for (int i = 1; i < k; i++)
			temp = temp->Next;
		Node* buf = temp->Next;
		cout << buf->x << " ";
		if (buf == Head) Head = buf->Next;
		if (buf == Tail) Tail = temp;
		temp->Next = buf->Next;
		delete buf;
	}
	return true;
}

void List::Show(int temp)
{
	Node* tempHead = Head; //��������� �� ������
	temp = size; 
	while (temp != 0) 
	{
		cout << tempHead->x << " "; 
		tempHead = tempHead->Next; 
		temp--; //���� ������� ������, ������ �������� �� ���� ������ 
	}
}

void main()
{
	setlocale(LC_ALL, "Russian");
	int n, k;
	List lst;
	cout << "������� ���-�� ��������� � ������" << endl;
	cin >> n;
	for (int i = 1; i < (n + 1); i++)
	{
		lst.Add(i);
	}
	cout << "������:" << endl;
	lst.Show(lst.Count());  //���������� ������ �� ������.
	cout << endl;
	cout << "������� k:" << endl;
	cin >> k;
	lst.del(k, n);
	cout << endl;
}