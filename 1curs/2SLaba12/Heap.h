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
	struct Heap // ����
	{
		int size;
		int maxSize;
		void** storage;              // ������    
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

		bool isEmpty() const// �������� �� ��, ����� ��� ���
		{
			return (size <= 0);
		};

		bool isLess(void* x1, void* x2) const // ����������� �������
		{
			return compare(x1, x2) == LESS;
		};

		bool isGreat(void* x1, void* x2) const // ������������ �������
		{
			return compare(x1, x2) == GREAT;
		};

		bool isEqual(void* x1, void* x2) const // ������ ��������
		{
			return compare(x1, x2) == EQUAL;
		};

		void swap(int i, int j);//�������� ������ ������
		void heapify(int ix);//����� ������������� ��������
		void _heapify(int ix);//����� ������������ ��������
		void insert(void* x);//�������� ����� �������
		void* extractMax();//������� ������������ �������
		void* extractMin();//������� ����������� �������
		void* extractI(int i);//������� i �������
		void unionHeap(Heap h1, Heap h2, Heap h3) const;//������� i �������
		//void enumHeap();
		void _swap(int i);
		void scan(int i) const;//������� �� ����� ����
		void iscan(int i) const;
		int find(int d);
	};

	Heap create(int maxsize, CMP(*f)(void*, void*));
};


