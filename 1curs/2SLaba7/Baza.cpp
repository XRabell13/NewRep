//очередь идет от первого элемента к последнему при указании на следущий элемеент, тоесть слева направо
/*Очередь одномерная структура данных, для которых загрузка или извлечение элементов осуществляется
с помощью указателей начала извлечения (head) и конца (tail) очереди
в соответствии с правилом FIFO ("first-in, first-out" "первым введен, первым выведен"),
т. е. включение производится с одного, а исключение – с другого конца.*/
#include <iostream>
using namespace std;

struct Queue
{
	char symbol;
	Queue* next;
};

void intoFIFO(Queue* ph[], int v); //Постановка элемента в конец очереди
void scan(Queue* ph[]);           //Вывод элемента   
char fromFIFO(Queue* ph[]);      //Извлечение элемента   

void main()
{
	Queue A3 = { 'a', NULL }, A2 = { 'b', &A3 }, A1 = { 'c', &A2 };
	Queue* ph[2];
	ph[0] = &A1;//адрес первого элемента записываем в массив
	ph[1] = &A3;//адрес последнего элемента записываем в массив
	scan(ph);//
	intoFIFO(ph, 'd');
	intoFIFO(ph, 't');
	scan(ph);
	char vv = fromFIFO(ph);
	scan(ph);
}

void intoFIFO(Queue* ph[], int v) //Постановка элемента в конец очереди
{
	Queue* p = new Queue;
	p->symbol = v;
	p->next = NULL;
	if (ph[0] == NULL)
		ph[0] = ph[1] = p;   //включение в пустую очередь
	else
	{
		ph[1]->next = p;
		ph[1] = p;
	}
}

void scan(Queue* ph[])           //Вывод элемента              
{
	for (Queue* p = ph[0]; p != NULL; p = p->next)
		cout << p->symbol << ' ';
	cout << endl;
}

//Передаем массив, чтобы взаомиодействовать с адресами первого и последнего жлемента очереди
char fromFIFO(Queue* ph[])      //Извлечение элемента 
{
	Queue* q;
	if (ph[0] == NULL) return -1;     // очередь пуста
	q = ph[0];                        // исключение первого элемента
	ph[0] = q->next;
	if (ph[0] == NULL) ph[1] = NULL;
	char v = q->symbol;
	return v;
}