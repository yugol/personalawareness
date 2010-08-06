#ifndef COMMAND_H_
#define COMMAND_H_

namespace adb {

class Command {
public:
	virtual void execute() = 0;
};

} // namespace adb

#endif /* COMMAND_H_ */
