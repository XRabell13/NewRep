//Государство. Наименование, столица, численность населения, площадь, фамилия президента. Выбор госу-дарства по названию.

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
	cout << "Введите:" << endl;
	cout << "1-для удаления записи" << endl;
	cout << "2-для ввода новой записи" << endl;
	cout << "3-для вывода записи(ей)" << endl;
	cout << "4.Ввод данных с клавиатуры и запись в файл" << endl;
	cout << "5.Вывод данных из файла" << endl;
	cout << "6.Поиск по названию государства" << endl;
	cout << "7-выход" << endl;
	cout << "Введите номер операции: ";

	cin >> choice;
	do
	{
		switch (choice)
		{
		case 1:  del();	break;
		case 2:  enter_new();  break;
		case 3:  out();	break;
		case 4:  cout << "Введите количество государств: "; cin >> number; input(number); break;
		case 5:  output();  break;
		case 6:  cout << "Введите государство: "; cin >> gosud; find(gosud);	break;
		}
	
	} while (choice != 7);
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
			list_of_gos[de1] = list_of_gos[de1 + 1];
		current_size = current_size - 1;
	}
	if (d == 99)
		for (int i = 0; i < size; i++)
			list_of_gos[i] = bad;
	cout << "Что дальше?" << endl;
	cin >> choice;
}
/*void change()
{
	int n, per;
	cout << "\nВведите номер строки" << endl; 	cin >> n;
	do
	{
		cout << "Введите: " << endl;
		cout << "1-для изменения фамилии" << endl;
		cout << "2-для изменения года рождения" << endl;
		cout << "3-для изменения факультета" << endl;
		cout << "4-конец\n";
		cin >> per;
		switch (per)
		{
		case 1: cout << "Новая фамилия";
			cin >> list_of_gos[n - 1].gosname;   break;
		case 2: cout << "Новый год рождения";
			cin >> list_of_gos[n - 1].chislennost; break;
		case 3: cout << "Новый факультет ";
			cin >> list_of_gos[n - 1].department; break;
		}
	} while (per != 4);
	cout << "Что дальше?" << endl;
	cin >> choice;
}*/
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
		cout << list_of_gos[n - 1].stolica<< endl;
		cout << "Численность ";
		cout << list_of_gos[n - 1].chislennost << endl;
		cout << "Площадь ";
		cout << list_of_gos[n - 1].ploscha << endl;
		cout << "Фамилия президента ";
		cout << list_of_gos[n - 1].famprezident << endl;
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
		}
	}
	cout << "Что дальше?" << endl;
	cin >> choice;
}

//////////////////////////////////////////////////////////////////////////////////////////

void input(int num)// в num колво вводимых обьектов
{
	GOS buf = { " ", " "," ", " ", " " };
	if (!fopen_s(&f, "Gos.txt", "a"))  //открывает файл для чтения и записи в конец
	{
		for (int i = 0; i < num; i++)
		{
			cout << "Государство: "; 	cin >> buf.gosname;
			cout << "Столица: "; 	cin >> buf.stolica;
			cout << "Площадь: "; 	cin >> buf.ploscha;
			cout << "Численность: "; 	cin >> buf.chislennost;
			cout << "Фамилия президента: "; 	cin >> buf.famprezident;
			fwrite(&buf, sizeof(buf), 1, f);
			fputs("\n", f);
		}
		fclose(f);
	}
	else {
		cout << "Ошибка открытия файла";
		return;
	}
	cout << "Что дальше?" << endl;
	cin >> choice;
}

void output()
{
	GOS buf;

	if (!fopen_s(&f, "Gos.txt", "r"))
	{
		cout << "\nГосударство   Столица     Площадь       Численность         Фамилия президента\n";
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
		cout << "Ошибка открытия файла";
		return;
	}
	
	cout << "Что дальше?" << endl;
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
			if (strcmp(gosud, buf.gosname) == 0)   //сравнение строк
			{
				cout << "\nГосударство   Столица     Площадь       Численность         Фамилия президента\n";
				cout << buf.gosname << "\t       " << buf.stolica << "\t    " << buf.ploscha << "\t    " << buf.chislennost << "\t         " << buf.famprezident << endl;
				flag = true; break;
			}
		}
		fclose(f);
		if (!flag) cout << "Ничего не найдено\n";
	}
	else
	{
		cout << "Ошибка открытия файла";
		return;
	}
	cout << "Что дальше?" << endl;
	cin >> choice;
}

