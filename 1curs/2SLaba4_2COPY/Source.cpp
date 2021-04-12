#include <iostream>   
#include <windows.h>
#define str_len 30                               
#define size 30  
using namespace std;

void enter_new();
void out();
void find(char fio[]);

typedef enum bitik
{
	one = 1, zero = 0,

};


typedef struct Zapis
{
	char fio[str_len];
	int data;
	char adres[str_len];
	char tel[str_len];
	char mesto[str_len];
	char status[str_len];


} ZAP;


Zapis list_of_zap[size];
Zapis bad;
int current_size = 0, choice, number;
char fio[str_len];
bool flag = false;
bitik zifra;
FILE* f; errno_t err;

int main()
{
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
	int per;
	setlocale(LC_CTYPE, "Russian");
	cout << "���� ����������" << endl;
	if (current_size < size)
	{
		//�.�.�, ���� ��������, �����, �������, ����� ������ ��� �����, ���������
		cout << "������ ����� ";
		cout << current_size + 1;
		cout << endl << "��� " << endl;
		cin >> list_of_zap[current_size].fio;
		cout << "���� �������� " << endl;
		cin >> list_of_zap[current_size].data;
		cout << "������ " << endl;
		cin >> list_of_zap[current_size].tel;
		cout << "������� " << endl;
		cin >> list_of_zap[current_size].mesto;
		cout << "����� ������ ��� ����� " << endl;
		cin >> list_of_zap[current_size].adres;
		cout << "��������� " << endl;
		cin >> list_of_zap[current_size].status;
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
		cout << "-------------------------------------------------------------------------------------";
		cout << endl << "���: " << list_of_zap[n - 1].fio << endl;
		cout << "���� ��������: " << list_of_zap[n - 1].data << endl;
		cout << "������: " << list_of_zap[n - 1].adres << endl;
		cout << "�������: " << list_of_zap[n - 1].tel << endl;
		cout << "����� ������ ��� �����: " << list_of_zap[n - 1].mesto << endl;
		cout << "���������: " << list_of_zap[n - 1].status << endl;
		cout << "-------------------------------------------------------------------------------------";
	}
	if (sw == 2)
	{
		for (int i = 0; i < current_size; i++)
		{
			cout << "����� ��������� ������: " << i + 1 << endl;
			cout << "-------------------------------------------------------------------------------------";
			cout << endl << "���: " << list_of_zap[i].fio << endl;
			cout << "���� ��������: " << list_of_zap[i].data << endl;
			cout << "������: " << list_of_zap[i].adres << endl;
			cout << "�������: " << list_of_zap[i].tel << endl;
			cout << "����� ������ ��� �����: " << list_of_zap[i].mesto << endl;
			cout << "���������: " << list_of_zap[i].status << endl;
			cout << "-------------------------------------------------------------------------------------" << endl;
		}
	}
	cout << "��� ������?" << endl;
	cin >> choice;
}

void find(char fio[16])
{

	for (int i = 0; i < 2; i++)

		if (strcmp(fio, list_of_zap[i].fio) == 0)
		{
			flag = true;
			cout << "����� ��������� ������: " << i + 1 << endl;
			cout << "-------------------------------------------------------------------------------------";
			cout << endl << "���: " << list_of_zap[i].fio << endl;
			cout << "���� ��������: " << list_of_zap[i].data << endl;
			cout << "������: " << list_of_zap[i].adres << endl;
			cout << "�������: " << list_of_zap[i].tel << endl;
			cout << "����� ������ ��� �����: " << list_of_zap[i].mesto << endl;
			cout << "���������: " << list_of_zap[i].status << endl;
			cout << "-------------------------------------------------------------------------------------" << endl;
		}
	if (flag == false)
		cout << "���������� �� ������ ������� �� �������!" << endl;
	cout << "��� ������?" << endl;
	cin >> choice;
}