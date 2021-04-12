//Чтение текстового файла.Указание: файл должен быть заранее подготовлен.
/*

#include <string.h>
#include <cstdio>
#include <tchar.h>
int _tmain(int argc, _TCHAR* argv[])
{

	FILE* fp = fopen("d:\\c_api.txt", "r");
	char str[80];

	if (fp != NULL)
	{
		fputs("Opening failed", fp);
		getchar();
	}
	else
	{
		fgets(str, 79, fp);
		printf("read: %s", str);
		int z = fclose(fp);
		getchar();
	}
	return 0;
}*/

/*
#include <string.h>
#include <stdio.h>

int main()
{

	FILE* fp;
	fopen_s(&fp, "c.txt", "rt");

	char str[80];
	if (fp == NULL)
	{
		puts("Opening failed");
	}
	else
	{
		fgets(str, 79, fp);
		printf("read: %s", str);
		fclose(fp);
	}
	getchar();
	return 0;
}*/

////////////////////////////////////////////////////////////////////////////////////////////////

//Запись с последующим чтением из текстового файла
/*
#include <string.h>
#include <stdio.h>
#include <tchar.h>
int _tmain(int argc, _TCHAR* argv[])
{

	FILE* fp;
	char str[80] = "glad to hear from you";
	if ((fp = fopen("c1.txt", "wt")) == NULL)
	{
		puts("Opening failed");
		getchar();
	}
	else
	{
		fputs(str, fp);
		int z = fclose(fp);

		fp = fopen("c1.txt", "rt");
		fgets(str, 79, fp);
		puts(str);
		z = fclose(fp);
		getchar();
	}
	return 0;
}*/


//Создание файла средствами API.
//Используется функция CreateFile.
//Если файл существует, то он пересоздается, а его содержимое стирается.
/*
#include <string.h>
#include <stdio.h>
#include "windows.h"
#include <tchar.h>

int _tmain(int argc, _TCHAR* argv[])
{
	TCHAR Buffer[256] = TEXT("Glad to hear from You");
	DWORD nLenCurDir;
	HANDLE hOut;
	FILE* fp;
	TCHAR stdPath[30] = TEXT("my_api2.txt");

	hOut = CreateFile(stdPath, GENERIC_WRITE, 0, NULL, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);

	if (hOut == INVALID_HANDLE_VALUE)//пустое значение дескриптора
	{
		printf("ERROR %x \n", GetLastError());// получим адрес ошибки.. номер ее
		getchar();
		return 2;
	}

	else
	{
		//nLenCurDir = GetCurrentDirectory(256, Buffer);//запись в буфер пути расположения файла
		WriteFile(hOut, Buffer, 256, NULL, NULL );
		printf("Created");
		getchar();
		CloseHandle(hOut);
	}

	return 0;
}*/



//Создание файла средствами API + запись в файл текста из буфера.
//Используется функция WriteFile.
/*
#include <string.h>
#include <stdio.h>
#include "windows.h"
#include <tchar.h>
int _tmain(int argc, _TCHAR* argv[])
{

	TCHAR Buffer[256] = TEXT("Glad to hear from You\n");
	HANDLE hOut;
DWORD dwNumberOfBytes;
   FILE* fp;


	TCHAR stdPath[30] = TEXT("c.txt");
	hOut = CreateFile(stdPath, GENERIC_WRITE, 0, NULL,
		CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);

	if (hOut == INVALID_HANDLE_VALUE) {
		printf("ERROR %x \n", GetLastError());
		getchar();

		return 2;
	}

	else
	{
		WriteFile(hOut, Buffer, 256, &dwNumberOfBytes, NULL);
		printf("Created and Written!");
		getchar();
		CloseHandle(hOut);
	}

	return 0;
}
*/

