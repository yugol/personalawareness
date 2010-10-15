#include <ArithmeticExpressionParser.h>
#include "_test.h"

TEST(empty, ArithmeticExpressionParser)
{
	try {
		ArithmeticExpressionParser parser("");
		parser.evaluate();
		FAIL("should not be here");
	} catch (const exception& exc) {
	}
}

TEST(zero, ArithmeticExpressionParser)
{
	ArithmeticExpressionParser parser("0 .0");
	CHECK( 0 == parser.evaluate() );
}

TEST(Sop, ArithmeticExpressionParser)
{
	ArithmeticExpressionParser parser("-1");
	CHECK( -1 == parser.evaluate() );
}

TEST(SPSPop, ArithmeticExpressionParser)
{
	ArithmeticExpressionParser parser("-+-+1");
	CHECK( 1 == parser.evaluate() );
}

TEST(opPop, ArithmeticExpressionParser)
{
	ArithmeticExpressionParser parser("1 + 1");
	CHECK( 2 == parser.evaluate() );
}

TEST(SopPSop, ArithmeticExpressionParser)
{
	ArithmeticExpressionParser parser("-1 + -1");
	CHECK( -2 == parser.evaluate() );
}

TEST(opMop, ArithmeticExpressionParser)
{
	ArithmeticExpressionParser parser("1 * 1");
	CHECK( 1 == parser.evaluate() );
}

TEST(SopPop, ArithmeticExpressionParser)
{
	ArithmeticExpressionParser parser("- 2 * 3");
	CHECK( -6 == parser.evaluate() );
}

TEST(opPSop, ArithmeticExpressionParser)
{
	ArithmeticExpressionParser parser("2 * - 3");
	CHECK( -6 == parser.evaluate() );
}

TEST(opPopMop, ArithmeticExpressionParser)
{
	ArithmeticExpressionParser parser("2 + 3 * 4");
	CHECK( 14 == parser.evaluate() );
}

TEST(opMopPop, ArithmeticExpressionParser)
{
	ArithmeticExpressionParser parser("2 * 3 + 4");
	CHECK( 10 == parser.evaluate() );
}

TEST(opMopPopMop, ArithmeticExpressionParser)
{
	ArithmeticExpressionParser parser("2 * 3 + 4 * 5");
	CHECK( 26 == parser.evaluate() );
}

TEST(opPopMopPop, ArithmeticExpressionParser)
{
	ArithmeticExpressionParser parser("2 + 3 * 4 + 5");
	CHECK( 19 == parser.evaluate() );
}

TEST(opPopMopMop, ArithmeticExpressionParser)
{
	ArithmeticExpressionParser parser("2 + 3 * 4 * 5");
	CHECK( 62 == parser.evaluate() );
}

TEST(opPopMopMopPop, ArithmeticExpressionParser)
{
	ArithmeticExpressionParser parser("2 + 3 * 4 * 5 + 6");
	CHECK( 68 == parser.evaluate() );
}

TEST(opPopPopPopPop, ArithmeticExpressionParser)
{
	ArithmeticExpressionParser parser("2 + 3 + 4 + 5 + 6");
	CHECK( 20 == parser.evaluate() );
}

TEST(SSopSSSopDSSopMSSopPSSop, ArithmeticExpressionParser)
{
	ArithmeticExpressionParser parser("--2 - --10 / --5 * --2 + --2");
	CHECK( 0 == parser.evaluate() );
}
