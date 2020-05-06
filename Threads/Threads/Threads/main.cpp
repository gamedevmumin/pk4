
#include <iostream>       
#include <thread>         
#include <chrono>         
#include "Exercise3.h"
#include "Exercise2.h"

void Sum(int values[], int startIndex, int endingIndex, int& result)
{
    for (int i = startIndex; i < endingIndex; i++)
    {
        result += values[i];
    }
}

int main()
{
	//zadanie 1.
	int tablica[100];

	for (int i = 0; i < 100; i++)
	{
		tablica[i] = i;
	}

	int pierwszaCzesc = 0;
	int drugaCzesc = 0;

	std::thread t1(&Sum, tablica, 0, 50, std::ref(pierwszaCzesc));
	std::thread t2(&Sum, tablica, 50, 100, std::ref(drugaCzesc));

	t1.join();
	t2.join();

	int wynik = pierwszaCzesc + drugaCzesc;

	std::cout << wynik << std::endl;
	//zadanie 2.
	std::vector<unsigned int> wektorLiczb;

	int startTime = clock();

	FindPrimes(1, 100000);

	int endTime = clock();

	std::cout << "Czas wykonania, jeden w¹tek: " <<
		(endTime - startTime) / double(CLOCKS_PER_SEC) << std::endl;

	startTime = clock();

	FindPrimesUsingThreads(1, 100000, 4);

	endTime = clock();

	std::cout << "Czas wykonania, 4 w¹tki : " <<
		(endTime - startTime) / double(CLOCKS_PER_SEC) << std::endl;

	
	

	//zadanie 3.
	std::thread produce(Produce, 100);
	std::thread consume(Consume);

	produce.join();
	consume.join();
    return 0;
}