// 15 ������� (��� � ������� ������ ������� ����? ��������)
//  � �����������
#include <iostream>
using namespace std;
int main()
{
	setlocale(LC_CTYPE, "Russian");
	using namespace std;
	int const N = 101;
	char str[N];
	char* mas;
	char b; int i = 0, j = 0, c, a, k;
	cout << "������� ������(�� ����� 100 ��������): ";
	cin >> str;
	mas = &str[0];
	cout << endl;
	cout << "������� ������ ��� �������� ��� �� ������: ";
	cin >> b;
	cout << endl;
	c = strlen(mas);
	for (; i <= c; i++)
		if (*(mas + i) == b)
		{
			a = c - i;
			for(int j=i; j<=c; j++)
			*(mas+j) = *(mas + j + 1);
		}
	cout << "������ ��� ���������� �������: " << str;
}
// � ���������
#include <iostream>
using namespace std;
int main()
{
	setlocale(LC_CTYPE, "Russian");
	using namespace std;
	int const N = 101;
	char str[N];
	char b; int i = 0, j = 0, c, a, k;
	cout << "������� ������(�� ����� 100 ��������): ";
	cin >> str;
	cout << endl;
	cout << "������� ������ ��� �������� ��� �� ������: ";
	cin >> b;
	cout << endl;
	c = strlen(str);
	for (; i <= c; i++)
		if (str[i] == b)
		{
			a = c - i;
			for (int j = i; j <= c; j++)
				str[j] = str[j+1];
		}
	cout << "������ ��� ���������� �������: " << str;
}
// 2 �������
// � �����������
#include <iostream>
using namespace std;
int main()
{
	setlocale(LC_CTYPE, "Russian");
	using namespace std;
	char s1[] = "Game over, QWERTY!", s2[30], s3[30];
	char* mas;
	int i = 0, j = 0, c, a, k;
	mas = &s1[0];
	cout << "������: " << s1<<endl;
	cout << "� ����� ������� �������� �������: "; cin >> c;
	cout << endl;
	cout << "���������� ���������� ��������: "; cin >> a;
	k = strlen(s1)-c;
	for (int n=0; n<=k; n++)
	s2[n] = *(mas+c+n);
	mas = &s3[0];
	strncpy_s(s3, s2, a);
	cout << "�������� ������: " << s3;
}
// � ���������
#include <iostream>
using namespace std;
int main()
{
	setlocale(LC_CTYPE, "Russian");
	using namespace std;
	char s1[] = "Game over, QWERTY!", s2[30], s3[30];
	int i = 0, j = 0, c, a, k;
	cout << "������: " << s1 << endl;
	cout << "� ����� ������� �������� �������: "; cin >> c;
	cout << endl;
	cout << "���������� ���������� ��������: "; cin >> a;
	k = strlen(s1) - c;
	for (int n = 0; n <= k; n++)
		s2[n] = s1[c + n];
	strncpy_s(s3, s2, a);
	cout << "�������� ������: " << s3;
}


/*#include <stdio.h>
void main()
{
	int num = 5;
	char symbol, new_symbol = ' ';
	symbol = num + '0';
	printf("%c\n", symbol);

	if (symbol >= '0' && symbol <= '9')
		num = symbol - '0';
	printf(" %d\n", num);
	symbol = 'b';

	if (symbol >= 'a' && symbol <= 'z')
		new_symbol = symbol - 'a' + 'A';
	printf(" %c\n", new_symbol);
}*/
