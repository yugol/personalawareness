#ifndef AGENT_H_
#define AGENT_H_

#include <iostream>
#include "Scanner.h"
#include "Parser.h"

class Memory;

class Agent {
public:
    Agent(std::istream& in, std::ostream& out, std::ostream& err);
    Agent(Memory* memory, std::istream& in, std::ostream& out, std::ostream& err);
    virtual ~Agent();

    bool isInteractive();
    void setInteractive();
    void start();
    virtual void stop();

    Memory* getMemory();
    std::istream& getIn();
    std::ostream& getOut();
    std::ostream& getErr();

private:
    std::istream& in_;
    std::ostream& out_;
    std::ostream& err_;
    Memory* memory_;
    Scanner scanner_;
    Parser parser_;
    bool ownMemory_;
    bool isRunning_;
    bool isInteractive_;
};

inline bool Agent::isInteractive()
{
    return isInteractive_;
}

inline Memory* Agent::getMemory()
{
    return memory_;
}

inline std::istream& Agent::getIn()
{
    return in_;
}

inline std::ostream& Agent::getOut()
{
    return out_;
}

inline std::ostream& Agent::getErr()
{
    return err_;
}

#endif /* AGENT_H_ */
