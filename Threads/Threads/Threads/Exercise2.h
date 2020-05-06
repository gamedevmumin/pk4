#pragma once


#include <iostream>
#include <string>
#include <vector>
#include <ctime>
#include <thread>
#include <ctime>
#include <mutex>

// Used to protect writing to the vector
std::mutex vectLock;
std::vector<unsigned int> primeVect;

void FindPrimes(unsigned int start,
	unsigned int end) {

	// Cycle through numbers while ignoring evens
	for (unsigned int x = start; x <= end; x += 2) {

		// If a modulus is 0 we know it isn't prime
		for (unsigned int y = 2; y < x; y++) {
			if ((x % y) == 0) {
				break;
			}
			else if ((y + 1) == x) {
				vectLock.lock();
				primeVect.push_back(x);
				vectLock.unlock();
			}
		}
	}
}

void FindPrimesUsingThreads(unsigned int start,
	unsigned int end,
	unsigned int numberOfThreads) {

	std::vector<std::thread> threadVector;

	unsigned int threadSpread = end / numberOfThreads;
	unsigned int endOfThreadValues = start + threadSpread - 1;

	for (unsigned int x = 0; x < numberOfThreads; x++) {
		threadVector.emplace_back(FindPrimes,
			start, endOfThreadValues);

		start += threadSpread;
		endOfThreadValues += threadSpread;
	}

	for (int i = 0; i < threadVector.size(); i++)
	{
		threadVector[i].join();
	}

}
