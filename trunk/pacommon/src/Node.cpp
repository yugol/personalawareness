#include <cstdlib>
#include <iostream>
#include <Exception.h>
#include <Node.h>

using namespace std;

Node::Node() :
	priority_(-1), parent_(0), first_(0), second_(0)
{
}

Node::~Node()
{
}

void Node::setPriority(int value)
{
	priority_ = value;
}

void Node::setFirst(Node* node)
{
	first_ = node;
	node->parent_ = this;
}

void Node::setSecond(Node* node)
{
	second_ = node;
	node->parent_ = this;
}

Node* Node::getTopParent()
{
	Node* tmpParent = this;
	while (tmpParent->parent_ != 0) {
		tmpParent = tmpParent->parent_;
	}
	return tmpParent;
}

double Node::evaluate() const
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
				THROW("invalid expression: unknown operator");
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
				THROW("invalid expression: unknown operator");
				break;
		}
	}
}

void Node::printPreorder() const
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
