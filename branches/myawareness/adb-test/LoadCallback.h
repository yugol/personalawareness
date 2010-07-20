#ifndef LOADCALLBACK_H_
#define LOADCALLBACK_H_

#include <cmd/LoadSqlCommand.h>

class LoadCallback: public adb::LoadSqlCommand {

public:
	void execute();

};

#endif /* LOADCALLBACK_H_ */
