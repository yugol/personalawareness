#ifndef TYPEHIERARCHY_H_
#define TYPEHIERARCHY_H_

#include <iostream>
#include <string>
#include <map>
#include "Type.h"

class TypeHierarchy {
public:
	TypeHierarchy();
	~TypeHierarchy();

	void createDerivedType(const char* spec);

	const Type* operator[](size_t index) const;
	const Type* operator[](const std::string& id) const;

	std::istream& load(std::istream& in);
	std::ostream& dump(std::ostream& out);
	std::ostream& exportGraphviz(std::ostream& out);

private:
	std::vector<Type*> typeList_;
	std::map<std::string, Type*> typeMap_;

	Type* getCreateType(const std::string& id);
	void clear();
};

inline const Type* TypeHierarchy::operator[](size_t index) const
{
	if (index > typeList_.size()) {
		return 0;
	}
	return typeList_[index];
}

inline const Type* TypeHierarchy::operator[](const std::string& id) const
{
	std::map<std::string, Type*>::const_iterator it = typeMap_.find(id);
	if (it == typeMap_.end()) {
		return 0;
	} else {
		return it->second;
	}
}

#endif /* TYPEHIERARCHY_H_ */
