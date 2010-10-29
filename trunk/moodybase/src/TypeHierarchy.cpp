#include <cstring>
#include <cctype>
#include <Exception.h>
#include <TypeHierarchy.h>

using namespace std;

static const char* TYPES_MARKER = "%==TYPES==%";
static const char* HIERARCHY_MARKER = "%==HIERARCHY==%";

TypeHierarchy::TypeHierarchy()
{
	// add TOP and BOTTOM
}

TypeHierarchy::~TypeHierarchy()
{
	clear();
}

void TypeHierarchy::clear()
{
	for (size_t i = 0; i < typeList_.size(); ++i) {
		delete typeList_[i];
	}
	typeList_.clear();
	typeMap_.clear();
}

Type* TypeHierarchy::getCreateType(const string& id)
{
	Type* type = 0;
	if (typeMap_.find(id) == typeMap_.end()) {
		type = new Type(id);
		typeMap_[id] = type;
		typeList_.push_back(type);
	} else {
		type = typeMap_[id];
	}
	return type;
}

void TypeHierarchy::createDerivedType(const char* spec)
{
	if (spec != 0) {
		Type* type = 0;
		string id;
		char ch;
		while ((ch = *spec++) != '\0') {
			if (isalnum(ch) || ch == '_') {
				id.append(1, ch);
			} else if (id.size() > 0) {
				if (type == 0) {
					type = getCreateType(id);
				} else {
					Type* superType = getCreateType(id);
					type->makeA(superType);
				}
				id.clear();
			}
		}
		if (id.size() > 0) {
			if (type == 0) {
				type = getCreateType(id);
			} else {
				Type* superType = getCreateType(id);
				type->makeA(superType);
			}
			id.clear();
		}
	}
}

istream& TypeHierarchy::load(istream& in)
{

	return in;
}

ostream& TypeHierarchy::dump(ostream& out)
{
	out << endl << TYPES_MARKER << endl;
	for (size_t i = 0; i < typeList_.size(); ++i) {
		out << typeList_[i]->getId() << endl;
	}
	out << endl << HIERARCHY_MARKER << endl;
	for (size_t i = 0; i < typeList_.size(); ++i) {
		typeList_[i]->dump(out);
	}
	return out;
}

ostream& TypeHierarchy::exportGraphviz(ostream& out)
{
	out << endl << "digraph \"" << HIERARCHY_MARKER << "\" {" << endl;
	for (size_t i = 0; i < typeList_.size(); ++i) {
		typeList_[i]->exportGraphviz(out);
	}
	out << "}" << endl;
	return out;
}
