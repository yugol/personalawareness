#ifndef AGENT_H_
#define AGENT_H_

#include <iostream>
#include <Scanner.h>
#include <Parser.h>

class Memory;

class Agent {
public:
    Agent(std::istream& in, std::ostream& out, std::ostream& err);
    Agent(Memory* memory, std::istream& in, std::ostream& out, std::ostream& err);
    virtual ~Agent();

    const std::string& getId() const;
    std::istream& getIn() const;
    std::ostream& getOut() const;
    std::ostream& getErr() const;
    Memory* getMemory() const;
    bool isInteractive() const;
    bool isStopOnError() const;
    const std::string& getInputId() const;

    void setId(const std::string& id);
    void setInteractive(bool);
    void setStopOnError(bool);
    void setInputId(const std::string& inputId);

    void start();
    void stop();

private:
    std::string id_;
    std::istream& in_;
    std::ostream& out_;
    std::ostream& err_;
    Memory* memory_;
    Scanner scanner_;
    Parser parser_;
    bool hasOwnMemory_;
    bool running_;
    bool interactive_;
    bool stopOnError_;
    std::string inputId_;
};

inline const std::string& Agent::getId() const
{
    return id_;
}

inline std::istream& Agent::getIn() const
{
    return in_;
}

inline std::ostream& Agent::getOut() const
{
    return out_;
}

inline std::ostream& Agent::getErr() const
{
    return err_;
}

inline Memory* Agent::getMemory() const
{
    return memory_;
}

inline bool Agent::isInteractive() const
{
    return interactive_;
}

inline bool Agent::isStopOnError() const
{
    return stopOnError_;
}

inline const std::string& Agent::getInputId() const
{
    return inputId_;
}

#endif /* AGENT_H_ */
