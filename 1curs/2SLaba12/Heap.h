#pragma once
struct AAA
{
	int x;
	void print();
	int iprint();
	int getPriority() const;
};
namespace heap
{
	enum CMP
	{
		LESS = -1, EQUAL = 0, GREAT = 1
	};
	struct Heap // куча
	{
		int size;
		int maxSize;
		void** storage;              // данные    
		CMP(*compare)(void*, void*);
		Heap(int maxsize, CMP(*f)(void*, void*))
		{
			size = 0;
			storage = new void* [maxSize = maxsize];
			compare = f;
		};

		int left(int ix);
		int right(int ix);
		int parent(int ix);

		bool isFull() const
		{
			return (size >= maxSize);
		};

		bool isEmpty() const// проверка на то, пусто или нет
		{
			return (size <= 0);
		};

		bool isLess(void* x1, void* x2) const // минимальный элемент
		{
			return compare(x1, x2) == LESS;
		};

		bool isGreat(void* x1, void* x2) const // максимальный элемент
		{
			return compare(x1, x2) == GREAT;
		};

		bool isEqual(void* x1, void* x2) const // равные элементы
		{
			return compare(x1, x2) == EQUAL;
		};

		void swap(int i, int j);//элементы буфера меняем
		void heapify(int ix);//поиск максимального элемента
		void _heapify(int ix);//поиск минимального элемента
		void insert(void* x);//добавить новый элемент
		void* extractMax();//удалить максимальный элемент
		void* extractMin();//удалить минимальный элемент
		void* extractI(int i);//удалить i элемент
		void unionHeap(Heap h1, Heap h2, Heap h3) const;//удалить i элемент
		//void enumHeap();
		void _swap(int i);
		void scan(int i) const;//вывести на экран кучу
		void iscan(int i) const;
		int find(int d);
	};

	Heap create(int maxsize, CMP(*f)(void*, void*));
};


