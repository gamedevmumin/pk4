#include "Classroom.h"

Classroom::Classroom(const std::string& fileName)
{
	std::ifstream file(fileName);
	if (file)
	{
		std::string name, surname, gender;
		while (!file.eof())
		{
			file >> name >> surname >> gender;
			students.emplace_back(Student(name, surname, gender));
			
		}
		file.close();
	}
}

bool Classroom::anyName(const std::string& value)
{
	return std::any_of(students.begin(), students.end(), [value](const Student& st) {return st.name == value; });
}

bool Classroom::anySurname(const std::string& value)
{
	return std::any_of(students.begin(), students.end(), [value](const Student& st) {return st.surname == value; });
}

bool Classroom::anyGender(const std::string& value)
{
	return std::any_of(students.begin(), students.end(), [value](const Student& st) {return st.gender == value; });
}

bool Classroom::noneName(const std::string& value)
{
	return std::none_of(students.begin(), students.end(), [value](const Student& st) {return st.name == value; });
}

bool Classroom::noneSurname(const std::string& value)
{
	return  std::none_of(students.begin(), students.end(), [value](const Student& st) {return st.surname == value; });
}

bool Classroom::noneGender(const std::string& value)
{
	return  std::none_of(students.begin(), students.end(), [value](const Student& st) {return st.gender == value; });
}

bool Classroom::allName(const std::string& value)
{
	return  std::all_of(students.begin(), students.end(), [value](const Student& st) {return st.name == value; });
}

bool Classroom::allSurname(const std::string& value)
{
	return std::all_of(students.begin(), students.end(), [value](const Student& st) {return st.surname == value; });
}

bool Classroom::allGender(const std::string& value)
{
	return std::all_of(students.begin(), students.end(), [value](const Student& st) {return st.gender == value; });
}