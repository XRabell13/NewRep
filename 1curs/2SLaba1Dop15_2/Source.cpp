#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	int m = 0, number = 0, pr = 0;
	long fsize, size;
	char pd;
	FILE* fd, * b;
	errno_t err;
	err = fopen_s(&fd, "a.txt", "r");
	if (err != 0)
	{
		perror("ошибка открытия a.txt");
		return;
	}
	b = fopen("b.txt", "w");
	fseek(fd, 0L, SEEK_END);
	fsize = ftell(fd);
	fseek(fd, 0L, SEEK_SET);

	printf("Введите номер предложения ");
	scanf("%d", &number);
	for (int k = 1; k <= fsize; k++)
	{
		fread((void*)& pd, sizeof(char), 1, fd);
		if (pd == '.')   pr++;
		if ((number - 1) == pr)  m++;
		if (number == pr)
		{
			long pos2, pos1 = k - m - 1;
			int kol, j=0;
	
			
			if (number != 1) pos1++;
			fseek(fd, pos1, SEEK_SET);
			while (j != 4)
			{
				fread((void*)& pd, sizeof(char), 1, fd);
				fprintf(b,"%c", pd);
				if (pd=='.')
				j++;
			}
			break;
		}
	}
	if (number > pr)
		printf("Такого номера нет");
	printf("Предложения в документе b");
	fclose(fd);
	fclose(b);
}
