#ifndef STRUCTURE_H_
#define STRUCTURE_H_

#include <string>
#include <vector>
#include <map>

class Atom;
class Type;
class TypeHierarchy;

class Structure {
public:
    Structure(TypeHierarchy* types);
    ~Structure();

    Atom* createAtom(Type* type);
    void nameFact(Atom* fact, const std::string& id);
    Atom* getFact(const std::string& id) const;

private:
    TypeHierarchy* types_;
    std::map<Type*, std::vector<Atom*> > atoms_;
    std::map<std::string, Atom*> namedFacts_;

};

#endif /* STRUCTURE_H_ */
