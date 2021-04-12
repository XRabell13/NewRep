#include <iostream>
#include <stdlib.h>
#include <string.h>
#include <time.h>
#include<windows.h>

using namespace std;

struct TRAIN
{
	char item[15];
	int number;
	char time[6];
};

void zap(TRAIN* tr, int count)
{


	cout << "------ Информация для " << count++ << " поезда ----------------------" << endl;
	cout << "Введите пункт назначения : ";
	cin >> tr->item;
	cout << "Введите номер поезда : ";
	cin >> tr->number;
	cout << "Введите время прибытия  ( ЧЧ : ММ )  : ";
	cin >> tr->time;
	cout << "----------------------------" << endl;

}

void sort(TRAIN* tr, int& n)
{
	TRAIN p;

	cout << "Сортирока по номерам поездов произведена" << endl;

	//for(int i=0; i<n; i++)
	for (int j = 0; j < (n - 1); j++)
	{
		if (tr[j].number > tr[j + 1].number)/*записываем текущий номер поезда в переменную,
											после чег меняем его на номер следующего,
											а номер послеследующего делаем номер текущего 
											и так несколько раз, пока не образуется все... метод пузырьков
											*/
		{
			p = *(tr + j);
			*(tr + j) = *(tr + j + 1);
			*(tr + j + 1) = p;
		}

	}
}


void main()
{
	TRAIN inf[2];// 2 записи чтобы не вводить слишком много
	int count, n = 2, i, nom;// здесь для 2 поездов только что бы не вводить слишком много
	bool flag = false;
	char otv[3], otv1[3], zn[3] = "да";

	setlocale(LC_ALL, "rus");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	count = 0;

	while (count < n)
		zap(&inf[count++], count); // запись инфы
//
	cout << "Введите номер поезда для которого вы хотите получить информацию : ";
	cin >> nom;
	for (i = 0; i < 2; i++)

		if (inf[i].number == nom)
		{
			flag = true;
			cout << "----------------------------" << endl;
			cout << "Пункт назнаения : " << inf[i].item << endl;
			cout << "Номер поезда : " << inf[i].number << endl;
			cout << "Время прибытия : " << inf[i].time << endl;
			cout << "----------------------------" << endl;
		}
	if (flag == false)
		cout << "Информации по вашему запросу не найдено!" << endl;
	//

	cout << "Хотите ли произвести сортировку базы по номеру поезда\nда/нет" << endl;
	cin >> otv;
	if (*otv == *zn)
	{
		sort(inf, n);
		for (i = 0; i < 2; i++)
		{
			cout << "----------------------------" << endl;
			cout << "Пункт назнаения : " << inf[i].item << endl;
			cout << "Номер поезда : " << inf[i].number << endl;
			cout << "Время прибытия : " << inf[i].time << endl;
			cout << "----------------------------" << endl;
		}
	}
	else
		cout << "Вывести на информацию о поездах?" << endl;
	cin >> otv1;


	if (*otv1 == *zn)
		for (i = 0; i < 2; i++)
		{
			cout << "----------------------------" << endl;
			cout << "Пункт назнаения : " << inf[i].item << endl;
			cout << "Номер поезда : " << inf[i].number << endl;
			cout << "Время прибытия : " << inf[i].time << endl;
			cout << "----------------------------" << endl;
		}

}