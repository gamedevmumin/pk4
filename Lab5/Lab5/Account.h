#ifndef ACCOUNT_H
#define ACCOUNT_H

class BankAccount {
	double savings;
public:
	BankAccount(double _savings) : savings(_savings) {}
	void interest()
	{
		savings *= 1.02;
	}
	void wypisz()
	{
		std::cout << savings << std::endl;
	}

};

#endif // !ACCOUNT_H
