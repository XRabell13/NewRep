/*#define _CRT_SECURE_NO_WARNINGS
#include <stdlib.h>
#include <stdio.h>
#include <conio.h>
#include <clocale>
#include <iostream>
using namespace std;
int main()
{
	setlocale(LC_CTYPE, "RUS");
	int i, a[50], t=0, k=0;
	FILE* fileA, * fileB, *g; //��������� �� ����� ��� ���������� � ������

	if ((fileA = fopen("fileA.txt", "r")) == NULL)
		printf("Error!");
	else {
		for (int i = 0; i < 10; i++)
			fscanf(fileA, "%d", &a[i]);

		g = fopen("g.txt", "w");
		for (i = 0; i < 10 && !feof(fileA);)
		{
			for (int j = 0; j < 50; j++)
			{
				if (a[i] == a[j])
				{
					t = a[i];
					k++;
				}
			}
			//printf("%d ",k);
			if ((t != 0) && (k>2))
			{
				printf("%d ", a[i]);
				fprintf(g, "%d ", a[i]);
				
				/*������� �������� �� ��, ������ �� �����, � ���� ���� ����� ��, �� � � ����������� ����� ���������� �����.. � ����� ���� � ������ 2,
				�� ������� ��� ����� � ���
			}
			k = 0;
		    t = 0;
			i++;
		}
		printf("���� ������!");
		fclose(fileA);
		fclose(g);
	}
}
	if ((fileA = fopen("fileA.txt", "r")) == NULL)
		printf("Error!");
	else {
		fileB = fopen("fileB.txt", "w");
		for (i = 0; i < 50 && !feof(fileA);) {
			fscanf_s(fileA, "%d", &a[i]);
			for (int j = t = 0; j < i; ++j)
			{
				t = (a[j] == a[i]);
				if (t != 0)
				{
					k++;
				}
			}
			if (k>2)
			{
				fprintf(fileB, "%d ", a[i++]);
			}
			printf("%d",k);
			k = 0;
		}
		printf("���� ������!");
		fclose(fileA);
		fclose(fileB);
	}
}*/
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
	FILE* fileA, *fileB; //��������� �� ����� ��� ���������� � ������

	if ((fileA = fopen("fileA.txt", "r")) == NULL)
		printf("Error!");
	else {
		fileB = fopen("fileB.txt", "w");
		for (int i = 0; i < 10; i++)
		{
			fscanf_s(fileA, "%d", &a[i]);
	 	    printf("%d ", a[i]);
	    }

		for (int i = 0; i < 10; i++)
		{
			for (int j = 0; j < 10; j++)
			{
				if (a[i] == a[j])
				{
					k++;
				}
			}
			if (k > 3)
			{
				fprintf(fileB, "%d ", a[i]);
			}
			k = 0; t = 0;
		}	
		}
	
		printf("���� ������!");
		fclose(fileA);
		fclose(fileB);
	}

/*	for (i = 0; i < 100 && !feof(fileA);) {
			fscanf_s(fileA, "%d", &a[i]);
			for (int j = t = 0; j < i && t == 0; ++j)
				t = (a[j] == a[i]);
			if (t == 0)
			{
				fprintf(fileB, "%d ", a[i++]);
			}
		}
		*/