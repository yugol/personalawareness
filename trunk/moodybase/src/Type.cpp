#include <constatnts.h>
#include <algorithm>
#include <Signature.h>
#include <Type.h>

using namespace std;

Type::Type(const std::string& id) :
    slots_(0), signature_(0), id_(id)
{
}

Type::~Type()
{
    delete slots_;
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

void Type::addSlot(const std::string& name, Type* type)
{
    if (!slots_) {
        slots_ = new Signature();
    }
    slots_->add(name, type);
}

const Slot* Type::getSlot(const std::string& id) const
{
    if (slots_) {
        return ((*slots_)[id]);
    }
    return 0;
}

void Type::sign()
{
    if (slots_ == 0) {
        slots_ = new Signature();
    }
}

ostream& Type::dump(ostream& out) const
{
    out << getId() << TOK_SPACE << TOK_DEFN << " " << TOK_OPAR;
    if (parents_.size() > 0) {
        out << parents_[0]->getId();
        for (size_t i = 1; i < parents_.size(); ++i) {
            out << TOK_SPACE << parents_[i]->getId();
        }
    }
    out << TOK_CPAR;
    if (slots_ != 0 && slots_->size() > 0) {
        out << endl << TOK_INDENT;
        (*slots_)[0]->dump(out);
        for (size_t i = 1; i < slots_->size(); ++i) {
            out << endl << TOK_INDENT;
            (*slots_)[i]->dump(out);
        }
    }
    out << TOK_STMT << endl;
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
