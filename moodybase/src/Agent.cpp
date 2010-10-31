#include <Exception.h>
#include <Memory.h>
#include <Agent.h>

using namespace std;

Agent::Agent(istream& in, ostream& out, ostream& err) :
    in_(in), out_(out), err_(err), memory_(new Memory()), scanner_(this), parser_(this),
            ownMemory_(true), isRunning_(false), isInteractive_(false)
{
}

Agent::Agent(Memory* memory, istream& in, ostream& out, ostream& err) :
    in_(in), out_(out), err_(err), memory_(memory), scanner_(this), parser_(this),
            ownMemory_(false), isRunning_(false), isInteractive_(false)
{
}

Agent::~Agent()
{
    if (ownMemory_) {
        delete memory_;
    }
}

void Agent::setInteractive()
{
    isInteractive_ = true;
}

void Agent::start()
{
    isRunning_ = true;
    while (isRunning_) {
        if (isInteractive_) {
            out_ << ">> ";
        }
        const Statement& stmt = scanner_.next();
        try {
            memory_->beginTransaction();
            parser_.parse(stmt);
            memory_->commitTransaction();
        } catch (const exception& ex) {
            err_ << ex.what() << endl;
            memory_->rollbackTransaction();
            if (isInteractive_) {
                stmt.dump(err_);
            }
        }
    }
}

void Agent::stop()
{
    isRunning_ = false;
}

