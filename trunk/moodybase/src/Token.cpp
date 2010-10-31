#include <Token.h>

using namespace std;

Token::Token() :
	type_(ID), line_(-1), column_(-1)
{
}

Token::~Token()
{
}
