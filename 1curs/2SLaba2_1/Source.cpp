/*����������� �� ����� FILE1 � ���� FILE2 ��� ������, 
� ������� ���� �����, ����������� � ������ ������.
���������� ���������� ������� ���� � ��������� ������  ����� FILE2.*/
/*#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	int m = 0, number = 0, pr = 0;
	long fsize;
	char pd;
	FILE* fd, * b;
	errno_t err;
	err = fopen_s(&fd, "a.txt", "r");
	if (err != 0)
	{
		perror("������ �������� a.txt");
		return;
	}
	b = fopen("b.txt", "w");

	fseek(fd, 0L, SEEK_END);
	fsize = ftell(fd);
	fseek(fd, 0L, SEEK_SET);

	for (int k = 1; k <= fsize; k++)
	{
		fread((void*)& pd, sizeof(char), 1, fd);/*������ ������ � ���������� ��� � pd... � ����� ���������� � ����� ��������� �����...
												����� ������� ��� ��, �� ����� �� �������� �... ������ �� �����? ����� ���� ���� ������� � ����������
												�� ��� ������ ��������� ����� ||.� ����� ������ �������� ����������� �� �����. ���� ����������� �����,
												�� ����� ������... break. � ����� ������ ����� ����� � �����...
		if (pd == '1' || pd == '2' || pd == '3' || pd == '4' || pd == '5' || pd == '6' || pd == '7' || pd == '8' || pd == '9' || pd == '0')
		{
			fprintf(b, " %c", pd);
			while (pd != '.')
			{
				fread((void*)& pd, sizeof(char), 1, fd);
				fprintf(b, "%c", pd);
			}
		}
	}
	printf("���� ������!");
	fclose(fd);
	fclose(b);
}*/

