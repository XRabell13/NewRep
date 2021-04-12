#define _CRT_SECURE_NO_WARNINGS
#include <stdlib.h>
#include <stdio.h>
#include <conio.h>
#include <clocale>
#include <iostream>
using namespace std;
int main()
{
	setlocale(LC_CTYPE, "RUS");
	int a[20], t = 0, k = 0;
	FILE* fileA,*g, *fileB; //указатели на файлы для считывания и записи
	fileB = fopen("fileB.txt", "w");
	fileA = fopen("fileA.txt", "r");
		for (int i = 0; i < 10; i++)
		{
			fscanf_s(fileA, "%d", &a[i]);
			printf("%d ", a[i]);
		}

		for (int i = 0; i < 10; i++)
		{
			for (int j = 0; j < 10; j++)
				if (a[i] == a[j])
				{
					k++;
				}
			
			if (k > 2)
			{
				fprintf(fileB, "%d ", a[i]);
			}
			k = 0; t = 0;
		}
		fclose(fileA);
		fclose(fileB);

		g = fopen("g.txt", "w");
		if ((fileB = fopen("fileB.txt", "r")) == NULL)
			printf("Error!");
		else {
			for (int i = 0; i < 100 && !feof(fileB);) {
				fscanf_s(fileB, "%d", &a[i]);
				for (int j = t = 0; j < i && t == 0; ++j)
					t = (a[j] == a[i]);
				if (t == 0)
				{
					fprintf(g, "%d ", a[i++]);
				}
			}
			fclose(fileB);
			fclose(g);
		}

	printf("Файл создан!");
	fclose(g);
	fclose(fileB);
}
