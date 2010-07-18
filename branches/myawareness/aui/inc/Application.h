#ifndef APPLICATION_H
#define APPLICATION_H

#include <wx/app.h>
#include <Controller.h>

class Application : public wxApp
{
public:
    virtual bool OnInit();

private:
    Controller controller_;
};

#endif // APPLICATION_H
