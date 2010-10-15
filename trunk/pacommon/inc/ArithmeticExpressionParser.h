#ifndef ARITHMETICEXPRESSIONPARSER_H_
#define ARITHMETICEXPRESSIONPARSER_H_

#include <string>
#include <vector>
#include "Node.h"

class ArithmeticExpressionParser {
public:
	ArithmeticExpressionParser(const std::string& expression);
	virtual ~ArithmeticExpressionParser();

	double evaluate();

private:
	std::vector<Node> parseTree_;
	Node* root_;

	void tokenize(const std::string& expression);
	void parse();
};

#endif /* ARITHMETICEXPRESSIONPARSER_H_ */
