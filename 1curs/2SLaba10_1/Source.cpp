#include <iostream>
using namespace std;
struct Tree          //������
{
	int key;         //����
	char text[5];    //����� - �� ����� 4 ����
	Tree* Left, * Right;
};

Tree* makeTree(Tree* Root);       //�������� ������
Tree* list(int i, char* s);       //�������� ������ ��������
Tree* insertElem(Tree* Root, int key, char* s);  //���������� ������ ��������
Tree* search(Tree* n, int key);   //����� �������� �� ����� 
Tree* delet(Tree* Root, int key); //�������� �������� �� �����
void view(Tree* t, int level);    //����� ������ 
int count(Tree* t, char letter);  //������� ���������� ����
void delAll(Tree* t);             //������� ������
int chet(Tree* t);                //����� ���������� ������ ������
int koluzl(Tree* t);              //����� ���������� ����� ������
int kolleft(Tree* t);             //����� ���������� ����� ������ ������
int kolprav(Tree* t);             //����� ���������� ������ ������ ������
//int sum(Tree* t);                 //����� ����� �������� ���� ������ ������
int c = 0, j=0;         //���������� ���� � ���������� ������ ������
Tree* Root = NULL; 	//��������� �����

void main()
{
	setlocale(0, "Russian");
	int key, choice, n;
	Tree* rc; char s[5], letter;
	for (;;)
	{
		cout << "1 -	�������� ������\n";
		cout << "2 -	���������� ��������\n";
		cout << "3 -	����� �� �����\n";
		cout << "4 -	�������� ��������\n";
		cout << "5 -	����� ������\n";
		cout << "6 -	������� ���������� ����\n";
		cout << "7 -	������� ������\n";
		cout << "8 -     ������� ���������� ������ ������\n"; // 12 ������� ���
		cout << "9 -     ������� ���������� ����� ������\n"; // 7 �������
		cout << "10 -    ������� ���������� ����� ������\n"; // 5 �������
 		cout << "11 -    ������� ���������� ������ ������\n"; // 2 �������
		cout << "12 -	�����\n";
		cout << "��� �����?\n";
		cin >> choice;
		cout << "\n";
		switch (choice)
		{
		case 1:  Root = makeTree(Root);	break;
		case 2:  cout << "\n������� ����: "; cin >> key;
			cout << "������� �����: "; cin >> s;
			insertElem(Root, key, s); break;
		case 3:  cout << "\n������� ����: ";  cin >> key;
			rc = search(Root, key);
			cout << "��������� �����= ";
			puts(rc->text); break;
		case 4:  cout << "\n������� ��������� ����: "; cin >> key;
			Root = delet(Root, key);  break;
		case 5:  if (Root->key >= 0)
		{
			cout << "������ ��������� �� 90 ����. �����" << endl;
			view(Root, 0);
		}
				 else cout << "������ ������\n"; break;
		case 6:  cout << "\n������� �����: "; cin >> letter;
			n = count(Root, letter);
			cout << "���������� ����, ������������ � ����� " << letter;
			cout << " ����� " << n << endl; break;
		case 7:  delAll(Root); break;
		case 8:  j = 0; cout << "���������� ������ ������: " << chet(Root) << '\n'; break;
		case 9: c = 0; cout << "���������� ����� ������: "<< koluzl(Root)<<'\n'; break;
		case 10: j = 0; cout << "���������� ����� ������: " << kolleft(Root) <<'\n'; break;
		case 11: j = 0; cout << "���������� ������ ������: " << kolprav(Root) <<'\n'; break;
		case 12:  exit(0);
		default: break;
		}
	}
}

Tree* makeTree(Tree* Root)    //�������� ������
{
	int key; char s[5];
	cout << "����� ����� - ������������� �����\n\n";
	if (Root == NULL)	// ���� ������ �� �������
	{
		cout << "������� ���� �����: "; cin >> key;
		cout << "������� ����� �����: "; cin >> s;
		Root = list(key, s);	// ��������� ��������� �� ������
	}
	while (1)                //���������� ���������
	{
		cout << "\n������� ����: ";  cin >> key;
		if (key < 0) break;       //������� ������ (���� < 0)   
		cout << "������� �����: ";  cin >> s;
		insertElem(Root, key, s);
	}
	return Root;
}

Tree* list(int i, char* s)     //�������� ������ ��������
{
	Tree* t = new Tree[sizeof(Tree)];
	t->key = i;
	for (i = 0; i < 5; i++)
		* ((t->text) + i) = *(s + i);
	t->Left = t->Right = NULL;
	return t;
}

