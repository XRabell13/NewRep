#include <stdio.h>
#include <clocale>
int main() 
{
	setlocale(LC_CTYPE, "Russian");
	int �����;
	printf("����� ��������: ");
	scanf_s("%d", &�����);
	int ������� = (����� - 1) / 36 + 1;
	int ������� = (����� - 1) % 36;
	int ���� = ������� / 4 + 1;
	printf("������� = %d\n", �������);
	printf("���� = %d\n", ����);
}