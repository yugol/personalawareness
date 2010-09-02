#ifndef EXCEPTION_H_
#define EXCEPTION_H_

#include <exception>
#include <string>

namespace adb {

    class Exception: public std::exception {

    public:
        static const char NO_DATABASE_MESSAGE[];
        static const char SQL_ERROR_MESSAGE[];
        static const char NO_RECORD_MESSAGE[];
        static const char WRONG_NAME_MESSAGE[];
        static const char WRONG_VALUE_MESSAGE[];
        static const char UNDEFINED_MESSAGE[];
        static const char RECORD_IN_USE[];

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

} // namespace adb

#endif /* EXCEPTION_H_ */
