#include <iostream>
#include <fstream>
#include "RegularExpressions.h"

bool checkFile(const std::string& file_name)
{
	std::ifstream file;
	file.open(file_name);
	if (!file.good())
	{
		std::cout << "Can't open file! " << std::endl;
		return false;
	}
	RegularExpressions regex;
	std::string str;
	while (!file.eof())
	{
		getline(file, str);
		if (!regex.name_surname_gender(str))
		{
			std::cout << "File isn't in the correct format. " << std::endl;
			file.close();
			return false;
		}
	}
	file.close();
	return true;
}

int countMen(const std::string& file_name)
{
	RegularExpressions regex;
	std::regex reg("M$");
	std::string str;
	int men_count = 0;
	std::ifstream file;
	file.open(file_name);
	while (!file.eof())
	{
		getline(file, str);
		if (regex_search(str, reg)) men_count++;
	}
	file.close();
	return men_count;
}


int main()
{
	RegularExpressions regex;
	std::regex reg("needle");
	std::string haystack = "There is a needle in the needle in the needle in this haystack";
	//zad. 1 
	regex.print_matches(haystack, reg);
	//zad. 2
	regex.printMatchesWithIterator(haystack, reg);
	//zad. 3
	std::cout << "Found " << regex.countMatches(haystack, reg) << " needles in this haystack\n";
	//zad. 4
	std::string whatIsInTheHaystack = "hay";
	regex.replace(haystack, reg, whatIsInTheHaystack);
	std::cout << haystack << std::endl;
	//zad. 5
	RegularExpressions r;
	std::string str;
	std::cout << "Podaj imie, nazwisko i date urodzenia: ";
	bool success = false;
	while (!success)
	{
		getline(std::cin, str);
		if (r.name_surname_date(str)) success = true;
		else std::cout << "Podano bledne dane\n";
	}
	std::cout << "\n";
	//zad. 6
	if (checkFile("imiona_i_nazwiska.txt"))
	{
		std::cout << countMen("imiona_i_nazwiska.txt") << "\n";
	}
	return 0;
}