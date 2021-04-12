/*������ � ���������� ������ ��������, ��������� �� ����, ����, �������, �����, ������ + � -, � �������� �� � ����. 
��������� �� ����� ������ � ��������� � ������� ���������� �������.

�� ������ ��������� ���� ���������� � ���������� � ����� � ���������� ���� ������ �������������� � ������� �������,
� ������ � ���� � ������ �� ����� � �������� ������������.
*/

#include <iostream>
#include <fstream>
using namespace std;
int inFile(ifstream& f, char str[]); //������� ������ �� ����� � �������� ����� �������
void fromFile(ofstream& f, char str[]); //������� ������ � ����

void main()
{
	setlocale(LC_ALL, "Russian");
	int a;
	char str[40];
	ifstream ifile;
	ofstream ofile;
	cout << "������� ������: \n";
	cin >> str;
	fromFile(ofile, str);
	a = inFile(ifile, str);
	cout << "�����: " << str<<endl;
	cout << "���������� �������: "<<a;

}

void fromFile(ofstream& f, char str[]) //������� ������ � ����
{
	f.open("FILE1.txt");
	if (f.fail())
	{
		cout << "\n ������ �������� �����";
		exit(1);
	}
	f << str;            //������ ����� �� ���������� a � ���� 
	f.close();
}

int inFile(ifstream&f, char str[]) //������� ������ �� ����� � ����������� ����� �������
{
	int a=0, l;

	f.open("FILE2.txt");
	if (f.fail())  //�������� �������� �����
	{
		cout << "\n ������ �������� �����";
		exit(1);
	}

	l = strlen(str);
	for (int i = 0; i < l; i++)
	{
		if (str[i] == ',') a++;
	}

	f.close();
	return a;
}
