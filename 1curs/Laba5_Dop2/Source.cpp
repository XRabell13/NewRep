#include <iostream>
using namespace std;
int main()
{
	setlocale(LC_CTYPE, "Russian");
	int x, xl, k = 0, i = 0;
	cout << "������������������: "<<endl;
	cin >> x; //������ ���� ����� ��� ��������
	if (i == 0) xl = x;
	while (x!=0)
	{
		cin >> x; 
		if ((x < 0 and xl > 0) | (xl < 0 and x > 0)) k = k + 1;
		xl = x;
		i = i + 1;
	}
	cout << "���������� ���� �����: " << k;
}

