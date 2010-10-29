#include <sstream>
#include <Scanner.h>
#include "_test.h"

const char* simple = "\n"
	"type T;"
	"type A(D,G)\n"
	"	B , C c\n"
	"	;\n"
	"type E;"
	"A a,a',a'';";

TEST(simple, Scanner)
{
	const vector<Token>* statement = 0;
	istringstream in(simple);
	Scanner scanner(in);

	statement = &scanner.next();
	// scanner.writeStatement(cout);
	CHECK(3 == (statement->size()));

	statement = &scanner.next();
	// scanner.writeStatement(cout);
	CHECK(12 == (statement->size()));

	statement = &scanner.next();
	// scanner.writeStatement(cout);
	CHECK(3 == (statement->size()));

	statement = &scanner.next();
	// scanner.writeStatement(cout);
	CHECK(7 == (statement->size()));

	statement = &scanner.next();
	// scanner.writeStatement(cout);
	CHECK(0 == (statement->size()));

	statement = &scanner.next();
	// scanner.writeStatement(cout);
	CHECK(0 == (statement->size()));
}
