﻿
#include <iostream>
#include <fstream>
using namespace std;
//double inFile(ifstream& f, char s[]); //Функция чтения из файла
void fromFile(ofstream& f, char str[]); //Функция записи в файл

void main()
{
	setlocale(LC_ALL, "Russian");
	double a;
	char str[40];
	ifstream ifile;
	ofstream ofile;
	cout << "Введите строку: \n";
	cin >> str;
	fromFile(ofile, str);

	/*a = inFile(ifile, str);
	cout << "\n Прочитанное из файла число = " << a;
	b = pow(a, 2);
	cout << "\n b=" << b;
	cout << "\n Ввести имя файла для записи: \n";
	cin >> str;
	fromFile(ofile, b, str);
	cout << endl;*/
}
/*double inFile(ifstream&f, char s[40]) //Функция чтения из файла
{
	double a;
	f.open(s);
	if (f.fail())  //проверка открытия файла
	{
		cout << "\n Ошибка открытия файла";
		exit(1);
	}
	f >> a;      //чтение числа из файла в переменную a 
	f.close();
	return a;
}*/
void fromFile(ofstream& f, char str[]) //Функция записи в файл
{
	f.open("FILE2.txt");
	if (f.fail())
	{
		cout << "\n Ошибка открытия файла";
		exit(1);
	}
	f << str;            //запись числа из переменной a в файл 
	f.close();
}
