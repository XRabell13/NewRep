/*Создать очередь для символов и функции для ввода, вывода,
удаления и определения размера очереди. Ввести символы с экрана в очередь.
В случае совпадения вводимого символа с первым элементом очереди вывести очередь и ее размер.
Создать проект из нескольких файлов, демонстрирующий работу с очередью. 
В соответствии со своим вариантом выполнить зада-ние из таблицы, представленной ниже.
Разработать меню и реализовать все операции с очередью через функции. Максимальный размер очереди ввести с клавиатуры.
*/

#include<iostream> 
#include"myQueue.h"


int main()
{
	setlocale(LC_CTYPE, "RUS");
	Symbole* begin = NULL, * end, * t;
	t = new Symbole;
	int size, choice=1, n; 
    char p, oneElem='n';
	std::cout << "Введите размер очереди: ";  std::cin >> size;
	while (choice!=5)
	{
		meny();
		std::cin >> choice;
		switch (choice)
		{
		case 1: std::cout << "Введите элемент: \n";
			if (begin == NULL)
			{
				std::cin >> p; 
				oneElem=p;
				t->info = p;        //первый элемент
				t->next = NULL;
				begin = end = t;
			}
			else //создание очереди
			{
			   std::cin >> p;
				create(&begin, &end, p);
				if (p == oneElem) 
				{
					std::cout << "Очередь: ";
					view(begin);
					n = siz(begin); 
					std::cout << "Размер очереди: " << n << '\n';
				}
			}
			break;
		case 2: n = siz(begin); std::cout << "Размер очереди: "<<n<<'\n';  break;
		case 3: if (begin == NULL)   //вывод на экран
			std::cout << "Элементов нет\n";
				else
			view(begin); break;
		case 4: clear(&begin); 
			if (begin == NULL) std::cout << "Очередь очищена!\n";
			else std::cout << "Не удалось очистить очередь!\n";
			break;
		}
	}
	std::cout << "\nGoodbye!\n";
	return 0;
}
