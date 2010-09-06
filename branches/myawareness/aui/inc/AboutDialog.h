#ifndef ABOUTDIALOG_H_
#define ABOUTDIALOG_H_

#include "AboutDialogBase.h"

class AboutDialog: public AboutDialogBase {
public:
    AboutDialog(wxWindow* parent);
    virtual ~AboutDialog();

protected:
    virtual void onInitDialog(wxInitDialogEvent& event);
    virtual void onClose(wxCommandEvent& event);
};

#endif /* ABOUTDIALOG_H_ */
