#include <stdio.h>
#include <iostream>
void main()
{
	setlocale(LC_CTYPE, "RUS");
	printf("/%d/\n", 336);
	printf("/%2d/\n", 336);
	printf("/%10d/\n", 336);
	printf("/%-10d/\n", 336);

}//вопрос про то, какие билиотеки нужно подключить , чтобы работала та или иная функция 