Tree* insertElem(Tree* t, int key, char* s)  //���������� ������ ��������
{
	Tree* Prev=NULL;	     // Prev - ������� ����� �������
	int find = 0;        // ������� ������
	while (t && !find)
	{
		Prev = t;
		if (key == t->key)
			find = 1;	   //����� ������ ���� ���������
		else
			if (key < t->key) t = t->Left;
			else t = t->Right;
	}
	if (!find)              //������� ����� � ������� Prev
	{
		t = list(key, s);           //��������� ����� ���� 
		if (key < Prev->key)  // � �������������� ���� 
			Prev->Left = t;    //������� �� ����� �����,
		else
			Prev->Right = t;   // ���� �� ������ 
	}
	return t;
}

Tree* delet(Tree* Root, int key)  //�������� �������� �� �����
{	// Del, Prev_Del - ��������� ������� � ��� ���������� ;
	// R, Prev_R - �������, �� ������� ���������� ���������, � ��� ��������; 
	Tree* Del, * Prev_Del, * R, * Prev_R;
	Del = Root;
	Prev_Del = NULL;
	while (Del != NULL && Del->key != key)//����� �������� � ��� �������� 
	{
		Prev_Del = Del;
		if (Del->key > key)
			Del = Del->Left;
		else
			Del = Del->Right;
	}
	if (Del == NULL)              // ������� �� ������
	{
		puts("\n��� ������ �����");
		return Root;
	}
	if (Del->Right == NULL) // ����� �������� R ��� ������
		R = Del->Left;
	else
		if (Del->Left == NULL)
			R = Del->Right;
		else
		{
			Prev_R = Del; //����� ������ ������� �������� � ����� ���������
			R = Del->Left;
			while (R->Right != NULL)
			{
				Prev_R = R;
				R = R->Right;
			}
			if (Prev_R == Del) // ������ ������� ��� ������ R � ��� �������� Prev_R 
				R->Right = Del->Right;
			else
			{
				R->Right = Del->Right;
				Prev_R->Right = R->Left;
				R->Left = Prev_R;
			}
		}
	if (Del == Root) Root = R;	//�������� ����� � ������ ��� �� R
	else
		// ��������� R �������������� � �������� ���������� ����
		if (Del->key < Prev_Del->key)
			Prev_Del->Left = R; // �� ����� ����� 
		else
			Prev_Del->Right = R;	// �� ������ �����
	int tmp = Del->key;
	cout << "\n������ ������� � ������ " << tmp << endl;
	delete Del;
	return Root;
}

Tree* search(Tree* n, int key)  //����� �������� �� ����� 
{
	Tree* rc = n;
	if (rc != NULL)
	{
		if (key < (key, n->key))
			rc = search(n->Left, key);
		else
			if (key > (key, n->key))
				rc = search(n->Right, key);
	}
	else
		cout << "��� ������ ��������\n";
	return rc;
}

int count(Tree* t, char letter) //������� ���������� ����
{
	if (t)
	{
		count(t->Right, letter);
		if (*(t->text) == letter)
			c++;
		count(t->Left, letter);
	}
	return c;
}

void view(Tree* t, int level) //����� ������ 
{
	if (t)
	{
		view(t->Right, level + 1);	//����� ������� ���������
		for (int i = 0; i < level; i++)
			cout << "   ";
		int tm = t->key;
		cout << tm << ' ';
		puts(t->text);
		view(t->Left, level + 1);	//����� ������ ���������
	}
}

void delAll(Tree* t) //������� ������
{
	if (t != NULL)
	{
		delAll(t->Left);
		delAll(t->Right);
		delete t;
	}
}

int chet(Tree* t)//������� ������ ���������
{
	if (t)
	{
		chet(t->Right);
		if ((t->key)%2==0)
			j++;
		chet(t->Left);
	}
	return j;
}

int koluzl(Tree* t)              //����� ���������� ����� ������
{
	if (t)
	{
		koluzl(t->Right);
		if ((t->Right)!=NULL || (t->Left)!=NULL)
			c++;
		koluzl(t->Left);
	}
	return c-1;//����� �� ������� ������ �� ����
}

int kolleft(Tree* t)  //����� ���������� ����� ������ ������
{
	if (t)
	{
		kolleft(t->Left);
		if (t->Left != NULL)
			j++;
	//	kolleft(t->Right);
	}
	return j-1;
}

int kolprav(Tree* t)  //����� ���������� ������ ������ ������
{

	if (t)
	{
		kolprav(t->Right);
		if (t->Right != NULL)
			j++;
		//kolprav(t->Left);
	}
	return j-1;
}

