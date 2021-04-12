
#include "stdafx.h"
#include "Hash.h"

//--------------------------------------------------------------------
static const unsigned char sTable[256] = {
	// 0-255 shuffled in any (random) order suffices
	 98,  6, 85,150, 36, 23,112,164,135,207,169,  5, 26, 64,165,219, //  1
	 61, 20, 68, 89,130, 63, 52,102, 24,229,132,245, 80,216,195,115, //  2
	 90,168,156,203,177,120,  2,190,188,  7,100,185,174,243,162, 10, //  3
	237, 18,253,225,  8,208,172,244,255,126,101, 79,145,235,228,121, //  4
	123,251, 67,250,161,  0,107, 97,241,111,181, 82,249, 33, 69, 55, //  5
	 59,153, 29,  9,213,167, 84, 93, 30, 46, 94, 75,151,114, 73,222, //  6
	197, 96,210, 45, 16,227,248,202, 51,152,252,125, 81,206,215,186, //  7
	 39,158,178,187,131,136,  1, 49, 50, 17,141, 91, 47,129, 60, 99, //  8
	154, 35, 86,171,105, 34, 38,200,147, 58, 77,118,173,246, 76,254, //  9
	133,232,196,144,198,124, 53,  4,108, 74,223,234,134,230,157,139, // 10
	189,205,199,128,176, 19,211,236,127,192,231, 70,233, 88,146, 44, // 11
	183,201, 22, 83, 13,214,116,109,159, 32, 95,226,140,220, 57, 12, // 12
	221, 31,209,182,143, 92,149,184,148, 62,113, 65, 37, 27,106,166, // 13
	  3, 14,204, 72, 21, 41, 56, 66, 28,193, 40,217, 25, 54,179,117, // 14
	238, 87,240,155,180,170,242,212,191,163, 78,218,137,194,175,110, // 15
	 43,119,224, 71,122,142, 42,160,104, 48,247,103, 15, 11,138,239  // 16
};

unsigned int HashTable::HashFunction(char* str, unsigned int len)
{
	unsigned int hash = 0, i;
	unsigned int rotate = 2;
	unsigned int seed = 0x1A4E41U;

	for (i = 0; i != len; i++, str++)
	{

		hash += sTable[(*str + i) & 255];
		hash = (hash << (32 - rotate)) | (hash >> rotate);
		hash = (hash + i) * seed;

	}

	return (hash + len) * seed;
}
/*int HashTable::HashFunction(int keyOfNewElem)
{
	unsigned int choiceOfHashFuncReturn = keyOfNewElem % 3;
	switch (choiceOfHashFuncReturn)
	{
		case 0: return  ((keyOfNewElem + 5 * 6 + 3 * 2 * 41) % this->size);
		case 1: return  ((keyOfNewElem * int(0.6180339887499 + choiceOfHashFuncReturn)) % this->size);
		case 2: return  int(0.6180339887499 * keyOfNewElem) % this->size;
	}
}*/
//--------------------------------------------------------------------
void HashTable::Insert()
{
	if (this->currentSize < this->size)
	{
		Node *newElem = new Node;
		Node *temp;

		cout << "\nНомер квартиры: ";	cin >> newElem->numflat;
		cout << "Жилец/жильцы: ";		cin >> newElem->surname; cout << endl;

		unsigned int position = HashFunction(newElem->numflat, strlen(newElem->numflat));
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
	Node *temp;

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
			cout << "|Номер квартиры: " << temp->numflat << "\t\t: Жилец/жильцы" << temp->surname << "|\n"; 
			temp = temp->next;
		}
		cout << endl;
		
	}
	cout << "\n-----------------------------------------------------------------------------------------------------------\n";
}
//--------------------------------------------------------------------
void HashTable::DeleteNode()
{
	char delElemKey[10]; Node *temp;

	cout << "Номер квартиры: " << endl;
	cin >> delElemKey; cout << endl;

			unsigned int position = HashFunction(delElemKey, strlen(delElemKey));
			if(!this->table[position].next)
			{
				cout << "Данные о квартире не найдены.\n";
				return;
			}

			temp = this->table[position].next;

			while (temp)
			{
				if (temp->numflat == delElemKey)
				{

					if (temp == this->table[position].next)
					{
						this->table[position].next = temp->next;
						this->table[position].prev = nullptr;
						if (this->table[position].next)
							this->table[position].next->prev = &this->table[position];
						delete temp;
						this->currentSize--;
						cout << "Информация об квартире удалена.\n";
						return;
					}

					if (temp->next == nullptr)
					{
						temp->prev->next = nullptr;
						delete temp;
						this->currentSize--;
						cout << "Информация об квартире удалена.\n";
						return;
					}

					temp->next->prev = temp->prev;
					temp->prev->next = temp->next;
					delete temp;
					this->currentSize--;

					cout << "Информация об квартире удалена.\n";
					break;
				}

				temp = temp->next;
			}

			this->table[position].next = nullptr;
			cout << "Данные о квартире удалены.\n";
			
}
//--------------------------------------------------------------------
void HashTable::SearchNodes()
{
	char searchNodeKey[10];
	cout << "Введите номер квартиры: "; cin >> searchNodeKey; cout << endl;

	unsigned int i = HashFunction(searchNodeKey, strlen(searchNodeKey));
	if (!this->table[i].next)
	{
		cout << "Данных о квартире номер "<< searchNodeKey <<" не обнаружено\n";
		return;
	}

	cout << "Квартира номер " << searchNodeKey <<":\n";
	cout << " Цепочка №" << i << ":\n";

	Node *temp = this->table[i].next;

	while (temp)
	{
		cout << "|Номер квартиры: " << temp->numflat << "\t\tЖилец-жильцы: " << temp->surname << "\t\t|\n";
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