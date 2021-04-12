//Разложение натурального числа на множители
#include <iostream>
using namespace std;
int main()
{
	int n, d = 2;
	cout << "N = ";
	cin >> n;
	cout << n << " = ";
	while (n > 1) {
		int k = 0;
		while (n % d == 0) {
			k++;
			n = n / d;
		}
		if (k > 0) {
			cout << d;
			if (k > 1) cout << "^" << k;
			if (n > 1) cout << "*";
		}
		if (d == 2) d++;
		else d = d + 2;
	}
	cout << endl;
}
/*#include <iostream>
using namespace std;
void main()
{ 
	setlocale(LC_CTYPE, "Russian");
	int nomer = 1000, ost11, ost22;
	while (nomer<=9999)
	{
		if (nomer % 154 == 0)
			((ost11 == nomer / 100) && (ost22 == nomer % 100));
		if (30 == ost11 + ost22)
			cout << "Номер автомобиля: " << nomer<<endl;
		nomer = nomer + 1;
	}
}*/