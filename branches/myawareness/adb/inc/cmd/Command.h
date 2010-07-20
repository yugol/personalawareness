#ifndef COMMAND_H_
#define COMMAND_H_

#include <string>

namespace adb {

class Command {
public:
	virtual void execute() = 0;
};

class ReversibleCommand: public Command {
public:
	virtual void unexecute() = 0;
};

} // namespace adb

#endif /* COMMAND_H_ */
