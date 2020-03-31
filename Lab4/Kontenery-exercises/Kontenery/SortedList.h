#pragma once
#pragma once
#include <list>

template<class T>
class SortedList {
	std::list<T> list;

public:
	void insert(const T& number) {

		auto it = list.begin();
		auto endOfList = list.end();
		if (list.size())
			while (it != endOfList && *it < number)
				it++;

		list.insert(it, number);
	}

	void erase(typename std::list<T>::iterator pos) {
		list.erase(pos);
	}

	typename std::list<T>::iterator begin() {
		return list.begin();
	}

	typename std::list<T>::iterator end() {
		return list.end();
	}

	T& operator[](std::size_t i) {
		auto it = list.begin();
		std::advance(it, i);
		return *it;
	}
};