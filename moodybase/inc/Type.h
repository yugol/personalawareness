#ifndef TYPE_H_
#define TYPE_H_

#include <string>
#include <vector>
#include <ostream>

class Signature;

class Type {
public:
    Type(const std::string& id);
    ~Type();

    const std::string& getId() const;
    bool isA(const Type*) const;
    bool isSigned() const;
    const Signature* getSignature() const;
    size_t getParentCount() const;
    size_t getChildCount() const;

    Type* getParent(int idx);
    Type* getChild(int idx);
    void addParent(Type* type);
    void addChild(Type* type);
    void removeParent(Type* type);
    void removeChild(Type* type);

    std::ostream& dump(std::ostream& out) const;
    std::ostream& dumpDot(std::ostream& out) const;

private:
    Signature* signature_;
    std::vector<Type*> parents_;
    std::vector<Type*> children_;
    const std::string id_;
};

inline const std::string& Type::getId() const
{
    return id_;
}

inline bool Type::isSigned() const
{
    return (signature_ != 0);
}

inline const Signature* Type::getSignature() const
{
    return signature_;
}

inline size_t Type::getParentCount() const
{
    return parents_.size();
}

inline size_t Type::getChildCount() const
{
    return children_.size();
}

inline Type* Type::getParent(int idx)
{
    return parents_[idx];
}

inline Type* Type::getChild(int idx)
{
    return children_[idx];
}

#endif /* TYPE_H_ */
