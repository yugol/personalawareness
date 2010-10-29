#include <Scanner.h>

using namespace std;

const char* Scanner::TYPE = "type";
const char Scanner::OPAREN = '(';
const char Scanner::LSTSEP = ',';
const char Scanner::CPAREN = ')';
const char Scanner::STMSEP = ';';

Scanner::Scanner(istream& in) :
	in_(in), line_(0), column_(0), hasCR_(false), hasLF_(false)
{
}

Scanner::~Scanner()
{
}

Token* Scanner::addToken(size_t line, size_t column)
{
	size_t pos = statement_.size();
	statement_.resize(pos + 1);
	Token& type = statement_[pos];
	type.setLine(line + 1);
	type.setColumn(column + 1);
	return &type;
}

void Scanner::finalizeToken(Token* token)
{
	if (token != 0) {
		if (token->content() == TYPE) {
			token->setType(Token::TYPE);
		} else {
			token->setType(Token::ID);
		}
	}
}

const vector<Token>& Scanner::next()
{
	statement_.clear();
	Token* token = 0;

	while (true) {
		int ch = in_.get();
		if (in_.good()) {

			if (ch == ' ' || ch == '\t') {
				finalizeToken(token);
				token = 0;
				++column_;
				continue;
			}

			if (ch == '\r') {
				finalizeToken(token);
				token = 0;
				hasCR_ = true;
				column_ = 0;
				++line_;
				continue;
			}

			if (ch == '\n') {
				hasLF_ = true;
				if (!hasCR_) {
					finalizeToken(token);
					token = 0;
					column_ = 0;
					++line_;
				}
				continue;
			}

			if (ch == OPAREN) {
				finalizeToken(token);
				token = addToken(line_, column_);
				token->setType(Token::OPAREN);
				token->content().append(1, ch);
				token = 0;
				++column_;
				continue;
			}

			if (ch == LSTSEP) {
				finalizeToken(token);
				token = addToken(line_, column_);
				token->setType(Token::LSTSEP);
				token->content().append(1, ch);
				token = 0;
				++column_;
				continue;
			}

			if (ch == CPAREN) {
				finalizeToken(token);
				token = addToken(line_, column_);
				token->setType(Token::CPAREN);
				token->content().append(1, ch);
				token = 0;
				++column_;
				continue;
			}

			if (ch == STMSEP) {
				finalizeToken(token);
				token = addToken(line_, column_);
				token->setType(Token::STMSEP);
				token->content().append(1, ch);
				token = 0;
				++column_;
				break;
			}

			if (token == 0) {
				token = addToken(line_, column_);
			}
			token->content().append(1, ch);
			++column_;

		} else {
			break;
		}
	}

	return statement_;
}

ostream& Scanner::writeStatement(ostream& out)
{
	out << endl;
	for (size_t i = 0; i < statement_.size(); ++i) {
		Token& token = statement_[i];
		out << token.content() << " \t(" << token.getLine() << ":" << token.getColumn() << ")-" << token.getType() << endl;
	}
	return out;
}

