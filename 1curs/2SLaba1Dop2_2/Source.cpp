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
	/*finput ������� ��� ������ ������ file.txt*/
	FILE* finput;
	int s;
	finput = fopen("file.txt", "r+");

	while ((fscanf(finput, "%d", &s) != EOF))
	{
		if (!finput) break;    //����� �� ����� �������
		k++;
	}
	int* c = (int*)malloc(k * sizeof(int));  /* malloc ������������ ��������� ������.
	����� ������������, ��� ���������� �� ������� ����� ������� ����.
	��������� ������ ������ � ������� �������� sizeof() */
	rewind(finput); //������������� ��������� �� ������ � �����,����� ����� ��������� ����

	//������� �� ������ ������ ���� F2,���� ����� ���������� ����������� ������ �� finput
	FILE* F2;
	F2 = fopen("file2.txt", "wt");
	//���������� � F2 5 �������
	cout << "������� ����� ������(�� ������ 5): "; cin >> k;
	for (int i = 0; i < 8; i++)
	{
		fscanf(finput, "%d", &c[i]);
	}
	for (i=k; k <(i+3); k++)
	{
		fprintf(F2, "%d\n", c[k]);
	}
	fclose(finput); //��������� ����

	free(c); //������������� ������ 
	fclose(F2);//��������� ����
	printf("���� ������");
	return 0;
}
