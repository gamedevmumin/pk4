#include "PermutatedSequence.h"

PermutatedSequence::PermutatedSequence(std::vector<int> vec) : sequence(vec)
{
}

void PermutatedSequence::print()
{
	for (auto el : sequence)
	{
		std::cout << el << " ";
	}
	std::cout << '\n';
}

void PermutatedSequence::generateAllPermutations()
{
	sort(sequence.begin(), sequence.end());
	do {
		print();
	} while (std::next_permutation(sequence.begin(), sequence.end()));
}