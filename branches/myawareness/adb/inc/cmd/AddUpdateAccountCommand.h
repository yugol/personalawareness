#ifndef ADDUPDATEACCOUNTCOMMAND_H_
#define ADDUPDATEACCOUNTCOMMAND_H_

#include <cmd/Command.h>

namespace adb {

class AddUpdateAccountCommand: public ReversibleCommand {
public:
	AddUpdateAccountCommand();
	virtual ~AddUpdateAccountCommand();
};

}

#endif /* ADDUPDATEACCOUNTCOMMAND_H_ */
