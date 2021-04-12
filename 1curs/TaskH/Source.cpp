#include <iostream>
using namespace std;
bool lucky(int n)
{
		while (n > 0)
		{
			if (n % 10 != 4 && n % 10 != 7)
				return false;
			n /= 10;
		}
	return true;
}
int main()
{
	freopen("input.txt", "rt", stdin);
	int n=0, k, j = 0;
		cin >> k;
		if (k >= 1 && k <= 109)
		{
			while (k > j)
			{
				n++;
				if (lucky(n) && n > 0) j++;
			}
			cout << n;
		}
	return 0;
}