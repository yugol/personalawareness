#include <Statement.h>
#include <Memory.h>
#include <Parser.h>

using namespace std;

static const size_t OPAR_INDEX = 2;

void Parser::defineType(const Statement& stmt)
{
    // create type
    const string& newTypeId = stmt[0].content();
    Type* newType = memory_->getType(newTypeId);
    if (memory_->isDefinible(newType)) {
        if (newType == 0) {
            newType = memory_->createType(newTypeId);
        }
    } else {
        throwParseError("type already defined", &(stmt[0]));
    }

    // create dependencies
    if (stmt.getParCount() != 1) {
        throwParseError("too many lists in type declaration - should be just one", &(stmt[0]));
    }
    size_t beginIdx = OPAR_INDEX + 1;
    size_t endIdx = stmt.getParMatch(OPAR_INDEX);
    for (size_t i = beginIdx; i < endIdx; ++i) {
        const Token& token = stmt[i];
        if ((i - OPAR_INDEX) % 2 == 1) {
            if (token.getType() != Token::ID) {
                throwParseError("misplaced in type declaration - should be type identifier", &token);
            }

            // TODO: cannot make a BOT
            const string& superTypeId = token.content();
            Type* superType = memory_->getType(superTypeId);
            if (superType == 0) {
                superType = memory_->createType(superTypeId);
            }
            if (memory_->isDerivable(superType)) {
                memory_->derive(newType, superType);
            } else {
                throwParseError("is not derivable", &token);
            }

        } else {
            if (token.getType() != Token::LSEP) {
                throwParseError("misplaced in type declaration - should be list separator", &token);
            }
        }
    }

    // read signature
}
