#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <clocale>
#include <iostream>
int main()
{
	using namespace std;
	setlocale(LC_CTYPE, "RUS");
	int i;
	FILE* F1;
	int k = 0;
	/*finput создаем для чтения нашего file.txt*/
	FILE* finput;
	int s;
	finput = fopen("file.txt", "r+");

	while ((fscanf(finput, "%d", &s) != EOF))
	{
		if (!finput) break;    //чтобы не делал лишнего
		k++;
	}
	int* c = (int*)malloc(k * sizeof(int));  /* malloc динамическое выделение памяти.
	будем предполагать, что неизвестно из скольки строк состоит файл.
	вычисляем размер памяти с помощью операции sizeof() */
	rewind(finput); //устанавливаем указатель на начало в файле,чтобы снова прочитать файл

	//создаем на запись второй файл F2,куда будем записывать прочитанный массив из finput
	FILE* F2;
	F2 = fopen("file2.txt", "wt");
	//записываем в F2 5 строчек
	cout << "Введите номер строки(не больше 5): "; cin >> k;
	for (int i = 0; i < 8; i++)
	{
		fscanf(finput, "%d", &c[i]);
	}
	for (i=k; k <(i+3); k++)
	{
		fprintf(F2, "%d\n", c[k]);
	}
	fclose(finput); //закрываем файл

	free(c); //Высвобождение памяти 
	fclose(F2);//закрываем файл
	printf("Файл создан");
	return 0;
}
