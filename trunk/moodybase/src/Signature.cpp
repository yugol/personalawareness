#include <Exception.h>
#include <Signature.h>

using namespace std;

static const char* ERR_INEXISTENT_SLOT = "inexistent slot";
static const char* ERR_EXISTENT_SLOT = "slot already exists";

Signature::Signature()
{
}

Signature::~Signature()
{
}

void Signature::add(const string& id, Type* type)
{
    if (getSlot(id)) {
        throw Exception(ERR_EXISTENT_SLOT);
    }
    size_t slotCount = slots_.size();
    slots_.resize(slotCount + 1);
    slots_[slotCount].setId(id);
    slots_[slotCount].setType(type);
}

void Signature::set(const std::string& id, Type* type)
{
    Slot* slot = getSlot(id);
    if (!slot) {
        throw Exception(ERR_INEXISTENT_SLOT);
    }
    slot->setType(type);
}

Slot* Signature::getSlot(const std::string& id) const
{
    for (size_t i = 0; i < slots_.size(); ++i) {
        if (slots_[i].getId() == id) {
            return const_cast<Slot*> (&(slots_[i]));
        }
    }
    return 0;
}

