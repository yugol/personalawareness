#ifndef SIGNATURE_H_
#define SIGNATURE_H_

#include <string>
#include <vector>

class Type;

class Signature {
public:
	Signature();
	~Signature();

private:
	std::vector<Type*> types_;
	std::vector<std::string> names_;
};

#endif /* SIGNATURE_H_ */
