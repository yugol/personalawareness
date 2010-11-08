#include <Signature.h>

using namespace std;

Signature::Signature()
{
}

Signature::~Signature()
{
}

void Signature::add(const string& id, Type* type)
{
    size_t slotCount = slots_.size();
    slots_.resize(slotCount + 1);
    slots_[slotCount].setId(id);
    slots_[slotCount].setType(type);
}

const Slot* Signature::operator[](const string& id) const
{
    for (size_t i = 0; i < slots_.size(); ++i) {
        if (slots_[i].getId() == id) {
            return &slots_[i];
        }
    }
    return 0;
}

