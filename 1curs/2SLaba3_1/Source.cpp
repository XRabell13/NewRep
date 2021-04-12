//�����������. ������������, �������, ����������� ���������, �������, ������� ����������. ����� ����-������� �� ��������.

#include <iostream>   
#include <windows.h>
# define str_len 30                               
# define size 30  
using namespace std;

void enter_new();
void del();
void out();
void input(int num);
void output();
void find(char gosud[]);

typedef struct Gosudarstvo 
{

	char gosname[str_len];
	char stolica[str_len];
	char famprezident[str_len];
	char chislennost[str_len];
	char ploscha[str_len];
	
} GOS;
struct Gosudarstvo list_of_gos[size];
struct Gosudarstvo bad;
int current_size = 0, choice, number;
char gosud[str_len];
FILE* f; errno_t err;

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	setlocale(LC_CTYPE, "Russian");
	cout << "�������:" << endl;
	cout << "1-��� �������� ������" << endl;
	cout << "2-��� ����� ����� ������" << endl;
	cout << "3-��� ������ ������(��)" << endl;
	cout << "4.���� ������ � ���������� � ������ � ����" << endl;
	cout << "5.����� ������ �� �����" << endl;
	cout << "6.����� �� �������� �����������" << endl;
	cout << "7-�����" << endl;
	cout << "������� ����� ��������: ";

	cin >> choice;
	do
	{
		switch (choice)
		{
		case 1:  del();	break;
		case 2:  enter_new();  break;
		case 3:  out();	break;
		case 4:  cout << "������� ���������� ����������: "; cin >> number; input(number); break;
		case 5:  output();  break;
		case 6:  cout << "������� �����������: "; cin >> gosud; find(gosud);	break;
		}
	
	} while (choice != 7);
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
		current_size++;
	}
	else
		cout << "������� ������������ ���-�� �����";
	cout << "��� ������?" << endl;
	cin >> choice;
}
void del()
{
	setlocale(LC_CTYPE, "Russian");
	int d;
	cout << "\n����� ������, ������� ���� ������� (��� �������� ���� ����� ������ 99)" << endl;  cin >> d;
	if (d != 99)
	{
		for (int de1 = (d - 1); de1 < current_size; de1++)
			list_of_gos[de1] = list_of_gos[de1 + 1];
		current_size = current_size - 1;
	}
	if (d == 99)
		for (int i = 0; i < size; i++)
			list_of_gos[i] = bad;
	cout << "��� ������?" << endl;
	cin >> choice;
}
/*void change()
{
	int n, per;
	cout << "\n������� ����� ������" << endl; 	cin >> n;
	do
	{
		cout << "�������: " << endl;
		cout << "1-��� ��������� �������" << endl;
		cout << "2-��� ��������� ���� ��������" << endl;
		cout << "3-��� ��������� ����������" << endl;
		cout << "4-�����\n";
		cin >> per;
		switch (per)
		{
		case 1: cout << "����� �������";
			cin >> list_of_gos[n - 1].gosname;   break;
		case 2: cout << "����� ��� ��������";
			cin >> list_of_gos[n - 1].chislennost; break;
		case 3: cout << "����� ��������� ";
			cin >> list_of_gos[n - 1].department; break;
		}
	} while (per != 4);
	cout << "��� ������?" << endl;
	cin >> choice;
}*/
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
		cout << list_of_gos[n - 1].stolica<< endl;
		cout << "����������� ";
		cout << list_of_gos[n - 1].chislennost << endl;
		cout << "������� ";
		cout << list_of_gos[n - 1].ploscha << endl;
		cout << "������� ���������� ";
		cout << list_of_gos[n - 1].famprezident << endl;
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
		}
	}
	cout << "��� ������?" << endl;
	cin >> choice;
}

//////////////////////////////////////////////////////////////////////////////////////////

void input(int num)// � num ����� �������� ��������
{
	GOS buf = { " ", " "," ", " ", " " };
	if (!fopen_s(&f, "Gos.txt", "a"))  //��������� ���� ��� ������ � ������ � �����
	{
		for (int i = 0; i < num; i++)
		{
			cout << "�����������: "; 	cin >> buf.gosname;
			cout << "�������: "; 	cin >> buf.stolica;
			cout << "�������: "; 	cin >> buf.ploscha;
			cout << "�����������: "; 	cin >> buf.chislennost;
			cout << "������� ����������: "; 	cin >> buf.famprezident;
			fwrite(&buf, sizeof(buf), 1, f);
			fputs("\n", f);
		}
		fclose(f);
	}
	else {
		cout << "������ �������� �����";
		return;
	}
	cout << "��� ������?" << endl;
	cin >> choice;
}

void output()
{
	GOS buf;

	if (!fopen_s(&f, "Gos.txt", "r"))
	{
		cout << "\n�����������   �������     �������       �����������         ������� ����������\n";
        fread(&buf, sizeof(buf), 1, f);
		while (!feof(f))
		{
			cout << buf.gosname << "\t    " << "   " << buf.stolica << "\t    " << buf.ploscha << "\t    " << buf.chislennost << "\t    " << buf.famprezident << endl;
			fread(&buf, sizeof(buf), 1, f);

		}
		fclose(f);
	}
	else
	{
		cout << "������ �������� �����";
		return;
	}
	
	cout << "��� ������?" << endl;
	cin >> choice;
}

void find(char gosud[16])
{
	bool flag = false;  GOS buf = { " ", " "," ", " ", " " };
	if (!fopen_s(&f, "Gos.txt", "rt"))
	{
		while (!feof(f))
		{
			fread(&buf, sizeof(buf), 1, f);
			if (strcmp(gosud, buf.gosname) == 0)   //��������� �����
			{
				cout << "\n�����������   �������     �������       �����������         ������� ����������\n";
				cout << buf.gosname << "\t       " << buf.stolica << "\t    " << buf.ploscha << "\t    " << buf.chislennost << "\t         " << buf.famprezident << endl;
				flag = true; break;
			}
		}
		fclose(f);
		if (!flag) cout << "������ �� �������\n";
	}
	else
	{
		cout << "������ �������� �����";
		return;
	}
	cout << "��� ������?" << endl;
	cin >> choice;
}

