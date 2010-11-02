#include <sstream>
#include <constatnts.h>
#include <Type.h>
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
    size_t beginIdx = OPAR_INDEX + 1;
    size_t endIdx = stmt.getParMatch(OPAR_INDEX);
    for (size_t i = beginIdx; i < endIdx; ++i) {
        const Token& token = stmt[i];
        if ((i - OPAR_INDEX) % 2 == 1) {
            if (token.getType() != ID) {
                throwParseError("misplaced in type declaration - should be type identifier", &token);
            }

            const string& superTypeId = token.content();
            Type* superType = memory_->getType(superTypeId);
            if (superType == 0) {
                superType = memory_->createType(superTypeId);
            }
            if (memory_->isDerivable(superType)) {
                try {
                    memory_->derive(newType, superType);
                } catch (const exception& ex) {
                    throwParseError(ex.what(), &token);
                }
            } else {
                throwParseError("is not derivable", &token);
            }

        } else {
            if (token.getType() != LSEP) {
                throwParseError("misplaced in type declaration - should be '" TOK_LSEP "'", &token);
            }
        }
    }

    // read signature
    if (endIdx < stmt.size() - 2) {

        const string* nameId = 0;
        bool defn = false;
        const string* typeId = 0;

        size_t i = endIdx;
        while (i < stmt.size() - 1) {
            ++i;
            const Token& token = stmt[i];
            if (token.getType() == ID) {
                if (nameId == 0) {
                    nameId = &(token.content());
                    continue;
                }
                if (defn && typeId == 0) {
                    typeId = &(token.content());
                    continue;
                }
            }
            if (token.getType() == DEFN) {
                if (nameId != 0 && typeId == 0) {
                    defn = true;
                    continue;
                }
            }
            if (token.getType() == LSEP || token.getType() == STMT) {
                if (nameId == 0) {
                    throwParseError("slot name expected", &token);
                }
                if (typeId == 0) {
                    throwParseError("type name expected", &token);
                }

                // TODO: what happens when TYPE is BOT
                Type* type = memory_->getType(*typeId);
                if (type == 0) {
                    type = memory_->createType(*typeId);
                }
                newType->addSlot((*nameId), type);

                nameId = 0;
                defn = false;
                typeId = 0;
                continue;
            }
            throwParseError("misplaced in type definition", &token);
        }

        if (defn || nameId != 0) {
            throwParseError("incomplete definition - type name expected", &stmt[i]);
        }
    }
}
