#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	int m = 0, number = 0, pr = 0;
	long fsize;
	char pd;
	FILE* fd, *b;
	errno_t err;
	err = fopen_s(&fd, "a.txt", "r");
	if (err != 0)
	{
		perror("������ �������� a.txt");
		return;
	}
	b = fopen("b.txt","w");

	fseek(fd, 0L, SEEK_END);
	fsize = ftell(fd);
	fseek(fd, 0L, SEEK_SET);

	for (int k = 1; k <= fsize; k++)
	{
		fread((void*)& pd, sizeof(char), 1, fd);/*������ ������ � ���������� ��� � pd... � ����� ���������� � ����� ��������� �����...
												����� ������� ��� ��, �� ����� �� �������� �... ������ �� �����? ����� ���� ���� ������� � ����������
												�� ��� ������ ��������� ����� ||.� ����� ������ �������� ����������� �� �����. ���� ����������� �����,
												�� ����� ������... break. � ����� ������ ����� ����� � �����...*/
		if (pd == '1' || pd == '2' || pd == '3' || pd == '4' || pd == '5' || pd == '6' || pd == '7' || pd == '8' || pd == '9' || pd == '0')
		{
			fprintf(b, " %c", pd);
			while (pd != '.')
			{
			fread((void*)& pd, sizeof(char), 1, fd);
			fprintf(b,"%c", pd);
			}
		}
	}
	printf("���� ������!");
	fclose(fd);
	fclose(b);
}
