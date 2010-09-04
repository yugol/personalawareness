#include <wx/textctrl.h>
#include <wx/listbox.h>
#include <wx/sizer.h>
#include <UiUtil.h>
#include <Controller.h>
#include <AutocompletionWindow.h>

AutocompletionWindow::AutocompletionWindow(wxWindow* parent, wxTextCtrl* handler) :
    wxFrame(parent, wxID_ANY, wxEmptyString, wxDefaultPosition, wxDefaultSize, wxFRAME_NO_TASKBAR | wxFRAME_FLOAT_ON_PARENT), handler_(handler)
{
    this->SetSizeHints(wxDefaultSize, wxDefaultSize);

    wxBoxSizer* frameSizer;
    frameSizer = new wxBoxSizer(wxVERTICAL);

    optionList_ = new wxListBox(this, wxID_ANY, wxDefaultPosition, wxDefaultSize, 0, NULL, wxLB_NEEDED_SB | wxLB_SINGLE);
    frameSizer->Add(optionList_, 1, wxALL | wxEXPAND, 0);

    this->SetSizer(frameSizer);
    this->Layout();

    // Connect Events
    optionList_->Connect(wxEVT_KILL_FOCUS, wxFocusEventHandler( AutocompletionWindow::onKillFocus ), NULL, this);
    optionList_->Connect(wxEVT_KEY_DOWN, wxKeyEventHandler( AutocompletionWindow::onKeyDown ), NULL, this);
}

AutocompletionWindow::~AutocompletionWindow()
{
}

void AutocompletionWindow::onKillFocus(wxFocusEvent& event)
{
    hide();
}

void AutocompletionWindow::onKeyDown(wxKeyEvent& event)
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

void AutocompletionWindow::show()
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

void AutocompletionWindow::hide()
{
    Show(false);
    int lastPos = handler_->GetValue().Len();
    handler_->SetSelection(lastPos, lastPos);
}

void AutocompletionWindow::clear()
{
    optionList_->Clear();
}

void AutocompletionWindow::append(const wxString& name, int id)
{
    optionList_->Append(name, reinterpret_cast<void*> (id));
}

void AutocompletionWindow::select(const wxString& hint, int direction)
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

