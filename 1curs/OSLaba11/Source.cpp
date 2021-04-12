#include <windows.h>
#include <iostream>
#include<iomanip>
int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	HANDLE hHeap;
	int* arr = NULL;
	int a_size;   //������ �������
	int choice; // �����
	int enter; //����
	int delet; //��������
	int index; //�����

	std::cout << "������� ������ �������:  ";
	std::cin >> a_size;
	hHeap = HeapCreate(HEAP_NO_SERIALIZE, a_size, a_size);//������� �������� ���� (����� �������������� � ������� ��������)
	if (!hHeap)
	{
		std::cout << "Heap Creation Failed" << std::endl;
		return GetLastError();
	}
	//������������ ������ ���� ��� ������
	arr = (int*)HeapAlloc(hHeap, NULL, a_size);//��������� �������� ���� �� �����
	if (!arr)
	{
		std::cout << "Heap allocation Failed" << std::endl; ;//�����. �����
		return GetLastError();
	}

	std::cout << "������ ������ �� " << a_size << " �����....\n";
	for (int i = 0; i < a_size; i++) {
		arr[i] = i;//���������� ����� � ������
	}
	do
	{
		std::cout << "�������:" << std::endl;
		std::cout << "1-��� ���������� ������� ������� �� 1           " << std::endl;
		std::cout << "2-��� ���������� ������� ������� �� 1           " << std::endl;
		std::cout << "3-��� ������� �������� � ��������               " << std::endl;
		std::cout << "4-��� �������� �������� �� ��������             " << std::endl;
		std::cout << "_____________________________________" << std::endl;
		std::cin >> choice;
		switch (choice)
		{
		case 1: {
			std::cout << "������ ������ ������� �� +1\n";
			arr = (int*)HeapReAlloc(hHeap, NULL, arr, a_size++);//�������� ������� ���� 
			arr[a_size - 1] = a_size - 1;
			std::cout << "� ������� ����� - " << a_size << " �����\n";
			for (int i = 0; i < a_size; i++) {
				std::cout << arr[i] << "   ";
			}break;
		}
		case 2: {
			std::cout << "������ ������ ������� �� -1\n";
			arr = (int*)HeapReAlloc(hHeap, NULL, arr, a_size--);
			std::cout << "� ������� ����� - " << a_size << " �����\n";
			for (int i = 0; i < a_size; i++) {
				std::cout << arr[i] << "   ";
			}break;
		}
		case 3: {
			std::cout << "������ ������ ������� �� +1\n";
			arr = (int*)HeapReAlloc(hHeap, NULL, arr, a_size++);
			std::cout << "������� ����������� ����� �� " << a_size << "    ";
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
			std::cout << "������� ��������� ����� �� " << a_size << "    ";
			std::cin >> enter;
			index = enter + 1;
			for (int i = index; i < a_size; i++) {
				arr[index] = index;
			}
			std::cout << "������ ������ ������� �� -1\n";
			arr = (int*)HeapReAlloc(hHeap, NULL, arr, a_size--);
			for (int i = 0; i < a_size; i++) {
				std::cout << arr[i] << "   ";
			}
			break;
		}
		default:
			std::cout << std::endl << "������� �������!" << std::endl;
		}
	} while (choice < 5);

	return 0;
}