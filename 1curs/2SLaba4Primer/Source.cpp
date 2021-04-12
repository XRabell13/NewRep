/*#include <iostream>
using namespace std;
struct byte
{
	unsigned a : 1;
	unsigned b : 1;
	unsigned c : 1;
	unsigned d : 1;
	unsigned e : 1;
	unsigned f : 1;
	unsigned g : 1;
	unsigned h : 1;
	unsigned a1 : 1;
	unsigned b1 : 1;
	unsigned c1 : 1;
	unsigned d1 : 1;
	unsigned e1 : 1;
	unsigned f1 : 1;
	unsigned g1 : 1;
	unsigned h1 : 1;
	unsigned a2 : 1;
};

union bits
{
	int ch;
	struct byte bit;
} ascii;

void disp_bits(bits b);

void main()
{
	do
	{
		cin >> ascii.ch;
		disp_bits(ascii);
	} while (ascii.ch != 'q');   //выход при вводе q
}

void disp_bits(bits b)
{
	if (b.bit.a2) cout << "1";  else cout << "0";
	if (b.bit.h1) cout << "1";  else cout << "0";// если в данном бите есть 1, то вывод 1, если 0, то вывод 0
	if (b.bit.g1) cout << "1";  else cout << "0";
	if (b.bit.f1) cout << "1";  else cout << "0 ";
	if (b.bit.e1) cout << "1";  else cout << "0";
	if (b.bit.d1) cout << "1";  else cout << "0";
	if (b.bit.c1) cout << "1";  else cout << "0";
	if (b.bit.b1) cout << "1";  else cout << "0 ";
	if (b.bit.a1) cout << "1";  else cout << "0";
	if (b.bit.h) cout << "1";  else cout << "0";// если в данном бите есть 1, то вывод 1, если 0, то вывод 0
	if (b.bit.g) cout << "1";  else cout << "0";
	if (b.bit.f) cout << "1";  else cout << "0 ";
	if (b.bit.e) cout << "1";  else cout << "0";
	if (b.bit.d) cout << "1";  else cout << "0";
	if (b.bit.c) cout << "1";  else cout << "0";
	if (b.bit.b) cout << "1";  else cout << "0";
	if (b.bit.a) cout << "1";  else cout << "0";

	cout << "\n";
}*/
#include <iostream> 
using namespace std;

union zet
{
	int ch;
} tabl;


typedef struct Zapis
{
	char fio[30];
	int data;

} ZAP;
Zapis list_of_zap[30], yui;


int main(void)
{
	setlocale(LC_ALL, "Russian");
	cin >> tabl.ch;
	list_of_zap[1].data = tabl.ch;
	cout << tabl.ch<<endl;
	cout << list_of_zap[1].data << endl;
	return 0;
}
