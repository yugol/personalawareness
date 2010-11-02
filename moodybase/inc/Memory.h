#ifndef MEMORY_H_
#define MEMORY_H_

#include <string>
#include <TypeHierarchy.h>
#include <Structure.h>
#include <TransactionMgr.h>

class Memory {
public:
    Memory();
    ~Memory();

    void beginTransaction();
    void rollbackTransaction();
    void commitTransaction();

    Type* getType(const std::string& id);
    Type* createType(const std::string& id);
    bool isDefinible(Type* type);
    bool isDerivable(Type* type);
    void derive(Type* type, Type* superType);

    std::ostream& dumpTypesDot(std::ostream& out);

private:
    TypeHierarchy types_;
    Structure facts_;
    TransactionMgr transactions_;
};

inline Type* Memory::getType(const std::string& id)
{
    return types_.getType(id);
}

inline Type* Memory::createType(const std::string& id)
{
    Type* type = types_.createType(id);
    transactions_.add(type);
    return type;
}

inline bool Memory::isDefinible(Type* type)
{
    return types_.isDefinible(type);
}

inline bool Memory::isDerivable(Type* type)
{
    return types_.isDerivable(type);
}

inline void Memory::derive(Type* type, Type* superType)
{
    types_.derive(type, superType);
}

#endif /* MEMORY_H_ */
