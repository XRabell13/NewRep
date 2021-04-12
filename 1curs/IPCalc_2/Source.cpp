#include <iostream>

using namespace std;

bool CheckAddress(char* ip_)
{
	int points = 0, // количествоточек
		numbers = 0;	// значение октета
	char* buff = new char[3]; // буффер для одного октета

	for (int i = 0; ip_[i] != '\0'; i++)
	{
		if (ip_[i] <= '9' && ip_[i] >= '0')
		{
			if (numbers > 3) return false;
			buff[numbers++] = ip_[i];
		}
		else if (ip_[i] == '.') // если точка
		{
			if (atoi(buff) > 255) return false;
			// проверитьдиапазоноктета
			if (numbers == 0) return false;
			//если числа нет - ошибка
			numbers = 0;
			memset(buff, 0, sizeof(buff));
			points++;
		}
		else return false;
	}
	if (points != 3) return false;
	// если количство точек в IP-адресе не 3 - ошибка
	return true;
}

bool CheckMask(char* mask)
{
	int points = 0, // количествоточек
		numbers = 0;	// значение октета

	int prevok = 255;
	int mask_for_mask[8] = { 255, 254, 252, 248, 240, 224, 192, 128 };
	char* buff = new char[3];

	for (int i = 0; mask[i] != '\0'; i++)
	{
		if (mask[i] <= '9' && mask[i] >= '0')
		{
			if (numbers > 3) return false;
			buff[numbers++] = mask[i];
		}
		else if (mask[i] == '.') // если точка
		{
			if (atoi(buff) > 255) return false; // проверить диапазон октета

			if ((atoi(buff) != 255) && (atoi(buff) != 254) && (atoi(buff) != 252) && (atoi(buff) != 248)
				&& (atoi(buff) != 240) && (atoi(buff) != 224) && (atoi(buff) != 192) && (atoi(buff) != 128) && (atoi(buff) != 0))
			{
				return false;
			}

			if (((atoi(buff) == 255) || (atoi(buff) == 254) || (atoi(buff) == 252) || (atoi(buff) == 248)
				|| (atoi(buff) == 240) || (atoi(buff) == 224) || (atoi(buff) == 192) || (atoi(buff) == 128)) && (prevok != 255))
			{
				if (prevok != 0) return false;
			}

			if (atoi(buff) > prevok) return false;

			if (numbers == 0) return false;
			//если числа нет - ошибка

			prevok = atoi(buff);
			numbers = 0;
			points++;
			memset(buff, 0, sizeof(buff));
			//for (int i = 0; i < sizeof(buff); i++) buff[i] = -1;
		}
		else return false;
	};
	if (points != 3) return false;
	// если количство точек в маске не 3 - ошибка

	if (atoi(buff) == 0) return true;

	if ((atoi(buff) != 255) && (atoi(buff) != 254) && (atoi(buff) != 252) && (atoi(buff) != 248) && (atoi(buff) != 240)
		&& (atoi(buff) != 224) && (atoi(buff) != 192) && (atoi(buff) != 128) && (atoi(buff) != 0))
	{
		return false;
	};
	if (((atoi(buff) == 255) || (atoi(buff) == 254) || (atoi(buff) == 252) || (atoi(buff) == 248) || (atoi(buff) == 240)
		|| (atoi(buff) == 224) || (atoi(buff) == 192) || (atoi(buff) == 128) || (atoi(buff) == 0)) && (prevok != 255))
	{
		return false;
	}

	return true;
}

int main()
{
//	char ip_[] = "172.168.156.218";
	//char mask_[] = "255.255.192.0";


	char ip_[16], mask_[16];
	int subnet[4], host[4], broadcast[4], oct[8], n = 0, y=1;//n - колво заполненных октетов
	char* pEnd;
	while (y != 0)
	{
		memset(ip_, 0, sizeof(ip_));
		memset(mask_, 0, sizeof(mask_));
		memset(subnet, 0, sizeof(subnet));
		memset(host, 0, sizeof(host));
		memset(oct, 0, sizeof(oct));
		memset(broadcast, 0, sizeof(broadcast));
		cout << "IP-address: "; cin >> ip_;
		cout << "\nMask for IP-address: "; cin >> mask_;

		if (CheckAddress(ip_)) cout << "IP valid: " << ip_ << endl;
		else cout << "IP NOT valid: " << ip_;
		if (CheckMask(mask_)) cout << "Mask valid: " << mask_ << endl;
		else cout << "Mask NOT valid: " << mask_;
		
		//заменяем точки на пробелы, чтобы использовать strol
		for (int i = 0; ip_[i] != '\0' || mask_[i] != '\0'; i++)
		{
			if (ip_[i] == '.') ip_[i] = ' ';
			if (mask_[i] == '.') mask_[i] = ' ';
		}

		unsigned long ip_octs[4];
		ip_octs[0] = strtol(ip_, &pEnd, 10);
		ip_octs[1] = strtol(pEnd, &pEnd, 10);
		ip_octs[2] = strtol(pEnd, &pEnd, 10);
		ip_octs[3] = strtol(pEnd, &pEnd, 10);

		unsigned long mask_octs[4];
		mask_octs[0] = strtol(mask_, &pEnd, 10);
		mask_octs[1] = strtol(pEnd, &pEnd, 10);
		mask_octs[2] = strtol(pEnd, &pEnd, 10);
		mask_octs[3] = strtol(pEnd, &pEnd, 10);

		for (int i = 0; i < 4; i++)
		{
			if (mask_octs[i] == 255)
			{
				subnet[i] = ip_octs[i];
				n++;
				continue;
			}
			else
			{
				subnet[i] = (ip_octs[i] & mask_octs[i]);
				n++;
			}

			for (int j = n; j < 4; j++)
				subnet[j] = 0;

			break;
		}

		for (int i = 0; i < 4; i++)
		{
			if (subnet[i] == ip_octs[i]) { host[i] = 0; }
			else { host[i] = ip_octs[i] - subnet[i]; n = i; break; }
		}
		for (int j = n + 1; j < 4; j++)
		{
			host[j] = ip_octs[j];
		}

		for (int i = 0; i < 4; i++)
			if (mask_octs[i] != 255) {
				broadcast[i] = (ip_octs[i] | (255-mask_octs[i]));
			
			}
			else broadcast[i] = subnet[i];


		cout << "\nNetwork ID: " << subnet[0] << '.' << subnet[1] << '.' << subnet[2] << '.' << subnet[3];
		cout << "\nHost ID: " << host[0] << '.' << host[1] << '.' << host[2] << '.' << host[3] << endl;
		cout << "\nBroadcast: " << broadcast[0] << '.' << broadcast[1] << '.' << broadcast[2] << '.' << broadcast[3] << endl;
		cout << "Continue? (no - 0, yes - other): "; cin >> y;
	}
	return 0;
}