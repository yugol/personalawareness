#ifndef LOADCALLBACK_H_
#define LOADCALLBACK_H_

#include <LoadSqlCallback.h>

class LoadCallback: public adb::LoadSqlCallback {

public:
	void execute(int current);

};

#endif /* LOADCALLBACK_H_ */
