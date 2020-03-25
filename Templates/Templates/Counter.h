#pragma once
#include <iostream>

template <class T>
class Counter {
private:
	static int existingObjects;
	static int createdObjects;
public:
	Counter() {
		++existingObjects;
		++createdObjects;
	}
	static void check() {
		std::cout << "Created: " << createdObjects << std::endl;
		std::cout << "Existing: " << existingObjects << std::endl;
	}
protected:
	~Counter() {
		--existingObjects;
	}
};

template <typename T> int Counter<T>::existingObjects(0);
template <typename T> int Counter<T>::createdObjects(0);

class X : public Counter<X> {

};

class Y : public Counter<Y> {

};