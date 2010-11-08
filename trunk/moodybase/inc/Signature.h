#ifndef SIGNATURE_H_
#define SIGNATURE_H_

#include <string>
#include <vector>
#include <Slot.h>

class Type;

class Signature {
public:
    Signature();
    ~Signature();

    size_t size() const;
    const Slot* operator[](int idx) const;
    const Slot* operator[](const std::string& id) const;
    void add(const std::string& id, Type* type);

private:
    std::vector<Slot> slots_;
};

inline size_t Signature::size() const
{
    return slots_.size();
}

inline const Slot* Signature::operator[](int idx) const
{
    return &slots_[idx];
}

#endif /* SIGNATURE_H_ */
