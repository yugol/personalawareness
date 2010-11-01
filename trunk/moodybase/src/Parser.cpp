#include <sstream>
#include <Exception.h>
#include <constatnts.h>
#include <Agent.h>
#include <Statement.h>
#include <Parser.h>

using namespace std;

Parser::Parser(Agent* agent) :
    agent_(agent), memory_(agent_->getMemory()), out_(agent_->getOut())
{
}

Parser::~Parser()
{
}

void Parser::parse(const Statement& stmt)
{
    if (!stmt.isComment()) {
        if (stmt.isGood()) {
            if (stmt.isCommand()) {
                const string& command = stmt[1].content();
                if (command == CMD_DOT) {
                    doDot(stmt);
                } else if (command == CMD_DOTTY) {
                    doDotty(stmt);
                } else if (command == CMD_LOAD) {
                    doLoad(stmt);
                } else if (command == CMD_STOP) {
                    doStop(stmt);
                } else {
                    throwParseError("unknown command", &(stmt[1]));
                }
            } else if (stmt.isTypeDef()) {
                defineType(stmt);
            } else {
                throwParseError("unrecognized statement", &(stmt[0]));
            }
        } else {
            if (!stmt.isComplete()) {
                throwParseError(
                        "incomplete statement - must end with '" TOK_STMT "' and have at least three tokens",
                        &(stmt[0]));
            }
            if (stmt.isMismatch()) {
                // TODO: find error token
                throwParseError("mismatched parentheses");
            }
        }
    }
}

void Parser::throwParseError(const char* message, const Token* token)
{
    ostringstream sout;
    if (token != 0) {
        sout << token->getLine() << ERR_SEP;
        sout << token->getColumn() << ERR_SEP << " error" << ERR_SEP << " '";
        sout << token->content() << "' ";
    }
    sout << message;
    throw Exception(sout.str().c_str());
}
