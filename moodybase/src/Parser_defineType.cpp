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
    // TODO: check newTypeId not to already be defined as a Type or Fact or Rule
    Type* newType = memory_->getType(newTypeId);
    if (memory_->isDefinible(newType)) {
        if (newType == 0) {
            newType = memory_->createType(newTypeId);
        }
    } else {
        throwParseError("type already defined", &(stmt[0]));
    }

    // create dependencies
    size_t derivationListBeginIdx = OPAR_INDEX + 1;
    size_t derivationListEndIdx = stmt.getParMatch(OPAR_INDEX);
    for (size_t i = derivationListBeginIdx; i < derivationListEndIdx; ++i) {
        const Token& token = stmt[i];
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
    }

    // read signature
    size_t definitionBeginIdx = derivationListEndIdx + 1;
    if (definitionBeginIdx < stmt.size() - 1) {

        const string* nameId = 0;
        bool defn = false;

        size_t i = definitionBeginIdx;
        while (i < stmt.size() - 1) {
            const Token& token = stmt[i];
            if (token.getType() == ID) {
                if (!nameId) {
                    nameId = &(token.content());
                    if (newType->getSlot(*nameId)) {
                        throwParseError("already used as a slot identifier", &token);
                    }
                } else {
                    if (!defn) {
                        throwParseError("instead of '" TOK_DEFN "'", &token);
                    }

                    const string& typeId = token.content();
                    Type* type = memory_->getType(typeId);
                    if (type == 0) {
                        type = memory_->createType(typeId);
                    }
                    newType->addSlot(*nameId, type);

                    nameId = 0;
                    defn = false;
                }
            } else if (token.getType() == DEFN) {
                if (!nameId) {
                    throwParseError("instead of slot identifier", &token);
                }
                defn = true;
            } else {
                throwParseError("misplaced in type definition", &token);
            }
            ++i;
        }

        if (nameId || defn) {
            throwParseError("type identifier expected", &stmt[i]);
        }
    }
}
