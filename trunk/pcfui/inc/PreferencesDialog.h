#ifndef PREFERENCESDIALOG_H_
#define PREFERENCESDIALOG_H_

#include "PreferencesDialogBase.h"

class PreferencesDialog: public PreferencesDialogBase {
public:
    PreferencesDialog(wxWindow* parent);
    virtual ~PreferencesDialog();

    void updatePreferences();

protected:
    virtual void onInitDialog(wxInitDialogEvent& event);
};

#endif /* PREFERENCESDIALOG_H_ */
