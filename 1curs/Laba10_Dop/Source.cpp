// 1 ������� 1 �����
/*#include <iostream> 
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	int someNumber, result=0;
	char A[15];
	cout << "�����: ";  cin >> someNumber;
	_itoa_s(someNumber, A, 2); cout << "����� � �������� �.�.: " << A << endl;
	for (int i = 3; i <= 13; ++i)
	{
		if (((someNumber >> i) ^ 0) == 0)
		{
			++result;
		}
	}
	cout << "����� � �������� ������������� �����: " <<result;

}*/
// 10 ������� 1 �����
/*#include <iostream>
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	char tmp[33];
	int A, maskA = 252;
	int maskB = ~maskA >> 1;
	cout << "������ �����="; cin >> A;
	_itoa_s(A, tmp, 2); cout << "A=" << tmp << endl;
	cout << "����� ��� �: " << tmp << endl;
	_itoa_s((A | maskA) >> 1, tmp, 2);
	cout << "���������� ���� �: " << tmp << endl;
	}
	*/
// 4 �������, 1 ����� (���������)
#include <iostream> 
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	int A, i; char tmp[33];
	cout << "������� ����� ";
	cin >> A;
	_itoa_s(A, tmp, 2);

	cout << "����� � �������� ���� = " << tmp << endl;
	if ((A & 3) == 0)
		cout << "����� ������ 4" << endl;
	else
		cout << "����� �� ������ 4" << endl;
}

/*4 �������, 2 �����(���������)
#include <iostream> 
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	int A, pos, n, razn, c; char tmp[33];
	cout << "������� ����� �: ";
	cin >> A; cout << endl;
	_itoa_s(A, tmp, 2);
	cout << "����� � � 2 c/c: " << tmp << endl;
	cout << "������� ���������� ����� ��� ����������� � 0 (n): ";
	cin >> n; cout << endl;
	cout << "������� ����� ������� p: ";// ���� ����� ���������� � 1, � �� 0.
	cin >> pos; cout << endl;
	razn = pos - n;
	c = pos; //����� �� ���������� � 0 ����� � ������� P
	while (pos >= razn)
	{
		if (c != pos)
		{
			A = A | (1 << (n + pos));//���� �������� | �� & � �������� � ������� ����� �� ������ ~, �� ����� ���������� ����������� ���� � 0
			pos--;
		}
		else pos--;
	}
	_itoa_s(A, tmp, 2);
	cout << "��������: " << tmp;
}*/
// 10 ������� 2 �����(���� ����� �������������)
/*#include <iostream> 
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	int A, pos, n, razn, c; char tmp[33];
	cout << "������� ����� �: ";
	cin >> A; cout << endl;
	_itoa_s(A, tmp, 2);
	cout << "����� � � 2 c/c: " << tmp << endl;
	cout << "������� ���������� ����� ��� �������������� (n): ";
	cin >> n; cout << endl;
	cout << "������� ����� ������� p: ";// ���� ����� ���������� � 1, � �� 0!!!
	cin >> pos; cout << endl;
	razn = pos - n;
	c = pos; //����� �� �������� ����� � ������� P?
	while (pos >= razn)
	{
		if (c != pos)
		{
			A = A ^ (1 << (n+pos)); // ��������������
			pos--;
		}
		else n--;
	}
	_itoa_s(A, tmp, 2);
	cout << "��������: " << tmp;
}*/
/* 11 ������� 1 �����(���������)
#include <iostream> 
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	int A, i; char tmp[33];
	cout << "������� ����� ";
	cin >> A;
	_itoa_s(A, tmp, 2);

	cout << "����� � �������� ���� = " << tmp << endl;
	if ((A & 15) == 0)
		cout << "����� ������ 16" << endl;
	else
		cout << "����� �� ������ 16" << endl;
}*/
/* 5 ������� 1 �����(���������)
#include <iostream> 
#include <cstring>
using namespace std;
void main()
{
	int a, b = 0, n=0, x=0, c, h;
	char A[20];
	setlocale(LC_CTYPE, "Russian");
	cout << "����� � = ";
	cin >> a;
	b = a;
	_itoa_s(a, A, 2);
	cout << "����� " << a << " � �������� �.�.: " << A << endl;
	while (a != 0) 
	{
		a = a & (a - 1);
		n++;
	}
	cout << "���������� ������: " << n << endl;
	c = strlen(A);
	cout<<"����� ���: "<<c<<endl;
	h = c - n; // ���-�� �����
	cout << "���������� �����: " << h << endl;
	c = n-h;//���������� 1 ������ �� ���������� 0
	if (c < 0) cout << "���������� ����� ������ ���������� ������ �� " << abs(c) << endl;// ���� ������ ������, ��� ����� 
	else cout << "���������� ������ ������ ���������� ����� �� " << c << endl;
	if (c == 0) cout << "���������� ������ � ����� ���������.";
}*/
/* 8 ������� 1 �����(���������)
#include <iostream> 
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	int A=0; char tmp[33];
	cout << "������� �: ";
	cin >> A;
	_itoa_s(A, tmp, 2);
	cout << " ����� �: " << tmp << endl;
	_itoa_s(0x24, tmp, 2);
	cout << " ����� ��� �: " << tmp << endl;
	_itoa_s(A ^ 0x24, tmp, 2);
	cout << " ���������: " << tmp << endl << endl;
}*/
/* 6 ������� 1 �����(���������)
#include <iostream> 
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	int A = 128, �=170; char tmp[33];
	_itoa_s(A, tmp, 2);
	cout << " ����� �: " << tmp << endl;
	_itoa_s(�, tmp, 2);
	cout << " ����� ��� �: " << tmp << endl;
	_itoa_s(A | �, tmp, 2);
	cout << " ���������: " << tmp << endl << endl;
}*/