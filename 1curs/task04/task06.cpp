/*�������� ���������, ����������� ������ ����� �����, ���������
������������� ����������.���������� ������� � ��������� ����� �� - 256 ��
1000.*/
#include <iostream>
using namespace std;
int main()
{
	setlocale(LC_CTYPE, "RUS");
	unsigned int year;
	cout << "������� ���: ";
	cin >> year;
	if ((year % 4 == 0) & (year % 400 != 0)) cout << year << " - ���������� ���\n";
	else cout << year << " - ������������ ���\n";
	system("Pause");
}
