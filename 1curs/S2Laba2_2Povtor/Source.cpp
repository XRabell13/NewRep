/*Ввести с клавиатуры строку символов, состоящую из букв, цифр, запятых, точек, знаков + и -, и записать ее в файл. 
Прочитать из файла данные и посчитать и вывести количество запятых.

Во второй программе ввод информации с клавиатуры и вывод в консольное окно должно осуществляться в главной функции,
а запись в файл и чтение из файла в функциях пользователя.
*/

#include <iostream>
#include <fstream>
using namespace std;
int inFile(ifstream& f, char str[]); //Функция чтения из файла и возврата колва запятых
void fromFile(ofstream& f, char str[]); //Функция записи в файл

void main()
{
	setlocale(LC_ALL, "Russian");
	int a;
	char str[40];
	ifstream ifile;
	ofstream ofile;
	cout << "Введите строку: \n";
	cin >> str;
	fromFile(ofile, str);
	a = inFile(ifile, str);
	cout << "Текст: " << str<<endl;
	cout << "Количество запятых: "<<a;

}

void fromFile(ofstream& f, char str[]) //Функция записи в файл
{
	f.open("FILE1.txt");
	if (f.fail())
	{
		cout << "\n Ошибка открытия файла";
		exit(1);
	}
	f << str;            //запись числа из переменной a в файл 
	f.close();
}

int inFile(ifstream&f, char str[]) //Функция чтения из файла и возвращения колва запятых
{
	int a=0, l;

	f.open("FILE2.txt");
	if (f.fail())  //проверка открытия файла
	{
		cout << "\n Ошибка открытия файла";
		exit(1);
	}

	l = strlen(str);
	for (int i = 0; i < l; i++)
	{
		if (str[i] == ',') a++;
	}

	f.close();
	return a;
}
