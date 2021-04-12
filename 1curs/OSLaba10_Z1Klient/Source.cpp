#include <windows.h>
#include <iostream>
#include"tchar.h"

int main()
{
	HANDLE hslot;

	LPCTSTR slotname = TEXT("\\\\.\\mailslot\\demoslot");
	hslot = CreateFile(slotname, GENERIC_WRITE, FILE_SHARE_READ, NULL, OPEN_EXISTING, 0, NULL);//создается ящик (точнее открывается) 

	if (hslot == INVALID_HANDLE_VALUE)
	{

		std::cout << "SLOT WRITING FAILED" << std::endl;
		std::cout << "PRESS KEY TO FINICH" << std::endl;
		std::cin.get();
		return 0;

	}

	std::cout << "SLOT IS WAITING(klient)" << std::endl;
	int nData = 1;
	int n = 10;
	DWORD dwBytesWrite;
	while (nData) {
		std::cout << "Data WRITTEN TO BOX: " << std::endl;
		std::cin >> nData;
		if (!WriteFile(hslot, &nData, sizeof(nData), &dwBytesWrite, NULL))
		{
			std::cout << "WRITE FAILED" << std::endl;
			CloseHandle(hslot);
			std::cout << "PRESS KEY TO FINICH" << std::endl;
			std::cin.get();
			return 0;
		}
	}
	CloseHandle(hslot);
	return 0;

}

