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


	cout << "------ ���������� ��� " << count++ << " ������ ----------------------" << endl;
	cout << "������� ����� ���������� : ";
	cin >> tr->item;
	cout << "������� ����� ������ : ";
	cin >> tr->number;
	cout << "������� ����� ��������  ( �� : �� )  : ";
	cin >> tr->time;
	cout << "----------------------------" << endl;

}

void sort(TRAIN* tr, int& n)
{
	TRAIN p;

	cout << "��������� �� ������� ������� �����������" << endl;

	//for(int i=0; i<n; i++)
	for (int j = 0; j < (n - 1); j++)
	{
		if (tr[j].number > tr[j + 1].number)/*���������� ������� ����� ������ � ����������,
											����� ��� ������ ��� �� ����� ����������,
											� ����� ��������������� ������ ����� �������� 
											� ��� ��������� ���, ���� �� ���������� ���... ����� ���������
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
	TRAIN inf[2];// 2 ������ ����� �� ������� ������� �����
	int count, n = 2, i, nom;// ����� ��� 2 ������� ������ ��� �� �� ������� ������� �����
	bool flag = false;
	char otv[3], otv1[3], zn[3] = "��";

	setlocale(LC_ALL, "rus");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	count = 0;

	while (count < n)
		zap(&inf[count++], count); // ������ ����
//
	cout << "������� ����� ������ ��� �������� �� ������ �������� ���������� : ";
	cin >> nom;
	for (i = 0; i < 2; i++)

		if (inf[i].number == nom)
		{
			flag = true;
			cout << "----------------------------" << endl;
			cout << "����� ��������� : " << inf[i].item << endl;
			cout << "����� ������ : " << inf[i].number << endl;
			cout << "����� �������� : " << inf[i].time << endl;
			cout << "----------------------------" << endl;
		}
	if (flag == false)
		cout << "���������� �� ������ ������� �� �������!" << endl;
	//

	cout << "������ �� ���������� ���������� ���� �� ������ ������\n��/���" << endl;
	cin >> otv;
	if (*otv == *zn)
	{
		sort(inf, n);
		for (i = 0; i < 2; i++)
		{
			cout << "----------------------------" << endl;
			cout << "����� ��������� : " << inf[i].item << endl;
			cout << "����� ������ : " << inf[i].number << endl;
			cout << "����� �������� : " << inf[i].time << endl;
			cout << "----------------------------" << endl;
		}
	}
	else
		cout << "������� �� ���������� � �������?" << endl;
	cin >> otv1;


	if (*otv1 == *zn)
		for (i = 0; i < 2; i++)
		{
			cout << "----------------------------" << endl;
			cout << "����� ��������� : " << inf[i].item << endl;
			cout << "����� ������ : " << inf[i].number << endl;
			cout << "����� �������� : " << inf[i].time << endl;
			cout << "----------------------------" << endl;
		}

}