#include <stdio.h>

int main()
{
	
const int N = 10;

	int A[N][N] = { { 3, 5, 7, 4, 2, 6, 8, 3, 9, 1 },
					{ 9, 4, 8, 3, 3, 8, 1, 5, 1, 2 },
					{ 7, 3, 5, 2, 8, 1, 7, 7, 4, 7 },
					{ 1, 1, 6, 1, 5, 7, 9, 9, 5, 6 },
					{ 4, 9, 8, -7, 6, 4, 6, 8, 6, 5 },
					{ 3, 8, 9, 8, 1, 5, 5, 6, 8, 4 },
					{ 2, 7, 4, 9, 4, 6, 3, 1, 7, 7 },
					{ 8, 6, 3, 4, 3, 3, -1, 4, 9, 8 },
					{ 9, 4, 5, 6, 9, 9, 2, 5, 3, 1 },
					{ 1, 3, -6, 5, 5, 8, 4, 6, 2, 9 } };

	for (int n1 = 0; n1 < N; n1++)
	{
		for (int n2 = 0; n2 < N; n2++)
			printf("%d ", A[n1][n2]);

		printf("\n");
	}

	printf("\n");

	for (int i = 0; i < N; i++)
	{
		bool negative = false;
		for (int j = 0; j < N && !negative; j++)
			negative = (A[i][j] < 0) ? 1 : 0;

		for (int q = 0; q < N && negative; q++)
		{
			for (int t1 = i; t1 < N; t1++)
				A[t1][q] = A[t1 + 1][q];

			A[N - 1][q] = 0;
		}
	}

	for (int r1 = 0; r1 < N; r1++)
	{
		for (int r2 = 0; r2 < N; r2++)
			printf("%d ", A[r1][r2]);

		printf("\n");
	}

	return 0;
}