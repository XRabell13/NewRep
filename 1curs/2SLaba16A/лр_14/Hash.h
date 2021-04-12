#pragma once

struct Node
{
	int creationYear;
	string surname;
	string address;
	Node *next;
	Node *prev;

	Node()
	{
		this->creationYear = -1;
		this->surname = this->address = "";
		this->next = this->prev = NULL;
	}
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
	int HashFunction(int keyOfNewElem);
	void PrintTable();
	void DeleteNode();
	void SearchNodes();
	void FillPercent();
};

