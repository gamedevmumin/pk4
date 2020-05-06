#pragma once

#pragma once
#include <thread>
#include <iostream>
#include <mutex>
#include <deque>

const int maxBufforSize = 128;
std::mutex mutex;
std::condition_variable condition;
std::deque<int> buffor;

void Produce(int amount)
{
	while (amount > 0)
	{
		std::unique_lock<std::mutex> locker(mutex);
		condition.wait(locker, []() { return buffor.size() < maxBufforSize; });
		buffor.push_back(amount);
		--amount;
		std::cout << "Wyprodukowana wartosc:" << amount << std::endl;
		locker.unlock();
		condition.notify_one();
	}
}

void Consume()
{
	while (true)
	{
		std::unique_lock<std::mutex> locker(mutex);
		condition.wait(locker, []() { return !buffor.empty(); });
		auto value = buffor.back();
		buffor.pop_back();
		std::cout << "Skonsumowana wartosc:" << value << std::endl;
		locker.unlock();
		condition.notify_one();
	}
}
