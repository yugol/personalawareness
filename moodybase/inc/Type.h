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
	void makeA(Type*);

	std::ostream& dump(std::ostream& out);
	std::ostream& exportGraphviz(std::ostream& out);

private:
	Signature* signature_;
	std::vector<const Type*> parents_;
	std::vector<const Type*> children_;
	const std::string id_;
};

inline const std::string& Type::getId() const
{
	return id_;
}

#endif /* TYPE_H_ */
