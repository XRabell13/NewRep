#include <iostream>
#include <algorithm>//оттуда sort
#include <string>
#include <windows.h>
using namespace std;

struct sanat {
	string Name;
	string Location;
	string MType;
	int Ntickets;
};

void vvod(sanat* a, int n);
void out(sanat* a, int n);
bool compare1(sanat& lhs, sanat& rhs) {
	return lhs.MType[0] < rhs.MType[0];
}
bool compare2(sanat& lhs, sanat& rhs) {
	return lhs.Name[0] < rhs.Name[0];
}
void dsort(sanat* a, int n);

int main(int argc, char* argv[])
{

	setlocale(LC_CTYPE, "RUS");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	int n;
	sanat* ar;
	cout << "»нформацию о скольких санаторий следует ввести в базу данных? " << endl;
	wcin >> n;
	//_flushall();//очистка буферов
	ar = new sanat[n];
	vvod(ar, n);
	sort(ar, ar + n, compare1);// сортировка по лечебному профилю
	dsort(ar, n);//сортировка санаториев по названи€м
	out(ar, n);
	return 0;
}

void vvod(sanat* a, int n) {
	int i;
	for (i = 0; i < n; i++) {
		cout << "¬ведите название санатори€ є" << i + 1 << ": " << endl;
	    cin>> a[i].Name;
		cout << "¬ведите месторасположение санатори€є" << i + 1 << " " << endl;
		cin>> a[i].Location;
		cout << "¬ведите лечебний профиль санаторииє" << i + 1 << ": " << endl;
		cin>> a[i].MType;
		cout << "¬ведите количество путЄвок: " << endl;
		cin >> a[i].Ntickets;
	//	_flushall();//очистка буферов
	}
}
void out(sanat* a, int n) {
	cout << "_________________________________________________________________________" << endl;
	for (int i = 0; i < n; i++) {
		cout << "|\t" << a->Name << "\t|";
		cout << "\t" << a->Location << "\t|";
		cout << "\t" << a->MType << "\t|";
		cout << "\t" << a->Ntickets << "\t|" << endl;
		cout << "_________________________________________________________________________" << endl;
		a++;
	}
}
void dsort(sanat* a, int n) {
	int x = 0;
	string c;
	sanat b;
	for (int i = 1; i < n; i++) {
		if (a[i - 1].MType == a[i].MType)
			x++;
		continue;
		sort(a + i, a + i + x, compare2);
	}
}