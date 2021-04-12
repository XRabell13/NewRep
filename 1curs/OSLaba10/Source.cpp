/*#include <stdio.h>
#include <conio.h>
#include <iostream>
#include <string.h>
#include <windows.h>
using namespace std;

HANDLE H = GetStdHandle(STD_OUTPUT_HANDLE);

int  main()
{
	int i, n, * massiv;    //объявление указателя на массив

	system("mode con cols=60 lines=10");// задает размеры консольного окна
	system("title String");
	setlocale(LC_ALL, "RUS");//отображает русский текст
	system("cls");
	SetConsoleTextAttribute(H, 11);//управляет цветом текста

	cout << "Введите размер массива\n";
	cin >> n;//ввод размера массива

	massiv = (int*)malloc(n * sizeof(int)); //выделяет память динамически под n целочисленных переменных.
											//Ссылка на массив хранится в указателе massiv.

	if (!massiv)                              //проверка факта выделения памяти

	{
		cout << "\nНедостаточно памяти";

		cout << "\nНажмите любую клавишу для завершения программы ...\n";
		getchar();

		return 0;
	}

	cout << "Введите (целочисленный) массив, нажимая ENTER после каждого элемента\n";

	for (i = 0; i < n; i++)

		cin >> massiv[i];       //ввод массива


	cout << "\n massiv\n";
	for (i = 0; i < n; i++)cout << ' ' << massiv[i];       //вывод массива

	free(massiv);//освобождение памяти
	cout << "\nДо свидания!\n\n";
	getchar();
	return 0;
	//освобождение памяти
}*/

///////////////////////////////////////zad1///////////////////////////////////////////////

#include <iostream>
#include <windows.h>
using namespace std;
int main()
{
	setlocale(LC_CTYPE, "RUS");
    int i, n, strSize;
	char **massiv;
	cout << "Введите размер массива\n"; cin >> n;
	cout << "Введите размер строки\n";  cin >> strSize;
	massiv = (char**)malloc(n * sizeof(char*));
	for (i = 0; i < n; i++) {
		massiv[i] = (char*)malloc(strSize * sizeof(char));
	}
	cout << "Введите массив:\n";
	for (i = 0; i < n; i++) 
		cin >> massiv[i];
	
	cout << "\nМассив:\n";
	for (i = 0; i < n; i++) {
		cout << "Элемент " << i+1 <<": " << massiv[i] << "\n";
	}
	for (i = 0; i < n; i++) {
		free(massiv[i]);
}
	free(massiv);
	return 0;
}
/////////////////////////////////////////////////zad2/////////////////////////////////////
//
/*
#include <iostream>
#include <windows.h>

using namespace std;

const int MAXSIZE = 30;

struct books
{
	char title[MAXSIZE];
};

HANDLE H = GetStdHandle(STD_OUTPUT_HANDLE);

int  main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	int i;
	int n;
	books **massiv;


	std::cout << "Введите размер массива\n";
	std::cin >> n;

	massiv = (books**)malloc(n * sizeof(books*));
	for (i = 0; i < n; i++) {
		massiv[i] = (books*)malloc(MAXSIZE * sizeof(books));
	}
	if (!massiv) {
		cout << "\nНедостаточно памяти";
		cout << "\nНажмите любую клавишу для завершения программы ...\n";
		getchar();
		return 0;
	}

	std::cout << "Введите поле title\n";

	for (int j = 0, i = 0; i < n; i++) {
		cout << i + 1 << "-ый" << "  ";
		cin >> massiv[i][j].title;
	}

	cout << "\n Массив:\n";
	for (int j = 0, i = 0; i < n; i++) {
		cout << i + 1 << "-ый" << "   " << massiv[i][j].title << "\n";
	}
	for (i = 0; i < n; i++) {
		free(massiv[i]);
	}
	free(massiv);
	system("pause");
	return 0;
}*/
/*
#include <iostream>
#include <windows.h>
using namespace std;
struct books
{
	char *title;
};
int  main()
{
	setlocale(LC_CTYPE,"RUS");
	int i, n, strSize;
	books *massiv;
	cout << "Введите размер массив: "; cin >> n;
	cout << "Введите размер строки: "; cin >> strSize;
	cout << "Элементы:\n";
	books* book = (books*)malloc(n * sizeof(books));
	for (int i = 0; i < n; i++)
	{
		book[i].title = (char*)malloc(strSize * sizeof(char));
		cin>>book[i].title;
	}
	for (int i = 0; i < n; i++)
		printf("Элемент %d: %s\n", i + 1, book[i].title);
	for (int i = 0; i < n; i++)
		free(book[i].title);
	free(book);
	return 0;
}*/
/////////////////////////////zad3//////////////////////////////////////
/*
#include <iostream>
#include <windows.h>
using namespace std;
struct books
{
	char* title;
};

int  main()
{
	setlocale(LC_CTYPE,"RUS");
	int i, n, strSize = 10;
	books **massiv;
	cout << "Размер массива массивов структур:\n";
	cin >> n;
	cout << "Размер строки: ";
	cin >> strSize;
	massiv = (books **)malloc(n * sizeof(books*));
	for (int i = 0; i < n; i++)
	{
		*(massiv + i) = (books*)malloc(n * sizeof(books));
		for (int j = 0; j < n; j++)
		{
			massiv[i][j].title = (char*)malloc(strSize * sizeof(char));
			cin>>massiv[i][j].title;
		}
	}

	if (!massiv) {
		std::cout << "\nНедостаточно памяти";
		std::cout << "\nНажмите любую клавишу для завершения программы ...\n";
		getchar();
		return 0;
	}
	for (int i = 0; i < n; i++)
		for (int j = 0; j < n; j++)
			cout<<"Элемент "<<i+1<<"-"<<j+1<<": "<<massiv[i][j].title<<endl;
		
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n; j++)
			free(massiv[i][j].title);
		free(massiv[i]);
	}

	free(massiv);
	return 0;
}
*/

