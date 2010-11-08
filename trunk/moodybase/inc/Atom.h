#ifndef ATOM_H_
#define ATOM_H_

#include <string>
#include <vector>
#include <ostream>

class Type;

class Atom {
public:
    Atom(Type* type);
    ~Atom();

    const std::string& getId() const;

    void setId(const std::string& id);

    std::ostream& dump(std::ostream& out) const;

private:
    Type* type_;
    Atom** args_;
    std::vector<Atom*> refs_;
    std::string id_;
};

inline const std::string& Atom::getId() const
{
    return id_;
}

#endif /* ATOM_H_ */
