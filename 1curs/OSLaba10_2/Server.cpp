#include <windows.h>
#include <iostream>
#include"tchar.h"


int _tmain(int argc, _TCHAR* argv[])
{
	HANDLE hslot;
	LPCTSTR slotname = TEXT("\\\\.\\mailslot\\demoslot");//Имя ящика фиксированно 
	hslot = CreateMailslot(slotname, 0, MAILSLOT_WAIT_FOREVER, NULL);//создаем ящик
	if (hslot == INVALID_HANDLE_VALUE)
	{

		std::cout << "SLOT FAILED" << std::endl;
		std::cout << "PRESS KEY TO FINICH" << std::endl;
		std::cin.get();
		return 0;

	}

	std::cout << "SLOT IS WAITING(server)" << std::endl;
	int nData = 1, i = 2;
	DWORD dwBytesRead;
	while (i) {
		if (!ReadFile(hslot, &nData, sizeof(nData), &dwBytesRead, (LPOVERLAPPED)NULL))
		{
			std::cout << "READING SLOT FAILED" << std::endl;
			CloseHandle(hslot);
			std::cout << "PRESS KEY TO FINICH" << std::endl;
			std::cin.get();
			return 0;
		}
		if (nData == 0) i--;
		std::cout << "Data Read :" << nData << std::endl;
	}
	CloseHandle(hslot);

	return 0;

}