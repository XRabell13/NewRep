//Взять из каждого файла число соответствующего номера и записать в NameD минимальное из них троих
/*Создать 3 одномерных массива, которые после записать в файлБ затем сравнивать элементы
с одним и тем же номером и записывать минимальный элемент в четвертый одномерный массив(или сразу в файл)Б после чего массив записать в файл*/
#include <iostream>
#include <fstream>
#include <stdio.h>
int main()
{
	using namespace std;
	setlocale(LC_CTYPE, "Rus");
	FILE* fAptr, * fBptr, *fCptr, *fDptr; //указатели на файлы для считывания и записи
	errno_t err;
	int min=0, j=0;
	char cmin;

	err = fopen_s(&fAptr, "NameA.txt", "wb"); // откроем файл для записи исходных знач
	if (err != 0) {
		perror("ошибка открытия NameA.txt");
	}
	/*Нужно открывать и закрывать файл перед каждой операцией записи, а после и... 
	а можно ли сделать так, дабы одновременно было открыто несколько файлов разныз? да*/
	cout << "Введите количество чисел в файле:" << endl; 

	int n=1; cin >> n; //загоняется  в исходник значения

	int* NameA = new int[n];
	int* NameB = new int[n];
	int* NameC = new int[n];
	int* NameD = new int[n];

	cout << "Введите числа в NameA: " << endl;
	for (int u = 0; u < n; u++) {
		cin >> NameA[u];
		fprintf(fAptr, "%d\t", NameA[u]);
	}

	fclose(fAptr); //закроем файл 

	err = fopen_s(&fBptr, "NameB.txt", "wb"); // откроем файл для записи исходных знач
	if (err != 0) {
		perror("ошибка открытия NameA.txt");
	}

	cout << "Введите числа в NameC: " << endl;
	for (int u = 0; u < n; u++) {
			cin >> NameB[u];
			fprintf(fBptr, "%d\t", NameB[u]);
		}

	
	fclose(fBptr); //закроем файл 

	err = fopen_s(&fCptr, "NameC.txt", "wb"); // откроем файл для записи исходных знач
	if (err != 0) {
		perror("ошибка открытия NameC.txt");
	}

	cout << "Введите числа в NameC: " << endl;
	for (int u = 0; u < n; u++) {
		cin >> NameC[u];
		fprintf(fCptr, "%d\t", NameC[u]);
	}

	fclose(fCptr); //закроем файл 

	err = fopen_s(&fDptr, "NameD.txt", "wb");
	if (err != 0) {
		perror("ошибка открытия NameD.txt");
	}

	for(int i=0; i<n;i++)// n номер числа
	 { 
			min = NameA[i];
			if (min > NameB[i]) min = NameB[i];
		    if (min > NameC[i]) min = NameC[i];
			fprintf_s(fDptr, "%d", min);
	}
			//fwrite(cmin, strlen(cmin), 1, fDptr);//нужно комана записи данной переменной в файл

	delete[] NameA;
	delete[] NameB;
	delete[] NameC;
}