//Чтение ранее созданного файла средствами API + .
//Используется функция  ReadFile.
/*
#include <string.h>
#include <stdio.h>
#include "windows.h"
#include <tchar.h>

int _tmain(int argc, _TCHAR* argv[])
{
	TCHAR Buffer[256];
	HANDLE hIn;
	DWORD dwNumberOfBytes;
	FILE* fp;


	TCHAR stdPath[30] = TEXT("my_api2.txt");

	hIn = CreateFile(stdPath, GENERIC_READ, 0, NULL,
		OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);

	if (hIn == INVALID_HANDLE_VALUE) {
		printf("ERROR %x \n", GetLastError());
		getchar();

		return 2;
	}

	else
	{
		ReadFile(hIn, Buffer, 256, &dwNumberOfBytes, NULL);
		printf("DataRead!");
		getchar();
		CloseHandle(hIn);
	}

	return 0;
}*/
//то же самое
/*
#include <string.h>
#include <stdio.h>
#include "windows.h"
#include <tchar.h>
#include <iostream>
int _tmain(int argc, _TCHAR* argv[])
{

	TCHAR Buffer[256];
	HANDLE hIn;
	DWORD dwNumberOfBytes;
	FILE* fp;


	TCHAR stdPath[30] = TEXT("my_api2.txt");

	hIn = CreateFile(stdPath, GENERIC_READ, 0, NULL,
		OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);

	if (hIn == INVALID_HANDLE_VALUE) {
		printf("ERROR %x \n", GetLastError());
		getchar();

		return 2;
	}

	else
	{
		ReadFile(hIn, Buffer, 256, &dwNumberOfBytes, NULL);
		std::wcout << "Read: " << Buffer << '\n';
		getchar();
		CloseHandle(hIn);
	}


	return 0;
}*///тоже самое



//Данные считываются в массив символов Buffer. 
//Вывод массива на консоль.
/*
#include <string.h>
#include <stdio.h>
#include "windows.h"
#include "iostream"
#include <tchar.h>

int _tmain(int argc, _TCHAR* argv[])
{

	TCHAR Buffer[256];
	HANDLE hIn;
	DWORD dwNumberOfBytes;
	FILE* fp;


	TCHAR stdPath[30] = TEXT("my_api2.txt");

	hIn = CreateFile(stdPath, GENERIC_READ, 0, NULL,
		OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);

	if (hIn == INVALID_HANDLE_VALUE) {
		printf("ERROR %x \n", GetLastError());
		getchar();

		return 2;
	}

	else
	{
		ReadFile(hIn, Buffer, 256, &dwNumberOfBytes, NULL);
		std::wcout << "Read: " << Buffer << '\n';
		getchar();
		CloseHandle(hIn);
	}
	return 0;
}*/


//ИСПОЛЬЗОВАНИЕ ФУНКЦИЙ API WINDOWS для переименования, перемещения и удаления файла.

//КОПИРОВАНИЕ ФАЙЛА.

/*
#include <string.h>
#include <stdio.h>
#include "windows.h"
#include <iostream>
#include <tchar.h>

int _tmain(int argc, _TCHAR* argv[])
{

	TCHAR Buffer[256];
	HANDLE hIn;
	DWORD dwNumberOfBytes;
	FILE* fp;
	BOOL pr2 = 0;

	TCHAR stdPathA[30] = TEXT("my_api2.txt");
	TCHAR stdPathB[30] = TEXT("my_api3.txt");

	BOOL pr = CopyFile(stdPathA, stdPathB, pr2);// третий аргумент указывает что вернуть в случае успешного копирования файла?..
	if (pr)
	{
		printf("COPIED");
		getchar();

	}
	else
	{
		printf(" NOT COPIED");
		getchar();

	}
}*/


//ПЕРЕМЕЩЕНИЕ ФАЙЛА(+переименование)
/*
#include <string.h>
#include <stdio.h>
#include "windows.h"
#include "iostream"
#include <tchar.h>

int _tmain(int argc, _TCHAR* argv[])
{
	FILE* fp;
	BOOL pr2 = 0;

	TCHAR stdPathA[30] = TEXT("my_api2.txt");
	TCHAR stdPathB[30] = TEXT("my_api4.txt");//если перемещение не удается, возможно, в той папке уже есть файл с таким именем!
											 //таким же образом делается и переименование файла
	BOOL pr = MoveFile(stdPathA, stdPathB);
	if (pr)
	{
		printf("MOVED");
		getchar();
	}
	else
	{
		printf(" NOT MOVED");
		getchar();

	}

	return 0;
}*/


//УДАЛЕНИЕ ФАЙЛА.
/*
#include <string.h>
#include <stdio.h>
#include "windows.h"
#include "iostream"
#include <tchar.h>

int _tmain(int argc, _TCHAR* argv[])
{


	TCHAR Buffer[256];
	HANDLE hIn;
	DWORD dwNumberOfBytes;

	TCHAR stdPathA[30] = TEXT("c2.txt");//создать его потом


	BOOL pr = DeleteFile(stdPathA);
	if (pr)
	{
		printf("DELETED");
		getchar();

	}
	else
	{
		printf(" NOT DELETED");
		getchar();

	}

	return 0;
}*/




//ОПРЕДЕЛЕНИЕ ТЕКУЩЕГО КАТАЛОГА

