/*���� �������� a ���������� ���� �� ������� ���������� ��������.
�������� � ���������� �������� b, ��������� �� �������� ������ �������� �������� a, ���������� � �������� �������,
����� ������� ���� ������� ������ �������� ������-�� a, ����� ���������� � �������� �������
(��������, ��� � = ������� b ������ ���� ����� �������).*/
#include <iostream>
using namespace std;
int main()
{
	setlocale(LC_CTYPE, "RUS");
	const int max = 50;
	char str[] = "������ ��� ���� ��� ������ �������  ", a[max], b[max];
	int i = 0, nstr, k=0, n, j;
	nstr = strlen(str);//6
	n = nstr-1;
	for (int i=0; i<nstr; i++)
	{
		if(i < (nstr / 2))
		{
			a[k++] = str[(nstr / 2) - (i+1)];
		}
		if (i >= nstr / 2)
		{
			a[k++] = str[n--];
		}
		cout << a[i];
	}
}