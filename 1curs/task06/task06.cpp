#include <iostream>
#include <iomanip>
using namespace std;
int main()
{
	int h, k, q, c1 = 1, c2 = 1;
	char s = '*';
	cin >> h;
	c2 = (h * 2) - 1;
		for (int i=0; i<((h*2)-1); i++)
			if (c1 < h)
			{
				cout << setw(c1++) << s;
				c2 = c2 - 3;
				cout << setw(c1 + c2) << s << endl;
			}
		cout << setw(h) << s;
}
