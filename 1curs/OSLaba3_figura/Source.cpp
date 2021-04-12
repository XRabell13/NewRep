/*#include <windows.h>
#include <stdio.h>
enum ConsoleColor {
	Black = 0,
	Blue = 1,
	Green = 2,
	Cyan = 3,
	Red = 4,
	Magenta = 5,
	Brown = 6,
	LightGray = 7,
	DarkGray = 8,
	LightBlue = 9,
	LightGreen = 10,
	LightCyan = 11,
	LightRed = 12,
	LightMagenta = 13,
	Yellow = 14,
	White = 15
};
int main()
{
	DWORD l;
	COORD point;
	point.X = 0; point.Y = 0;
	HANDLE hout = GetStdHandle(STD_OUTPUT_HANDLE);
	SetConsoleTextAttribute(hout, 8);
	/*for (int y = 0; y < 16; y++) {
		point.Y = y;
		FillConsoleOutputAttribute(hout, y << 4, 80, point, &l);
		SetConsoleCursorPosition(hout, point);
	}
	//getchar();
	return 0;
}*/
#include <windows.h>
#include <iostream>
enum ConsoleColor {
	Black = 0,
	Blue = 1,
	Green = 2,
	Cyan = 3,
	Red = 4,
	Magenta = 5,
	Brown = 6,
	LightGray = 7,
	DarkGray = 8,
	LightBlue = 9,
	LightGreen = 10,
	LightCyan = 11,
	LightRed = 12,
	LightMagenta = 13,
	Yellow = 14,
	White = 15
};
const WORD colors[] =
	{
	0x1A, 0x2B, 0x3C, 0x4D, 0x5E, 0x6F,
	0xA1, 0xB2, 0xC3, 0xD4, 0xE5, 0xF6
	};

int main()
{
	HANDLE consoleOutput;
	COORD cursorPos;
    HANDLE hstdout = GetStdHandle(STD_OUTPUT_HANDLE);
	int index = 1;
	// Получаем хэндл(дескриптор) консоли 
	consoleOutput = GetStdHandle(STD_OUTPUT_HANDLE);

	// Задаем координаты курсора и перемещаем курсор
	cursorPos.X = 0;
	cursorPos.Y = 0;
	SetConsoleCursorPosition(consoleOutput, cursorPos);
		printf("Hello~~");

		while (index < 13)
		{
			cursorPos.Y = index;
			SetConsoleCursorPosition(consoleOutput, cursorPos);
			SetConsoleTextAttribute(hstdout, (WORD)(Yellow<<4|Red));
			printf(" ");
			if (++index > 12)
				break;
		}
		index = 0;
		while (index < 13)
		{
			cursorPos.X = index;
			SetConsoleCursorPosition(consoleOutput, cursorPos);
			SetConsoleTextAttribute(hstdout, (WORD)(Yellow << 4 | Red));
			printf(" ");
		
			if (++index > 12)
				break;
		}
		cursorPos.Y = 1;
		index = 0;
		while (index < 13)
		{
			cursorPos.X = index;
			SetConsoleCursorPosition(consoleOutput, cursorPos);
			SetConsoleTextAttribute(hstdout, (WORD)(Yellow << 4 | Red));
			printf(" ");

			if (++index > 12)
				break;
		}
		cursorPos.X = 13;
		index = 1;
		while (index < 13)
		{
			cursorPos.Y = index;
			SetConsoleCursorPosition(consoleOutput, cursorPos);
			SetConsoleTextAttribute(hstdout, (WORD)(Yellow << 4 | Yellow));
			printf(" ");

			if (++index > 12)
				break;
		}
		cursorPos.X = 4;
		cursorPos.Y = 6;
		SetConsoleCursorPosition(consoleOutput, cursorPos);
		SetConsoleTextAttribute(hstdout, (WORD)(Black<<4|Blue));
		printf("Hello");
		cursorPos.X = 0;
		cursorPos.Y = 15;
		SetConsoleCursorPosition(consoleOutput, cursorPos);


			SetConsoleTextAttribute(hstdout, (WORD)(Black|Red));
			getchar();
	return 0;
}