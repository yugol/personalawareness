#include <Item.h>
#include "util.h"

namespace adb
{

Item::Item()
    :
    id_(-1)
{
}

Item::Item(const char *name)
    :
    id_(0)
{
    setName(name);
}

Item::Item(int id, const char *name)
    :
    id_(id)
{
    setName(name);
}

Item::~Item()
{
}

void Item::setName(const char *name)
{
    charPtrToString(this->name_, name);
}

} // namespace adb
