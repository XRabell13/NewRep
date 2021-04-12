#include <iostream>
#include <ctime>
using namespace std;
void bubbleSort(int a[], int n)// �� �����������
{
	int i, j, t;
	for (i = 1; i < n; i++)
		for (j = n - 1; j >= i; j--)
			if (a[j - 1] > a[j])
			{
				t = a[j - 1];
				a[j - 1] = a[j];
				a[j] = t;
			}
}
void _bubbleSort(int a[], int n)//�� ��������
{
	int i, j, t;
	for (i = 1; i < n; i++)
		for (j = n - 1; j >= i; j--)
			if (a[j - 1] < a[j])
			{
				t = a[j - 1];
				a[j - 1] = a[j];
				a[j] = t;
			}
}
void selectSort(int A[], int size)
{
	int k, i, j;
	for (i = 0; i < size - 1; i++)
	{
		for (j = i + 1, k = i; j < size; j++)
			if (A[j] < A[k])
				k = j;
		int c = A[k];
		A[k] = A[i];
		A[i] = c;
	}
}

int getHoarBorder(int A[], int sm, int em)
{
	int i = sm - 1, j = em + 1;
	int brd = A[sm];
	int buf;
	while (i < j)
	{
		while (A[--j] < brd);//�� ��������
		while (A[++i] > brd);//�� ��������
		if (i < j)
		{
			buf = A[j];
			A[j] = A[i];
			A[i] = buf;
		};
	}
	return j;
}
int* sortHoar(int A[], int sm, int em)/*����� A[] � �������� ������ �����,
									  sm �  ������ ������� �������� �������,
									  em �  ������ ��-�������� (��������� ������� ������ �����).*/
{
	if (sm < em)
	{
		int hb = getHoarBorder(A, sm, em);
		sortHoar(A, sm, hb);
		sortHoar(A, hb + 1, em);
	}
	return A;
};

