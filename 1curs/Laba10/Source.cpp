// 0 - true, 1 - false. Мас ку используем для того, чтобы с ее помощью при накладывании выбирать то, что нам нужно! Если в маске 1 и в числе
// 1, то с помощью бттовых операций можно или убрать или оставить данные числа... или с помощью маски, в которой 4 единицы в начале, выбрать 
// 4 цифры из числа в А.
// cout << "Введите число А: ";
// cin >> A; cout << endl; A |= ((1 << n) - 1) << (pos > n) ? (pos - n) : 0; while (pos && n--) A |= 1 << pos--;

// 15 вариант, 1.
/*#include <iostream> 
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	int A, i; char tmp[33];
	cout << "Введите число ";
	cin >> A;
	_itoa_s(A, tmp, 2);

	cout << "Число в двоичном виде = " << tmp << endl;
	if ((A & 1) == 0)// у чисел кратных 2 первый бит всегда равен 0
		cout << "Число кратно 2" << endl;
	else
		cout << "Число не кратно 2" << endl;
}
*/
/*2 пункт
#include <iostream> 
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	int A, pos, n, razn, c; char tmp[33];
	cout << "Введите число А: ";
	cin >> A; cout << endl;
	_itoa_s(A, tmp, 2);
	cout << "Число А в 2 c/c: " << tmp << endl;
	cout << "Введите количество битов для превращения в 0 (n): ";
	cin >> n; cout << endl;
	cout << "Введите номер позиции p: ";// счет будет начинаться с 1, а не 0.
	cin >> pos; cout << endl;
	razn = pos - n;
	c = pos; //чтобы не превращать в 0 число в позиции P
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
	cout << "Конечное: " << tmp;
}*/

/* Вариант 16, пункт 1 
#include <iostream>
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	char tmp[33];
	int A, B, maskA = 14;
	int maskB = ~maskA >> 1;
	cout << "А = "; cin >> A;
	cout << "В = "; cin >> B;

	_itoa_s(A, tmp, 2); cout << "A в двоичной с.с.: " << tmp << endl;
	_itoa_s(B, tmp, 2); cout << "B в двоичной с.с.: " << tmp << endl;

	_itoa_s(maskA, tmp, 2); 
	cout << "Маска для А: " << tmp << endl;
	_itoa_s((A & maskA) >> 1, tmp, 2);
	cout << "Выделенные биты А: " << tmp << endl;
	_itoa_s(maskB, tmp, 2);
	cout << "Маска для В: " << tmp << endl;
	_itoa_s(B & maskB, tmp, 2);
	cout << " Очищены биты в B: " << tmp << endl;
	_itoa_s(((B & maskB) | ((A & maskA) >> 1)), tmp, 2);
	cout << " Результат B=" << tmp << endl;
}*/
// Пункт 2
#include <iostream>
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	char ctmp[33], atmp[33], ac[33];
	int A, B, C = 12;
	_itoa_s(C, ctmp, 2); cout << "C=12 в двоичной с.с.: " << ctmp << endl;
	cout << "А = "; cin >> A;
	_itoa_s(A, atmp, 2); cout << "A в двоичной с.с.: " << atmp << endl;
	_itoa_s((A<<4)| C, ac, 2); cout << "Число в двоичном представлении: " << ac;
} 

