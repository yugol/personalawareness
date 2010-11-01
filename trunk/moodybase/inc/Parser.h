#ifndef PARSER_H_
#define PARSER_H_

#include <iostream>

class Token;
class Statement;
class Agent;
class Memory;

class Parser {
public:
    Parser(Agent* agent);
    ~Parser();

    void parse(const Statement& stmt);

private:
    Agent* agent_;
    Memory* memory_;
    std::ostream& out_;

    void throwParseError(const char* message, const Token* token = 0);

    void defineType(const Statement& stmt);

    void doDot(const Statement& stmt);
    void doDotty(const Statement& stmt);
    void doLoad(const Statement& stmt);
    void doStop(const Statement& stmt);
};

#endif /* PARSER_H_ */
