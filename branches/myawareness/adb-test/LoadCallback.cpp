#include <iostream>
#include "LoadCallback.h"

using namespace std;

void LoadCallback::execute()
{
	cout << getLineNo() << endl;
}
