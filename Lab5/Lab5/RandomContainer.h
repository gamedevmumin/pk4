#ifndef RANDOMCONTAINER_H
#define RANDOMCONTAINER_H

#include <iostream>
#include <random>
#include <vector>
#include <algorithm>
class RandomContainer {
	std::vector<int> sequence;
public:
	RandomContainer(size_t length, int lowerBound, int upperBound);
	friend std::ostream& operator<<(std::ostream& stream, const RandomContainer& cont);
	void sort();
	void sortDesc();
};
#endif // !RANDOMCONTAINER_H