int* shell(int m[], int lm)
{
	int buf;
	bool sort;
	for (int g = lm / 2; g > 0; g /= 2)
		do
		{
			sort = false;
			for (int i = 0, j = g; j < lm; i++, j++)
				if (m[i] < m[j])
				{
					sort = true;
					buf = m[i];
					m[i] = m[j];
					m[j] = buf;
				}
		} while (sort);
		return m;
}
void main()
{
	setlocale(LC_ALL, "Rus");
	srand((unsigned int)time(NULL));
	int size, i, k = 0, choise, max, imax;
	int B[1000], A[1000], C[1500];
	for (;;) {
		cout << "\n���������� ��������� = ";
		cin >> size;
		if (size <= 0) exit(0);
		for (i = 0; i < size; i++)
		{
			cout << " ";
			A[i] = (rand() % 1000);
			cout << A[i];
		}
		cout << endl;
		
		cout << "\n1 - ���������� ��������� �� �����������\n2 - ���������� �� ������\n\n3 - ���������� ����� �� ��������(���13)";
		cout << "\n4 - ���������� ��������� �� ��������(���13)\n\n5 - ���������� �����(���14)";
		cout<<"\n6 - ���������� ��������� �� ��������(���14)\n\n7 - ���������� ��������� �� ��������(���15)\n8 - ���������� ����� �� ��������(���15)\n";
		cout << "�����: ";
		cin >> choise;
		switch (choise) {
		case 1:
			k = 0;
			for (i = 0; i < size; i++)
				if (i % 2 == 0) B[k++] = A[i];
			cout << "\nB-������: ";
			for (i = 0; i < k; i++)
				cout << B[i] << " ";
			bubbleSort(B, k);
			cout << "\n�������������� ������ ������������� ���������: ";
			for (i = 0; i < k; i++)
				cout << B[i] << " ";
			cout << endl;
			break;
		case 2:
			k = 0;
			for (i = 0; i < size; i++)
				if (i % 2 == 0) B[k++] = A[i];
			cout << "\nB-������: ";
			for (i = 0; i < k; i++)
				cout << B[i] << " ";
			selectSort(B, k);
			cout << "\n�������������� ������ ������������� �� ������: ";
			for (i = 0; i < k; i++)
				cout << B[i] << " ";
			cout << endl;
			break;
		case 3:
			k = 0; max = A[0];
			for (i = 0; i < size; i++)
				if (A[i] >= max) {
					max = A[i];
					imax = i;
				}
			cout << "\nMax element: " << max << "\nindex: " << imax << endl;
			for (i = imax; i < size; i++)
				if (i % 2 == 0) B[k++] = A[i];
			cout << "\n\nB-������: ";
			for (i = 0; i < k; i++)
				cout << B[i] << " ";
			i = 0;
			sortHoar(B, i, k);
			cout << "\n\nB-������ ����� ���������� �����: ";
			for (i = 0; i < k; i++)
				cout << B[i] << " ";
			cout << endl;
			break;
		case 4:
			k = 0; max = A[0];
			for (i = 0; i < size; i++)
				if (A[i] >= max) {
					max = A[i];
					imax = i;
				}
			cout << "\nMax element: " << max << "\nindex: " << imax << endl;
			for (i = imax; i < size; i++)
				if (i % 2 == 0) B[k++] = A[i];
			cout << "\n\nB-������: ";
			for (i = 0; i < k; i++)
				cout << B[i] << " ";
			_bubbleSort(B, k);
			cout << "\n�������������� ������ ������������� ���������: ";
			for (i = 0; i < k; i++)
				cout << B[i] << " ";
			cout << endl;
			break;

		case 5:
			k = 0;
			cout << "\n\n������ �: ";
			for (i = 0; i < size; i++)
			{
				cout << " ";
				B[i] = (rand() % 1000);
				cout << B[i];
			}
			for (i = 0; i < size; i++)
				if (A[i] % 2 != 0) C[k++] = A[i];
			for (i = 0; i < size; i++)
				if (B[i] % 2 == 0) C[k++] = B[i];
			cout << "\n\nC-������: ";
			for (i = 0; i < k; i++)
				cout << C[i] << " ";
			
			cout << "\n\nC-������: ";
			shell(C,k);
			for (i = 0; i < k; i++)
				cout << C[i] << " ";
			break;
		case 6: 
			k = 0;
			cout << "\n\n������ �: ";
			for (i = 0; i < size; i++)
			{
				cout << " ";
				B[i] = (rand() % 1000);
				cout << B[i];
			}
			for (i = 0; i < size; i++)
				if (A[i] % 2 != 0) C[k++] = A[i];
			for (i = 0; i < size; i++)
				if (B[i] % 2 == 0) C[k++] = B[i];
			cout << "\n\nC-������: ";
			for (i = 0; i < k; i++)
				cout << C[i] << " ";

			cout << "\n\nC-������: ";
			_bubbleSort(C, k);
			for (i = 0; i < k; i++)
				cout << C[i] << " ";
		case 7: 
			cout << "\n\n������ �: ";
			for (i = 0; i < size; i++)
			{
				cout << " ";
				B[i] = (rand() % 1000);
				cout << B[i];
			}
			k = 0; max = B[0];
			for (i = 0; i < size; i++)
				if (B[i] >= max) {
					max = B[i];
					imax = i;
				}
			cout << "\nMax element: " << max << "\nindex: " << imax << endl;
			for (i = 0; i < size; i++)
				if (A[i] < max) C[k++] = A[i];
			cout << "\n\nC-������: ";
			for (i = 0; i < k; i++)
				cout << C[i] << " ";
			cout << "\n\nC-������: ";
			_bubbleSort(C, k);
			for (i = 0; i < k; i++)
				cout << C[i] << " ";
			break;
		case 8:
			cout << "\n\n������ �: ";
			for (i = 0; i < size; i++)
			{
				cout << " ";
				B[i] = (rand() % 1000);
				cout << B[i];
			}
			k = 0; max = B[0];
			for (i = 0; i < size; i++)
				if (B[i] >= max) {
					max = B[i];
					imax = i;
				}
			cout << "\nMax element: " << max << "\nindex: " << imax << endl;
			for (i = 0; i < size; i++)
				if (A[i] < max) C[k++] = A[i];
			cout << "\n\nC-������: ";
			for (i = 0; i < k; i++)
				cout << C[i] << " ";
			cout << "\n\nC-������: ";
			i = 0;
			sortHoar(C, i, k);
			for (i = 0; i < k; i++)
				cout << C[i] << " ";
			break;
		default: exit(0);
			for (i = 0; i < k; i++) B[i] = NULL;
			for (i = 0; i < size; i++) A[i] = NULL;	
		}
	}
}
