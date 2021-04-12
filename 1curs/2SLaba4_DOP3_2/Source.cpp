// 5.1 
//Преподаватели. Фамилия преподавателя, название экзамена, дата экзамена. Выбор по фамилии.
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

	setlocale(LC_CTYPE, "Russian");
	cout << "Ввод информации" << endl;
	if (strnum < size)
	{
		//Ф.И.О, дата рождения, адрес, телефон, место работы или учебы, должность
		cout << "Строка номер ";
		cout << strnum + 1;
		cout << endl << "Фамилия преподавателя " << endl;
		cin >> list_of_zap[strnum].fio;
		cout << "Дата экзамена" << endl;
		cin >> list_of_zap[strnum].data;
		cout << "Название экзамена" << endl;
		cin >> list_of_zap[strnum].examen;
		strnum++;
	}
	else
		cout << "Введено максимальное кол-во строк";
	cout << "Что дальше?" << endl;
	cin >> choice;
}


void out()
{
	setlocale(LC_CTYPE, "Russian");
	int sw;
	cout << "1-вывод 1 строки" << endl;
	cout << "2-вывод всех строк" << endl;
	cin >> sw;
	if (sw == 1)
	{
		cout << "Номер выводимой строки " << endl;   cin >> tabl.coutnomer;  cout << endl;
		cout << "-------------------------------------------------------------------------------------";
		cout << endl << "Фамилия преподваталя: " << list_of_zap[tabl.coutnomer - 1].fio << endl;
		cout << "Дата экзамена: " << list_of_zap[tabl.coutnomer - 1].data << endl;
		cout << "Название экзамена: " << list_of_zap[tabl.coutnomer - 1].examen << endl;
		cout << "-------------------------------------------------------------------------------------";
	}
	if (sw == 2)
	{
		for (int i = 0; i < strnum; i++)
		{
			cout << "Номер выводимой строки: " << i + 1 << endl;
			cout << "-------------------------------------------------------------------------------------";
			cout << endl << "Фамилия преподавателя: " << list_of_zap[i].fio << endl;
			cout << "Дата экзамена: " << list_of_zap[i].data << endl;
			cout << "Название экзамена: " << list_of_zap[i].examen << endl;
			cout << "-------------------------------------------------------------------------------------" << endl;
		}
	}
	cout << "Что дальше?" << endl;
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
			cout << "Номер выводимой строки: " << tabl.coutnomer + 1 << endl;
			cout << "-------------------------------------------------------------------------------------";
			cout << endl << "Фамилия преподавателя: " << list_of_zap[tabl.coutnomer].fio << endl;
			cout << "Дата экзамена: " << list_of_zap[tabl.coutnomer].data << endl;
			cout << "Название экзамена: " << list_of_zap[tabl.coutnomer].examen << endl;
			cout << "-------------------------------------------------------------------------------------" << endl;
		}
	if (flag == false)
		cout << "Информации по вашему запросу не найдено!" << endl;
	cout << "Что дальше?" << endl;
	cin >> choice;
}