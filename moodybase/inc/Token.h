#ifndef TOKEN_H_
#define TOKEN_H_

#include <string>

class Token {
public:
	enum {
		ID, DEFN, OPAR, LSEP, CPAR, RULE, STMT, CMT
	};

	Token();
	~Token();

	int getType() const;
	const std::string& content() const;
	size_t getLine() const;
	size_t getColumn() const;

	void setType(int);
	std::string& content();
	void setLine(size_t);
	void setColumn(size_t);

private:
	int type_;
	std::string content_;
	size_t line_;
	size_t column_;
};

inline int Token::getType() const
{
	return type_;
}

inline const std::string& Token::content() const
{
	return content_;
}

inline size_t Token::getLine() const
{
	return line_;
}

inline size_t Token::getColumn() const
{
	return column_;
}

inline void Token::setType(int type)
{
	type_ = type;
}

inline std::string& Token::content()
{
	return content_;
}

inline void Token::setLine(size_t line)
{
	line_ = line;
}

inline void Token::setColumn(size_t column)
{
	column_ = column;
}

#endif /* TOKEN_H_ */
