#include <sstream>
#include <Agent.h>
#include "_test.h"

TEST(ok_1, defineType)
{
    istringstream sin("A:();");
    ostringstream sout;
    ostringstream serr;
    Agent tester(sin, sout, serr);
    tester.setInteractive(false);
    tester.setStopOnError(true);
    tester.start();
    if (serr.str().size() > 0) {
        FAIL(serr.str().c_str());
    }
}

TEST(ok_2, defineType)
{
    istringstream sin("A:(B);");
    ostringstream sout;
    ostringstream serr;
    Agent tester(sin, sout, serr);
    tester.setInteractive(false);
    tester.setStopOnError(true);
    tester.start();
    if (serr.str().size() > 0) {
        FAIL(serr.str().c_str());
    }
}

TEST(ok_3, defineType)
{
    istringstream sin("A:(B, C);");
    ostringstream sout;
    ostringstream serr;
    Agent tester(sin, sout, serr);
    tester.setInteractive(false);
    tester.setStopOnError(true);
    tester.start();
    if (serr.str().size() > 0) {
        FAIL(serr.str().c_str());
    }
}

TEST(ok_4, defineType)
{
    istringstream sin("A:(B, C) d : D;");
    ostringstream sout;
    ostringstream serr;
    Agent tester(sin, sout, serr);
    tester.setInteractive(false);
    tester.setStopOnError(true);
    tester.start();
    if (serr.str().size() > 0) {
        FAIL(serr.str().c_str());
    }
}

TEST(ok_5, defineType)
{
    istringstream sin("A:(B,C)d:D,e:A,f:B;");
    ostringstream sout;
    ostringstream serr;
    Agent tester(sin, sout, serr);
    tester.setInteractive(false);
    tester.setStopOnError(true);
    tester.start();
    if (serr.str().size() > 0) {
        FAIL(serr.str().c_str());
    }
}
