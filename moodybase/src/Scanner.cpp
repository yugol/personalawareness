#include <Agent.h>
#include <Scanner.h>

using namespace std;

const char DEFN = ':';
const char OPAR = '(';
const char LSEP = ',';
const char CPAR = ')';
const char STMT = ';';
const char CMT = '@';

Scanner::Scanner(Agent* agent) :
    agent_(agent), in_(agent_->getIn()), hasCR_(false), hasLF_(false), line_(1), column_(1)
{
}

Scanner::~Scanner()
{
}

const Statement& Scanner::next()
{
    if (agent_->isInteractive()) {
        if (statement_.size() > 0) {
            line_ = 0;
        } else {
            line_ = 1;
        }
        column_ = 1;
    }
    statement_.clear();
    Token* token = 0;

    while (true) {
        int ch = in_.get();
        if (in_.good()) {

            if (ch == ' ' || ch == '\t') {
                token = 0;
                ++column_;
                continue;
            }

            if (ch == '\r') {
                token = 0;
                hasCR_ = true;
                column_ = 1;
                ++line_;
                continue;
            }

            if (ch == '\n') {
                hasLF_ = true;
                if (!hasCR_) {
                    token = 0;
                    column_ = 1;
                    ++line_;
                }
                continue;
            }

            if (ch == CMT) {
                token = statement_.append(line_, column_);
                token->setType(Token::CMT);
                token->content().append(1, ch);
                statement_.setComment();
                token = 0;
                ++column_;
                continue;
            }

            if (ch == DEFN) {
                token = statement_.append(line_, column_);
                token->setType(Token::DEFN);
                token->content().append(1, ch);
                token = 0;
                ++column_;
                continue;
            }

            if (ch == OPAR) {
                token = statement_.append(line_, column_);
                token->setType(Token::OPAR);
                token->content().append(1, ch);
                statement_.pushPar();
                token = 0;
                ++column_;
                continue;
            }

            if (ch == LSEP) {
                token = statement_.append(line_, column_);
                token->setType(Token::LSEP);
                token->content().append(1, ch);
                token = 0;
                ++column_;
                continue;
            }

            if (ch == CPAR) {
                token = statement_.append(line_, column_);
                token->setType(Token::CPAR);
                token->content().append(1, ch);
                statement_.popPar();
                token = 0;
                ++column_;
                continue;
            }

            if (ch == STMT) {
                token = statement_.append(line_, column_);
                token->setType(Token::STMT);
                token->content().append(1, ch);
                token = 0;
                ++column_;
                break;
            }

            if (token == 0) {
                token = statement_.append(line_, column_);
            }
            token->content().append(1, ch);
            ++column_;

        } else {
            break;
        }
    }

    statement_.preProcess();
    return statement_;
}

