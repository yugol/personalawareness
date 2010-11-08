#include <Atom.h>
#include <TypeHierarchy.h>
#include <Structure.h>

using namespace std;

Structure::Structure(TypeHierarchy* types) :
    types_(types)
{
}

Structure::~Structure()
{
    map<Type*, vector<Atom*> >::iterator it = atoms_.begin();
    while (it != atoms_.end()) {
        vector<Atom*>& atoms = it->second;
        for (size_t i = 0; i < atoms.size(); ++i) {
            // TODO: what happens in rollback
            delete atoms[i];
        }
        ++it;
    }
}

Atom* Structure::createAtom(Type* type)
{
    types_->sign(type);
    Atom* atom = new Atom(type);
    atoms_[type].push_back(atom);
    return atom;
}

void Structure::nameFact(Atom* fact, const std::string& id)
{
    fact->setId(id);
    namedFacts_[id] = fact;
}

Atom* Structure::getFact(const std::string& id) const
{
    map<string, Atom*>::const_iterator it = namedFacts_.find(id);
    if (it == namedFacts_.end()) {
        return 0;
    }
    return it->second;
}

