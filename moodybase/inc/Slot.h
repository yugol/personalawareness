#ifndef SLOT_H_
#define SLOT_H_

#include <ostream>
#include <string>

class Type;

class Slot {
public:
    Slot();
    ~Slot();

    const std::string& getName() const;
    const Type* getValue() const;

    void setName(const std::string& name);
    void setType(Type* type);

    std::ostream& dump(std::ostream& out) const;

private:
    std::string name_;
    Type* type_;
};

inline const std::string& Slot::getName() const
{
    return name_;
}

inline const Type* Slot::getValue() const
{
    return type_;
}

#endif /* SLOT_H_ */
