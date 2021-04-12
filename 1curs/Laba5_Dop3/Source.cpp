#include <iostream>
#include <math.h>
using namespace std;
int main() 
{
	int n;
	double s, p; 
	double S = 0;  
	scanf_s("%lf %d", &p, &n); 
	for (int i = 1; i <= n; i++) 
	{
		scanf_s("%lf", &s);  
		S = S * (100 - p) / 100;
		S += s;
		printf("%lf\n", S);
	}
}