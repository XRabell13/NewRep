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

		cout << "\nНомер квартиры: ";	cin >> newElem->creationYear;
		cout << "Жилец/жильцы: ";			cin >> newElem->address;
		cout << "Введите фамилию: ";		cin >> newElem->surname; cout << endl;

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
		cout << "Хэш-таблица заполнена." << endl;

}
//--------------------------------------------------------------------
void HashTable::PrintTable()
{
	Node* temp;

	cout << "\n-----------------------------------------------------------------------------------------------------------\n";
	for (int i = 0; i < this->size; i++)
	{
		temp = this->table[i].next;

		cout << " Цепочка №" << i << ":\n";
		if (!this->table[i].next)
		{
			cout << "пусто\n\n";
			continue;
		}

		while (temp)
		{
			cout << "|Адрес: " << temp->address << "\t\tФамилия: " << temp->surname << "\t\tГод создания: " << temp->creationYear << "|\n";
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

	cout << "Как удалить?" << endl;
	cout << "1. По году создания(удалятся все эл-ты с этим ключем)" << endl;
	cout << "2. По году создания и фамилии(удалится определенный эл-т)" << endl;
	cout << "3. Отмена" << endl;
	cout << "Ваш выбор: "; cin >> choice; cout << endl;

	int delElemKey; string delElemStr; Node* temp;
	switch (choice)
	{
	case 1:
	{
		cout << "Введите год создания: ";	cin >> delElemKey;
		int position = HashFunction(delElemKey);
		if (!this->table[position].next)
		{
			cout << "Абоненты соответствующие данному году создания не найдены.\n";
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
					cout << "Информация об абоненте удалена.\n";
					return;
				}

				if (temp->next = nullptr)
				{
					temp->prev->next = nullptr;
					delete temp;
					this->currentSize--;
					cout << "Информация об абоненте удалена.\n";
					return;
				}

				temp->next->prev = temp->prev;
				temp->prev->next = temp->next;
				delete temp;
				this->currentSize--;

				cout << "Информация об абоненте удалена.\n";
				break;
			}

			temp = temp->next;
		}

		this->table[position].next = nullptr;
		cout << "Абоненты удалены.\n";
		break;
	}
	case 2:
	{
		cout << "\nВведите год создания: ";	cin >> delElemKey;
		cout << "Введите фамилию "; cin >> delElemStr; cout << endl;

		int position = HashFunction(delElemKey);
		if (!this->table[position].next)
		{
			cout << "Абонентов с данным годом создания не найдено.\n";
			return;
		}

		temp = this->table[position].next;

		while (temp->surname != delElemStr)
		{

			if (!temp)
			{
				cout << "Абонентов с такой фамилией не найдено.\n";
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
			cout << "Информация об абоненте удалена.\n";
			return;
		}

		if (temp->next = nullptr)
		{
			temp->prev->next = nullptr;
			delete temp;
			this->currentSize--;
			cout << "Информация об абоненте удалена.\n";
			return;
		}

		temp->next->prev = temp->prev;
		temp->prev->next = temp->next;
		delete temp;
		this->currentSize--;

		cout << "Информация об абоненте удалена.\n";
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
	cout << "Введите год создания по которому будут отобраны абоненты: "; cin >> searchNodeKey; cout << endl;

	int i = HashFunction(searchNodeKey);
	if (!this->table[i].next)
	{
		cout << "Абонентов не обнаружено.\n";
		return;
	}

	cout << "Все найденные абоненты:\n";
	cout << " Цепочка №" << i << ":\n";

	Node* temp = this->table[i].next;

	while (temp)
	{
		cout << "|Адрес: " << temp->address << "\t\tФамилия: " << temp->surname << "\t\tГод создания: " << temp->creationYear << "|\n";
		temp = temp->next;
	}
	cout << endl;

}
//--------------------------------------------------------------------
void HashTable::FillPercent()
{
	cout << "\nНа данный момент таблица заполнена на " << int(float(this->currentSize) / float(this->size) * 100) << "%.\n";
}
//--------------------------------------------------------------------