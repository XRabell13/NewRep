/*
3. N человек  располагаются  по кругу.  Начав отсчет от первого, удаляют каждого k-го, смыкая круг после удаления. 
Определить порядок удаления людей из круга. Использовать линейный список.(Порядок... это колічество?)
*/
/*
#include <iostream>
#include <conio.h>
using namespace std;

struct  Node
{
	int x;
	Node* Next;
};

struct List
{
	Node* Head, * Tail; //Первый элемент и тот что последний
	int size; //Число элементов в списке
	List():Head(NULL), Tail(NULL), size(0) {}; //Инициализация элементов в ноль с помощью конструктора
	void Add(int x); //Функция добавления элементов в список
	bool del(int k, int n);    //Функция удаления элементов из списка
	void Show(int size); //Функция отображения элементов списка
	int Count(); //Функция возвращающая число элементов в списке
};

int List::Count()
{
	return size; //Возвращаем число элементов списка
}

void List::Add(int x)
{
	size++; //При каждом добавлении элемента увеличиваем число элементов в списке
	Node* temp = new Node; //Выделение памяти для нового элемента списка
	temp->Next = Head; //Замыкание контура. Последний элемент - это начало списка 
	temp->x = x; //Записываем в выделенную ячейку памяти значение x 

	if (Head != NULL) //В том случае если список не пустой
	{
		Tail->Next = temp; //Запись данных в следующее за последним элементом поле
		Tail = temp; //Последний активный элемент=только что созданный.
	}
	else Head = Tail = temp;//Если список пуст то создается первый элемент.
}

bool List::del(int k, int n)   //Удаляем элемент с заданной позиции
{

	Node* temp = Tail;
	int rt = -1;
	while (rt < n)//Head!=Tail
	{
		rt++;
		if (Head == NULL) {
			cout << "Список пуст" << endl;
			return false;
		}
		for (int i = 1; i < k; i++)//temp уже указывает на следующий элемент, поэтому количество итераций -1
			temp = temp->Next;
		Node* buf = temp->Next;
		cout << buf->x << " ";
		if (buf == Head) Head = buf->Next;
		if (buf == Tail) Tail = temp;
		temp->Next = buf->Next;
		delete buf;
	}
	return true;
}

void List::Show(int temp)
{
	Node* tempHead = Head; //Указываем на голову

	temp = size; //Временная переменная равная числу элементов в списке
	while (temp != 0) //Пока не выполнен признак прохода по всему списку
	{
		cout << tempHead->x << " "; //Очередной элемент списка на экран 
		tempHead = tempHead->Next; //Указываем, что нужен следующий элемент
		temp--; //Один элемент считан, значит осталось на один меньше 
	}
}

void main()
{
	setlocale(LC_ALL, "Russian");
	int n, k;
	List lst;
	cout << "Введите кол-во элементов в списке" << endl;
	cin >> n;
	for (int i = 1; i < (n+1); i++)
	{
		lst.Add(i);
	}
	cout << "Список:" << endl;
	lst.Show(lst.Count());  //Показываем список на экране.
	cout << endl;
	cout << "Введите k:" << endl;
	cin >> k;
	lst.del(k, n);
	cout << endl;
	getchar();
}*/
#include <iostream>
#include <conio.h>
using namespace std;

struct  Node
{
	int x;
	Node* Next;
};

struct List
{
	Node* Head=NULL, * Tail=NULL; 
	int size=0; 

	void Add(int x); //Функция добавления элементов в список
	bool del(int k, int n);    //Функция удаления элементов из списка
	void Show(int size); //Функция отображения элементов списка
	int Count(); //Функция возвращающая число элементов в списке
};

int List::Count()
{
	return size; //Возвращаем число элементов списка
}

void List::Add(int x)
{
	size++; 
	Node* temp = new Node; 
	temp->Next = Head;
	temp->x = x; 

	if (Head != NULL) 
	{
		Tail->Next = temp;
		Tail = temp; 
	}
	else Head = Tail = temp;
}

bool List::del(int k, int n)   //Удаляем элемент с заданной позиции
{
	int rt=0;
	Node* temp = Tail;
	while (rt<n)
	{
		rt++;
		if (Head == NULL) {
			cout << "Список пуст" << endl;
			return false;
		}
		for (int i = 1; i < k; i++)
			temp = temp->Next;
		Node* buf = temp->Next;
		cout << buf->x << " ";
		if (buf == Head) Head = buf->Next;
		if (buf == Tail) Tail = temp;
		temp->Next = buf->Next;
		delete buf;
	}
	return true;
}

void List::Show(int temp)
{
	Node* tempHead = Head; //Указываем на голову
	temp = size; 
	while (temp != 0) 
	{
		cout << tempHead->x << " "; 
		tempHead = tempHead->Next; 
		temp--; //Один элемент считан, значит осталось на один меньше 
	}
}

void main()
{
	setlocale(LC_ALL, "Russian");
	int n, k;
	List lst;
	cout << "Введите кол-во элементов в списке" << endl;
	cin >> n;
	for (int i = 1; i < (n + 1); i++)
	{
		lst.Add(i);
	}
	cout << "Список:" << endl;
	lst.Show(lst.Count());  //Показываем список на экране.
	cout << endl;
	cout << "Введите k:" << endl;
	cin >> k;
	lst.del(k, n);
	cout << endl;
}