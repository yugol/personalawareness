#ifndef SCANNER_H_
#define SCANNER_H_

#include <string>
#include <vector>
#include <iostream>

#include "Token.h"

class Scanner {
public:
	static const char* TYPE;
	static const char OPAREN;
	static const char CPAREN;
	static const char STMSEP;
	static const char LSTSEP;

	Scanner(std::istream& in);
	~Scanner();

	const std::vector<Token>& next();
	std::ostream& writeStatement(std::ostream& out);

private:
	std::istream& in_;
	size_t line_;
	size_t column_;
	std::vector<Token> statement_;
	bool hasCR_;
	bool hasLF_;

	Token* addToken(size_t line, size_t column);
	void finalizeToken(Token*);
};

#endif /* SCANNER_H_ */
