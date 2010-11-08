#include <constatnts.h>
#include <Type.h>
#include <Slot.h>

using namespace std;

Slot::Slot() :
    type_(0)
{
}

Slot::~Slot()
{
}

void Slot::setId(const std::string & name)
{
    id_ = name;
}

void Slot::setType(Type *type)
{
    type_ = type;
}

std::ostream& Slot::dump(std::ostream& out) const
{
    out << id_ << TOK_SPACE << TOK_DEFN << TOK_SPACE << type_->getId();
    return out;
}

