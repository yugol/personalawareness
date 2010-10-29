#ifndef ATOM_H_
#define ATOM_H_

#include <string>
#include <vector>

class Type;

class Atom {
public:
	Atom(const Type* type);
	~Atom();

private:
	const Type* type_;
	Atom** args_;
	std::vector<Atom*> refs_;
	std::string content_;
};

#endif /* ATOM_H_ */
