// 1 вариант 1 пункт
/*#include <iostream> 
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	int someNumber, result=0;
	char A[15];
	cout << "Число: ";  cin >> someNumber;
	_itoa_s(someNumber, A, 2); cout << "Число в двоичной с.с.: " << A << endl;
	for (int i = 3; i <= 13; ++i)
	{
		if (((someNumber >> i) ^ 0) == 0)
		{
			++result;
		}
	}
	cout << "Нулей в двоичном представлении числа: " <<result;

}*/
// 10 вариант 1 пункт
/*#include <iostream>
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	char tmp[33];
	int A, maskA = 252;
	int maskB = ~maskA >> 1;
	cout << "Первое число="; cin >> A;
	_itoa_s(A, tmp, 2); cout << "A=" << tmp << endl;
	cout << "Маска для А: " << tmp << endl;
	_itoa_s((A | maskA) >> 1, tmp, 2);
	cout << "Выделенные биты А: " << tmp << endl;
	}
	*/
// 4 вариант, 1 пункт (выполнено)
#include <iostream> 
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	int A, i; char tmp[33];
	cout << "Введите число ";
	cin >> A;
	_itoa_s(A, tmp, 2);

	cout << "Число в двоичном виде = " << tmp << endl;
	if ((A & 3) == 0)
		cout << "Число кратно 4" << endl;
	else
		cout << "Число не кратно 4" << endl;
}

/*4 вариант, 2 пункт(выполнено)
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
			A = A | (1 << (n + pos));//если поменять | на & и значение в скобках взять со знаком ~, то будет вревращать последующие биты в 0
			pos--;
		}
		else pos--;
	}
	_itoa_s(A, tmp, 2);
	cout << "Конечное: " << tmp;
}*/
// 10 вариант 2 пункт(надо влево инвентировать)
/*#include <iostream> 
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	int A, pos, n, razn, c; char tmp[33];
	cout << "Введите число А: ";
	cin >> A; cout << endl;
	_itoa_s(A, tmp, 2);
	cout << "Число А в 2 c/c: " << tmp << endl;
	cout << "Введите количество битов для инвентирования (n): ";
	cin >> n; cout << endl;
	cout << "Введите номер позиции p: ";// счет будет начинаться с 1, а не 0!!!
	cin >> pos; cout << endl;
	razn = pos - n;
	c = pos; //чтобы не изменять число в позиции P?
	while (pos >= razn)
	{
		if (c != pos)
		{
			A = A ^ (1 << (n+pos)); // инвентирование
			pos--;
		}
		else n--;
	}
	_itoa_s(A, tmp, 2);
	cout << "Конечное: " << tmp;
}*/
/* 11 вариант 1 пункт(выполнено)
#include <iostream> 
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	int A, i; char tmp[33];
	cout << "Введите число ";
	cin >> A;
	_itoa_s(A, tmp, 2);

	cout << "Число в двоичном виде = " << tmp << endl;
	if ((A & 15) == 0)
		cout << "Число кратно 16" << endl;
	else
		cout << "Число не кратно 16" << endl;
}*/
/* 5 вариант 1 пункт(выполнено)
#include <iostream> 
#include <cstring>
using namespace std;
void main()
{
	int a, b = 0, n=0, x=0, c, h;
	char A[20];
	setlocale(LC_CTYPE, "Russian");
	cout << "Число А = ";
	cin >> a;
	b = a;
	_itoa_s(a, A, 2);
	cout << "Число " << a << " в двоичной с.с.: " << A << endl;
	while (a != 0) 
	{
		a = a & (a - 1);
		n++;
	}
	cout << "Количество единиц: " << n << endl;
	c = strlen(A);
	cout<<"Число бит: "<<c<<endl;
	h = c - n; // кол-во нулей
	cout << "Количество нулей: " << h << endl;
	c = n-h;//количество 1 отнять от количества 0
	if (c < 0) cout << "Количество нулей больше количества единиц на " << abs(c) << endl;// если единиц меньше, чем нулей 
	else cout << "Количество единиц больше количества нулей на " << c << endl;
	if (c == 0) cout << "Количество единиц и нулей совпадает.";
}*/
/* 8 вариант 1 пункт(выполнено)
#include <iostream> 
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	int A=0; char tmp[33];
	cout << "Введите А: ";
	cin >> A;
	_itoa_s(A, tmp, 2);
	cout << " Число А: " << tmp << endl;
	_itoa_s(0x24, tmp, 2);
	cout << " Маска для А: " << tmp << endl;
	_itoa_s(A ^ 0x24, tmp, 2);
	cout << " Результат: " << tmp << endl << endl;
}*/
/* 6 вариант 1 пункт(выполнено)
#include <iostream> 
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	int A = 128, с=170; char tmp[33];
	_itoa_s(A, tmp, 2);
	cout << " Число А: " << tmp << endl;
	_itoa_s(с, tmp, 2);
	cout << " Маска для А: " << tmp << endl;
	_itoa_s(A | с, tmp, 2);
	cout << " Результат: " << tmp << endl << endl;
}*/