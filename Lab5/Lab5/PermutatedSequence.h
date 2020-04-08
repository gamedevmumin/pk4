#ifndef PERMUTATEDSEQUENCE_H
#define PERMUTATEDSEQUENCE_H

#include <vector>
#include <algorithm>
#include <iostream>

class PermutatedSequence {
	std::vector<int> sequence;
public:
	PermutatedSequence(std::vector<int> vec);
	void print();
	void generateAllPermutations();
};

#endif // !PERMUTATEDSEQUENCE_H
