#include <iostream>
#include <string>
#include "test.h"

using namespace std;

SKIPTEST( encoding, string )
{
    cout << endl << endl;

    wstring ws(L"abcȘă");
    wcout << L"utf16: " << ws << endl;

    string s("abcȘă");
    cout << " utf8: " << s << endl;

    cout << endl;
}
