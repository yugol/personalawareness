#ifndef TYPEHIERARCHY_H_
#define TYPEHIERARCHY_H_

#include <ostream>
#include <string>
#include <vector>
#include <map>

class Type;
class Signature;

class TypeHierarchy {
public:
    TypeHierarchy();
    ~TypeHierarchy();

    Type* getType(const std::string& id);
    Type* createType(const std::string& id);
    bool isDefinible(Type*) const;
    bool isDerivable(Type*) const;
    void derive(Type* type, Type* superType);
    const Signature* sign(Type* type);

    std::ostream& dump(std::ostream& out) const;
    std::ostream& dumpDot(std::ostream& out) const;

private:
    static const std::string TOP;
    static const std::string BOT;

    std::map<std::string, Type*> types_;
    std::vector<Signature*> signatures_;
    Type* top_;
    Type* bot_;

    void clear();
    void link(Type* sup, Type* sub);
    void unlink(Type* sup, Type* sub);
    void merge(Signature* signature, const Signature* parentSignature);
};

#endif /* TYPEHIERARCHY_H_ */
