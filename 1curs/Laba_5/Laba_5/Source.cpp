#include <iostream>
#include <iomanip>
int main()
{
	setlocale(LC_CTYPE, "Russian");
	int k;
	puts("На какую тему хотите поговорить? (1- искусство, 2- политика)");
	std::cin >> k;
	switch (k)
	{
	case 1: { puts("Каких Вы знаете художников? (1- Леонардо Да Винчи, 2-Дали, 3-Винсент Ван Гог)");
		std::cin >> k;
		switch (k)
		{
		case 1: puts("Великий человек"); break;
		case 2: puts("Его картины были полны сюрреализма!"); break;
		case 3: puts("Человек с нелегкой судьбой");
			break;
		}
		break;
	}
	case 2: puts("Это скучно... может поговорим о другом?"); break;
	default: puts("Не то число. Попробуйте еще раз..."); break;
	}
	return 0;
}

	
