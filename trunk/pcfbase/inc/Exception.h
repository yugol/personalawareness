#ifndef EXCEPTION_H_
#define EXCEPTION_H_

#include <exception>
#include <string>

class Exception: public std::exception {

public:
    static const char EMSG_NO_DATABASE[];
    static const char EMSG_SQL_ERROR[];
    static const char EMSG_NO_RECORD[];
    static const char EMSG_WRONG_NAME[];
    static const char EMSG_WRONG_VALUE[];
    static const char EMSG_UNDEFINED[];
    static const char EMSG_RECORD_IN_USE[];

    Exception();
    Exception(const char* message);
    Exception(const char* message, const char* fileName, int lineNo);
    Exception(const exception& ex, const char* fileName, int lineNo);
    virtual ~Exception() throw ();
    virtual const char* what() const throw ();

private:
    std::string message_;
};

inline const char* Exception::what() const throw ()
{
    return message_.c_str();
}

#define THROW( message ) throw Exception((message), __FILE__, __LINE__)
#define RETHROW( ex ) throw Exception((ex), __FILE__, __LINE__)

#endif /* EXCEPTION_H_ */
