#include <iostream>
using namespace std;
void main()
{
	int q, b, x, i;
	double ost, cel;
	cout << "q = ";
	cin >> q;
	cout << "b = ";
	cin >> b;
	for (int i=1; i <= q; i++)
	{
		ost = i % 10;
		cel = i / 10;
		x = pow(ost + cel, 2);
		if (x == b) 
			cout << "q = " << i << endl;
	}
}