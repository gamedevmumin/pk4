#pragma once
#include <iostream>

template<class T1, class T2>
class Pair
{
private:
	T1 first;
	T2 second;
public:
	Pair(T1 _first, T2 _second) : first(_first), second(_second) {

	}
	void printTypeNames()
	{
		std::cout << typeid(first).name() << std::endl;
		std::cout << typeid(second).name() << std::endl;
	}
};
