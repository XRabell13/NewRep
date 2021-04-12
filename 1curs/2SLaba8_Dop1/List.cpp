#include "List.h"
#include <cstddef>
bool Object::Insert(void* data)           // ������� � ������
{
	bool rc = 0;
	if (Head == NULL)
	{
		Head = new Element(NULL, data, Head);
		rc = true;
	}
	else
	{
		Head = (Head->Prev = new Element(NULL, data, Head));
		rc = true;
	}
	return rc;
}
//-----------------------------------------------------------
Element* Object::Search(void* data)    // ����� �������� �������
{
	Element* rc = Head;
	while ((rc != NULL) && (rc->Data != data))
		rc = rc->Next;
	return rc;
}
//-----------------------------------------------------------
void Object::PrintList(void(*f)(void*))  //�������� ������� ������ // �����
{
	Element* e = Head;
	while (e != NULL)
	{
		f(e->Data);//� ������� ��������� ������ � ��� �� ������� � ��� �� �����
		e = e->GetNext();
	};
}
//-----------------------------------------------------------
void Object::PrintList(void(*f)(void*), Element* e)// ������� ���������� �������?
{
	f(e->Data);
}
//-----------------------------------------------------------
bool  Object::Delete(Element* e)    // ������� �� ������
{
	bool rc = 0;
	if (rc = (e != NULL))
	{
		if (e->Next != NULL)
			e->Next->Prev = e->Prev;//��������� �� ��������� ���������� ������� ������ ������ ����������?
		if (e->Prev != NULL)
			e->Prev->Next = e->Next;//��������� �� ���������� ��������� ������� ������ ������ ���������?
		else
			Head = e->Next;
		delete e;
	}
	return rc;//�� ���� �������� ������ ��� �� ������ ��������
}
//-----------------------------------------------------------
bool Object::Delete(void* data)      // ������� �� ��������
{
	return Delete(Search(data));
};
//-----------------------------------------------------------
Element* Object::GetLast()
{
	Element* e = Head, * rc = e;
	while (e != NULL)
	{
		rc = e;
		e = e->GetNext();
	}
	return rc;
}
//-----------------------------------------------------------
Object Create()
{
	return *(new Object());
}
 
bool Object::DeleteList()
{
	while (Head!=NULL)
	{
		Element* e=Head;
		if (e->Next != NULL)
			e->Next->Prev = e->Prev;
		if (e->Prev != NULL)
			e->Prev->Next = e->Next;
		else
			Head = e->Next;
		delete e;
	}
	if (Head == NULL)
		return 1;//�� ���� �������� ������ ��� �� ������ ��������
	else return 0;
}

int Object::CountList()
{
	Element* rc = Head;
	int count=0;
	while (rc != NULL)
	{
		rc = rc->Next;
		count++;
	}
	return count;
}	