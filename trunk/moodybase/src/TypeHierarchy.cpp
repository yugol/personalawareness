#include <Exception.h>
#include <Type.h>
#include <TypeHierarchy.h>

using namespace std;

const char* ERR_EXISTENT_DERIVATION = "existent derivation";
const char* ERR_CIRCULAR_DERIVATION = "circular derivation";

const string TypeHierarchy::TOP("TOP");
const string TypeHierarchy::BOT("BOT");

TypeHierarchy::TypeHierarchy()
{
    top_ = new Type(TOP);
    bot_ = new Type(BOT);
    link(top_, bot_);
    top_->sign();
}

TypeHierarchy::~TypeHierarchy()
{
    clear();
    delete top_;
    delete bot_;
}

void TypeHierarchy::clear()
{
    for (map<string, Type*>::iterator it = types_.begin(); it != types_.end(); ++it) {
        delete it->second;
    }
    types_.clear();
}

Type* TypeHierarchy::getType(const std::string& id)
{
    std::map<std::string, Type*>::const_iterator it = types_.find(id);
    if (it == types_.end()) {
        if (id == TOP) {
            return top_;
        }
        if (id == BOT) {
            return bot_;
        }
        return 0;
    } else {
        return it->second;
    }
}

Type* TypeHierarchy::createType(const string& id)
{
    Type* type = new Type(id);
    try {
        unlink(top_, bot_);
        link(top_, type);
        link(type, bot_);
        types_[id] = type;
    } catch (const exception& ex) {
        RETHROW(ex);
    }
    return type;
}

bool TypeHierarchy::isDefinible(Type* type) const
{
    if (type == 0) {
        return true;
    }
    if (type == top_) {
        return false;
    }
    if (type == bot_) {
        return false;
    }
    if (type->isSigned()) {
        return false;
    }
    size_t parentCount = type->getParentCount();
    if (parentCount == 1) {
        const Type* firstParent = type->getParent(0);
        if (firstParent == top_) {
            return true;
        }
        return false;
    }
    if (parentCount == 0) {
        return true;
    }
    return false;
}

bool TypeHierarchy::isDerivable(Type* type) const
{
    if (type == 0) {
        return false;
    }
    if (type == bot_) {
        return false;
    }
    return true;
}

void TypeHierarchy::link(Type* sup, Type* sub)
{
    sup->addChild(sub);
    sub->addParent(sup);
}

void TypeHierarchy::unlink(Type* sup, Type* sub)
{
    sup->removeChild(sub);
    sub->removeParent(sup);
}

void TypeHierarchy::derive(Type* type, Type* superType)
{
    if (type->isA(superType)) {
        throw Exception(ERR_EXISTENT_DERIVATION);
    }
    if (superType->isA(type)) {
        throw Exception(ERR_CIRCULAR_DERIVATION);
    }

    unlink(top_, type);

    for (size_t i = 0; i < type->getChildCount(); ++i) {
        Type* child = type->getChild(i);
        for (size_t j = 0; j <= superType->getChildCount(); ++j) {
            Type* superChild = superType->getChild(j);
            if (superChild == child) {
                unlink(superType, superChild);
                break;
            }
        }
    }

    link(superType, type);
}

ostream& TypeHierarchy::dump(ostream& out) const
{
    for (map<string, Type*>::const_iterator it = types_.begin(); it != types_.end(); ++it) {
        it->second->dump(out);
    }
    return out;
}

ostream& TypeHierarchy::dumpDot(ostream& out) const
{
    out << "digraph \"types\" {" << endl;
    top_->dumpDot(out);
    for (map<string, Type*>::const_iterator it = types_.begin(); it != types_.end(); ++it) {
        it->second->dumpDot(out);
    }
    bot_->dumpDot(out);
    out << "}" << endl;
    return out;
}
