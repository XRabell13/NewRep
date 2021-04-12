/*�������� � �������  ������� ���������� � ����������� ������ ������ � �������  �� �������,
�������� ������������������ ������ � ������� � ������������
� ��������� �� �������, �������������� � ������������ ������ � 11,
������� �� ���, ���-�� ������� ��������������� ������� ������ ������������ ������.*/

/*�������� �������� ��������, ����������� ��� ��������� ��������� � ����� ������.
����� � ��� ���������, ��� ���������� ������� ������ ���� �������������� ����� ���� ��� ��������� ������ �������.
����� ������ ����������� � ��������� ������ �� ������, ����� � ������ ���������� � ���������� � ������� �� �����������
��������������� ��������� ��������� �� ��� ���, ���� � �������� ��������� �� ����� �������� ������ ������.
������ ����� ������ ���� �������� ����������� �����, ��� ��������� ���������� ������ ����������.
���������� ��� �������� ������������, ������� ����������� �������� �� ��������� ������.
��� � ���� ����������� ���������, �� ������ �������� � ������� ��������. �� ������������ ��� ������������� ��������� ������.

���������� (������) ����� ����������� �� ������� �������-�����-������ (�-�-�).
���������� �������� ����;
������ ����� ��������� � ���������� �������;
������ ������ ��������� � ���������� �������.
������ ����������� ������ ������ ���. 68: A B C D E F.

���������� (��������) ����� ����������� �� ������� ������-������-������� (�-�-�).
������ ����� ��������� � ���������� �������;
������ ������ ��������� � ���������� �������;
���������� �������� ����.
������ ����������� ������ ������ ���. 68 C D B F E A .

��������� (��������) ����� ����������� �� ������� ������������-������ (�-�-�).*/
#include "Tree.h"
#include <fstream>
#include <tchar.h>
using namespace std;
struct NodeTree
{
	int  key;
};
//-------------------------------
btree::CMP cmpfnc(void* x, void* y)    // ���������
{
	btree::CMP rc = btree::EQUAL;
	if (((NodeTree*)x)->key < ((NodeTree*)y)->key)
		rc = btree::LESS;
	else
		if (((NodeTree*)x)->key > ((NodeTree*)y)->key)
			rc = btree::GREAT;
	return rc;
}
//-------------------------------

void printNode(void* x)               // ����� ��� ������
{
	cout << ((NodeTree*)x)->key << ends; //ends ����
}
//-------------------------------
bool buildTree(char* FileName, btree::Object& tree) //���������� ������ �� �����
{
	bool rc = true;
	FILE* inFile;
	fopen_s(&inFile, FileName, "r");
	if (inFile == NULL)
	{
		cout << "������ �������� �������� �����" << endl;
		rc = false; return rc;
	}
	while (!feof(inFile)) // ���������� ������ 
	{
		int num;
		fscanf_s(inFile, "%d", &num, 1);
		NodeTree* a = new NodeTree();
		a->key = num;
		tree.insert(a);
	}
	fclose(inFile);
	return rc;
}
FILE* outFile;
//-------------------------------
void saveToFile(void* x)              // ������ ������ �������� � ����
{
	NodeTree* a = (NodeTree*)x;
	int q = a->key;
	cout <<q<<"\n";
	fprintf(outFile, "%d\n", q);
}
void inConsol(void* x)              // ����� ������ �������� � ����
{
	NodeTree* a = (NodeTree*)x;
	int q = a->key;
	cout << q << "\n";
}
/*int chet(void* x)              
{
	NodeTree* a = (NodeTree*)x;
	int q = a->key;
	if (a)
	{
		chet(t->right);
		if ((int)(t->data) % 2 == 0)
			std::cout << "!!! " << t->data << " !!!!";
		chet(t->left);
	}
	return q;
}*/
//-------------------------------
void saveTree(btree::Object& tree, char *FileName)    //���������� ������ � ���� 
{
	fopen_s(&outFile, FileName, "w");
	if (outFile == NULL)
	{
		cout << "������ �������� ��������� �����" << endl;
		return;
	}
	tree.Root->scanDown(saveToFile);
	fclose(outFile);
}
void inConsolAll(btree::Object& tree)    //���������� ������ � ���� 
{
	tree.Root->scanDownKLP(inConsol);
}
void inConsolAll1(btree::Object& tree)    //���������� ������ � ���� 
{
	tree.Root->scanDownLKP(inConsol);
}
/*
int maxDepth(Node* root) {
	if (!root) {
		return 0;
	}
	return  max(maxDepth(root->left), maxDepth(root->right));
}

int minDepth(Node* root) {
	if (!root) {
		return 0;
	}
	return  min(minDepth(root->left), minDepth(root->right));
}

void isBalanced(Node* root) {
	if (maxDepth(root) - minDepth(root) <= 1)
		f1 << "YES";
	else
		f1 << "NO";
}
*/
//-------------------------------
int _tmain(int argc, _TCHAR* argv[])
{
	setlocale(LC_CTYPE, "Russian");
	btree::Object demoTree = btree::create(cmpfnc);
	
	int k, choice, j=0;
	char textfile[10] = "G.txt";
	NodeTree a1 = { 1 }, a2 = { 2 }, a3 = { 3 }, a4 = { 4 }, a5 = { 5 }, a6 = { 6 };
	bool rc = demoTree.insert(&a4);   //           4(Root)  
	rc = demoTree.insert(&a1);        //   1             
	rc = demoTree.insert(&a6);        //                   6
	rc = demoTree.insert(&a2);        //      2     
	rc = demoTree.insert(&a3);        //         3
	rc = demoTree.insert(&a5);        //                 5	
	for (;;)
	{
		NodeTree* a = new NodeTree;
		cout << "1 - ����� ������ �� �����" << endl;
		cout << "2 - ���������� ��������" << endl;
		cout << "3 - �������� ��������" << endl;
		cout << "4 - ��������� � ����" << endl;
		cout << "5 - ��������� �� �����" << endl;
		cout << "6 - �������� ������" << endl;
		cout << "7 - ���������� ������ ������" << endl;
		cout << "8 - ���������� �����" << endl;
		cout << "9 - ��������� �����" << endl;
		cout << "10 - �������� �������" << endl;
		cout << "0 - �����" << endl;
		cout << "�������� �����" << endl; cin >> choice;
		switch (choice)
		{
		case 0:   	exit(0);
		case 1:  cout<<endl;	
			if (demoTree.Root)
			demoTree.Root->scanByLevel(printNode);
			else
			cout << "������ ������" << endl;
			break;
		case 2: 	cout << "������� ����" << endl;  cin >> k;
			a->key = k;
			demoTree.insert(a);
			break;
		case 3:  	cout << "������� ����" << endl;  cin >> k;
			a->key = k;
			demoTree.deleteByData(a);
			break;
		case 4:   	saveTree(demoTree, textfile);
			break;
		case 5:  	buildTree(textfile, demoTree);
			break;
		case 6:	while (demoTree.Root)
			demoTree.deleteByNode(demoTree.Root);
			break;
		case 7: cout << "���������� ������ ������: " << demoTree.chet(demoTree.Root) << '\n'; break;
		case 8: cout << endl;  inConsolAll(demoTree); cout << endl; break;
	   	case 9:  cout << endl;  inConsolAll1(demoTree); cout << endl; break;
		case 10: if (demoTree.isBalanced(demoTree.Root)) cout << "������ ��������������\n";
				 else cout << "������ �� ��������������\n"; break;
		}
	}
	return 0;
}
