#include <algorithm>
#include <Signature.h>
#include <Type.h>

using namespace std;

Type::Type(const std::string& id) :
    signature_(0), id_(id)
{
}

Type::~Type()
{
    delete signature_;
}

bool Type::isA(const Type* type) const
{
    if (this == type) {
        return true;
    }
    for (size_t i = 0; i < parents_.size(); ++i) {
        if (parents_[i]->isA(type)) {
            return true;
        }
    }
    return false;
}

void Type::addParent(Type* type)
{
    parents_.push_back(type);
}

void Type::addChild(Type* type)
{
    children_.push_back(type);
}

void Type::removeParent(Type* type)
{
    vector<Type*>::iterator it = find(parents_.begin(), parents_.end(), type);
    if (it != parents_.end()) {
        parents_.erase(it);
    }
}

void Type::removeChild(Type* type)
{
    vector<Type*>::iterator it = find(children_.begin(), children_.end(), type);
    if (it != children_.end()) {
        children_.erase(it);
    }
}

ostream& Type::dump(ostream& out) const
{
    if (parents_.size() > 0) {
        out << getId() << " :";
        for (size_t i = 0; i < parents_.size() - 1; ++i) {
            out << " " << parents_[i]->getId() << ",";
        }
        out << " " << parents_[parents_.size() - 1]->getId() << endl;
    }
    return out;
}

ostream& Type::dumpDot(ostream& out) const
{
    for (size_t i = 0; i < children_.size(); ++i) {
        out << '"' << getId() << "\" -> \"" << children_[i]->getId() << '"' << endl;
    }
    for (size_t i = 0; i < parents_.size(); ++i) {
        out << '"' << getId() << "\" -> \"" << parents_[i]->getId() << '"' << endl;
    }
    if (parents_.size() + children_.size() == 0) {
        out << '"' << getId() << '"' << endl;
    }
    return out;
}