/*
#include <stdio.h>
#include <conio.h>
#include <iostream>
#include <string.h>
#include <windows.h>
using namespace std;

struct books
{
    char* title;
};

int  main()
{
    int i, n, * massiv;    //объявление указателя на массив
    system("title String");
    setlocale(LC_ALL, "RUS");
    system("cls");

    //строка
    int strSize;
    cout << "Введите размер строки\n";
    cin >> strSize;
    while (getchar() != '\n');
    char* str[2];
    for (int i = 0; i < 2; i++)
    {
        str[i] = (char*)malloc(strSize * sizeof(char));
        gets_s(str[i], strSize);
    }
    for (int i = 0; i < 2; i++)
        printf("Строка: %s\n", str[i]);
    for (int i = 0; i < 2; i++)
        free(str[i]);

    //массив структур
    cout << "Введите размер массива\n";
    cin >> n;//ввод размера массива
    while (getchar() != '\n');
    cout << "названия книг:\n";
    books* book = (books*)malloc(n * sizeof(books));
    for (int i = 0; i < n; i++)
    {
        book[i].title = (char*)malloc(strSize * sizeof(char));

        gets_s(book[i].title, strSize);
    }
    for (int i = 0; i < n; i++)
        printf("название %d: %s\n", i+1, book[i].title);
    for (int i = 0; i < n; i++)
        free(book[i].title);
    free(book);

    //двухмерный массив структур
    cout << "названия книг:\n";
	//cin >> n;
	//cin >> strSize;
    books** book2 = (books**)malloc(n * sizeof(books*));
    for (int i = 0; i < n; i++)
    {
        *(book2 + i) = (books*)malloc(n * sizeof(books));
        for (int j = 0; j < n; j++)
        {
            book2[i][j].title = (char*)malloc(strSize * sizeof(char));
            gets_s(book2[i][j].title, strSize);
        }
    }
    for (int i = 0; i < n; i++)
        for (int j = 0; j < n; j++)
            printf("название %d-%d: %s\n", i+1, j+1, book2[i][j]);
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
            free(book2[i][j].title);
        free(book2[i]);
    }
    free(book2);
    return 0;
}
*/