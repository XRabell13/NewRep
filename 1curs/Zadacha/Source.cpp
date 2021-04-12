#include <fstream>
#include <iostream>
using namespace std;
void main()
{
	
    int g=0, x = 0, y = 0, h = 0, k = 0;
	x = 10; y = 11;
	g = ((8 * y / (x + 5 * x)) * 6) % ((35 * y - 25 * x) / 27);
	
	
		cout << "x=" << x << " y= " << y << endl;
		cout << "g=" <<g << endl;
 /* for(int i=10; i<=50; i++)
		for (int j = 10; j <= 50; j++)
		{
			x = i; y = j;
			g = ((8*y/(x+5*x))*6)%((35 * y -25*x)/27);
			if (g == 1)
			{
				cout << "x=" << x << " y= " << y << endl;
				k++;
			}

		}
	/*x=10y= 11
x=10y= 16
x=11y= 12
x=11y= 17
x=12y= 13*/
}