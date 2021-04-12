#pragma once

struct Node
{
	char numflat[10];
	char surname[70];
	Node *next;
	Node *prev;
};


struct HashTable
{
	int currentSize;
	int size;
	Node *table;

	HashTable(int size)
	{
		this->size = size;
		this->currentSize = 0;
		this->table = new Node[size];
	}

	void Insert();
	unsigned int HashFunction(char* str, unsigned int len);
	void PrintTable();
	void DeleteNode();
	void SearchNodes();
	void FillPercent();
};

