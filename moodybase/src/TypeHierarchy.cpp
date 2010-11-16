#include <Exception.h>
#include <constatnts.h>
#include <Type.h>
#include <Signature.h>
#include <TypeHierarchy.h>

using namespace std;

const char* ERR_EXISTENT_DERIVATION = "existent derivation";
const char* ERR_CIRCULAR_DERIVATION = "circular derivation";
const char* ERR_INCOMPATIBLE_SIGNATURE = "incompatible signature";

const string TypeHierarchy::TOP(TYPE_TOP);
const string TypeHierarchy::BOT(TYPE_BOT);

TypeHierarchy::TypeHierarchy()
{
    top_ = new Type(TOP);
    bot_ = new Type(BOT);
    link(top_, bot_);
    sign(top_);
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

    for (size_t i = 0; i < signatures_.size(); ++i) {
        delete signatures_[i];
    }
    signatures_.clear();
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
    if (!type) {
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
    if (!type) {
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

const Signature* TypeHierarchy::sign(Type* type)
{
    if (type->getSignature()) {
        return type->getSignature();
    }
    if (type->getParentCount() == 0) { // only happens for TOP
        Signature* signature = new Signature();
        type->setSignature(signature);
        signatures_.push_back(signature);
    } else if (type->getParentCount() == 1 && !type->getDeltaSignature()) {
        type->setSignature(const_cast<Signature*> (sign(type->getParent(0))));
    } else {
        Signature* signature = new Signature();
        for (size_t i = 0; i < type->getParentCount(); ++i) {
            try {
                merge(signature, sign(type->getParent(i)));
            } catch (Exception e) {
                delete signature;
                return 0;
            }
        }
        if (type->getDeltaSignature()) {
            try {
                merge(signature, type->getDeltaSignature());
            } catch (Exception e) {
                delete signature;
                return 0;
            }
        }
        type->setSignature(signature);
        signatures_.push_back(signature);
    }
    if (!type->getSignature()) {
        throw Exception(ERR_INCOMPATIBLE_SIGNATURE);
    }
    return type->getSignature();
}

void TypeHierarchy::merge(Signature* toSignature, const Signature* fromSignature)
{
    if (!fromSignature) {
        throw Exception(ERR_INCOMPATIBLE_SIGNATURE);
    }
    for (size_t i = 0; i < fromSignature->size(); ++i) {
        const Slot* parentSlot = (*fromSignature)[i];
        const Slot* slot = (*toSignature)[parentSlot->getId()];
        if (slot) {
            if (!slot->getType()->isA(parentSlot->getType())) {
                throw Exception(ERR_INCOMPATIBLE_SIGNATURE);
            }
            toSignature->set(parentSlot->getId(), const_cast<Type*> (parentSlot->getType()));
        } else {
            toSignature->add(parentSlot->getId(), const_cast<Type*> (parentSlot->getType()));
        }
    }
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
