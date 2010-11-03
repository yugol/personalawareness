#ifndef OPTIMIZATIONDIALOG_H_
#define OPTIMIZATIONDIALOG_H_

#include "OptimizationDialogBase.h"

class OptimizationReport;

class OptimizationDialog: public OptimizationDialogBase {
public:
    OptimizationDialog(wxWindow* parent, OptimizationReport* report);
    virtual ~OptimizationDialog();

protected:
    void onClose(wxCloseEvent& event);

private:
    OptimizationReport* report_;
};

#endif /* OPTIMIZATIONDIALOG_H_ */
