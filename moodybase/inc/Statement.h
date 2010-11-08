#ifndef STATEMENT_H_
#define STATEMENT_H_

#include <ostream>
#include <vector>
#include <stack>
#include <map>
#include <Token.h>

class Statement {
public:
    Statement();
    ~Statement();

    bool isGood() const;
    bool isComplete() const;
    bool isMismatch() const;
    bool isUnknown() const;

    bool isComment() const;
    bool isTypeDef() const;
    bool isAtomDef() const;
    bool isFactDef() const;
    bool isRuleDef() const;
    bool isCommand() const;

    size_t size() const;
    const Token& operator[](size_t index) const;
    const size_t getParMatch(size_t oparIdx) const;

    void clear();
    Token* append(int line, int column);
    void setComment();
    void pushPar();
    void popPar();
    void preProcess();

    std::ostream& dump(std::ostream& out) const;

private:
    std::vector<Token> tokens_;
    std::stack<size_t> parStack_;
    std::map<size_t, size_t> parMap_;

    union {
        unsigned mask_;
        struct {
            unsigned isGood_ :1;
            unsigned isComplete_ :1;
            unsigned isMismatch_ :1;
            unsigned isUnknown_ :1;

            unsigned isComment_ :1;
            unsigned isTypeDef_ :1;
            unsigned isFactDef_ :1;
            unsigned isRuleDef_ :1;
            unsigned isCommand_ :1;
        };
    } flags_;
};

inline size_t Statement::size() const
{
    return tokens_.size();
}

inline const Token& Statement::operator[](size_t index) const
{
    return tokens_[index];
}

inline const size_t Statement::getParMatch(size_t oparIdx) const
{
    return (parMap_.find(oparIdx)->second);
}

inline bool Statement::isGood() const
{
    return flags_.isGood_;
}

inline bool Statement::isComplete() const
{
    return flags_.isComplete_;
}

inline bool Statement::isMismatch() const
{
    return flags_.isMismatch_;
}

inline bool Statement::isUnknown() const
{
    return flags_.isUnknown_;
}

inline bool Statement::isTypeDef() const
{
    return flags_.isTypeDef_;
}

inline bool Statement::isFactDef() const
{
    return flags_.isFactDef_;
}

inline bool Statement::isRuleDef() const
{
    return flags_.isRuleDef_;
}

inline bool Statement::isCommand() const
{
    return flags_.isCommand_;
}

inline bool Statement::isComment() const
{
    return flags_.isComment_;
}

#endif /* STATEMENT_H_ */
