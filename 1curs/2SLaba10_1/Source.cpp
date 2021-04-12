#include <iostream>
using namespace std;
struct Tree          //дерево
{
	int key;         //ключ
	char text[5];    //текст - не более 4 букв
	Tree* Left, * Right;
};

Tree* makeTree(Tree* Root);       //Создание дерева
Tree* list(int i, char* s);       //Создание нового элемента
Tree* insertElem(Tree* Root, int key, char* s);  //Добавление нового элемента
Tree* search(Tree* n, int key);   //Поиск элемента по ключу 
Tree* delet(Tree* Root, int key); //Удаление элемента по ключу
void view(Tree* t, int level);    //Вывод дерева 
int count(Tree* t, char letter);  //Подсчет количества слов
void delAll(Tree* t);             //Очистка дерева
int chet(Tree* t);                //Вывод количества четных ключей
int koluzl(Tree* t);              //Вывод количества узлов дерева
int kolleft(Tree* t);             //Вывод количества левых вершин дерева
int kolprav(Tree* t);             //Вывод количества правых вершин дерева
//int sum(Tree* t);                 //Вывод суммы значений всех вершин дерева
int c = 0, j=0;         //количество слов и количество четных ключей
Tree* Root = NULL; 	//указатель корня

void main()
{
	setlocale(0, "Russian");
	int key, choice, n;
	Tree* rc; char s[5], letter;
	for (;;)
	{
		cout << "1 -	создание дерева\n";
		cout << "2 -	добавление элемента\n";
		cout << "3 -	поиск по ключу\n";
		cout << "4 -	удаление элемента\n";
		cout << "5 -	вывод дерева\n";
		cout << "6 -	подсчет количества букв\n";
		cout << "7 -	очистка дерева\n";
		cout << "8 -     вывести количество четных ключей\n"; // 12 вариант мой
		cout << "9 -     вывести количество узлов дерева\n"; // 7 вариант
		cout << "10 -    вывести количество левых вершин\n"; // 5 вариант
 		cout << "11 -    вывести количество правых вершин\n"; // 2 вариант
		cout << "12 -	выход\n";
		cout << "ваш выбор?\n";
		cin >> choice;
		cout << "\n";
		switch (choice)
		{
		case 1:  Root = makeTree(Root);	break;
		case 2:  cout << "\nВведите ключ: "; cin >> key;
			cout << "Введите слово: "; cin >> s;
			insertElem(Root, key, s); break;
		case 3:  cout << "\nВведите ключ: ";  cin >> key;
			rc = search(Root, key);
			cout << "Найденное слово= ";
			puts(rc->text); break;
		case 4:  cout << "\nВведите удаляемый ключ: "; cin >> key;
			Root = delet(Root, key);  break;
		case 5:  if (Root->key >= 0)
		{
			cout << "Дерево повернуто на 90 град. влево" << endl;
			view(Root, 0);
		}
				 else cout << "Дерево пустое\n"; break;
		case 6:  cout << "\nВведите букву: "; cin >> letter;
			n = count(Root, letter);
			cout << "Количество слов, начинающихся с буквы " << letter;
			cout << " равно " << n << endl; break;
		case 7:  delAll(Root); break;
		case 8:  j = 0; cout << "Количество четных ключей: " << chet(Root) << '\n'; break;
		case 9: c = 0; cout << "Количество узлов дерева: "<< koluzl(Root)<<'\n'; break;
		case 10: j = 0; cout << "Количество левых вершин: " << kolleft(Root) <<'\n'; break;
		case 11: j = 0; cout << "Количество правых вершин: " << kolprav(Root) <<'\n'; break;
		case 12:  exit(0);
		default: break;
		}
	}
}

Tree* makeTree(Tree* Root)    //Создание дерева
{
	int key; char s[5];
	cout << "Конец ввода - отрицательное число\n\n";
	if (Root == NULL)	// если дерево не создано
	{
		cout << "Введите ключ корня: "; cin >> key;
		cout << "Введите слово корня: "; cin >> s;
		Root = list(key, s);	// установка указателя на корень
	}
	while (1)                //добавление элементов
	{
		cout << "\nВведите ключ: ";  cin >> key;
		if (key < 0) break;       //признак выхода (ключ < 0)   
		cout << "Введите слово: ";  cin >> s;
		insertElem(Root, key, s);
	}
	return Root;
}

Tree* list(int i, char* s)     //Создание нового элемента
{
	Tree* t = new Tree[sizeof(Tree)];
	t->key = i;
	for (i = 0; i < 5; i++)
		* ((t->text) + i) = *(s + i);
	t->Left = t->Right = NULL;
	return t;
}

