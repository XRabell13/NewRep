#include "windows.h"
#include <iostream>
#include <tlhelp32.h>
#include "string.h"
int main()
{

	HANDLE consoleOutput;
	COORD cursorPos;

	// �������� ����� ������� 
	consoleOutput = GetStdHandle(2);//STD_OUTPUT_HANDLE

	// ������ ���������� ������� � ���������� ������
	cursorPos.X = 30;
	cursorPos.Y = 3;
	SetConsoleCursorPosition(consoleOutput, cursorPos);

	// ������� ������
	printf("Test string at position (30, 3)");

	// ��������� � ������� ������������...
	cursorPos.X = 15;
	cursorPos.Y = 8;
	SetConsoleCursorPosition(consoleOutput, cursorPos);

	printf("Test string at position (15, 8)");
	
	return 0;
}
