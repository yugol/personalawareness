#ifndef ATOM_H_
#define ATOM_H_

#include <string>
#include <vector>

class Type;

class Atom {
public:
    Atom(Type* type);
    ~Atom();

private:
    Type* type_;
    Atom** args_;
    std::vector<Atom*> refs_;
    std::string id_;
};

#endif /* ATOM_H_ */
