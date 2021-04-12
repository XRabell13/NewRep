#include <stdio.h>
#include <clocale>
int main() 
{
	setlocale(LC_CTYPE, "Russian");
	int номер;
	printf("Номер квартиры: ");
	scanf_s("%d", &номер);
	int подъезд = (номер - 1) / 36 + 1;
	int остаток = (номер - 1) % 36;
	int этаж = остаток / 4 + 1;
	printf("подъезд = %d\n", подъезд);
	printf("этаж = %d\n", этаж);
}