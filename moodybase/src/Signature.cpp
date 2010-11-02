#include <Signature.h>

Signature::Signature()
{
}

Signature::~Signature()
{
}

void Signature::add(const std::string& name, Type* type)
{
    size_t slotCount = slots_.size();
    slots_.resize(slotCount + 1);
    slots_[slotCount].setName(name);
    slots_[slotCount].setType(type);
}
