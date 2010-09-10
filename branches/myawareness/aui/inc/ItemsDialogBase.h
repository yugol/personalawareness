///////////////////////////////////////////////////////////////////////////
// C++ code generated with wxFormBuilder (version Apr 17 2008)
// http://www.wxformbuilder.org/
//
// PLEASE DO "NOT" EDIT THIS FILE!
///////////////////////////////////////////////////////////////////////////

#ifndef __ItemsDialogBase__
#define __ItemsDialogBase__

#include <wx/string.h>
#include <wx/stattext.h>
#include <wx/gdicmn.h>
#include <wx/font.h>
#include <wx/colour.h>
#include <wx/settings.h>
#include <wx/textctrl.h>
#include <wx/sizer.h>
#include <wx/listctrl.h>
#include <wx/button.h>
#include <wx/dialog.h>

///////////////////////////////////////////////////////////////////////////


///////////////////////////////////////////////////////////////////////////////
/// Class ItemsDialogBase
///////////////////////////////////////////////////////////////////////////////
class ItemsDialogBase : public wxDialog 
{
	private:
	
	protected:
		wxStaticText* patternLabel_;
		wxTextCtrl* patternText_;
		wxListCtrl* itemList_;
		wxButton* renameButton_;
		wxButton* deleteButton_;
		
		wxButton* closeButton_;
		
		// Virtual event handlers, overide them in your derived class
		virtual void onCloseDialog( wxCloseEvent& event ){ event.Skip(); }
		virtual void onInitDialog( wxInitDialogEvent& event ){ event.Skip(); }
		virtual void onPatternText( wxCommandEvent& event ){ event.Skip(); }
		virtual void onItemSelected( wxListEvent& event ){ event.Skip(); }
		virtual void onRename( wxCommandEvent& event ){ event.Skip(); }
		virtual void onDelete( wxCommandEvent& event ){ event.Skip(); }
		virtual void onClose( wxCommandEvent& event ){ event.Skip(); }
		
	
	public:
		ItemsDialogBase( wxWindow* parent, wxWindowID id = wxID_ANY, const wxString& title = wxT("Edit transacted items"), const wxPoint& pos = wxDefaultPosition, const wxSize& size = wxSize( 400,520 ), long style = wxDEFAULT_DIALOG_STYLE );
		~ItemsDialogBase();
	
};

#endif //__ItemsDialogBase__
