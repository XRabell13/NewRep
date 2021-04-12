/*Скопировать из файла FILE1 в файл FILE2 все строки, 
в которых есть слова, совпадающие с первым словом.
Определить количество гласных букв в последней строке  файла FILE2.*/
/*#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
using namespace std;
void main()
{
	setlocale(LC_CTYPE, "Russian");
	int m = 0, number = 0, pr = 0;
	long fsize;
	char pd;
	FILE* fd, * b;
	errno_t err;
	err = fopen_s(&fd, "a.txt", "r");
	if (err != 0)
	{
		perror("ошибка открытия a.txt");
		return;
	}
	b = fopen("b.txt", "w");

	fseek(fd, 0L, SEEK_END);
	fsize = ftell(fd);
	fseek(fd, 0L, SEEK_SET);

	for (int k = 1; k <= fsize; k++)
	{
		fread((void*)& pd, sizeof(char), 1, fd);/*читаем символ и записываем его в pd... а потом сравниваем и снова следующей берем...
												нуэно сделать так же, но чтобы он сранивал с... цифрой из файла? можно файл циер сделать и сравнивать
												но или просто прописать через ||.А потом начать выводить посимвольно до точки. Если встретилась точка,
												то конец вывода... break. И потом искать снвоа цифру и снова...
		if (pd == '1' || pd == '2' || pd == '3' || pd == '4' || pd == '5' || pd == '6' || pd == '7' || pd == '8' || pd == '9' || pd == '0')
		{
			fprintf(b, " %c", pd);
			while (pd != '.')
			{
				fread((void*)& pd, sizeof(char), 1, fd);
				fprintf(b, "%c", pd);
			}
		}
	}
	printf("Файл создан!");
	fclose(fd);
	fclose(b);
}*/

/*#include <fstream>
#include <iostream>
using namespace std;
void main()
{
	setlocale(LC_ALL, "rus");
	char buff[100], firstword;            // буфер для хранения считываемого из файла текста   
	ifstream fin("FILE1.txt");    // создание объекта fin класса ifstream для чтения  
	if (!fin.is_open())
		cout << "Файл не может быть открыт!\n";
	else
	{
		fin >> firstword;           // считывание первого слова из файла
		fin.close();
		cout << firstword << endl;   // печать строки
	}
}*/
/*Считывать в буфер предложения от точки до точки, а потом каждое слово из этого предлоежния савнивать с первым словом...
или же найти длинну слова в предложении и сравнивать с длиной первого слова... если длинна одинаковая, сравнивать посимвольно. Если 
это то предложение, то */
#define _CRT_SECURE_NO_WARNINGS
#include <fstream>
#include <iostream>
using namespace std;
void main()
{
	setlocale(LC_ALL, "rus");
	char first[50], buff[100], buff1[100], first1[100], wort[] = "           ", buff2[50];
	int k = 0, n = 0, fsize, worts = 0, chars = 0, fwort = 0;
	ifstream fin("t.txt"); // создание объекта fin класса ifstream для чтения (аналогия с fin = fopen("FILE1.txt", "r")), но только fin - обьект
	ofstream fout("t1.txt");
	FILE* fin1, * fout12;
	fin1 = fopen("t.txt", "r");

	ofstream fout1("t2.txt");
	ifstream fout1r("t2.txt");
	if (!fin.is_open())
		cout << "Файл не может быть открыт!\n";
	else
	{

		fseek(fin1, 0L, SEEK_END);
		fsize = ftell(fin1);//колво символов
		fseek(fin1, 0L, SEEK_SET);

		fsize++; //колво символов на один добавляем, ибо последний символ не входит в число(?)
		fin >> first;
		fout1 << first;
		fwort = strlen(first);//колво символов в слове

		fin.getline(first1, 100, '.');//записано первое предложение, но его пропустим ибо оно и так будет обяазтельно выведено в файл
		fout1 << first1 << ". ";
		fgets(buff, fsize, fin1); //записали в массив данные файла


		for (int i = 0; i < fsize; i++)
			if (buff[i] == '.') k++; // узнаем количество предложений


		for (int i = 0; i < k - 1; i++)
		{
			fin.getline(buff1, 20, '.');
			n = strlen(buff1);// колво символов в предложении

			int y = 0;

			for (int j = 0; j <= n; j++)
			{
				// запись в массив слова
				if ((buff1[j] != ' ') & (buff1[j] != '.'))
				{
					wort[y] = buff1[j];

					y++;
				}
				else// если пробел или точка встретились
				{

					int l = 0;
					while (wort[l] != ' ')
					{
						chars++;//количество символов в слове
						l++;
					}

					// если одинаковое колво символов, проверяем, одинаковые ли они
					if (chars == fwort)
					{

						int p = 0;
						for (int h = 0; h < 3; h++)
							if (wort[h] == first[h])
							{
								p++;
								if (p == 3)fout1 << buff1 << ".";// запись в файл
							}
						y = 0;
						for (int ii = 0; ii < 11; ii++)
							wort[ii] = ' ';
					}
				}
				chars = 0;


			}
			for (int ii = 0; ii < 11; ii++)
				wort[ii] = ' ';
		}
	}
	fin.close();
	fout.close();
	fout1.close();
	fout1r.close();
	fclose(fin1);

	// вторая част задания, найти количество согласных
	// найти количество точек, а после столько раз использовать пзапись в буфер до точки.
	// сверять один сивол со всеми согласными, если свопадение есть, то т++

	fout12 = fopen("t2.txt", "r");
	ifstream fout122("t2.txt");

	fseek(fout12, 0L, SEEK_END);
	fsize = ftell(fout12);//колво символов
	fseek(fout12, 0L, SEEK_SET);

	fsize++;
	cout << endl << fsize << endl;

	for (int ii = 0; ii < fsize; ii++)
		buff2[ii] = ' ';

	fout122.getline(buff2, fsize); //записали в массив данные файла
	cout << buff2 << endl;

	k = 0;
	for (int i = 0; i < fsize; i++)
		if (buff2[i] == '.') k++; // узнаем количество точек

	char sogl[] = "EYUIOAJeyioaj";
	int g = 0, q=0, s=0;

	g = strlen(sogl);

	for (int i = 0; i < fsize; i++)
	{
		if ((buff2[i] == '.') & (q!=2)) q++;
		if (q == 2)
		{
			for (int j = 0; j < g; j++)
				if (buff[i] == sogl[j]) s++;
		}
	}
	cout << "Количетсво гласных: " << s;
	fclose(fout12);
	fout122.close();
}



/*string line, firstWord, word;
while (getline(in, line))
{
	stringstream ss(line);
	bool hasEquals = false;
	ss >> firstWord;
	while (ss >> word)
	{
		if (word == firstWord)
		{
			hasEquals = true;
			break;
		}
	}
	if (hasEquals) out << line << endl;
}



fin.getline(buff, 100, ' ');//считывание строки в 10 символов в массив до символа " "
		cout << buff << "        ";
		fin >> first;           // считывание первого слова из файла
		cout << first << endl;  // печать слова

		for (int i = 0; i < 30; i++)
		{
			fin.getline(buff, 40, ' ');//слова следующего
			cout << buff << ' ';
			k = strlen(buff);
			cout << k;
			if (k == strlen(first))
			{
				for (int j = 0; j < k; j++)
				{
					if (buff[j] == first[j]) n++;
				}

			}

			if (n == k)
			{
				fin.getline(buff1, 40, '.');
				cout << buff1;
				cout << buff1 << "." << endl;
				cout << "sdfsdfsfs";
			}
			n = 0;
			//cout << buff << "." << endl;*/