Tree* insertElem(Tree* t, int key, char* s)  //Добавление нового элемента
{
	Tree* Prev=NULL;	     // Prev - элемент перед текущим
	int find = 0;        // признак поиска
	while (t && !find)
	{
		Prev = t;
		if (key == t->key)
			find = 1;	   //ключи должны быть уникальны
		else
			if (key < t->key) t = t->Left;
			else t = t->Right;
	}
	if (!find)              //найдено место с адресом Prev
	{
		t = list(key, s);           //создается новый узел 
		if (key < Prev->key)  // и присоединяется либо 
			Prev->Left = t;    //переход на левую ветвь,
		else
			Prev->Right = t;   // либо на правую 
	}
	return t;
}

Tree* delet(Tree* Root, int key)  //Удаление элемента по ключу
{	// Del, Prev_Del - удаляемый элемент и его предыдущий ;
	// R, Prev_R - элемент, на который заменяется удаленный, и его родитель; 
	Tree* Del, * Prev_Del, * R, * Prev_R;
	Del = Root;
	Prev_Del = NULL;
	while (Del != NULL && Del->key != key)//поиск элемента и его родителя 
	{
		Prev_Del = Del;
		if (Del->key > key)
			Del = Del->Left;
		else
			Del = Del->Right;
	}
	if (Del == NULL)              // элемент не найден
	{
		puts("\nНет такого ключа");
		return Root;
	}
	if (Del->Right == NULL) // поиск элемента R для замены
		R = Del->Left;
	else
		if (Del->Left == NULL)
			R = Del->Right;
		else
		{
			Prev_R = Del; //поиск самого правого элемента в левом поддереве
			R = Del->Left;
			while (R->Right != NULL)
			{
				Prev_R = R;
				R = R->Right;
			}
			if (Prev_R == Del) // найден элемент для замены R и его родителя Prev_R 
				R->Right = Del->Right;
			else
			{
				R->Right = Del->Right;
				Prev_R->Right = R->Left;
				R->Left = Prev_R;
			}
		}
	if (Del == Root) Root = R;	//удаление корня и замена его на R
	else
		// поддерево R присоединяется к родителю удаляемого узла
		if (Del->key < Prev_Del->key)
			Prev_Del->Left = R; // на левую ветвь 
		else
			Prev_Del->Right = R;	// на правую ветвь
	int tmp = Del->key;
	cout << "\nУдален элемент с ключом " << tmp << endl;
	delete Del;
	return Root;
}

Tree* search(Tree* n, int key)  //Поиск элемента по ключу 
{
	Tree* rc = n;
	if (rc != NULL)
	{
		if (key < (key, n->key))
			rc = search(n->Left, key);
		else
			if (key > (key, n->key))
				rc = search(n->Right, key);
	}
	else
		cout << "Нет такого элемента\n";
	return rc;
}

int count(Tree* t, char letter) //Подсчет количества слов
{
	if (t)
	{
		count(t->Right, letter);
		if (*(t->text) == letter)
			c++;
		count(t->Left, letter);
	}
	return c;
}

void view(Tree* t, int level) //Вывод дерева 
{
	if (t)
	{
		view(t->Right, level + 1);	//вывод правого поддерева
		for (int i = 0; i < level; i++)
			cout << "   ";
		int tm = t->key;
		cout << tm << ' ';
		puts(t->text);
		view(t->Left, level + 1);	//вывод левого поддерева
	}
}

void delAll(Tree* t) //Очистка дерева
{
	if (t != NULL)
	{
		delAll(t->Left);
		delAll(t->Right);
		delete t;
	}
}

int chet(Tree* t)//подсчет четных элементов
{
	if (t)
	{
		chet(t->Right);
		if ((t->key)%2==0)
			j++;
		chet(t->Left);
	}
	return j;
}

int koluzl(Tree* t)              //Вывод количества узлов дерева
{
	if (t)
	{
		koluzl(t->Right);
		if ((t->Right)!=NULL || (t->Left)!=NULL)
			c++;
		koluzl(t->Left);
	}
	return c-1;//чтобы не считало корень за узел
}

int kolleft(Tree* t)  //Вывод количества левых вершин дерева
{
	if (t)
	{
		kolleft(t->Left);
		if (t->Left != NULL)
			j++;
	//	kolleft(t->Right);
	}
	return j-1;
}

int kolprav(Tree* t)  //Вывод количества правых вершин дерева
{

	if (t)
	{
		kolprav(t->Right);
		if (t->Right != NULL)
			j++;
		//kolprav(t->Left);
	}
	return j-1;
}

