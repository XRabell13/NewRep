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
	int i, a[100], t;
	FILE* f, * g; //��������� �� ����� ��� ���������� � ������
/*errno_t err;

	err = fopen_s(&f, "f.txt", "w"); // ������� ���� ��� ������ �������� ����
	if (err != 0) {
		perror("������ �������� f.txt");
		return;
	}

	cout << "������� ���������� ��������: " << endl; int n; cin >> n;//����������  � �������� ��������
	int* source = new int[n];
	cout << "������� �������� �������: " << endl;
	for (int g = 0, u = 0; g < n; g++) {

			cin >> source[u];
			fprintf(f, "%d\t", source[u]);
		}
	fclose(f);

	delete[] source;*/

	if ((f = fopen("f.txt", "r")) == NULL)
		printf("Error!");
	else {
		g = fopen("g.txt", "w");
		for (i = 0; i < 100 && !feof(f);) {
			fscanf_s(f, "%d",&a[i]);
			for (int j = t = 0; j < i && t == 0; ++j)
				t = (a[j] == a[i]);
			if (t == 0)
			{
				fprintf(g, "%d ", a[i++]);
			}
		}
		printf("���� ������!");
		fclose(f);
		fclose(g);
	}
}