#ifndef LOADSQLCALLBACK_H_
#define LOADSQLCALLBACK_H_

namespace adb {

class LoadSqlCallback {

public:
	virtual void execute(int current) = 0;

};

} // namespace adb


#endif /* LOADSQLCALLBACK_H_ */
