#pragma once
#include <iostream>
template <class T>
class Point {
private:
	T x;
	T y;
public:
	Point(T _x, T _y) :x(_x), y(_y) {}
	void print() {
		std::cout << "x: " << x << std::endl;
		std::cout << "y: " << y << std::endl;
	}
};