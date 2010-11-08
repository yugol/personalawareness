#include <constatnts.h>
#include <Type.h>
#include <Atom.h>

using namespace std;

Atom::Atom(Type* type) :
    type_(type), args_(0)
{
}

Atom::~Atom()
{
}

void Atom::setId(const std::string& id)
{
    id_ = id;
}

ostream& Atom::dump(ostream& out) const
{
    if (id_.size() > 0) {
        out << id_ << TOK_SPACE << TOK_DEFN << TOK_SPACE;
    }
    out << type_->getId() << TOK_OPAR << TOK_CPAR << TOK_STMT;
    out << endl;
    return out;
}
