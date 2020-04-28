#pragma once
#include <string>
#include <memory>
#include <iostream>
class book
{
	std::string title;
	int pages;

public:
	std::shared_ptr<book> pNext;
	std::weak_ptr<book> pPrev;
	book(std::string text, int number, std::shared_ptr<book> _pNext, std::weak_ptr<book> _pPrev);
	book();
	void DisplayBook();
};

