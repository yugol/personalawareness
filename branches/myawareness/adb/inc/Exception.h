#ifndef EXCEPTION_H_
#define EXCEPTION_H_

#include <exception>
#include <string>

namespace adb {

class Exception: public std::exception {

public:
	Exception();
	Exception(const char* message);
	virtual ~Exception() throw ();
	virtual const char* what() const throw ();

private:
	std::string message_;
};

inline const char* Exception::what() const throw ()
{
	return message_.c_str();
}

}

#endif /* EXCEPTION_H_ */
