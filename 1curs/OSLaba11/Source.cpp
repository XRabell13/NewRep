#include <windows.h>
#include <iostream>
#include<iomanip>
int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	HANDLE hHeap;
	int* arr = NULL;
	int a_size;   //размер массива
	int choice; // выбор
	int enter; //ввод
	int delet; //удаление
	int index; //адрес

	std::cout << "Введите размер массива:  ";
	std::cin >> a_size;
	hHeap = HeapCreate(HEAP_NO_SERIALIZE, a_size, a_size);//создане бинарной кучи (может использоваться и другими потоками)
	if (!hHeap)
	{
		std::cout << "Heap Creation Failed" << std::endl;
		return GetLastError();
	}
	//распределяем память кучи под массив
	arr = (int*)HeapAlloc(hHeap, NULL, a_size);//выделение бинарной кучи из файла
	if (!arr)
	{
		std::cout << "Heap allocation Failed" << std::endl; ;//контр. вывод
		return GetLastError();
	}

	std::cout << "Вводим массив из " << a_size << " чисел....\n";
	for (int i = 0; i < a_size; i++) {
		arr[i] = i;//Записываем числа в массив
	}
	do
	{
		std::cout << "Введите:" << std::endl;
		std::cout << "1-для увеличения размера массива на 1           " << std::endl;
		std::cout << "2-для уменьшения размера массива на 1           " << std::endl;
		std::cout << "3-для вставки элемента в середину               " << std::endl;
		std::cout << "4-для удаления элемента из середины             " << std::endl;
		std::cout << "_____________________________________" << std::endl;
		std::cin >> choice;
		switch (choice)
		{
		case 1: {
			std::cout << "Меняем размер массива на +1\n";
			arr = (int*)HeapReAlloc(hHeap, NULL, arr, a_size++);//Изменить размеры кучи 
			arr[a_size - 1] = a_size - 1;
			std::cout << "В массиве стало - " << a_size << " чисел\n";
			for (int i = 0; i < a_size; i++) {
				std::cout << arr[i] << "   ";
			}break;
		}
		case 2: {
			std::cout << "Меняем размер массива на -1\n";
			arr = (int*)HeapReAlloc(hHeap, NULL, arr, a_size--);
			std::cout << "В массиве стало - " << a_size << " чисел\n";
			for (int i = 0; i < a_size; i++) {
				std::cout << arr[i] << "   ";
			}break;
		}
		case 3: {
			std::cout << "Меняем размер массива на +1\n";
			arr = (int*)HeapReAlloc(hHeap, NULL, arr, a_size++);
			std::cout << "Введите добавляемое число до " << a_size << "    ";
			std::cin >> enter;
			index = enter + 1;
			for (int i = index; i < a_size; i++) {
				arr[index + 1] = index + 1;
			}
			for (int i = 0; i < a_size; i++) {
				std::cout << arr[i] << "   ";
			}break;
		}
		case 4: {
			std::cout << "Введите удаляемое число до " << a_size << "    ";
			std::cin >> enter;
			index = enter + 1;
			for (int i = index; i < a_size; i++) {
				arr[index] = index;
			}
			std::cout << "Меняем размер массива на -1\n";
			arr = (int*)HeapReAlloc(hHeap, NULL, arr, a_size--);
			for (int i = 0; i < a_size; i++) {
				std::cout << arr[i] << "   ";
			}
			break;
		}
		default:
			std::cout << std::endl << "Введено неверно!" << std::endl;
		}
	} while (choice < 5);

	return 0;
}