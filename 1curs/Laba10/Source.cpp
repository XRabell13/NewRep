// 0 - true, 1 - false. ��� �� ���������� ��� ����, ����� � �� ������� ��� ������������ �������� ��, ��� ��� �����! ���� � ����� 1 � � �����
// 1, �� � ������� ������� �������� ����� ��� ������ ��� �������� ������ �����... ��� � ������� �����, � ������� 4 ������� � ������, ������� 
// 4 ����� �� ����� � �.
// cout << "������� ����� �: ";
// cin >> A; cout << endl; A |= ((1 << n) - 1) << (pos > n) ? (pos - n) : 0; while (pos && n--) A |= 1 << pos--;

// 15 �������, 1.
/*#include <iostream> 
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	int A, i; char tmp[33];
	cout << "������� ����� ";
	cin >> A;
	_itoa_s(A, tmp, 2);

	cout << "����� � �������� ���� = " << tmp << endl;
	if ((A & 1) == 0)// � ����� ������� 2 ������ ��� ������ ����� 0
		cout << "����� ������ 2" << endl;
	else
		cout << "����� �� ������ 2" << endl;
}
*/
/*2 �����
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
			A = A & (~(1 << (n + pos)));
			pos--;
		}
		else pos--;
	}
		_itoa_s(A, tmp, 2);
	cout << "��������: " << tmp;
}*/

/* ������� 16, ����� 1 
#include <iostream>
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	char tmp[33];
	int A, B, maskA = 14;
	int maskB = ~maskA >> 1;
	cout << "� = "; cin >> A;
	cout << "� = "; cin >> B;

	_itoa_s(A, tmp, 2); cout << "A � �������� �.�.: " << tmp << endl;
	_itoa_s(B, tmp, 2); cout << "B � �������� �.�.: " << tmp << endl;

	_itoa_s(maskA, tmp, 2); 
	cout << "����� ��� �: " << tmp << endl;
	_itoa_s((A & maskA) >> 1, tmp, 2);
	cout << "���������� ���� �: " << tmp << endl;
	_itoa_s(maskB, tmp, 2);
	cout << "����� ��� �: " << tmp << endl;
	_itoa_s(B & maskB, tmp, 2);
	cout << " ������� ���� � B: " << tmp << endl;
	_itoa_s(((B & maskB) | ((A & maskA) >> 1)), tmp, 2);
	cout << " ��������� B=" << tmp << endl;
}*/
// ����� 2
#include <iostream>
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	char ctmp[33], atmp[33], ac[33];
	int A, B, C = 12;
	_itoa_s(C, ctmp, 2); cout << "C=12 � �������� �.�.: " << ctmp << endl;
	cout << "� = "; cin >> A;
	_itoa_s(A, atmp, 2); cout << "A � �������� �.�.: " << atmp << endl;
	_itoa_s((A<<4)| C, ac, 2); cout << "����� � �������� �������������: " << ac;
} 

