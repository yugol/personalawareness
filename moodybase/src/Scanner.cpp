#include <constatnts.h>
#include <Agent.h>
#include <Scanner.h>

using namespace std;

const char DEFN_SYMB = string(TOK_DEFN)[0];
const char OPAR_SYMB = string(TOK_OPAR)[0];
const char LSEP_SYMB = string(TOK_LSEP)[0];
const char CPAR_SYMB = string(TOK_CPAR)[0];
const char STMT_SYMB = string(TOK_STMT)[0];
const char CMT_SYMB = string(TOK_CMT)[0];

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

            if (ch == CMT_SYMB) {
                token = statement_.append(line_, column_);
                token->setType(CMT);
                token->content().append(1, ch);
                statement_.setComment();
                token = 0;
                ++column_;
                continue;
            }

            if (ch == DEFN_SYMB) {
                token = statement_.append(line_, column_);
                token->setType(DEFN);
                token->content().append(1, ch);
                token = 0;
                ++column_;
                continue;
            }

            if (ch == OPAR_SYMB) {
                token = statement_.append(line_, column_);
                token->setType(OPAR);
                token->content().append(1, ch);
                statement_.pushPar();
                token = 0;
                ++column_;
                continue;
            }

            if (ch == LSEP_SYMB) {
                token = statement_.append(line_, column_);
                token->setType(LSEP);
                token->content().append(1, ch);
                token = 0;
                ++column_;
                continue;
            }

            if (ch == CPAR_SYMB) {
                token = statement_.append(line_, column_);
                token->setType(CPAR);
                token->content().append(1, ch);
                statement_.popPar();
                token = 0;
                ++column_;
                continue;
            }

            if (ch == STMT_SYMB) {
                token = statement_.append(line_, column_);
                token->setType(STMT);
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

