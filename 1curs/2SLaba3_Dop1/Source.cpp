#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <conio.h>
#include <iomanip>
#include <windows.h>
using namespace std;
bool obrab();
bool obrab1();
char namePredmets[5][32];
//opredelaem strukturu
struct Spisok
{
	char fio[40];
	int Exam=5;
	int Ball[5];
};
Spisok stud[4]; // sozdaem massiv strok

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	setlocale(LC_CTYPE, "RUS");
	const int n = 4;
	for (int i = 0; i < n; i++)
	{
		cout << "Введите ФИО: \n";
		cout << "\n";
		cin >> stud[i].fio;
		cout << "Введите баллы по предметам: \n";
		cout << "\n";
		cout << "Математика | Иностранный | ОАП | КЯР | ОС \n";

		for (int j = 0; j < 5; j++)
		{
			cout << "\n";
			cin >> stud[i].Ball[j];
		}
	}

	
	strcpy(namePredmets[0], "Математика");// копируем в массив слова
	strcpy(namePredmets[1], "Иностранный");
	strcpy(namePredmets[2], "ОАП");
	strcpy(namePredmets[3], "КЯР");
	strcpy(namePredmets[4], "ОС");
	/*for (int j = 0; j < 5; j++)//j - текущий предмет, 5 - всего предметов
	{
		int badRes = 0, goodRes = 0;

		for (int i = 0; i < n; i++)//i - текущий студент, n - всего студентов
		{
			if ((stud[i].Ball[j] == 4) || (stud[i].Ball[j] == 5))
			{
				goodRes++;
			}
			else
			{
				badRes++;
			}
		}

		cout << namePredmets[j] << ": " << (goodRes * (100 / 4)) << endl;
		//100 / 4, 100 количество процентов (т.е. всегда сто), 4 - количество студентов, 1 студент - 25 процентов от всех студентов
	}*/
	obrab();
	obrab1();

	return 0;
}
//Сдагны ли все экзамены у какого-то студента на 4 или 5
bool obrab()
{
	setlocale(LC_CTYPE, "RUS");
	for (int j = 0; j < 5; j++)//j - текущий предмет, 5 - всего предметов
	{
		int badRes = 0, goodRes = 0;

		for (int i = 0; i < 4; i++)//i - текущий студент, 4 - всего студентов
		{
			if ((stud[i].Ball[j] == 4) || (stud[i].Ball[j] == 5))
				goodRes++;
			else
				badRes++;
		}
		cout << namePredmets[j] << ": " << (goodRes * (100 / 4)) << endl;
	}
	cout << "\n\n";
	return 0;
}

bool obrab1()
{
	setlocale(LC_CTYPE, "RUS");
	for (int j = 0; j < 4; j++)//j - текущий студент, 4 - всего студентов
	{
		int badRes = 0, goodRes = 0;

		for (int i = 0; i < 5; i++)//i - текущий предмет, 5 - всего предметов
		{
			if ((stud[j].Ball[i] == 4) || (stud[j].Ball[i] == 5))
				goodRes++;
		}
			if (goodRes == 5)
				cout << "Студент "<<stud[j].fio<<" сдал все экзамены на 4 и 5\n";
			else cout << "Студент " << stud[j].fio << " НЕ сдал все экзамены на 4 и 5\n";
	}
	return 0;
}