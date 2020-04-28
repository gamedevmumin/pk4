#include "book.h"

book::book(std::string text, int number, std::shared_ptr<book> _pNext, std::weak_ptr<book> _pPrev)
{
	title = text;
	pages = number;
	pNext = _pNext;
	pPrev = _pPrev;
}

void book::DisplayBook()
{
	std::cout << title << " (" << pages << " stron)" << std::endl;
}


