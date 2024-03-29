#ifdef WINDOWS
#include <direct.h>
#define getcwd_api _getcwd
#else
#include <unistd.h>
#define getcwd_api getcwd
#endif

#include <cerrno>
#include <cstdio>
#include <iostream>
#include <Agent.h>

using namespace std;

// TODO: end commands with `;'
// TODO: start declarations with `'' end them with `;'
// TODO: use `,' as list separator and `(' and  `)' as list delimiters
// TODO: implement escape sequences
// TODO: implement transaction commit and rollback (named transactions)
// TODO: create signatures and freeze type hierarchy when creating an atom

int main(int argc, char** argv)
{
    char cwd[FILENAME_MAX];
    if (!getcwd_api(cwd, sizeof(cwd))) {
        cerr << "Cannot read working directory" << endl;
        return errno;
    }

    cout << "Moody 0.0.1 (Meta Objects Organized DYnamically)" << endl;
    cout << "Working directory: " << cwd << endl;

    Agent agent(cin, cout, cerr);
    agent.setId("console");
    agent.setInteractive(true);
    agent.setStopOnError(false);
    agent.setInputId("");
    agent.start();

    return 0;
}
