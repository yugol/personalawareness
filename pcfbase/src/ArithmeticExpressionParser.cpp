#include <Exception.h>
#include <ArithmeticExpressionParser.h>

using namespace std;

ArithmeticExpressionParser::ArithmeticExpressionParser(const string& expression) :
	root_(0)
{
	tokenize(expression);
	parse();
}

ArithmeticExpressionParser::~ArithmeticExpressionParser()
{
}

double ArithmeticExpressionParser::evaluate()
{
	// root_->printPreorder();
	return root_->evaluate();
}

void ArithmeticExpressionParser::tokenize(const string& expression)
{
	ArithmeticExpressionNode* node = 0;
	for (size_t i = 0; i < expression.size(); ++i) {
		char ch = expression[i];
		if (('0' <= ch && ch <= '9') || ch == '.') {
			if (node == 0) {
				parseTree_.resize(parseTree_.size() + 1);
				node = &(parseTree_[parseTree_.size() - 1]);
				node->setPriority(0);
			}
			node->content().append(1, ch);
		} else if (ch == '+' || ch == '-') {
			parseTree_.resize(parseTree_.size() + 1);
			node = &(parseTree_[parseTree_.size() - 1]);
			node->setPriority(1);
			node->content().append(1, ch);
			node = 0;
		} else if (ch == '*' || ch == '/') {
			parseTree_.resize(parseTree_.size() + 1);
			node = &(parseTree_[parseTree_.size() - 1]);
			node->setPriority(2);
			node->content().append(1, ch);
			node = 0;
		}
	}
}

void ArithmeticExpressionParser::parse()
{
	bool changeSign = false;
	for (unsigned i = parseTree_.size() - 1; i < parseTree_.size(); --i) {
		switch (parseTree_[i].getPriority()) {
			case 0:
				changeSign = true;
				break;
			case 1:
				if (changeSign) {
					parseTree_[i].setFirst(&(parseTree_[i + 1]));
				}
				break;
			case 2:
				changeSign = false;
				break;
		}
	}

	ArithmeticExpressionNode* root = 0;
	ArithmeticExpressionNode* node = 0;

	for (size_t i = 0; i < parseTree_.size(); ++i) {

		node = &(parseTree_[i]);
		if (node->getParent() != 0) {
			continue;
		}

		switch (node->getPriority()) {
			case 0:
				if (root == 0) {
					root = node;
				} else {
					if (root->getSecond() == 0) {
						root->setSecond(node);
					} else {
						THROW(Exception::EMSG_NO_OPERATOR);
					}
				}
				break;

			case 1:
				if (root == 0) {
					root = node;
				} else {
					switch (root->getPriority()) {
						case 0:
							node->setSecond(node->getFirst());
							node->setFirst(root);
							root = node;
							break;
						case 1:
							if (root->getFirst() == 0) {
								THROW(Exception::EMSG_NO_FIRST_OPERAND);
							} else {
								node->setSecond(node->getFirst());
								node->setFirst(root);
								root = node;
							}
							break;
						case 2:
							if (root->getFirst() == 0) {
								THROW(Exception::EMSG_NO_FIRST_OPERAND);
							} else if (root->getSecond() == 0) {
								root->setSecond(node);
							} else {
								root = root->getTopParent();
								node->setSecond(node->getFirst());
								node->setFirst(root);
								root = node;
							}
							break;
					}
				}
				break;

			case 2:
				if (root == 0) {
					THROW(Exception::EMSG_NO_FIRST_OPERAND);
				} else {
					switch (root->getPriority()) {
						case 0:
							node->setFirst(root);
							root = node;
							break;
						case 1:
							if (root->getFirst() == 0) {
								THROW(Exception::EMSG_NO_FIRST_OPERAND);
							}
							if (root->getSecond() == 0) {
								node->setFirst(root);
								root = node;
							} else {
								node->setFirst(root->getSecond());
								root->setSecond(node);
								root = node;
							}
							break;
						case 2:
							if (root->getFirst() == 0) {
								THROW(Exception::EMSG_NO_FIRST_OPERAND);
							} else if (root->getSecond() == 0) {
								THROW(Exception::EMSG_NO_SECOND_OPERAND);
							} else {
								if (root->getParent() != 0) {
									root->getParent()->setSecond(node);
								}
								node->setFirst(root);
								root = node;
							}
							break;
					}
				}
				break;

			default:
				THROW(Exception::EMSG_UNKNOWN_PRIORITY);
		}
	}

	if (root == 0) {
		root_ = 0;
	} else {
		root_ = root->getTopParent();
	}

	if (root_ == 0) {
		THROW(Exception::EMSG_EMPTY_EXPRESSION);
	}
	if (root_->getPriority() >= 1 && root_->getFirst() == 0) {
		THROW(Exception::EMSG_NO_FIRST_OPERAND);
	}
	if (root_->getPriority() >= 2 && root_->getSecond() == 0) {
		THROW(Exception::EMSG_NO_SECOND_OPERAND);
	}
}

