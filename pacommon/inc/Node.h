#ifndef NODE_H_
#define NODE_H_

class Node {
public:
	Node();
	virtual ~Node();

	int getPriority() const;
	Node* getParent() const;
	Node* getFirst() const;
	Node* getSecond() const;

	std::string& content();

	void setPriority(int);
	void setFirst(Node*);
	void setSecond(Node*);

	Node* getTopParent();
	double evaluate() const;
	void printPreorder() const;

private:
	int priority_;
	std::string content_;
	Node* parent_;
	Node* first_;
	Node* second_;
};

inline int Node::getPriority() const
{
	return priority_;
}

inline Node* Node::getParent() const
{
	return parent_;
}

inline Node* Node::getFirst() const
{
	return first_;
}

inline Node* Node::getSecond() const
{
	return second_;
}

inline std::string& Node::content()
{
	return content_;
}

#endif /* NODE_H_ */
