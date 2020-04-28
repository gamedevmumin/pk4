#pragma once
#include <memory>
#include "book.h"

class shelf
{
private:
	std::shared_ptr<book> head;
public:
	void addBook(std::string name, int pages)
	{
		head = std::make_shared<book>(book(name, pages, nullptr, head));
	}
};