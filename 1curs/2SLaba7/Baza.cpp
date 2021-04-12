//������� ���� �� ������� �������� � ���������� ��� �������� �� �������� ��������, ������ ����� �������
/*������� ���������� ��������� ������, ��� ������� �������� ��� ���������� ��������� ��������������
� ������� ���������� ������ ���������� (head) � ����� (tail) �������
� ������������ � �������� FIFO ("first-in, first-out" "������ ������, ������ �������"),
�. �. ��������� ������������ � ������, � ���������� � � ������� �����.*/
#include <iostream>
using namespace std;

struct Queue
{
	char symbol;
	Queue* next;
};

void intoFIFO(Queue* ph[], int v); //���������� �������� � ����� �������
void scan(Queue* ph[]);           //����� ��������   
char fromFIFO(Queue* ph[]);      //���������� ��������   

void main()
{
	Queue A3 = { 'a', NULL }, A2 = { 'b', &A3 }, A1 = { 'c', &A2 };
	Queue* ph[2];
	ph[0] = &A1;//����� ������� �������� ���������� � ������
	ph[1] = &A3;//����� ���������� �������� ���������� � ������
	scan(ph);//
	intoFIFO(ph, 'd');
	intoFIFO(ph, 't');
	scan(ph);
	char vv = fromFIFO(ph);
	scan(ph);
}

void intoFIFO(Queue* ph[], int v) //���������� �������� � ����� �������
{
	Queue* p = new Queue;
	p->symbol = v;
	p->next = NULL;
	if (ph[0] == NULL)
		ph[0] = ph[1] = p;   //��������� � ������ �������
	else
	{
		ph[1]->next = p;
		ph[1] = p;
	}
}

void scan(Queue* ph[])           //����� ��������              
{
	for (Queue* p = ph[0]; p != NULL; p = p->next)
		cout << p->symbol << ' ';
	cout << endl;
}

//�������� ������, ����� ������������������ � �������� ������� � ���������� �������� �������
char fromFIFO(Queue* ph[])      //���������� �������� 
{
	Queue* q;
	if (ph[0] == NULL) return -1;     // ������� �����
	q = ph[0];                        // ���������� ������� ��������
	ph[0] = q->next;
	if (ph[0] == NULL) ph[1] = NULL;
	char v = q->symbol;
	return v;
}