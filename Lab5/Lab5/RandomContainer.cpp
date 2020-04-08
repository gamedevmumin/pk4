#include "RandomContainer.h"

RandomContainer::RandomContainer(size_t length, int lowerBound, int upperBound) : sequence(length) {
	std::random_device rd;
	std::uniform_int_distribution<int> distr(lowerBound, upperBound);
	for (int i = 0; i < length; ++i)
		sequence.at(i) = distr(rd);
}

std::ostream& operator<<(std::ostream& stream, const RandomContainer& cont)
{
	for (auto item : cont.sequence)
		stream << item << " ";
	stream << '\n';
	return stream;
}

void RandomContainer::sort()
{
	std::sort(sequence.begin(), sequence.end());
}

void RandomContainer::sortDesc()
{
	std::sort(sequence.begin(), sequence.end(), [](int a, int b) {return a > b; });
}