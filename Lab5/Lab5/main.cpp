#include <iostream>
#include "RandomContainer.h"
#include "Account.h"
#include "PermutatedSequence.h"
#include "Classroom.h"
#include <functional>

int countIf(std::vector<int>::iterator beg, std::vector<int>::iterator end, std::function<bool(int i)> func) {
    int num=0;
    if (func == nullptr)
        throw std::runtime_error("There isn't such a function.\n");
    while (beg != end) {
        if (func(*beg))
            num++;
        beg++;
    }
    return num;
}

int main(int argc, char** argv) {


    PermutatedSequence sequence({1, 2
});
    sequence.generateAllPermutations();


    std::vector<BankAccount> accounts = { BankAccount(1000), BankAccount(30.32),
            BankAccount(1023.13), BankAccount(644315.1441) };
    std::for_each(accounts.begin(), accounts.end(), [](BankAccount& acc) { acc.wypisz(); });
    std::for_each(accounts.begin(), accounts.end(), [](BankAccount& acc) {acc.interest(); });
    std::for_each(accounts.begin(), accounts.end(), [](BankAccount& acc) {acc.wypisz(); });


    Classroom classroom("students.txt");
    if (classroom.anySurname("Pinochet"))
    {
        std::cout << " Jest Pinochet\n";
    }
    if (classroom.noneName("Allende"))
    {
        std::cout << " Nie ma Allende\n";
    }
    if (classroom.allGender("m"))
    {
        std::cout << " Sami mezczyzni\n";
    }

    //zad.5 
    std::vector<int> numerki;
    for (int i = 1; i <= 30; ++i)
        numerki.push_back(i*3);

    std::cout << "Z biblioteki: " << std::count_if(numerki.begin(), numerki.end(),
        [](int i) {return i % 3 == 0; }) << std::endl;
    std::cout<< "Moja: " << countIf(numerki.begin(), numerki.end(), [](int i) {return i % 3 == 0; }) << std::endl;
    return 0;
}