#include <cstdlib>
#include <sstream>
#include <fstream>
#include <constatnts.h>
#include <Type.h>
#include <Memory.h>
#include <Agent.h>
#include <Parser.h>

using namespace std;

void Parser::doStop(const Statement& stmt)
{
    agent_->stop();
}

void Parser::doDot(const Statement& stmt)
{
    memory_->dumpTypesDot(out_);
}

void Parser::doDotty(const Statement& stmt)
{
    if (stmt[2].getType() == DEFN) {
        out_ << "Some models are: ";
        out_ << "dot, neato, fdp, sfdp, twopi, circo";
        out_ << endl;
        return;
    }

    if (system(NULL)) {
        string file(TMP_FILE);
        ofstream fout(file.c_str(), ios::trunc);
        memory_->dumpTypesDot(fout);
        fout.close();

        string filter(DOTTY_DEFAULT_FILTER);
        if (stmt[2].getType() == ID) {
            filter = stmt[2].content();
        }

        string fileExt = file;
        fileExt.append(".");
        fileExt.append(filter);

        ostringstream buildCmd;
        buildCmd << filter << " " << file << " > " << fileExt;

        ostringstream showCmd;
        showCmd << DOTTY_EXECUTABLE;
        showCmd << " ";

        if (::system(buildCmd.str().c_str())) {
            showCmd << file;
        } else {
            showCmd << fileExt;
        }
        ::system(showCmd.str().c_str());

        ::remove(file.c_str());
        ::remove(fileExt.c_str());
    } else {
        throwParseError("system command processor is not available");
    }
}

void Parser::doLoad(const Statement& stmt)
{
    if (stmt.size() <= 3) {
        throwParseError("unspecified file in :" CMD_LOAD " command");
    }
    const string& fileName = stmt[2].content();
    ifstream fin(fileName.c_str(), ifstream::in);
    if (fin.good()) {
        try {
            memory_->beginTransaction();
            Agent loader(memory_, fin, agent_->getOut(), agent_->getErr());
            loader.setInteractive(false);
            loader.setStopOnError(true);
            loader.setInputId(fileName);
            loader.start();
            memory_ ->commitTransaction();
        } catch (const exception& ex) {
            memory_->rollbackTransaction();
            throwParseError(ex.what());
        }
    } else {
        throwParseError("file not found in :" CMD_LOAD " command", &stmt[2]);
    }
    fin.close();
}

void Parser::doWhat(const Statement & stmt)
{
    if (stmt.size() <= 3) {
        throwParseError("unspecified identifier in :" CMD_WHAT " command");
    }
    const string& id = stmt[2].content();
    Type* type = memory_->getType(id);
    if (type != 0) {
        type->dump(out_);
    }
}
