#pragma once

#include "RegularExpressions.h"

//Zad.1 
void RegularExpressions::print_matches(const std::string& str, std::regex reg)
{
	std::string tmp = str;
	std::smatch matches;
	while (std::regex_search(tmp, matches, reg))
	{
		std::cout << matches.str(0) << std::endl;
		tmp = matches.suffix().str();
	}
	std::cout << std::endl;
}

void RegularExpressions::printMatchesWithIterator(const std::string& str, std::regex reg)
{
	std::sregex_iterator current_match(str.begin(), str.end(), reg);
	std::sregex_iterator last_match;
	while (current_match != last_match)
	{
		std::smatch match = *current_match;
		std::cout << match.str() << std::endl;
		current_match++;
	}
	std::cout << std::endl;
}

int RegularExpressions::countMatches(const std::string& str, std::regex reg)
{
	std::string tmp = str;
	std::smatch matches;
	int count = 0;
	while (std::regex_search(tmp, matches, reg))
	{
		count++;
		tmp = matches.suffix().str();
	}
	return count;
}

void RegularExpressions::replace(std::string& whereToReplace, std::regex reg, const std::string& replacingString)
{
	whereToReplace = std::regex_replace(whereToReplace, reg, replacingString);
}

bool RegularExpressions::name_surname_date(const std::string& str)
{
	std::regex reg("[A-Z][a-z]+ [A-Z][a-z]+ [0-9]{2}-[0-9]{2}-[0-9]{4}");
	return regex_match(str, reg);
}

bool RegularExpressions::name_surname_gender(const std::string& str)
{
	std::regex reg("[A-Z][a-z]+ [A-Z][a-z]+ (K|M)");
	return regex_match(str, reg);
}