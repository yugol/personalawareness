#include <MainWindow.h>
#include <Controller.h>

void MainWindow::checkItem()
{
    int nChars = trItemCombo_->GetValue().Trim(true).Trim(false).size();
    if (nChars > 0) {
        trAcceptButton_->Enable();
    } else {
        trAcceptButton_->Disable();
    }
}

int MainWindow::getItemIndexById(int id)
{
    for (unsigned int i = 0; i < trItemCombo_->GetCount(); ++i) {
        int tmpId = reinterpret_cast<int> (trItemCombo_->GetClientData(i));
        if (tmpId == id) {
            return i;
        }
    }
    return -1;
}

int MainWindow::getSourceIndexById(int id)
{
    for (unsigned int i = 0; i < trSourceChoice_->GetCount(); ++i) {
        int tmpId = reinterpret_cast<int> (trSourceChoice_->GetClientData(i));
        if (tmpId == id) {
            return i;
        }
    }
    return -1;
}

int MainWindow::getDestinationIndexById(int id)
{
    for (unsigned int i = 0; i < trDestinationChoice_->GetCount(); ++i) {
        int tmpId = reinterpret_cast<int> (trDestinationChoice_->GetClientData(i));
        if (tmpId == id) {
            return i;
        }
    }
    return -1;
}

