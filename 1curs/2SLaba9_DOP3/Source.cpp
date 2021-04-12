//По заданному числу n определить символ,
//который стоит на n-ом месте последовательности,
//получившейся после шага c номером 26.
#include <iostream>
using namespace std;
int main()
{
	const int size = 100;
	char a[size], k='1';
	int n, x;
	cout << "n = "; cin >> n;
	cout << "Array: ";
	for (int i = 0; i < size; i++, k++) 
	{
		cout << k <<" ";
		a[i] = k;
	}
	cout << "\nSymbole 26: " << a[26];
	cout << "\nSymbole: "<<a[n + 26];
	return 0;
}