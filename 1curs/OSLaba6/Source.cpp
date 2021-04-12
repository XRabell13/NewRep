//������ ���������� �����.��������: ���� ������ ���� ������� �����������.
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

//������ � ����������� ������� �� ���������� �����
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


//�������� ����� ���������� API.
//������������ ������� CreateFile.
//���� ���� ����������, �� �� �������������, � ��� ���������� ���������.
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

	if (hOut == INVALID_HANDLE_VALUE)//������ �������� �����������
	{
		printf("ERROR %x \n", GetLastError());// ������� ����� ������.. ����� ��
		getchar();
		return 2;
	}

	else
	{
		//nLenCurDir = GetCurrentDirectory(256, Buffer);//������ � ����� ���� ������������ �����
		WriteFile(hOut, Buffer, 256, NULL, NULL );
		printf("Created");
		getchar();
		CloseHandle(hOut);
	}

	return 0;
}*/



//�������� ����� ���������� API + ������ � ���� ������ �� ������.
//������������ ������� WriteFile.
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

//������ ����� ���������� ����� ���������� API + .
//������������ �������  ReadFile.
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
//�� �� �����
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
}*///���� �����



//������ ����������� � ������ �������� Buffer. 
//����� ������� �� �������.
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


//������������� ������� API WINDOWS ��� ��������������, ����������� � �������� �����.

//����������� �����.

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

	BOOL pr = CopyFile(stdPathA, stdPathB, pr2);// ������ �������� ��������� ��� ������� � ������ ��������� ����������� �����?..
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


//����������� �����(+��������������)
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
	TCHAR stdPathB[30] = TEXT("my_api4.txt");//���� ����������� �� �������, ��������, � ��� ����� ��� ���� ���� � ����� ������!
											 //����� �� ������� �������� � �������������� �����
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


//�������� �����.
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

	TCHAR stdPathA[30] = TEXT("c2.txt");//������� ��� �����


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




//����������� �������� ��������

/*

#include <string.h>
#include <stdio.h>
#include "windows.h"
#include "iostream"
#include <tchar.h>

int _tmain(int argc, _TCHAR* argv[])
{

	TCHAR Buffer[256];
	DWORD dwResult = GetCurrentDirectory(256, Buffer);//��������� �������� ��������.. ������ - ������ ������, ������ - ���� ����������
	std::wcout << "Dir: " << Buffer << '\n';
	getchar();
	return 0;
}*/




//����� ��������(?)

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
   // std::wcout << "Dir: " << Buffer << '\n';//���������������� ��� ��� ����� �� ������� 2 ������ ������-��
	BOOL b = SetCurrentDirectory(Buffer2);//���������� 1
	dwResult = GetCurrentDirectory(256, Buffer);
	std::wcout << "Dir: " << Buffer << '\n';
	getchar();
	return 0;
}*/

//�������� ��������

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
1.	����������� � ��������� ����������� �������.
2.	������� ���������� ��� ��������.
3.	� ������ �������� ������� ��������� ���� � �������� � ���� �����.
4.	����������� ��������� ���� �� ������� �������� �� ������.
5.	������� ���� �� ������� ��������.
6.	������������� ���� �� ������ �������� � ��������� ��� ����������.
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
	TCHAR Buffer1_1[] = TEXT("newA1\\txt1.txt");//�� ������ ����� ������� ��������� ��� � ��� ���� �������, ����� ����� ��������� ��������
	TCHAR Buffer2[] = TEXT("newA2");
	TCHAR Buffer2_1[] = TEXT("newA2\\txt1.txt");
	TCHAR Buffer2_2[] = TEXT("newA2\\2TXT2.txt");
	DWORD nLenCurDir;
	DWORD dwNumberOfBytes;//���������� ����
	HANDLE hOut;
	if ((CreateDirectory(Buffer1, NULL)) && (CreateDirectory(Buffer2, NULL)))// ������ �������� - �������� ������������... (read, write and ��� �����?) 
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
	BOOL pr = CopyFile(Buffer1_1, Buffer2_1, pr2);// ������ �������� - ��������, ���� ���� ����������
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
	std::wcout << "File delete";//������� �� ������� ��������
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
	ReadFile(hOut, Buffer3, 256, &dwNumberOfBytes, NULL);//���������� �����, ������� ������, ������, ���� ���������, ������� ����������n ����� ���� ������� �������� �� �����,
	std::wcout << "Read:\n" << Buffer3 << '\n';
	return 0;
}