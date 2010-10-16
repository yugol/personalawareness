#ifndef EXCEPTION_H_
#define EXCEPTION_H_

#include <exception>
#include <string>

class Exception: public std::exception {

public:
	static const char EMSG_EMPTY_EXPRESSION[];
	static const char EMSG_UNKNOWN_PRIORITY[];
	static const char EMSG_UNKNOWN_OPERATOR[];
	static const char EMSG_NO_OPERATOR[];
	static const char EMSG_NO_FIRST_OPERAND[];
	static const char EMSG_NO_SECOND_OPERAND[];

	Exception();
	Exception(const char* message);
	Exception(const char* message, const char* fileName, int lineNo);
	Exception(const exception& ex, const char* fileName, int lineNo);
	virtual ~Exception() throw ();

	virtual const char* what() const throw ();

private:
	std::string what_;
};

inline const char* Exception::what() const throw ()
{
	return what_.c_str();
}

#define THROW( message ) throw Exception((message), __FILE__, __LINE__)
#define RETHROW( ex ) throw Exception((ex), __FILE__, __LINE__)

#endif /* EXCEPTION_H_ */
