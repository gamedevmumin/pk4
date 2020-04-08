#ifndef CLASSROOM_H
#define CLASSROOM_H
#include <string>
#include <vector>
#include <fstream>
#include <algorithm>
#include <iostream>
struct Student {
	std::string name;
	std::string surname;
	std::string gender;

	Student(const std::string& _name,const std::string& _surname,const std::string& _gender) : name(_name), surname(_surname), gender(_gender) {}
};

class Classroom {
	std::vector<Student> students;
public:
	Classroom(const std::string& file);
	bool anyName(const std::string& value);
	bool anySurname(const std::string& value);
	bool anyGender(const std::string& value);
	bool noneName(const std::string& value);
	bool noneSurname(const std::string& value);
	bool noneGender(const std::string& value);
	bool allName(const std::string& value);
	bool allSurname(const std::string& value);
	bool allGender(const std::string& value);
};
#endif 
