#ifndef GETMETADATA_H_
#define GETMETADATA_H_

#include <DatabaseCommand.h>

class GetMetadata: public DatabaseCommand {
public:
    GetMetadata(sqlite3* database);

    virtual void execute();

    bool isEmpty() const;
    int getTableCount() const;

protected:
    virtual void buildSqlCommand();

private:
    int tableCount_;
};

inline int GetMetadata::getTableCount() const
{
    return tableCount_;
}

inline bool GetMetadata::isEmpty() const
{
    return (tableCount_ <= 1);
}

#endif /* GETMETADATA_H_ */
