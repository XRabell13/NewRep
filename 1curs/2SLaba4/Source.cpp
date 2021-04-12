//Записная книжка. Ф.И.О, дата рождения, адрес, телефон, место работы или учебы, должность. Поиск по фамилии.
// Дату рождения реализовать с помощью битового поля.

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
 // буквы - это каждый из 8 битов по отдельности... тоесть, можно обратится по букве к 1-ому, 2-ому, 3-ему и тд биту

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
	cout << "Введите:" << endl;
	cout << "1-для удаления записи" << endl;
	cout << "2-для ввода новой записи" << endl;
	cout << "3-для вывода записи(ей)" << endl;
	cout << "4.Поиск по фамилии" << endl;
	cout << "5-выход" << endl;
	cout << "Введите номер операции: ";

	cin >> choice;
	do
	{
		switch (choice)
		{
		case 1:  del();	break;//удалить
		case 2:  enter_new();  break;// ввести новую строку
		case 3:  out();	break; //вывести
		case 4:  cout << "Введите фамилию: "; cin >> fio; find(fio);	break;//найти
		}

	} while (choice != 5);
}

void disp_bits(bits b)
{
	if (b.bit.a2) cout << one;  else cout << zero;
	if (b.bit.h1) cout << one;  else cout <<zero;// если в данном бите есть 1, то вывод 1, если 0, то вывод 0
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
	cout << "Ввод информации" << endl;
	if (current_size < size)
	{
		//Ф.И.О, дата рождения, адрес, телефон, место работы или учебы, должность
		cout << "Строка номер ";
		cout << current_size + 1;
		cout << endl << "ФИО " << endl;
		cin >> list_of_zap[current_size].fio;
		cout << "Дата рождения " << endl;


		cin >> per;
			ascii.ch = per;
			list_of_zap[current_size].data = per;
			disp_bits(ascii);


		cout << "Адресс " << endl;
		cin >> list_of_zap[current_size].tel;
		cout << "Телефон " << endl;
		cin >> list_of_zap[current_size].mesto;
		cout << "Место работы или учебы " << endl;
		cin >> list_of_zap[current_size].adres;
		cout << "Должность " << endl;
		cin >> list_of_zap[current_size].status;
		current_size++;
	}
	else
		cout << "Введено максимальное кол-во строк";
	cout << "Что дальше?" << endl;
	cin >> choice;
}
void del()
{
	setlocale(LC_CTYPE, "Russian");
	int d;
	cout << "\nНомер строки, которую надо удалить (для удаления всех строк нажать 99)" << endl;  cin >> d;
	if (d != 99)
	{
		for (int de1 = (d - 1); de1 < current_size; de1++)
			list_of_zap[de1] = list_of_zap[de1 + 1];
		current_size = current_size - 1;
	}
	if (d == 99)
		for (int i = 0; i < size; i++)
			list_of_zap[i] = bad;
	cout << "Что дальше?" << endl;
	cin >> choice;
}

void out()
{
	setlocale(LC_CTYPE, "Russian");
	int sw, n;
	cout << "1-вывод 1 строки" << endl;
	cout << "2-вывод всех строк" << endl;
	cin >> sw;
	if (sw == 1)
	{
		cout << "Номер выводимой строки " << endl;   cin >> n;  cout << endl;
		cout << "-------------------------------------------------------------------------------------";
		cout << endl << "ФИО: "<<list_of_zap[n - 1].fio << endl;
		cout << "Дата рождения: " << list_of_zap[n - 1].data<< endl;
		cout << "Адресс: "<<list_of_zap[n - 1].adres << endl;
		cout << "Телефон: " << list_of_zap[n - 1].tel << endl;
		cout << "Место работы или учебы: " << list_of_zap[n - 1].mesto << endl;
		cout << "Должность: " << list_of_zap[n - 1].status << endl;
		cout << "-------------------------------------------------------------------------------------";
	}
	if (sw == 2)
	{
		for (int i = 0; i < current_size; i++)
		{
			cout << "Номер выводимой строки: " << i+1 << endl;
			cout << "-------------------------------------------------------------------------------------";
			cout << endl << "ФИО: " << list_of_zap[i].fio << endl;
			cout << "Дата рождения: " << list_of_zap[i].data << endl;
			cout << "Адресс: " << list_of_zap[i].adres << endl;
			cout << "Телефон: " << list_of_zap[i].tel << endl;
			cout << "Место работы или учебы: " << list_of_zap[i].mesto << endl;
			cout << "Должность: " << list_of_zap[i].status << endl;
			cout << "-------------------------------------------------------------------------------------"<<endl;
		}
	}
	cout << "Что дальше?" << endl;
	cin >> choice;
}

void find(char fio[16])
{
	
	for (int i = 0; i < 2; i++)

		if (strcmp(fio, list_of_zap[i].fio) == 0)
		{
			flag = true;
			cout << "Номер выводимой строки: " << i+1 << endl;
			cout << "-------------------------------------------------------------------------------------";
			cout << endl << "ФИО: " << list_of_zap[i].fio << endl;
			cout << "Дата рождения: " << list_of_zap[i].data << endl;
			cout << "Адресс: " << list_of_zap[i].adres << endl;
			cout << "Телефон: " << list_of_zap[i].tel << endl;
			cout << "Место работы или учебы: " << list_of_zap[i].mesto << endl;
			cout << "Должность: " << list_of_zap[i].status << endl;
			cout << "-------------------------------------------------------------------------------------" << endl;
		}
	if (flag == false)
		cout << "Информации по вашему запросу не найдено!" << endl;
	cout << "Что дальше?" << endl;
	cin >> choice;
}