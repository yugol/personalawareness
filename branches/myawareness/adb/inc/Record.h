#ifndef RECORD_H_
#define RECORD_H_

#include <string>

namespace adb {

    class Record {
    public:
        static void assign(std::string& str, const char* cstr);

        Record(int id);
        virtual ~Record();

        int getId() const;

        void setId(int id);

        virtual void validate() const = 0;

    protected:
        int id_;
    };

    inline int Record::getId() const
    {
        return id_;
    }

} // namespace adb

#endif /* RECORD_H_ */
