#pragma once
#include <string>
#include <iostream>
#include <regex>

class RegularExpressions
{
public:
	void print_matches(const std::string& str, std::regex reg);
	void printMatchesWithIterator(const std::string& str, std::regex reg);
	int countMatches(const std::string& str, std::regex reg);
	void replace(std::string& whereToReplace, std::regex reg, const std::string& replacingString);
	bool name_surname_date(const std::string& str);
	bool name_surname_gender(const std::string& str);
};