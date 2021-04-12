#include "Heap.h"
#include <iostream>
#include <iomanip>
void AAA::print()
{
	std::cout << x;
}
int AAA::iprint()
{
	return x;
}
int AAA::getPriority() const
{
	return x;
}
namespace heap
{
	Heap create(int maxsize, CMP(*f)(void*, void*))
	{
		return *(new Heap(maxsize, f));
	}
	int Heap::left(int ix)//����� �����
	{
		return (2 * ix + 1 >= size) ? -1 : (2 * ix + 1);
	}
	int Heap::right(int ix)//������ �����
	{
		return (2 * ix + 2 >= size) ? -1 : (2 * ix + 2);
	}
	int Heap::parent(int ix)
	{
		return (ix + 1) / 2 - 1;
	}
	void Heap::swap(int i, int j)// ix and irl ��� ����������� � ������� �� ��� �� � �������� �������
	{
		void* buf = storage[i];
		storage[i] = storage[j];
		storage[j] = buf;
	}
	void Heap::heapify(int ix)//����� ������������� ��������
	{
		int l = left(ix), r = right(ix), irl = ix;//�������� ������! �������� � �������
		if (l > 0)
		{
			if (isGreat(storage[l], storage[ix])) irl = l;//��������� ��������� �� ����� ����� � ��������� �� ������ �����, ������� �������� ����� ������ ���������?
			if (r > 0 && isGreat(storage[r], storage[irl])) irl = r;//���� ����� ������ ������� ������ �������� ������� ��������(����� ��������� �������), �� ����������� �����
			if (irl != ix)// ���� ����� ������������ ������� �� ������� ��������(������������ ������) �� ����� ��������� �����, ��... ������ ����� ��� �����, �� ��� ����������
			{
				swap(ix, irl);
				heapify(irl);
			}
		}
	}
	void Heap::_swap(int i)
	{
		//	void* buf = storage[i];
		void* buf = storage[i];
		storage[i] = storage[i+1];
		storage[i+1] = buf;

	}
	void Heap::_heapify(int ix)//����� ������������ ��������
	{
		int x, y, l = left(ix), r = right(ix), irl = ix;//��� ��������� �������� ����� 0
		for (int i=0; i<size; i++)
			if (((AAA*)storage[i])->iprint() < ((AAA*)storage[irl])->iprint()) irl = i;//���� ����������� �������
		x = size - irl;//������� ������� �� ����� ������� �� ������������ ��������
		for (int i=0; i<=x; i++)
		_swap(irl++);// �������� ������� �� ��������� ����� � ������ ������ ������ �� 1, �.�. ���������� ������� �� ������� �������. ����� ����� ������� �����
	//	�� ������� ������ � ��� ��
		
		/* for(int i = 0; i<=size; i++)
		 {
			 if (storage[i] <= storage[irl]) irl = i;
		 }
		 _swap(irl);*/
	}

	void* Heap::extractMax()// �������� ������������� ��������
	{
		void* rc = nullptr;
		if (!isEmpty())
		{
			rc = storage[0];

			storage[0] = storage[size - 1];
			size--;
			heapify(0);
		} return rc;
	}

	void* Heap::extractMin()// �������� ������������ ��������(�������� ���� �������� � ������������ �������� �������������� ������ � ����� �����)
	{
		void* rc = nullptr;
		if (!isEmpty())
		{
			rc = storage[0];
			//	storage[0] = storage[size - 1];
			_heapify(0);
			size--;
		} return rc;
	}
	void* Heap::extractI(int i)//������� i �������
	{
		AAA* a = new AAA;
		int p, k=i, buf[20], size1;
		void* rc = nullptr;
		if (!isEmpty())
		{
			rc = storage[0];
		//	storage[0] = storage[size - 1];
			p = size - i;//������� ������� �� ����� ������� �� ��������
			for (int j = 0; j <= p; j++)
				_swap(k++);
			size1=size-1;
			size = 0;
			for (int j = 0; j < size1; j++) buf[j] = ((AAA*)storage[j])->iprint();
			for (int i=0; i < size1; i++)
			{
				a->x = buf[i];
				insert(a);
				a++;
			}
		
		} return rc;
	}
	void Heap::scan(int i) const     //����� �������� ��������� �� �����
	{
		int probel = 20;
		std::cout << '\n';
		if (size == 0)
			std::cout << "���� �����";
		for (int u = 0, y = 0; u < size; u++)
		{

			std::cout << std::setw(probel + 10) << std::setfill(' ');
			((AAA*)storage[u])->print();
			if (u == y)
			{
				std::cout << '\n';
				if (y == 0)
					y = 2;
				else
					y += y * 2;
			}
			probel /= 2;
		}
		std::cout << '\n';
	
	}
	void Heap::iscan(int i) const
	{
		for (int i = 0; i < size; i++) { ((AAA*)storage[i])->print(); }
		std::cout << '\n'; 
	}
	void Heap::insert(void* x)//���������� ������ ��������
	{
		int i;
		if (!isFull())
		{
			storage[i = ++size - 1] = x;
			while (i > 0 && isLess(storage[parent(i)], storage[i]))
			{
				swap(parent(i), i);
				i = parent(i);
			}
		}
	}
	void Heap::unionHeap(Heap h1, Heap h2, Heap h3) const
	{
		AAA* a = new AAA;
		int i=0, j, k;
		for (; i < h1.size; i++) 
		{
			a->x = ((AAA*)h1.storage[i])->iprint();
			h3.insert(a);
			a++;
		}

		for (int h=0;  h<h2.size; h++)
		{
			a->x = ((AAA*)h2.storage[h])->iprint();
			h3.insert(a);
			a++;
		}

		h3.scan(0);

	}
	int Heap::find(int d)
	{
		int num;
		for (int i = 0; i < size; i++)
			if ((((AAA*)storage[i])->iprint()) == d) num = ((AAA*)storage[i])->iprint();
		return num;
	}
}

