#include <cstdlib>
#include <sstream>
#include <fstream>
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
    if (stmt[2].getType() == Token::DEFN) {
        out_ << "Some models are: ";
        out_ << "dot, neato, fdp, sfdp, twopi, circo";
        out_ << endl;
        return;
    }

    if (system(NULL)) {
        string file("~moody-temp");
        ofstream fout(file.c_str(), ios::trunc);
        memory_->dumpTypesDot(fout);
        fout.close();

        string filter("dot");
        if (stmt[2].getType() == Token::ID) {
            filter = stmt[2].content();
        }

        string fileExt = file;
        fileExt.append(".");
        fileExt.append(filter);

        ostringstream buildCmd;
        buildCmd << filter << " " << file << " > " << fileExt;

        ostringstream showCmd;
        showCmd << "dotty ";

        if (system(buildCmd.str().c_str())) {
            showCmd << file;
        } else {
            showCmd << fileExt;
        }

        system(showCmd.str().c_str());

        remove(file.c_str());
        remove(fileExt.c_str());
    } else {
        throwParseError("system command processor is not available");
    }
}