/*#include <fstream>
#include <iostream>
using namespace std;
void main()
{
	setlocale(LC_ALL, "rus");
	char buff[100], firstword;            // ����� ��� �������� ������������ �� ����� ������   
	ifstream fin("FILE1.txt");    // �������� ������� fin ������ ifstream ��� ������  
	if (!fin.is_open())
		cout << "���� �� ����� ���� ������!\n";
	else
	{
		fin >> firstword;           // ���������� ������� ����� �� �����
		fin.close();
		cout << firstword << endl;   // ������ ������
	}
}*/
/*��������� � ����� ����������� �� ����� �� �����, � ����� ������ ����� �� ����� ����������� ��������� � ������ ������...
��� �� ����� ������ ����� � ����������� � ���������� � ������ ������� �����... ���� ������ ����������, ���������� �����������. ���� 
��� �� �����������, �� */
#define _CRT_SECURE_NO_WARNINGS
#include <fstream>
#include <iostream>
using namespace std;
void main()
{
	setlocale(LC_ALL, "rus");
	char first[50], buff[100], buff1[100], first1[100], wort[] = "           ", buff2[50];
	int k = 0, n = 0, fsize, worts = 0, chars = 0, fwort = 0;
	ifstream fin("t.txt"); // �������� ������� fin ������ ifstream ��� ������ (�������� � fin = fopen("FILE1.txt", "r")), �� ������ fin - ������
	ofstream fout("t1.txt");
	FILE* fin1, * fout12;
	fin1 = fopen("t.txt", "r");

	ofstream fout1("t2.txt");
	ifstream fout1r("t2.txt");
	if (!fin.is_open())
		cout << "���� �� ����� ���� ������!\n";
	else
	{

		fseek(fin1, 0L, SEEK_END);
		fsize = ftell(fin1);//����� ��������
		fseek(fin1, 0L, SEEK_SET);

		fsize++; //����� �������� �� ���� ���������, ��� ��������� ������ �� ������ � �����(?)
		fin >> first;
		fout1 << first;
		fwort = strlen(first);//����� �������� � �����

		fin.getline(first1, 100, '.');//�������� ������ �����������, �� ��� ��������� ��� ��� � ��� ����� ����������� �������� � ����
		fout1 << first1 << ". ";
		fgets(buff, fsize, fin1); //�������� � ������ ������ �����


		for (int i = 0; i < fsize; i++)
			if (buff[i] == '.') k++; // ������ ���������� �����������


		for (int i = 0; i < k - 1; i++)
		{
			fin.getline(buff1, 20, '.');
			n = strlen(buff1);// ����� �������� � �����������

			int y = 0;

			for (int j = 0; j <= n; j++)
			{
				// ������ � ������ �����
				if ((buff1[j] != ' ') & (buff1[j] != '.'))
				{
					wort[y] = buff1[j];

					y++;
				}
				else// ���� ������ ��� ����� �����������
				{

					int l = 0;
					while (wort[l] != ' ')
					{
						chars++;//���������� �������� � �����
						l++;
					}

					// ���� ���������� ����� ��������, ���������, ���������� �� ���
					if (chars == fwort)
					{

						int p = 0;
						for (int h = 0; h < 3; h++)
							if (wort[h] == first[h])
							{
								p++;
								if (p == 3)fout1 << buff1 << ".";// ������ � ����
							}
						y = 0;
						for (int ii = 0; ii < 11; ii++)
							wort[ii] = ' ';
					}
				}
				chars = 0;


			}
			for (int ii = 0; ii < 11; ii++)
				wort[ii] = ' ';
		}
	}
	fin.close();
	fout.close();
	fout1.close();
	fout1r.close();
	fclose(fin1);

	// ������ ���� �������, ����� ���������� ���������
	// ����� ���������� �����, � ����� ������� ��� ������������ ������� � ����� �� �����.
	// ������� ���� ����� �� ����� ����������, ���� ���������� ����, �� �++

	fout12 = fopen("t2.txt", "r");
	ifstream fout122("t2.txt");

	fseek(fout12, 0L, SEEK_END);
	fsize = ftell(fout12);//����� ��������
	fseek(fout12, 0L, SEEK_SET);

	fsize++;
	cout << endl << fsize << endl;

	for (int ii = 0; ii < fsize; ii++)
		buff2[ii] = ' ';

	fout122.getline(buff2, fsize); //�������� � ������ ������ �����
	cout << buff2 << endl;

	k = 0;
	for (int i = 0; i < fsize; i++)
		if (buff2[i] == '.') k++; // ������ ���������� �����

	char sogl[] = "EYUIOAJeyioaj";
	int g = 0, q=0, s=0;

	g = strlen(sogl);

	for (int i = 0; i < fsize; i++)
	{
		if ((buff2[i] == '.') & (q!=2)) q++;
		if (q == 2)
		{
			for (int j = 0; j < g; j++)
				if (buff[i] == sogl[j]) s++;
		}
	}
	cout << "���������� �������: " << s;
	fclose(fout12);
	fout122.close();
}



/*string line, firstWord, word;
while (getline(in, line))
{
	stringstream ss(line);
	bool hasEquals = false;
	ss >> firstWord;
	while (ss >> word)
	{
		if (word == firstWord)
		{
			hasEquals = true;
			break;
		}
	}
	if (hasEquals) out << line << endl;
}



fin.getline(buff, 100, ' ');//���������� ������ � 10 �������� � ������ �� ������� " "
		cout << buff << "        ";
		fin >> first;           // ���������� ������� ����� �� �����
		cout << first << endl;  // ������ �����

		for (int i = 0; i < 30; i++)
		{
			fin.getline(buff, 40, ' ');//����� ����������
			cout << buff << ' ';
			k = strlen(buff);
			cout << k;
			if (k == strlen(first))
			{
				for (int j = 0; j < k; j++)
				{
					if (buff[j] == first[j]) n++;
				}

			}

			if (n == k)
			{
				fin.getline(buff1, 40, '.');
				cout << buff1;
				cout << buff1 << "." << endl;
				cout << "sdfsdfsfs";
			}
			n = 0;
			//cout << buff << "." << endl;*/

