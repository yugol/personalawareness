#ifndef ARITHMETICEXPRESSIONNODE_H_
#define ARITHMETICEXPRESSIONNODE_H_

class ArithmeticExpressionNode {
public:
	ArithmeticExpressionNode();
	virtual ~ArithmeticExpressionNode();

	int getPriority() const;
	ArithmeticExpressionNode* getParent() const;
	ArithmeticExpressionNode* getFirst() const;
	ArithmeticExpressionNode* getSecond() const;

	std::string& content();

	void setPriority(int);
	void setFirst(ArithmeticExpressionNode*);
	void setSecond(ArithmeticExpressionNode*);

	ArithmeticExpressionNode* getTopParent();
	double evaluate() const;
	void printPreorder() const;

private:
	int priority_;
	std::string content_;
	ArithmeticExpressionNode* parent_;
	ArithmeticExpressionNode* first_;
	ArithmeticExpressionNode* second_;
};

inline int ArithmeticExpressionNode::getPriority() const
{
	return priority_;
}

inline ArithmeticExpressionNode* ArithmeticExpressionNode::getParent() const
{
	return parent_;
}

inline ArithmeticExpressionNode* ArithmeticExpressionNode::getFirst() const
{
	return first_;
}

inline ArithmeticExpressionNode* ArithmeticExpressionNode::getSecond() const
{
	return second_;
}

inline std::string& ArithmeticExpressionNode::content()
{
	return content_;
}

#endif /* ARITHMETICEXPRESSIONNODE_H_ */
