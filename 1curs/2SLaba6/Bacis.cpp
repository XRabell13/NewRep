//Основной программный модуль
// 2 новых стека создаютс путем перебора и удаления жэлементов основнгого но перед удалением их записмывают в другие 2 стека...
//что-то как сортировка с удалением изначального материала?
//попробовать посоздавать массивы, записать в них четныеи нечетные, а потом массивы записать в стеки

// Доп 11 вариант
//Разработать функцию, которая по одному стеку строит два новых: 
//Stack1 из элементов, значение которых превышает число 50, и Stack2 из остальных элементов.

#include <iostream>
#include "myStack.h"
using namespace std;
int main()
{
	setlocale(LC_ALL, "Rus");
	int choice;
	Stack* myStk = new Stack; //выделение памяти для стека
	myStk->head = NULL;       //инициализация первого элемента	
	nechStack* nechStk = new nechStack; //выделение памяти для стека
	nechStk->head = NULL;       //инициализация первого элемента	
	chStack* chStk = new chStack; //выделение памяти для стека
	chStk->head = NULL;       //инициализация первого элемента	
	for (;;)
	{
		cout << "Выберите команду:" << endl;
		cout << "1 - Добавление элемента в стек" << endl;
		cout << "2 - Извлечение элемента из стека" << endl;
		cout << "3 - Вывод стека" << endl;
		cout << "4 - Очистка стека" << endl;
		cout << "5 - Запись стека в файл" << endl;
		cout << "6 - Чтение стека из файла" << endl;
		cout << "7 - Разбиение на 2 стека c четными и нечетными элементами" << endl;
		cout << "8 - Разбиение на 2 стека c элементами больше 50 и оставшимися элементами" << endl;
		cout << "9 - Выход" << endl;
		cin >> choice;
		switch (choice)
		{
		case 1: cout << "Введите элемент: " << endl;
			cin >> choice;
			push(choice, myStk);
			break;
		case 2: choice = pop(myStk);
			if (choice != -1)
				cout << "Извлеченный элемент: " << choice << endl;
			break;
		case 3: cout << "Весь стек: " << endl;
			show(myStk);
			break;
		case 4: clear(myStk); cout << "Стек очищен!";
			break;
		case 5: toFile(myStk);
			break;
		case 6:
			fromFile();
			break;
		case 7: stkfunc(myStk, chStk,nechStk); break;
		case 8: stkdop(myStk, chStk, nechStk); break;
		case 9: return 0;
			break;
		}
	}
	return 0;
}
