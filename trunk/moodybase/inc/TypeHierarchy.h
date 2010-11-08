#ifndef TYPEHIERARCHY_H_
#define TYPEHIERARCHY_H_

#include <ostream>
#include <string>
#include <map>

class Type;

class TypeHierarchy {
public:
    TypeHierarchy();
    ~TypeHierarchy();

    Type* getType(const std::string& id);
    Type* createType(const std::string& id);
    bool isDefinible(Type*) const;
    bool isDerivable(Type*) const;
    void derive(Type* type, Type* superType);
    void sign(Type* type);

    std::ostream& dump(std::ostream& out) const;
    std::ostream& dumpDot(std::ostream& out) const;

private:
    static const std::string TOP;
    static const std::string BOT;

    std::map<std::string, Type*> types_;
    Type* top_;
    Type* bot_;

    void clear();
    void link(Type* sup, Type* sub);
    void unlink(Type* sup, Type* sub);
};

#endif /* TYPEHIERARCHY_H_ */
