#ifndef SCANNER_H_
#define SCANNER_H_

#include <istream>
#include <Statement.h>

class Agent;

class Scanner {
public:
    Scanner(Agent* agent);
    ~Scanner();

    const Statement& next();

private:
    Agent* agent_;
    std::istream& in_;
    Statement statement_;
    bool hasCR_;
    bool hasLF_;
    size_t line_;
    size_t column_;
};

#endif /* SCANNER_H_ */
