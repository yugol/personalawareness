#include <Exception.h>
#include <Type.h>

using namespace std;

Type::Type(const std::string& id) :
	signature_(0), id_(id)
{
}

Type::~Type()
{
}

bool Type::isA(const Type* type) const
{
	if (this == type) {
		return true;
	}
	for (size_t i = 0; i < parents_.size(); ++i) {
		if (parents_[i]->isA(type)) {
			return true;
		}
	}
	return false;
}

void Type::makeA(Type* type)
{
	if (this->isA(type)) {
		return;
	}
	if (type->isA(this)) {
		THROW("circular derivation");
	}
	for (size_t i = 0; i < parents_.size(); ++i) {
		if (type->isA(parents_[i])) {
			parents_[i] = type;
			return;
		}
	}
	parents_.push_back(type);
}

ostream& Type::dump(ostream& out)
{
	if (parents_.size() > 0) {
		out << getId() << " :";
		for (size_t i = 0; i < parents_.size() - 1; ++i) {
			out << " " << parents_[i]->getId() << ",";
		}
		out << " " << parents_[parents_.size() - 1]->getId() << endl;
	}
	return out;
}

ostream& Type::exportGraphviz(ostream& out)
{
	for (size_t i = 0; i < parents_.size(); ++i) {
		out << '"' << getId() << "\" -> \"" << parents_[i]->getId() << '"' << endl;
	}
	for (size_t i = 0; i < children_.size(); ++i) {
		out << '"' << children_[i]->getId() << "\" -> \"" << getId() << '"' << endl;
	}
	if (parents_.size() + children_.size() == 0) {
		out << '"' << getId() << '"' << endl;
	}
	return out;
}
