#include <iostream>
using namespace std;
int main()
{
	setlocale(LC_CTYPE, "RUS");
	int raund, sum1 = 0, sum2 = 0; 
	cout << "������� ���������� �������: ";
	cin >> raund; 
		for (int j = 1; j <= raund; j++) 
		{ 
			char p1, p2;
			cout <<endl<< "����� " << j <<endl<<endl;
			cout << "����������, �������� ���� �� ��������� ���������:\n1. ������\n2. �������\n3. ������\n\n";
			cout << "����� 1 ������: ";
			cin >> p1;
			cout << "����� 2 ������: ";
			cin >> p2;
			if ((p2 == '1' and p1 == '2') or (p2 == '2' and p1 == '3') or (p2 == '3' and p1 == '1')) {
				sum2++;
				cout << "\n� ������ " << j << " ��������� ����� 2\n\n";
			}
			else if (p1 != p2) {
				sum1++;
				cout << "\n� ������ " << j << " ��������� ����� 1\n\n";
			}
		}
		if (sum1 > sum2) {
			cout << "���� ����:\n����� 1 �������!" << endl;
		}
		else if (sum2 > sum1) {
			cout << "���� ����:\n����� 2 �������!" << endl;
		}
		else cout << "���� ����:\n�����!" << endl;
		system("Pause");
}