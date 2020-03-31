#pragma once
#include "Types.hpp"
#include <array>
#include <iostream>
class IPv4 {
private:
	std::array<byte_t, 4> bytes;
public:
	IPv4(const std::array<byte_t, 4>& _bytes) : bytes(_bytes)
	{
	}


    constexpr size_t size() const {
        return bytes.size();
    }

    const byte_t& operator[](size_t index) const {
        return bytes.at(index);
    }

    byte_t& operator[](size_t index) {
        return bytes.at(index);
    }

    IPv4 changeEndianess()
    {
        std::array<byte_t, 4> reversed = bytes;
        std::reverse(reversed.begin(), reversed.end());
        return IPv4(reversed);

    }

    IPv4 maskWith(const IPv4& mask) const {
        std::array<byte_t, 4> masked;
        for (size_t i = 0; i < bytes.size(); i++)
            masked[i] = bytes.at(i) & mask.bytes.at(i);
        return IPv4(masked);
    }

};