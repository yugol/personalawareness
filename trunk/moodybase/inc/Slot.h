#ifndef SLOT_H_
#define SLOT_H_

#include <ostream>
#include <string>

class Type;

class Slot {
public:
    Slot();
    ~Slot();

    const std::string& getId() const;
    const Type* getType() const;

    void setId(const std::string& name);
    void setType(Type* type);

    std::ostream& dump(std::ostream& out) const;

private:
    std::string id_;
    Type* type_;
};

inline const std::string& Slot::getId() const
{
    return id_;
}

inline const Type* Slot::getType() const
{
    return type_;
}

#endif /* SLOT_H_ */
