#include <iostream>
using namespace std;

struct tree {
	int inf;
	tree* r;
	tree* l;
};
tree* Root = NULL;
tree* Node = NULL;

void insert(tree** root, tree** node, int item);
void print(tree* Root, int l);

int height(tree* t) {
	if (t == NULL) {
		return 0;
	}
	else {
		if (t->l == NULL && t->r == NULL) return 0;
		if (height(t->l) > height(t->r)) return height(t->l) + 1;
		else return height(t->r) + 1;
	}
}
int countel(tree* t) {
	if (t == NULL) {
		return 0;
	}
	else {
		int count = 1;
		count += countel(t->l);
		count += countel(t->r);
		return count;
	}
}

int main() 
{
	setlocale(LC_CTYPE, "RUS");
	cout << "Дерево мудрости: (но это не точно) " << endl;
	int n, a;
	int h, c;
	cout << "Сколько вершин вы хотите добавить? ->";
	cin >> n;
	if (n < 1) {
		cout << "Ошибка" << endl;
		return 0;
	}
	for (int i = 0; i < n; i++) {
		cin >> a;
		insert(&Root, &Node, a);
		h = height(Root);
		c = countel(Root);
		cout << "height: " << h << endl;
		cout << "count: " << c << endl;
		print(Root, 0);
	}

	return 0;
	system("pause");
}
void insert(tree** root, tree** node, int item) {
	if (*root == NULL) {
		*root = new tree;
		(*root)->inf = item;
		(*root)->l = NULL;
		(*root)->r = NULL;
	}
	else if (item >= (*root)->inf) {
		if ((*root)->r == NULL) {
			*node = new tree;
			(*node)->inf = item;
			(*root)->r = (*node);
			(*node)->r = NULL;
			(*node)->l = NULL;
		}
		else {
			if (*node == NULL) {
				*node = new tree;
				(*node)->inf = item;
				(*node)->r = NULL;
				(*node)->l = NULL;
			}
			else if ((*node)->inf % 2 == 0) {
				insert(&(*root)->r, &(*node)->r, item);
			}
			else {
				insert(&(*root)->r, &(*node)->l, item);
			}
		}
	}
	else if (item < (*root)->inf) {
		if ((*root)->l == NULL) {
			*node = new tree;
			(*node)->inf = item;
			(*root)->l = (*node);
			(*node)->r = NULL;
			(*node)->l = NULL;
		}
		else {
			if (*node == NULL) {
				*node = new tree;
				(*node)->inf = item;
				(*node)->r = NULL;
				(*node)->l = NULL;
			}
			else if ((*node)->inf % 2 == 0) {
				insert(&(*root)->l, &(*node)->r, item);
			}
			else {
				insert(&(*root)->l, &(*node)->l, item);
			}
		}
	}
}


void print(tree* Root, int l) {
	if (Root == NULL) {
		cout << endl;
	}
	else {
		print(Root->r, l + 1);
		for (int i = 0; i < l; i++) cout << " | ";
		cout << Root->inf << endl;
		print(Root->l, l + 1);
	}
}