///////////////////////////////////////////////////////////////////////////
// C++ code generated with wxFormBuilder (version Apr 17 2008)
// http://www.wxformbuilder.org/
//
// PLEASE DO "NOT" EDIT THIS FILE!
///////////////////////////////////////////////////////////////////////////

#ifndef __AccountsDialogBase__
#define __AccountsDialogBase__

#include <wx/string.h>
#include <wx/stattext.h>
#include <wx/gdicmn.h>
#include <wx/font.h>
#include <wx/colour.h>
#include <wx/settings.h>
#include <wx/listctrl.h>
#include <wx/sizer.h>
#include <wx/textctrl.h>
#include <wx/choice.h>
#include <wx/combobox.h>
#include <wx/button.h>
#include <wx/dialog.h>

///////////////////////////////////////////////////////////////////////////


///////////////////////////////////////////////////////////////////////////////
/// Class AccountsDialogBase
///////////////////////////////////////////////////////////////////////////////
class AccountsDialogBase : public wxDialog 
{
	private:
	
	protected:
		wxStaticText* listLabel_;
		wxListCtrl* accountList_;
		wxStaticText* nameLabel_;
		wxTextCtrl* nameText_;
		wxStaticText* typeLabel_;
		wxChoice* typeChoice_;
		wxStaticText* groupLabel_;
		wxComboBox* groupCombo_;
		wxStaticText* valueLabel_;
		wxTextCtrl* valueText_;
		wxStaticText* commentLabel_;
		wxTextCtrl* commentText_;
		wxButton* insertButton_;
		wxButton* updateButton_;
		wxButton* deleteButton_;
		wxButton* clearButton_;
		
		wxButton* closeButton_;
		
		// Virtual event handlers, overide them in your derived class
		virtual void onCloseDialog( wxCloseEvent& event ){ event.Skip(); }
		virtual void onInitDialog( wxInitDialogEvent& event ){ event.Skip(); }
		virtual void onSelectAccount( wxListEvent& event ){ event.Skip(); }
		virtual void onNameText( wxCommandEvent& event ){ event.Skip(); }
		virtual void onTypeChange( wxCommandEvent& event ){ event.Skip(); }
		virtual void onGroupText( wxCommandEvent& event ){ event.Skip(); }
		virtual void onValueText( wxCommandEvent& event ){ event.Skip(); }
		virtual void onCommentText( wxCommandEvent& event ){ event.Skip(); }
		virtual void onInsert( wxCommandEvent& event ){ event.Skip(); }
		virtual void onUpdate( wxCommandEvent& event ){ event.Skip(); }
		virtual void onDelete( wxCommandEvent& event ){ event.Skip(); }
		virtual void onClear( wxCommandEvent& event ){ event.Skip(); }
		virtual void onClose( wxCommandEvent& event ){ event.Skip(); }
		
	
	public:
		AccountsDialogBase( wxWindow* parent, wxWindowID id = wxID_ANY, const wxString& title = wxT("Edit accounts"), const wxPoint& pos = wxDefaultPosition, const wxSize& size = wxSize( 540,405 ), long style = wxDEFAULT_DIALOG_STYLE );
		~AccountsDialogBase();
	
};

#endif //__AccountsDialogBase__
