#include <wx/textctrl.h>
#include <wx/listbox.h>
#include <wx/sizer.h>
#include <UiUtil.h>
#include <Controller.h>
#include <AutocompleteWindow.h>

AutocompleteWindow::AutocompleteWindow(wxWindow* parent, wxTextCtrl* handler) :
    AutocompleteWindowBase(parent), handler_(handler)
{
}

AutocompleteWindow::~AutocompleteWindow()
{
}

void AutocompleteWindow::onKillFocus(wxFocusEvent& event)
{
    hide();
}

void AutocompleteWindow::onKeyDown(wxKeyEvent& event)
{
    int keyCode = event.GetKeyCode();

    if (keyCode == WXK_UP) {
        int selection = optionList_->GetSelection();
        --selection;
        if (selection >= 0) {
            optionList_->SetSelection(selection);
        }
        return;
    }

    if (keyCode == WXK_DOWN) {
        unsigned int selection = optionList_->GetSelection();
        ++selection;
        if (selection < optionList_->GetCount()) {
            optionList_->SetSelection(selection);
        }
        return;
    }

    if (keyCode == WXK_RETURN || keyCode == WXK_SPACE) {
        handler_->SetValue(optionList_->GetString(optionList_->GetSelection()));
    }

    if (keyCode == WXK_BACK) {
        handler_->EmulateKeyPress(event);
    }

    hide();
}

void AutocompleteWindow::show()
{
    if (optionList_->GetCount() <= 0) {
        return;
    }

    int width = handler_->GetSize().GetWidth();
    int height = GetParent()->GetSize().GetHeight() / 2;
    SetSize(width, height);

    int x, y;
    int delta = 10; // TBD-: magic number
    handler_->GetScreenPosition(&x, &y);
    y -= (height + delta);
    SetPosition(wxPoint(x, y));

    Show(true);
}

void AutocompleteWindow::hide()
{
    Show(false);
    int lastPos = handler_->GetValue().Len();
    handler_->SetSelection(lastPos, lastPos);
}

void AutocompleteWindow::clear()
{
    optionList_->Clear();
}

void AutocompleteWindow::append(const wxString& name, int id)
{
    optionList_->Append(name, reinterpret_cast<void*> (id));
}

void AutocompleteWindow::select(const wxString& hint, int direction)
{
    int idx = wxNOT_FOUND;

    int itemCount = optionList_->GetCount();

    if (hint.Len() <= 0) {
        if (direction < 0) {
            idx = itemCount - 1;
        } else {
            idx = 0;
        }
    } else {
        if (direction >= 0) {
            for (idx = 0; idx < itemCount; ++idx) {
                int cmp = UiUtil::compareBeginning(hint, optionList_->GetString(idx));
                if (cmp <= 0) {
                    break;
                }
            }
        } else {
            for (idx = itemCount - 1; idx >= 0; --idx) {
                int cmp = UiUtil::compareBeginning(hint, optionList_->GetString(idx));
                if (cmp >= 0) {
                    break;
                }
            }
        }
    }

    optionList_->SetSelection(idx);
    optionList_->SetFirstItem(idx - 1);
    optionList_->SetFocus();
}

