#include <TypeHierarchy.h>
#include "_test.h"

/*
TEST(simpleDerivation, TypeHierarchy)
{
	TypeHierarchy th;

	th.createDerivedType("ORPHAN");
	th.createDerivedType("ONE_PARENT : MOTHER");
	th.createDerivedType("TWO_PARENTS: MOTHER, FATHER");

	CHECK(th["ONE_PARENT"]->isA(th["ONE_PARENT"]));
	CHECK(th["ONE_PARENT"]->isA(th["MOTHER"]));
	CHECK(!th["MOTHER"]->isA(th["FATEHR"]));

	//th.dump(cout);
	//th.exportGraphviz(cout);
}

TEST(circularDerivation, TypeHierarchy)
{
	try {
		TypeHierarchy th;
		th.createDerivedType("A : B");
		th.createDerivedType("B : C");
		th.createDerivedType("C : A");
		th.dump(cout);
		FAIL("should throw 'circular derivation'");
	} catch (exception& ex) {
	}
}

TEST(redundantDerivation, TypeHierarchy)
{
	TypeHierarchy th;
	th.createDerivedType("C : A");
	th.createDerivedType("B : A");
	th.createDerivedType("C : B");
	th.createDerivedType("C : A");
	// th.exportGraphviz(cout);
}

TEST(diamondDerivation, TypeHierarchy)
{
	TypeHierarchy th;
	th.createDerivedType("C : A");
	th.createDerivedType("B : A");
	th.createDerivedType("D : C");
	th.createDerivedType("D : B");
	// th.exportGraphviz(cout);
}

*/
