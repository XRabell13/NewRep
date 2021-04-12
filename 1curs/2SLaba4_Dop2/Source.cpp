//Государство. Наименование, столица, численность населения, площадь, фамилия президента. Выбор госу-дарства по названию.
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
	cout << "Введите:" << endl;
	cout << "1-для ввода новой записи" << endl;
	cout << "2-для вывода записи(ей)" << endl;
	cout << "3.Поиск по названию государства" << endl;
	cout << "4-выход" << endl;
	cout << "Введите номер операции: ";

	cin >> choice;
	do
	{
		switch (choice)
		{
		case 1:  enter_new();  break;
		case 2:  out();	break;
		case 3:  cout << "Введите площадь: "; cin >> plosch; find(plosch);	break;
		}

	} while (choice != 4);
}


void enter_new()
{
	setlocale(LC_CTYPE, "Russian");
	cout << "Ввод информации" << endl;
	if (current_size < size)
	{
		cout << "Строка номер ";
		cout << current_size + 1;
		cout << endl << "Государство " << endl;
		cin >> list_of_gos[current_size].gosname;
		cout << "Столица" << endl;
		cin >> list_of_gos[current_size].stolica;
		cout << " Численность населения" << endl;
		cin >> list_of_gos[current_size].chislennost;
		cout << " Площадь" << endl;
		cin >> list_of_gos[current_size].ploscha;
		cout << " Фамилия президента" << endl;
		cin >> list_of_gos[current_size].famprezident;
		cout << "Выберите форму правления: \n1.Капитализм\n2.Монархия\n3.Коммунизм\n";
		cin >> list_of_gos[current_size].forma;
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
		cout << "Государство ";
		cout << list_of_gos[n - 1].gosname << endl;
		cout << "Столица ";
		cout << list_of_gos[n - 1].stolica << endl;
		cout << "Численность ";
		cout << list_of_gos[n - 1].chislennost << endl;
		cout << "Площадь ";
		cout << list_of_gos[n - 1].ploscha << endl;
		cout << "Фамилия президента ";
		cout << list_of_gos[n - 1].famprezident << endl;
		cout << "Форма правления ";
		if (list_of_gos[n - 1].forma == kapital) cout << "Капитализм\n";
		if (list_of_gos[n - 1].forma == monarch) cout << "Монархия\n";
		if (list_of_gos[n - 1].forma == kommunizm) cout << "Коммунизм\n";
	}
	if (sw == 2)
	{
		for (int i = 0; i < current_size; i++)
		{
			cout << "Государство ";
			cout << list_of_gos[i].gosname << endl;
			cout << "Столица ";
			cout << list_of_gos[i].stolica << endl;
			cout << "Численность ";
			cout << list_of_gos[i].chislennost << endl;
			cout << "Площадь ";
			cout << list_of_gos[i].ploscha << endl;
			cout << "Фамилия президента ";
			cout << list_of_gos[i].famprezident << endl;
			cout << "Форма правления ";
			if (list_of_gos[i].forma == kapital) cout << "Капитализм\n";
			if (list_of_gos[i].forma == monarch) cout << "Монархия\n";
			if (list_of_gos[i].forma == kommunizm) cout << "Коммунизм\n";
		}
	}
	cout << "Что дальше?" << endl;
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
			cout << "\nГосударство   Столица     Площадь       Численность         Фамилия президента        Форма правления\n";
			cout << list_of_gos[tabl.coutnomer].gosname << "\t       " << list_of_gos[tabl.coutnomer].stolica << "\t    ";
			cout << list_of_gos[tabl.coutnomer].ploscha << "\t    " << list_of_gos[tabl.coutnomer].chislennost << "\t         ";
			cout << list_of_gos[tabl.coutnomer].famprezident << endl;
			if (list_of_gos[tabl.coutnomer].forma == kapital) cout << "Капитализм\t";
			if (list_of_gos[tabl.coutnomer].forma == monarch) cout << "Монархия\t";
			if (list_of_gos[tabl.coutnomer].forma == kommunizm) cout << "Коммунизм\t";
			flag = true; break;

		}
	if (!flag) cout << "Ничего не найдено\n";
	cout << "Что дальше?" << endl;
	cin >> choice;
}


