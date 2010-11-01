#include <ctime>
#include <constatnts.h>
#include <Exception.h>
#include <Memory.h>
#include <Agent.h>

using namespace std;

static const char* get_time_string()
{
    time_t rawtime;
    ::time(&rawtime);
    tm* timeinfo = ::localtime(&rawtime);
    return ::asctime(timeinfo);
}

Agent::Agent(istream& in, ostream& out, ostream& err) :
    in_(in), out_(out), err_(err), memory_(new Memory()), scanner_(this), parser_(this),
            hasOwnMemory_(true), running_(false), interactive_(false), stopOnError_(true)
{
}

Agent::Agent(Memory* memory, istream& in, ostream& out, ostream& err) :
    in_(in), out_(out), err_(err), memory_(memory), scanner_(this), parser_(this), hasOwnMemory_(
            false), running_(false), interactive_(false), stopOnError_(true)
{
}

Agent::~Agent()
{
    if (hasOwnMemory_) {
        delete memory_;
    }
}

void Agent::setId(const std::string& id)
{
    id_ = id;
}

void Agent::setInteractive(bool val)
{
    interactive_ = val;
}

void Agent::setStopOnError(bool val)
{
    stopOnError_ = val;
}

void Agent::setInputId(const std::string& inputId)
{
    inputId_ = inputId;
    if (inputId_.size() > 0) {
        inputId_.append(ERR_SEP);
    }
}

void Agent::start()
{
    if (interactive_) {
        out_ << "Agent ";
        if (id_.size() > 0) {
            out_ << "'" << id_ << "' ";
        }
        out_ << "started on " << get_time_string();
    }

    running_ = true;
    while (running_) {
        if (interactive_) {
            out_ << ">> ";
        }
        const Statement& stmt = scanner_.next();
        if (stmt.size() == 0) {
            break;
        }
        try {
            memory_->beginTransaction();
            parser_.parse(stmt);
            memory_->commitTransaction();
        } catch (const exception& ex) {
            err_ << inputId_ << ex.what() << endl;
            memory_->rollbackTransaction();
            if (interactive_) {
                // stmt.dump(err_);
            }
            if (stopOnError_) {
                break;
            }
        }
    }

    if (interactive_) {
        out_ << "Agent ";
        if (id_.size() > 0) {
            out_ << "'" << id_ << "' ";
        }
        out_ << "stopped on " << get_time_string();
    }
}

void Agent::stop()
{
    running_ = false;
}

