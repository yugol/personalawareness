#include <cstdlib>
#include <iostream>
#include <Exception.h>
#include <ArithmeticExpressionNode.h>

using namespace std;

ArithmeticExpressionNode::ArithmeticExpressionNode() :
	priority_(-1), parent_(0), first_(0), second_(0)
{
}

ArithmeticExpressionNode::~ArithmeticExpressionNode()
{
}

void ArithmeticExpressionNode::setPriority(int value)
{
	priority_ = value;
}

void ArithmeticExpressionNode::setFirst(ArithmeticExpressionNode* node)
{
	if (node == 0) {
		THROW(Exception::EMSG_NO_FIRST_OPERAND);
	}
	first_ = node;
	node->parent_ = this;
}

void ArithmeticExpressionNode::setSecond(ArithmeticExpressionNode* node)
{
	if (node == 0) {
		THROW(Exception::EMSG_NO_SECOND_OPERAND);
	}
	second_ = node;
	node->parent_ = this;
}

ArithmeticExpressionNode* ArithmeticExpressionNode::getTopParent()
{
	ArithmeticExpressionNode* tmpParent = this;
	while (tmpParent->parent_ != 0) {
		tmpParent = tmpParent->parent_;
	}
	return tmpParent;
}

double ArithmeticExpressionNode::evaluate() const
{
	if (first_ == 0) {
		return atof(content_.c_str());
	} else if (second_ == 0) {
		double leftVal = first_->evaluate();

		switch (content_[0]) {
			case '+':
				return leftVal;
			case '-':
				return (-leftVal);
			default:
				THROW(Exception::EMSG_UNKNOWN_OPERATOR);
				break;
		}
	} else {
		double leftVal = first_->evaluate();
		double rightVal = second_->evaluate();

		switch (content_[0]) {
			case '+':
				return leftVal + rightVal;
			case '-':
				return leftVal - rightVal;
			case '*':
				return leftVal * rightVal;
			case '/':
				return leftVal / rightVal;
			default:
				THROW(Exception::EMSG_UNKNOWN_OPERATOR);
				break;
		}
	}
}

void ArithmeticExpressionNode::printPreorder() const
{
	cout << "(";
	cout << content_;
	if (first_ != 0) {
		cout << " ";
		first_->printPreorder();
	}
	if (second_ != 0) {
		cout << " ";
		second_->printPreorder();
	}
	cout << ")";
}
