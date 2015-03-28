# Windows #

  1. install Microsoft Visual C++ 2010 Express (or above) http://www.microsoft.com/express/Downloads/
  1. install wxWidgets http://www.wxwidgets.org/
  1. compile wxWidgets http://wiki.wxwidgets.org/Microsoft_Visual_C%2B%2B_Guide (DLL Release & Debug)
  1. checkout
    * cppunitlite
    * pacommon
    * pacommon-test
    * pcfbase
    * pcfbase-test
    * pcfui
    * sqlite3
    * pcf-msvc
  1. download SQLite http://www.sqlite.org/
    1. copy `sqlite3.h`, `sqlite3ext.h` and `sqlite3.c` to the above _sqlite3_ folder
  1. edit project properties for _pcfui_
    1. C/C++ --> General --> Additional Include Directories
      * `<WXPATH>\include`
      * `<WXPATH>\include\msvc`
    1. Linker --> General --> Additional Library Directories
      * `<WXPATH>\lib\vc_dll`
  1. build _pcfui_
  1. make sure the following files are in the path
    * `wxmsw[291ud]_core[_vc_custom].dll`
    * `wxbase[291ud_vc_custom].dll`
    * `wxmsw[291ud]_adv[_vc_custom].dll`
    * `wxmsw[291ud]_html[_vc_custom].dll`
