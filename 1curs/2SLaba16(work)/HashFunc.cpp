#include "Hash.h"
#include <iostream>
#include <string>
using namespace std;
//--------------------------------------------------------------------
int HashTable::HashFunction(int keyOfNewElem)
{
	unsigned int choiceOfHashFuncReturn = keyOfNewElem % 3;
	switch (choiceOfHashFuncReturn)
	{
	case 0: return  ((keyOfNewElem + 5 * 6 + 3 * 2 * 41) % this->size);
	case 1: return  ((keyOfNewElem * int(0.6180339887499 + choiceOfHashFuncReturn)) % this->size);
	case 2: return  int(0.6180339887499 * keyOfNewElem) % this->size;
	}
}
//--------------------------------------------------------------------
void HashTable::Insert()
{
	if (this->currentSize < this->size)
	{
		Node* newElem = new Node;
		Node* temp;

		cout << "\n����� ��������: ";	cin >> newElem->creationYear;
		cout << "�����/������: ";			cin >> newElem->address;
		cout << "������� �������: ";		cin >> newElem->surname; cout << endl;

		int position = HashFunction(newElem->creationYear);
		temp = this->table[position].next;

		if (!temp)
		{
			this->table[position].next = newElem;
			this->table[position].next->prev = &this->table[position];
			this->currentSize++;
			return;
		}

		while (true)
		{
			if (!temp->next)
			{
				temp->next = newElem;
				temp->next->prev = temp;

				this->currentSize++;
				return;
			}
			else
				temp = temp->next;
		}
	}
	else
		cout << "���-������� ���������." << endl;

}
//--------------------------------------------------------------------
void HashTable::PrintTable()
{
	Node* temp;

	cout << "\n-----------------------------------------------------------------------------------------------------------\n";
	for (int i = 0; i < this->size; i++)
	{
		temp = this->table[i].next;

		cout << " ������� �" << i << ":\n";
		if (!this->table[i].next)
		{
			cout << "�����\n\n";
			continue;
		}

		while (temp)
		{
			cout << "|�����: " << temp->address << "\t\t�������: " << temp->surname << "\t\t��� ��������: " << temp->creationYear << "|\n";
			temp = temp->next;
		}
		cout << endl;

	}
	cout << "\n-----------------------------------------------------------------------------------------------------------\n";
}
//--------------------------------------------------------------------
void HashTable::DeleteNode()
{
	int choice;

	cout << "��� �������?" << endl;
	cout << "1. �� ���� ��������(�������� ��� ��-�� � ���� ������)" << endl;
	cout << "2. �� ���� �������� � �������(�������� ������������ ��-�)" << endl;
	cout << "3. ������" << endl;
	cout << "��� �����: "; cin >> choice; cout << endl;

	int delElemKey; string delElemStr; Node* temp;
	switch (choice)
	{
	case 1:
	{
		cout << "������� ��� ��������: ";	cin >> delElemKey;
		int position = HashFunction(delElemKey);
		if (!this->table[position].next)
		{
			cout << "�������� ��������������� ������� ���� �������� �� �������.\n";
			return;
		}

		temp = this->table[position].next;

		while (temp)
		{
			if (temp->creationYear == delElemKey)
			{

				if (temp == this->table[position].next)
				{
					this->table[position].next = temp->next;
					this->table[position].prev = nullptr;
					if (this->table[position].next)
						this->table[position].next->prev = &this->table[position];
					delete temp;
					this->currentSize--;
					cout << "���������� �� �������� �������.\n";
					return;
				}

				if (temp->next = nullptr)
				{
					temp->prev->next = nullptr;
					delete temp;
					this->currentSize--;
					cout << "���������� �� �������� �������.\n";
					return;
				}

				temp->next->prev = temp->prev;
				temp->prev->next = temp->next;
				delete temp;
				this->currentSize--;

				cout << "���������� �� �������� �������.\n";
				break;
			}

			temp = temp->next;
		}

		this->table[position].next = nullptr;
		cout << "�������� �������.\n";
		break;
	}
	case 2:
	{
		cout << "\n������� ��� ��������: ";	cin >> delElemKey;
		cout << "������� ������� "; cin >> delElemStr; cout << endl;

		int position = HashFunction(delElemKey);
		if (!this->table[position].next)
		{
			cout << "��������� � ������ ����� �������� �� �������.\n";
			return;
		}

		temp = this->table[position].next;

		while (temp->surname != delElemStr)
		{

			if (!temp)
			{
				cout << "��������� � ����� �������� �� �������.\n";
				return;
			}
			temp = temp->next;
		}

		if (temp == this->table[position].next)
		{
			this->table[position].next = temp->next;
			this->table[position].prev = nullptr;
			if (this->table[position].next)
				this->table[position].next->prev = &this->table[position];
			delete temp;
			this->currentSize--;
			cout << "���������� �� �������� �������.\n";
			return;
		}

		if (temp->next = nullptr)
		{
			temp->prev->next = nullptr;
			delete temp;
			this->currentSize--;
			cout << "���������� �� �������� �������.\n";
			return;
		}

		temp->next->prev = temp->prev;
		temp->prev->next = temp->next;
		delete temp;
		this->currentSize--;

		cout << "���������� �� �������� �������.\n";
		break;
	}
	case 3:
	{
		break;
	}
	}
}
//--------------------------------------------------------------------
void HashTable::SearchNodes()
{
	int searchNodeKey;
	cout << "������� ��� �������� �� �������� ����� �������� ��������: "; cin >> searchNodeKey; cout << endl;

	int i = HashFunction(searchNodeKey);
	if (!this->table[i].next)
	{
		cout << "��������� �� ����������.\n";
		return;
	}

	cout << "��� ��������� ��������:\n";
	cout << " ������� �" << i << ":\n";

	Node* temp = this->table[i].next;

	while (temp)
	{
		cout << "|�����: " << temp->address << "\t\t�������: " << temp->surname << "\t\t��� ��������: " << temp->creationYear << "|\n";
		temp = temp->next;
	}
	cout << endl;

}
//--------------------------------------------------------------------
void HashTable::FillPercent()
{
	cout << "\n�� ������ ������ ������� ��������� �� " << int(float(this->currentSize) / float(this->size) * 100) << "%.\n";
}
//--------------------------------------------------------------------