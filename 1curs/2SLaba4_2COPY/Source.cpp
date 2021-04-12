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
	cout << "Введите:" << endl;
	cout << "1-для ввода новой записи" << endl;
	cout << "2-для вывода записи(ей)" << endl;
	cout << "3.Поиск по фамилии" << endl;
	cout << "4-выход" << endl;
	cout << "Введите номер операции: ";

	cin >> choice;
	do
	{
		switch (choice)
		{
		case 1:  enter_new();  break;// ввести новую строку
		case 2:  out();	break; //вывести
		case 3:  cout << "Введите фамилию: "; cin >> fio; find(fio);	break;//найти
		}

	} while (choice != 4);
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
		cin >> list_of_zap[current_size].data;
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
		cout << endl << "ФИО: " << list_of_zap[n - 1].fio << endl;
		cout << "Дата рождения: " << list_of_zap[n - 1].data << endl;
		cout << "Адресс: " << list_of_zap[n - 1].adres << endl;
		cout << "Телефон: " << list_of_zap[n - 1].tel << endl;
		cout << "Место работы или учебы: " << list_of_zap[n - 1].mesto << endl;
		cout << "Должность: " << list_of_zap[n - 1].status << endl;
		cout << "-------------------------------------------------------------------------------------";
	}
	if (sw == 2)
	{
		for (int i = 0; i < current_size; i++)
		{
			cout << "Номер выводимой строки: " << i + 1 << endl;
			cout << "-------------------------------------------------------------------------------------";
			cout << endl << "ФИО: " << list_of_zap[i].fio << endl;
			cout << "Дата рождения: " << list_of_zap[i].data << endl;
			cout << "Адресс: " << list_of_zap[i].adres << endl;
			cout << "Телефон: " << list_of_zap[i].tel << endl;
			cout << "Место работы или учебы: " << list_of_zap[i].mesto << endl;
			cout << "Должность: " << list_of_zap[i].status << endl;
			cout << "-------------------------------------------------------------------------------------" << endl;
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
			cout << "Номер выводимой строки: " << i + 1 << endl;
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