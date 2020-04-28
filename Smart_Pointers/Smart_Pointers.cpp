#include <iostream>
#include <memory>
#include "book.h"
#include "shelf.h"

//Zadanie 2.
void Fibonacci(unsigned int size)
{
	if (size == 1)
	{
		std::cout << "0" << '\n';
	}
	else
	{

		std::unique_ptr<int[]> newarray{ new int[size+2] };
		newarray[0] = 0;
		newarray[1] = 1;
		if (size > 2)
		{
			for (int i = 2; i < size+2; ++i)
			{
				newarray[i] = newarray[i - 1] + newarray[i - 2];
				std::cout << newarray[i] << std::endl;
			}
		}
	}
}

int main()
{
	//Zadanie 1.
	std::shared_ptr<int> ptr =  std::make_shared<int>();
	std::cout << "Ile: " << ptr.use_count() << std::endl;
	{		
			std::shared_ptr<int> ptr1 = ptr;
			std::cout << "Ile: " << ptr.use_count() << std::endl;
			{
				std::shared_ptr<int> ptr2 = ptr;
				std::cout << "Ile: " << ptr.use_count() << std::endl;
				{
					std::shared_ptr<int> ptr3 = ptr;
					std::cout << "Ile: " << ptr.use_count() << std::endl;
				}
				std::cout << "Ile: " << ptr.use_count() << std::endl;
			}
			std::cout << "Ile: " << ptr.use_count() << std::endl;
	}
	std::cout << "Ile: " << ptr.use_count() << std::endl;
	//Zadanie 2.
	Fibonacci(6);
	//Zadanie 3.
	shelf sh;
	sh.addBook("Harry Potter", 356);
	sh.displayShelf();
}

