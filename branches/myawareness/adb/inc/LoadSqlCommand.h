#ifndef LOADSQLCOMMAND_H_
#define LOADSQLCOMMAND_H_

#include "Command.h"

namespace adb {

    class LoadSqlCommand: public Command {
    public:
        LoadSqlCommand();

        int getLineNo() const;
        void setLineNo(int lineNo);

    private:
        int lineNo_;
    };

    inline LoadSqlCommand::LoadSqlCommand() :
        lineNo_(0)
    {
    }

    inline int LoadSqlCommand::getLineNo() const
    {
        return lineNo_;
    }

    inline void LoadSqlCommand::setLineNo(int lineNo)
    {
        lineNo_ = lineNo;
    }

} // namespace adb

#endif /* LOADSQLCOMMAND_H_ */
