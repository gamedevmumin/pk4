#pragma once
#include "IPv4.h"
#include "Functions.hpp"
#include <vector>
#include <queue>
#include <unordered_set>
#include <set>
#include "SortedList.h"
#include "RandomNumberGenerator.hpp"
#include "Employee.hpp"

void wypiszPracownika(const Employee& pracownik) {
	std::cout << pracownik.firstName << " " << pracownik.lastName << std::endl;
}

int main()
{
	//zadanie 1
	IPv4 ipv4({ 110, 1 ,35, 36 });
	IPv4 ipv4_1({ 10, 24, 125, 6 });
	IPv4 ipv_2({ 10, 44, 235, 26 });
	IPv4 mask({ 255, 255, 255, 0 });
	printIndexable<IPv4, int>(ipv4.maskWith(mask));
	printIndexable<IPv4, int>(ipv4.changeEndianess());
	ipv_2[3] = 115;
	printIndexable<IPv4, int>(ipv_2);

	//zadanie 2 
	std::vector<Employee> employees{
		Employee("Lukasz", "Ochwat"),
		Employee("Michalina", "Swierszcz"),
		{ "Katarzyna", "Caryca" }
	};

	for (const Employee& employee : employees)
		std::cout << employee.firstName << " " << employee.lastName << std::endl;

	employees.insert(employees.begin(), Employee("Mariusz", "Styka³a"));
	employees.insert(employees.begin() + 1, Employee("Irena", "Reniewicz"));
	employees.insert(employees.begin() + 2, Employee("Jan", "Kochanowski"));
	employees.insert(employees.begin() + 3, Employee("Jerzy", "Jeziorowski"));
	employees.insert(employees.begin() + 4, Employee("Stanis³aw", "Staniszewski"));

	auto it = employees.begin() + 2;
	employees.erase(it);

	it = employees.end();
	std::advance(it, -1);
	employees.erase(it);

	it = std::find(employees.begin(), employees.end(), Employee("Jerzy", "Jeziorowski"));
	employees.erase(it);

	std::for_each(employees.begin(), employees.end(),
		wypiszPracownika);

	// zadanie 3
	RandomNumberGenerator<int> generator(-25, 25);
	std::vector<int> randomNumbers(10000);

	for (auto& element : randomNumbers)
		element = generator.getNext();

	std::priority_queue<int, std::deque<int>> queue1;
	std::priority_queue<int, std::vector<int>> queue2;

	auto t1 = sysclock_t::now();
	for (int element : randomNumbers)
		queue2.emplace(element);

	auto t2 = sysclock_t::now();
	for (int element : randomNumbers)
		queue1.emplace(element);

	auto t3 = sysclock_t::now();

	std::cout <<  "Vector queue time: " << std::chrono::duration_cast<std::chrono::microseconds>(t2 - t1).count() << std::endl;
	std::cout << " VequeQueue time: " << std::chrono::duration_cast<std::chrono::microseconds>(t3 - t2).count() << std::endl;

	// czas dodawania elementu do deque jest zauwazalnie wiekszy niz czas dodawania do vectora. Wynika to prawdopdobonie z tego, ze vector zapewnia ciaglosc pamieci, w przeciwienstwie do deque.

	//zadanie 4
	RandomNumberGenerator<int> randomNumberGenerator(0, 19);

	randomNumbers.resize(15);

	for (int i = 0; i < randomNumbers.size(); i++)
	{
		randomNumbers[i] = randomNumberGenerator.getNext();
	}


	for (auto liczba : randomNumbers)
		std::cout << liczba << " ";

	std::cout << std::endl;

	std::unordered_set<int> randomNumbersNoDuplicates(randomNumbers.begin(), randomNumbers.end());

	for (auto liczba : randomNumbersNoDuplicates)
		std::cout << liczba << " ";
	std::cout << std::endl;

	std::set<int> sortedRandomNumbersNoDuplicates(randomNumbers.begin(), randomNumbers.end());
	std::cout << "Posortowane:" << std::endl;

	for (auto liczba : sortedRandomNumbersNoDuplicates)
		std::cout << liczba << " ";
	std::cout << std::endl;

	//Zadanie 5
	SortedList<int> lista;
	lista.insert(10);
	lista.insert(5);
	lista.insert(23);
	lista.insert(114);
	lista.insert(1);
	
	return 0;
}