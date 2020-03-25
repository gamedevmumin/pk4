#include <iostream>
#include <string>
#include "functions.h"
#include "Point.h"
#include "Pair.h"
#include "Counter.h"

template <typename T>
void print(T rzecz)
{
	std::cout << rzecz << std::endl;
}

int main()
{
	print<int>(10);
	print<float>(10.5);
	print<std::string>("123");
	//returnGivenValue<int>(5); wywolanie konczy sie niepowodzeniem kompilacji przez unresolved external symbol
	Point<int> pointint(-5, 4);
	Point<unsigned int> pointuint(5, 5);
	Point<float> pointfloat(3.5, 4.5);
	pointint.print();
	pointuint.print();
	pointfloat.print();
	Pair<std::string, int> para("hello", 100);
	para.printTypeNames();
	X dwaiksy[2];
	{
		X iksy[10];
		Y igreki[100];
		Counter<X>::check();
		Counter<Y>::check();
	}
	Counter<X>::check();
	Counter<Y>::check();

	return 0;
}