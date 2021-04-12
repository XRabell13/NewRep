// 5.1 
//�������������. ������� �������������, �������� ��������, ���� ��������. ����� �� �������.
#include <iostream>   
#include <windows.h>
#define str_len 30                               
#define size 30  
using namespace std;
void enter_new();
void out();
void find(char fio[16]);

union zet
{
	int coutnomer;
} tabl;


typedef struct Zapis
{
	char fio[str_len];
	char data[str_len];
	char examen[str_len];
} ZAP;


Zapis list_of_zap[size];
Zapis bad;
int choice, number, strnum = -1;
char fio[str_len];
bool flag = false;
FILE* f;


int main()
{
	strnum = 0;
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	setlocale(LC_CTYPE, "Russian");
	cout << "�������:" << endl;
	cout << "1-��� ����� ����� ������" << endl;
	cout << "2-��� ������ ������(��)" << endl;
	cout << "3.����� �� �������" << endl;
	cout << "4-�����" << endl;
	cout << "������� ����� ��������: ";

	cin >> choice;
	do
	{
		switch (choice)
		{
		case 1:  enter_new();  break;// ������ ����� ������
		case 2:  out();	break; //�������
		case 3:  cout << "������� �������: "; cin >> fio; find(fio);	break;//�����
		}

	} while (choice != 4);
}

void enter_new()
{

	setlocale(LC_CTYPE, "Russian");
	cout << "���� ����������" << endl;
	if (strnum < size)
	{
		//�.�.�, ���� ��������, �����, �������, ����� ������ ��� �����, ���������
		cout << "������ ����� ";
		cout << strnum + 1;
		cout << endl << "������� ������������� " << endl;
		cin >> list_of_zap[strnum].fio;
		cout << "���� ��������" << endl;
		cin >> list_of_zap[strnum].data;
		cout << "�������� ��������" << endl;
		cin >> list_of_zap[strnum].examen;
		strnum++;
	}
	else
		cout << "������� ������������ ���-�� �����";
	cout << "��� ������?" << endl;
	cin >> choice;
}


void out()
{
	setlocale(LC_CTYPE, "Russian");
	int sw;
	cout << "1-����� 1 ������" << endl;
	cout << "2-����� ���� �����" << endl;
	cin >> sw;
	if (sw == 1)
	{
		cout << "����� ��������� ������ " << endl;   cin >> tabl.coutnomer;  cout << endl;
		cout << "-------------------------------------------------------------------------------------";
		cout << endl << "������� ������������: " << list_of_zap[tabl.coutnomer - 1].fio << endl;
		cout << "���� ��������: " << list_of_zap[tabl.coutnomer - 1].data << endl;
		cout << "�������� ��������: " << list_of_zap[tabl.coutnomer - 1].examen << endl;
		cout << "-------------------------------------------------------------------------------------";
	}
	if (sw == 2)
	{
		for (int i = 0; i < strnum; i++)
		{
			cout << "����� ��������� ������: " << i + 1 << endl;
			cout << "-------------------------------------------------------------------------------------";
			cout << endl << "������� �������������: " << list_of_zap[i].fio << endl;
			cout << "���� ��������: " << list_of_zap[i].data << endl;
			cout << "�������� ��������: " << list_of_zap[i].examen << endl;
			cout << "-------------------------------------------------------------------------------------" << endl;
		}
	}
	cout << "��� ������?" << endl;
	cin >> choice;
}

void find(char fio[16])
{
	tabl.coutnomer = 0;
	flag = false;
	for (; tabl.coutnomer < str_len; tabl.coutnomer++)

		if (strcmp(fio, list_of_zap[tabl.coutnomer].fio) == 0)
		{
			flag = true;
			cout << "����� ��������� ������: " << tabl.coutnomer + 1 << endl;
			cout << "-------------------------------------------------------------------------------------";
			cout << endl << "������� �������������: " << list_of_zap[tabl.coutnomer].fio << endl;
			cout << "���� ��������: " << list_of_zap[tabl.coutnomer].data << endl;
			cout << "�������� ��������: " << list_of_zap[tabl.coutnomer].examen << endl;
			cout << "-------------------------------------------------------------------------------------" << endl;
		}
	if (flag == false)
		cout << "���������� �� ������ ������� �� �������!" << endl;
	cout << "��� ������?" << endl;
	cin >> choice;
}