/*Написать программу, сортирующую массив целых чисел, используя
Пирамидальную сортировку.Наполнение массива – случайные числа от - 256 до
1000.*/
#include <iostream>
using namespace std;
int main()
{
	setlocale(LC_CTYPE, "RUS");
	unsigned int year;
	cout << "¬ведите год: ";
	cin >> year;
	if ((year % 4 == 0) & (year % 400 != 0)) cout << year << " - високосный год\n";
	else cout << year << " - невисокосный год\n";
	system("Pause");
}
