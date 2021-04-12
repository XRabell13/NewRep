/*������� ������� ��� �������� � ������� ��� �����, ������,
�������� � ����������� ������� �������. ������ ������� � ������ � �������.
� ������ ���������� ��������� ������� � ������ ��������� ������� ������� ������� � �� ������.
������� ������ �� ���������� ������, ��������������� ������ � ��������. 
� ������������ �� ����� ��������� ��������� ����-��� �� �������, �������������� ����.
����������� ���� � ����������� ��� �������� � �������� ����� �������. ������������ ������ ������� ������ � ����������.
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
	std::cout << "������� ������ �������: ";  std::cin >> size;
	while (choice!=5)
	{
		meny();
		std::cin >> choice;
		switch (choice)
		{
		case 1: std::cout << "������� �������: \n";
			if (begin == NULL)
			{
				std::cin >> p; 
				oneElem=p;
				t->info = p;        //������ �������
				t->next = NULL;
				begin = end = t;
			}
			else //�������� �������
			{
			   std::cin >> p;
				create(&begin, &end, p);
				if (p == oneElem) 
				{
					std::cout << "�������: ";
					view(begin);
					n = siz(begin); 
					std::cout << "������ �������: " << n << '\n';
				}
			}
			break;
		case 2: n = siz(begin); std::cout << "������ �������: "<<n<<'\n';  break;
		case 3: if (begin == NULL)   //����� �� �����
			std::cout << "��������� ���\n";
				else
			view(begin); break;
		case 4: clear(&begin); 
			if (begin == NULL) std::cout << "������� �������!\n";
			else std::cout << "�� ������� �������� �������!\n";
			break;
		}
	}
	std::cout << "\nGoodbye!\n";
	return 0;
}
