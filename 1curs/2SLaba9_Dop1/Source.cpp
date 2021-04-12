/*Ввести цифру А, записать в файл все возможные числа, состоящие из цифр, не превышающих или равных A.Количество цифр в числах должно быть равно А.

*/
#include <iostream>
#include <cmath>
#include <fstream>
using namespace std;

int i, c, b = 0;

int func(int smth, int max, int* array) /*передаем в функцию цифру, разряд чисел, которые нам нужно вывести(10, 100, 1000 и т.д.), и массив, в который запишем числа*/
{
	if (!b) {
		while (i < max) {
			i++;
			b++;
		}
	}
	if (i <= smth) {
		array[c] = i;
		++i;
		c++;
		func(smth, max, array);//рекурсия
	}
	else {
		return c;
	}
}

int main(int argc, char* argv[])
{
	ofstream f("f.txt");
	int a = 0;
	cin >> a;
	int* arr = new int[a];

	int counter = 1;
	while (counter < a) {
		counter = counter * 10;
		cout << "count : " << counter << endl;
	}
	counter = counter / 10;
	cout << "after / " << counter << endl;
	int count = func(a, counter, arr);

	for (int i = 0; i < count; i++) {
		f << arr[i]<<" ";
	}
	delete[] arr;
	return 0;
}