//����� �� ������� ����� ����� ���������������� ������ � �������� � NameD ����������� �� ��� �����
/*������� 3 ���������� �������, ������� ����� �������� � ����� ����� ���������� ��������
� ����� � ��� �� ������� � ���������� ����������� ������� � ��������� ���������� ������(��� ����� � ����)� ����� ���� ������ �������� � ����*/
#include <iostream>
#include <fstream>
#include <stdio.h>
int main()
{
	using namespace std;
	setlocale(LC_CTYPE, "Rus");
	FILE* fAptr, * fBptr, *fCptr, *fDptr; //��������� �� ����� ��� ���������� � ������
	errno_t err;
	int min=0, j=0;
	char cmin;

	err = fopen_s(&fAptr, "NameA.txt", "wb"); // ������� ���� ��� ������ �������� ����
	if (err != 0) {
		perror("������ �������� NameA.txt");
	}
	/*����� ��������� � ��������� ���� ����� ������ ��������� ������, � ����� �... 
	� ����� �� ������� ���, ���� ������������ ���� ������� ��������� ������ ������? ��*/
	cout << "������� ���������� ����� � �����:" << endl; 

	int n=1; cin >> n; //����������  � �������� ��������

	int* NameA = new int[n];
	int* NameB = new int[n];
	int* NameC = new int[n];
	int* NameD = new int[n];

	cout << "������� ����� � NameA: " << endl;
	for (int u = 0; u < n; u++) {
		cin >> NameA[u];
		fprintf(fAptr, "%d\t", NameA[u]);
	}

	fclose(fAptr); //������� ���� 

	err = fopen_s(&fBptr, "NameB.txt", "wb"); // ������� ���� ��� ������ �������� ����
	if (err != 0) {
		perror("������ �������� NameA.txt");
	}

	cout << "������� ����� � NameC: " << endl;
	for (int u = 0; u < n; u++) {
			cin >> NameB[u];
			fprintf(fBptr, "%d\t", NameB[u]);
		}

	
	fclose(fBptr); //������� ���� 

	err = fopen_s(&fCptr, "NameC.txt", "wb"); // ������� ���� ��� ������ �������� ����
	if (err != 0) {
		perror("������ �������� NameC.txt");
	}

	cout << "������� ����� � NameC: " << endl;
	for (int u = 0; u < n; u++) {
		cin >> NameC[u];
		fprintf(fCptr, "%d\t", NameC[u]);
	}

	fclose(fCptr); //������� ���� 

	err = fopen_s(&fDptr, "NameD.txt", "wb");
	if (err != 0) {
		perror("������ �������� NameD.txt");
	}

	for(int i=0; i<n;i++)// n ����� �����
	 { 
			min = NameA[i];
			if (min > NameB[i]) min = NameB[i];
		    if (min > NameC[i]) min = NameC[i];
			fprintf_s(fDptr, "%d", min);
	}
			//fwrite(cmin, strlen(cmin), 1, fDptr);//����� ������ ������ ������ ���������� � ����

	delete[] NameA;
	delete[] NameB;
	delete[] NameC;
}