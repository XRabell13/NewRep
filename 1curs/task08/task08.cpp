#include <iostream>
using namespace std;
int main()
{
	setlocale(LC_CTYPE, "RUS");
	int raund, sum1 = 0, sum2 = 0; 
	cout << "Введите количество раундов: ";
	cin >> raund; 
		for (int j = 1; j <= raund; j++) 
		{ 
			char p1, p2;
			cout <<endl<< "Раунд " << j <<endl<<endl;
			cout << "Пожалуйста, выберите один из следующих вариантов:\n1. Камень\n2. Ножницы\n3. Бумага\n\n";
			cout << "Выбор 1 игрока: ";
			cin >> p1;
			cout << "Выбор 2 игрока: ";
			cin >> p2;
			if ((p2 == '1' and p1 == '2') or (p2 == '2' and p1 == '3') or (p2 == '3' and p1 == '1')) {
				sum2++;
				cout << "\nВ раунде " << j << " побеждает игрок 2\n\n";
			}
			else if (p1 != p2) {
				sum1++;
				cout << "\nВ раунде " << j << " побеждает игрок 1\n\n";
			}
		}
		if (sum1 > sum2) {
			cout << "Итог игры:\nИгрок 1 выиграл!" << endl;
		}
		else if (sum2 > sum1) {
			cout << "Итог игры:\nИгрок 2 выиграл!" << endl;
		}
		else cout << "Итог игры:\nНичья!" << endl;
		system("Pause");
}