/*

#include <string.h>
#include <stdio.h>
#include "windows.h"
#include "iostream"
#include <tchar.h>

int _tmain(int argc, _TCHAR* argv[])
{

	TCHAR Buffer[256];
	DWORD dwResult = GetCurrentDirectory(256, Buffer);//получение текущего каталога.. первое - размер записи, второе - куда записывать
	std::wcout << "Dir: " << Buffer << '\n';
	getchar();
	return 0;
}*/




//СМЕНА КАТАЛОГА(?)

/*
#include <string.h>
#include <stdio.h>
#include "windows.h"
#include "iostream"
#include <tchar.h>

int _tmain(int argc, _TCHAR* argv[])
{
	TCHAR Buffer[256];
	TCHAR Buffer2[] = TEXT("e:\\work\\");
	DWORD dwResult = GetCurrentDirectory(256, Buffer);
   // std::wcout << "Dir: " << Buffer << '\n';//закомментировано ибо без этого не выводит 2 сторки почему-то
	BOOL b = SetCurrentDirectory(Buffer2);//возвращает 1
	dwResult = GetCurrentDirectory(256, Buffer);
	std::wcout << "Dir: " << Buffer << '\n';
	getchar();
	return 0;
}*/

//СОЗДАНИЕ КАТАЛОГА

/*
#include <string.h>
#include <stdio.h>
#include "windows.h"
#include "iostream"
#include <tchar.h>

int _tmain(int argc, _TCHAR* argv[])
{

	TCHAR Buffer[256];
	TCHAR Buffer3[] = TEXT("e:\\newAA");

	if (CreateDirectory(Buffer3, NULL))
		std::wcout << "directory create" << '\n';
	else
		std::wcout << "error create directory" << '\n';
	getchar();

	return 0;
}*/
/*
1.	Рассмотреть и выполнить приведенные примеры.
2.	Создать программно два каталога.
3.	В первом каталоге создать текстовый файл и записать в него текст.
4.	Скопировать созданный файл из первого каталога во второй.
5.	Удалить файл из первого каталога.
6.	Переименовать файл во втором каталоге и прочитать его содержимое.
*/

#include <string.h>
#include <stdio.h>
#include "windows.h"
#include "iostream"
#include <tchar.h>

int _tmain(int argc, _TCHAR* argv[])
{
	TCHAR Buffer[256] = TEXT("This text?\nYes");
	TCHAR Buffer3[256];
	TCHAR Buffer1[] = TEXT("newA1");
	TCHAR Buffer1_1[] = TEXT("newA1\\txt1.txt");//не забыть после запуска программы его и еще один удалить, чтобы снвоа программа работала
	TCHAR Buffer2[] = TEXT("newA2");
	TCHAR Buffer2_1[] = TEXT("newA2\\txt1.txt");
	TCHAR Buffer2_2[] = TEXT("newA2\\2TXT2.txt");
	DWORD nLenCurDir;
	DWORD dwNumberOfBytes;//количество байт
	HANDLE hOut;
	if ((CreateDirectory(Buffer1, NULL)) && (CreateDirectory(Buffer2, NULL)))// второй параметр - аттрибут безопасности... (read, write and так далее?) 
		std::wcout << "directories create";
	else
		std::wcout << "error create directories";
	getchar();
	hOut = CreateFile(Buffer1_1, GENERIC_WRITE, 0, NULL,
		CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);
	if (hOut == INVALID_HANDLE_VALUE) {
		printf("ERROR %x \n", GetLastError());
		getchar();

		return 2;
	}

	else
	{
		WriteFile(hOut, Buffer, 256, &dwNumberOfBytes, NULL);
		printf("Created and Written!");
		getchar();
		CloseHandle(hOut);
	}

	BOOL pr2 = 0;
	BOOL pr = CopyFile(Buffer1_1, Buffer2_1, pr2);// третий аргумент - операция, есил файл существует
	if (pr)
	{
		printf("COPIED");
		getchar();

	}
	else
	{
		printf(" NOT COPIED");
		getchar();

	}
	DeleteFile(Buffer1_1);
	std::wcout << "File delete";//удалить из первого каталога
	getchar();
	BOOL pr1 = MoveFile(Buffer2_1, Buffer2_2);
	if (pr1)
	{
		printf("MOVED");
	}
	else
	{
		printf(" NOT MOVED");

	}
	getchar();
	hOut = CreateFile(Buffer2_2, GENERIC_READ, FILE_SHARE_READ, NULL, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);
	ReadFile(hOut, Buffer3, 256, &dwNumberOfBytes, NULL);//дескриптор файла, который читаем, буффер, куда запиываем, сколько разписываеn колво байт которые читаются из файла,
	std::wcout << "Read:\n" << Buffer3 << '\n';
	return 0;
}