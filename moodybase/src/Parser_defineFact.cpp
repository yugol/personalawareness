#include <constatnts.h>
#include <Statement.h>
#include <Memory.h>
#include <Parser.h>

using namespace std;

void Parser::defineFact(const Statement& stmt)
{
    size_t typeIdPos = 0;
    const string* newFactId = 0;
    if (stmt[1].getType() == DEFN) {
        const Token& first = stmt[0];
        newFactId = &(first.content());
        if (memory_->getFact(*newFactId)) {
            throwParseError("fact already defined", &first);
        }
        if (memory_->getType(*newFactId)) {
            throwParseError("already defined as type identifier", &first);
        }
        typeIdPos = 2;
    }
    Atom* newFact = defineFactRec(stmt, typeIdPos);
    if (newFactId) {
        memory_->nameFact(newFact, *newFactId);
    }
}

Atom* Parser::defineFactRec(const Statement& stmt, size_t typeIdPos)
{
    const Token& typeToken = stmt[typeIdPos];
    Type* type = memory_->getType(typeToken.content());
    if (!type) {
        throwParseError("type undefined", &typeToken);
    }
    Atom* atom = memory_->createAtom(type);
    if (!atom) {
        throwParseError("unable to create fact", &typeToken);
    }

    size_t symbolPos = typeIdPos + 1;
    const Token& symbolToken = stmt[symbolPos];
    if (symbolToken.getType() == OPAR) {
        size_t beginArgPos = symbolPos + 1;
        size_t endArgPos = stmt.getParMatch(symbolPos);
        bool identifyArgByPos = true;

    } else if (symbolToken.getType() != STMT) {
        throwParseError("unexpected token", &symbolToken);
    }

    return atom;
}
