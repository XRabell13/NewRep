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
		cout << "������� ���: \n";
		cout << "\n";
		cin >> stud[i].fio;
		cout << "������� ����� �� ���������: \n";
		cout << "\n";
		cout << "���������� | ����������� | ��� | ��� | �� \n";

		for (int j = 0; j < 5; j++)
		{
			cout << "\n";
			cin >> stud[i].Ball[j];
		}
	}

	
	strcpy(namePredmets[0], "����������");// �������� � ������ �����
	strcpy(namePredmets[1], "�����������");
	strcpy(namePredmets[2], "���");
	strcpy(namePredmets[3], "���");
	strcpy(namePredmets[4], "��");
	/*for (int j = 0; j < 5; j++)//j - ������� �������, 5 - ����� ���������
	{
		int badRes = 0, goodRes = 0;

		for (int i = 0; i < n; i++)//i - ������� �������, n - ����� ���������
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
		//100 / 4, 100 ���������� ��������� (�.�. ������ ���), 4 - ���������� ���������, 1 ������� - 25 ��������� �� ���� ���������
	}*/
	obrab();
	obrab1();

	return 0;
}
//������ �� ��� �������� � ������-�� �������� �� 4 ��� 5
bool obrab()
{
	setlocale(LC_CTYPE, "RUS");
	for (int j = 0; j < 5; j++)//j - ������� �������, 5 - ����� ���������
	{
		int badRes = 0, goodRes = 0;

		for (int i = 0; i < 4; i++)//i - ������� �������, 4 - ����� ���������
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
	for (int j = 0; j < 4; j++)//j - ������� �������, 4 - ����� ���������
	{
		int badRes = 0, goodRes = 0;

		for (int i = 0; i < 5; i++)//i - ������� �������, 5 - ����� ���������
		{
			if ((stud[j].Ball[i] == 4) || (stud[j].Ball[i] == 5))
				goodRes++;
		}
			if (goodRes == 5)
				cout << "������� "<<stud[j].fio<<" ���� ��� �������� �� 4 � 5\n";
			else cout << "������� " << stud[j].fio << " �� ���� ��� �������� �� 4 � 5\n";
	}
	return 0;
}