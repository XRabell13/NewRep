#pragma once

struct Node
{

	char surname[70];
	int numflat;
	Node* next;
	Node* prev;

	Node()
	{
		this->next = this->prev = NULL;
	}
};


struct HashTable
{
	int currentSize;
	int size;
	Node* table;

	HashTable(int size)
	{
		this->size = size;
		this->currentSize = 0;
		this->table = new Node[size];
	}

	void Insert();
	int HashFunction(int keyOfNewElem);
	unsigned int HashFunc(char* str, unsigned int len);
	void PrintTable();
	void DeleteNode();
	void SearchNodes();
	void FillPercent();
};

