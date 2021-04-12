#include <iostream>
#include <fstream>
#include <windows.h>
using namespace std;
struct list
{
	float number;
	list* next;
};
void insert(list*&, float); //функция добавления элемента, передается адрес спис-ка и символ, который добавляется 
float del(list*&, float);   //функция удаления, передается адрес списка и символ, который удаляется 
int IsEmpty(list*);         //функция, которая проверяет, пуст ли список
void printList(list*);      //функция вывода
void menu(void);     //функция, показывающая меню
void sum7(list*);//функция подсчет
void toFile(list*& p);//функция записи в файл
void fromFile(list*& p);//функция чтения из файла
void find(float valu, list*& p);//функция поиска элемента в списке

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	setlocale(LC_CTYPE, "Russian");
	list* first = NULL;
	int choice;
	float value;
	menu();    // вывести меню 
	cout << " ? ";
	cin >> choice;
	while (choice != 8)
	{
		switch (choice)
		{
		case 1:  	cout << "Введите число "; // добавить число в список
			cin >> value;
			insert(first, value);
			break;
		case 2:   if (!IsEmpty(first)) // удалить число из списка
		{
			cout << "Введите удаляемое число ";
			cin >> value;
			if (del(first, value))
			{
				cout << "Удалено число " << value << endl;
				printList(first);
			}
			else
				cout << "Число не найдено" << endl;
		}
				  else
			cout << "Список пуст" << endl;
			break;
		case 3:   sum7(first);	// вычисление суммы	
			break;
		case 4: 	printList(first); break;
		case 5: cout << "Введите элемент, который хотите найти: "; 
			cin >> value; 
			find(value, first); break;
		case 6: toFile(first); break;
		case 7: fromFile(first); break;
		default:  cout << "Неправильный выбор" << endl;
			menu();
			break;
		}
		cout << "?  ";
		cin >> choice;
	}
	cout << "Конец" << endl;
	return 0;
}

void menu(void)  //Вывод меню 
{
	cout << "Сделайте выбор:" << endl;
	cout << " 1 - Ввод элемента" << endl;
	cout << " 2 - Удаление элемента" << endl;
	cout << " 3 - Вычисление среднего значения положительных элементов" << endl;
	cout << " 4 - Вывод списка в консольное окно" << endl;
	cout << " 5 - Поиск элемента" << endl;
	cout << " 6 - Запись списка элементов в файл" << endl;
	cout << " 7 - Считывание списка элементов из файла" << endl;
	cout << " 8 - Выход" << endl;
}
//добавление элемента, удаление элемента, поиск элемента, вывод списка в консольное окно, запись списка в файл, считывание списка из файла. 

void insert(list*& p, float value) //Добавление числа value в список 
{
	list* newP = new list;// выделение достаточного места памяти и указатель на этот участок выделенной памяти
	if (newP != NULL)     //есть ли место?  
	{
		newP->number = value;
		newP->next = p;
		p = newP;
	}
	else
		cout << "Операция добавления не выполнена" << endl;
}
float del(list*& p, float value)  // Удаление числа 
{
	list* previous, * current, * temp;
	if (value == p->number)
	{
		temp = p;
		p = p->next;    // отсоединить узел 
		delete temp;      //освободить отсоединенный узел 
		return value;
	}
	else
	{
		previous = p;
		current = p->next;
		while (current != NULL && current->number != value)
		{
			previous = current;
			current = current->next; // перейти к следующему 
		}
		if (current != NULL)
		{
			temp = current;
			previous->next = current->next;
			free(temp);
			return value;
		}
	}
	return 0;
}

int IsEmpty(list* p) //Список  пустой? (1-да, 0-нет) 
{
	return p == NULL;
}

void printList(list* p)  //Вывод списка 
{
	if (p == NULL)
		cout << "Список пуст" << endl;
	else
	{
		cout << "Список:" << endl;
		while (p != NULL)
		{
			cout << "-->" << p->number;
			p = p->next;
		}
		cout << "-->NULL" << endl;
	}
}

void sum7(list* p)  // Подсчет среднего значения положительных чисел
{
	float sm = 0, nom=0;
	if (p == NULL)
		cout << "Список пуст" << endl;
	else
	{
		while (p != NULL)
		{
			if (p->number > 0)
			{
				sm = sm + (p->number);
				nom++;
			}
			p = p->next;
		}
		sm = sm / nom;
		cout << "Среднее значение: " << sm << endl;
	}
}

void toFile(list*& p)
{
	list* temp = p;
	list buf;
	ofstream frm("mList.txt");
	if (frm.fail())
	{
		cout << "\n Ошибка открытия файла";
		exit(1);
	}
	while (temp)
	{
		buf = *temp;
		frm.write((char*)& buf, sizeof(list));
		temp = temp->next;
	}
	frm.close();
	cout << "Список записан в файл mList.txt\n";
}

void fromFile(list*& p)          //Считывание из файла
{
	list buf, * first = nullptr;
	ifstream frm("mList.txt");
	if (frm.fail())
	{
		cout << "\n Ошибка открытия файла";
		exit(1);
	}
	frm.read((char*)& buf, sizeof(list));
	while (!frm.eof())
	{
		insert(first, buf.number);
		cout << "-->" << buf.number;
		frm.read((char*)& buf, sizeof(list));
	}
	cout << "-->NULL" << endl;
	frm.close();
	p = first;
	cout << "\nСписок считан из файла mList.txt\n";
}

void find(float valu, list*& p)    // Поиск имени в списке
{
	
	list* t = p;
	int k = 0;
	for(int i=0; i<10; i++)
	{
		if (valu == (t->number))
		{
			k++;
			break;
		}
		t=t->next;
		if (t == NULL) break; 
	}
	if (!k)
		cout << "Элемент не найден!" << endl;
	else
		cout << "Элемент " << t->number <<" присутствует в списке"<< endl;
}
