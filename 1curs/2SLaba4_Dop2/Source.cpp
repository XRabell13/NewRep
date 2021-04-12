//�����������. ������������, �������, ����������� ���������, �������, ������� ����������. ����� ����-������� �� ��������.
// 4.10
#include <iostream>   
#include <windows.h>
# define str_len 30                               
# define size 30  
using namespace std;

void enter_new();
void out();
void find(int ploch);

typedef struct Gosudarstvo
{

	char gosname[str_len];
	char stolica[str_len];
	char famprezident[str_len];
	char chislennost[str_len];
	int forma;
	int ploscha;

} GOS;

union zet
{
	int strnumber;
	int coutnomer;
} tabl;

enum pravlenie
{
	kapital = 1, monarch, kommunizm,
};

struct Gosudarstvo list_of_gos[size];
struct Gosudarstvo bad;
int current_size = 0, choice, number, plosch;
char gosud[str_len];
FILE* f;

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	setlocale(LC_CTYPE, "Russian");
	cout << "�������:" << endl;
	cout << "1-��� ����� ����� ������" << endl;
	cout << "2-��� ������ ������(��)" << endl;
	cout << "3.����� �� �������� �����������" << endl;
	cout << "4-�����" << endl;
	cout << "������� ����� ��������: ";

	cin >> choice;
	do
	{
		switch (choice)
		{
		case 1:  enter_new();  break;
		case 2:  out();	break;
		case 3:  cout << "������� �������: "; cin >> plosch; find(plosch);	break;
		}

	} while (choice != 4);
}


void enter_new()
{
	setlocale(LC_CTYPE, "Russian");
	cout << "���� ����������" << endl;
	if (current_size < size)
	{
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
		cout << "�������� ����� ���������: \n1.����������\n2.��������\n3.���������\n";
		cin >> list_of_gos[current_size].forma;
		current_size++;
	}
	else
		cout << "������� ������������ ���-�� �����";
	cout << "��� ������?" << endl;
	cin >> choice;
}

void out()
{
	setlocale(LC_CTYPE, "Russian");
	int sw, n;
	cout << "1-����� 1 ������" << endl;
	cout << "2-����� ���� �����" << endl;
	cin >> sw;
	if (sw == 1)
	{
		cout << "����� ��������� ������ " << endl;   cin >> n;  cout << endl;
		cout << "����������� ";
		cout << list_of_gos[n - 1].gosname << endl;
		cout << "������� ";
		cout << list_of_gos[n - 1].stolica << endl;
		cout << "����������� ";
		cout << list_of_gos[n - 1].chislennost << endl;
		cout << "������� ";
		cout << list_of_gos[n - 1].ploscha << endl;
		cout << "������� ���������� ";
		cout << list_of_gos[n - 1].famprezident << endl;
		cout << "����� ��������� ";
		if (list_of_gos[n - 1].forma == kapital) cout << "����������\n";
		if (list_of_gos[n - 1].forma == monarch) cout << "��������\n";
		if (list_of_gos[n - 1].forma == kommunizm) cout << "���������\n";
	}
	if (sw == 2)
	{
		for (int i = 0; i < current_size; i++)
		{
			cout << "����������� ";
			cout << list_of_gos[i].gosname << endl;
			cout << "������� ";
			cout << list_of_gos[i].stolica << endl;
			cout << "����������� ";
			cout << list_of_gos[i].chislennost << endl;
			cout << "������� ";
			cout << list_of_gos[i].ploscha << endl;
			cout << "������� ���������� ";
			cout << list_of_gos[i].famprezident << endl;
			cout << "����� ��������� ";
			if (list_of_gos[i].forma == kapital) cout << "����������\n";
			if (list_of_gos[i].forma == monarch) cout << "��������\n";
			if (list_of_gos[i].forma == kommunizm) cout << "���������\n";
		}
	}
	cout << "��� ������?" << endl;
	cin >> choice;
}

//////////////////////////////////////////////////////////////////////////////////////////

void find(int ploch)
{
	bool flag = false;
	tabl.coutnomer = 0;
	for (; tabl.coutnomer < str_len; tabl.coutnomer++)
		if (list_of_gos[tabl.coutnomer].ploscha > ploch)
		{
			cout << "\n�����������   �������     �������       �����������         ������� ����������        ����� ���������\n";
			cout << list_of_gos[tabl.coutnomer].gosname << "\t       " << list_of_gos[tabl.coutnomer].stolica << "\t    ";
			cout << list_of_gos[tabl.coutnomer].ploscha << "\t    " << list_of_gos[tabl.coutnomer].chislennost << "\t         ";
			cout << list_of_gos[tabl.coutnomer].famprezident << endl;
			if (list_of_gos[tabl.coutnomer].forma == kapital) cout << "����������\t";
			if (list_of_gos[tabl.coutnomer].forma == monarch) cout << "��������\t";
			if (list_of_gos[tabl.coutnomer].forma == kommunizm) cout << "���������\t";
			flag = true; break;

		}
	if (!flag) cout << "������ �� �������\n";
	cout << "��� ������?" << endl;
	cin >> choice;
}


