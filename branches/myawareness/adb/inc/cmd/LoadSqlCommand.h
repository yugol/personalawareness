#ifndef LOADSQLCOMMAND_H_
#define LOADSQLCOMMAND_H_

#include <cmd/Command.h>

namespace adb {

class LoadSqlCommand: public Command {
public:
	LoadSqlCommand();
	virtual ~LoadSqlCommand();

	int getLineNo() const;
	void setLineNo(int lineNo);

private:
	int lineNo_;
};

inline int LoadSqlCommand::getLineNo() const
{
	return lineNo_;
}

inline void LoadSqlCommand::setLineNo(int lineNo)
{
	lineNo_ = lineNo;
}

}

#endif /* LOADSQLCOMMAND_H_ */
