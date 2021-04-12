//�������� ������. �.�.�, ���� ��������, �����, �������, ����� ������ ��� �����, ���������. ����� �� �������.
// ���� �������� ����������� � ������� �������� ����.

#include <iostream>   
#include <windows.h>
#define str_len 30                               
#define size 30  
using namespace std;

void enter_new();
void del();
void out();
void find(char fio[16]);

typedef enum bitik
{
	one = 1, zero = 0,

};

struct Byte
{
	unsigned a : 1;
	unsigned b : 1;
	unsigned c : 1;
	unsigned d : 1;
	unsigned e : 1;
	unsigned f : 1;
	unsigned g : 1;
	unsigned h : 1;
	unsigned a1 : 1;
	unsigned b1 : 1;
	unsigned c1 : 1;
	unsigned d1 : 1;
	unsigned e1 : 1;
	unsigned f1 : 1;
	unsigned g1 : 1;
	unsigned h1 : 1;
	unsigned a2 : 1;

};

typedef struct Zapis
{
	char fio[str_len];
	int data;
	char adres[str_len];
	char tel[str_len];
	char mesto[str_len];
	char status[str_len];
 // ����� - ��� ������ �� 8 ����� �� �����������... ������, ����� ��������� �� ����� � 1-���, 2-���, 3-��� � �� ����

} ZAP;

union bits
{
	int ch;
	struct Byte bit;
} ascii;

void disp_bits(Byte b);

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
	cout << "1-��� �������� ������" << endl;
	cout << "2-��� ����� ����� ������" << endl;
	cout << "3-��� ������ ������(��)" << endl;
	cout << "4.����� �� �������" << endl;
	cout << "5-�����" << endl;
	cout << "������� ����� ��������: ";

	cin >> choice;
	do
	{
		switch (choice)
		{
		case 1:  del();	break;//�������
		case 2:  enter_new();  break;// ������ ����� ������
		case 3:  out();	break; //�������
		case 4:  cout << "������� �������: "; cin >> fio; find(fio);	break;//�����
		}

	} while (choice != 5);
}

void disp_bits(bits b)
{
	if (b.bit.a2) cout << one;  else cout << zero;
	if (b.bit.h1) cout << one;  else cout <<zero;// ���� � ������ ���� ���� 1, �� ����� 1, ���� 0, �� ����� 0
	if (b.bit.g1) cout << one;  else cout << zero;
	if (b.bit.f1) cout << one;  else cout << zero;
	if (b.bit.e1)  cout << one;  else cout << zero;
	if (b.bit.d1)  cout << one;  else cout << zero;
	if (b.bit.c1)  cout << one;  else cout << zero;
	if (b.bit.b1) cout << one;  else cout << zero;
	if (b.bit.a1)  cout << one;  else cout << zero;
	if (b.bit.h)  cout << one;  else cout << zero;
	if (b.bit.g)  cout << one;  else cout << zero;
	if (b.bit.f) cout << one; else cout << zero;
	if (b.bit.e)  cout << one;  else cout << zero;
	if (b.bit.d)  cout << one; else cout << zero;
	if (b.bit.c) cout << one;  else cout << zero;
	if (b.bit.b)  cout << one; else cout << zero;
	if (b.bit.a)  cout << one; else cout << zero;

	cout << "\n";
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


		cin >> per;
			ascii.ch = per;
			list_of_zap[current_size].data = per;
			disp_bits(ascii);


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
void del()
{
	setlocale(LC_CTYPE, "Russian");
	int d;
	cout << "\n����� ������, ������� ���� ������� (��� �������� ���� ����� ������ 99)" << endl;  cin >> d;
	if (d != 99)
	{
		for (int de1 = (d - 1); de1 < current_size; de1++)
			list_of_zap[de1] = list_of_zap[de1 + 1];
		current_size = current_size - 1;
	}
	if (d == 99)
		for (int i = 0; i < size; i++)
			list_of_zap[i] = bad;
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
		cout << endl << "���: "<<list_of_zap[n - 1].fio << endl;
		cout << "���� ��������: " << list_of_zap[n - 1].data<< endl;
		cout << "������: "<<list_of_zap[n - 1].adres << endl;
		cout << "�������: " << list_of_zap[n - 1].tel << endl;
		cout << "����� ������ ��� �����: " << list_of_zap[n - 1].mesto << endl;
		cout << "���������: " << list_of_zap[n - 1].status << endl;
		cout << "-------------------------------------------------------------------------------------";
	}
	if (sw == 2)
	{
		for (int i = 0; i < current_size; i++)
		{
			cout << "����� ��������� ������: " << i+1 << endl;
			cout << "-------------------------------------------------------------------------------------";
			cout << endl << "���: " << list_of_zap[i].fio << endl;
			cout << "���� ��������: " << list_of_zap[i].data << endl;
			cout << "������: " << list_of_zap[i].adres << endl;
			cout << "�������: " << list_of_zap[i].tel << endl;
			cout << "����� ������ ��� �����: " << list_of_zap[i].mesto << endl;
			cout << "���������: " << list_of_zap[i].status << endl;
			cout << "-------------------------------------------------------------------------------------"<<endl;
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
			cout << "����� ��������� ������: " << i+1 << endl;
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