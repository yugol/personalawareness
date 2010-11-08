#include <constatnts.h>
#include <Statement.h>

using namespace std;

Statement::Statement()
{
    flags_.mask_ = 0;
}

Statement::~Statement()
{
}

void Statement::clear()
{
    tokens_.clear();
    while (!parStack_.empty()) {
        parStack_.pop();
    }
    parMap_.clear();
    flags_.mask_ = 0;
}

Token* Statement::append(int line, int column)
{
    size_t oldLen = tokens_.size();
    tokens_.resize(oldLen + 1);
    Token* newToken = &(tokens_[oldLen]);
    newToken->setLine(line);
    newToken->setColumn(column);
    return newToken;
}

ostream& Statement::dump(ostream& out) const
{
    out << endl;
    for (size_t i = 0; i < tokens_.size(); ++i) {
        const Token& token = tokens_[i];
        out << token.content() << " \t(" << token.getLine() << ":" << token.getColumn() << ")-"
                << token.getType() << endl;
    }
    return out;
}

void Statement::setComment()
{
    flags_.isComment_ = true;
}

void Statement::pushPar()
{
    size_t oPos = tokens_.size() - 1;
    parStack_.push(oPos);
}

void Statement::popPar()
{
    if (parStack_.empty()) {
        flags_.isMismatch_ = true;
    } else {
        size_t oPos = parStack_.top();
        size_t cPos = tokens_.size() - 1;
        parMap_[oPos] = cPos;
        parStack_.pop();
    }
}

void Statement::preProcess()
{
    if (!flags_.isComment_) {
        size_t tokenCount = tokens_.size();
        if (tokenCount < 3) {
            flags_.isComplete_ = false;
        } else {
            flags_.isComplete_ = (tokens_[tokenCount - 1].getType() == STMT);
        }

        if (!parStack_.empty()) {
            flags_.isMismatch_ = true;
        }

        flags_.isGood_ = flags_.isComplete_ && !flags_.isMismatch_;

        if (flags_.isGood_) {
            int st = tokens_[0].getType();
            int nd = tokens_[1].getType();
            int rd = tokens_[2].getType();

            if (st == DEFN && nd == ID) {
                flags_.isCommand_ = true;
            } else if (st == ID) {
                if (nd == DEFN && rd == OPAR) {
                    flags_.isTypeDef_ = true;
                } else if (!flags_.isRuleDef_) {
                    flags_.isFactDef_ = true;
                }
            } else {
                flags_.isUnknown_ = true;
                flags_.isGood_ = false;
            }
        }
    }
}

