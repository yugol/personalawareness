///////////////////////////////////////////////////////////////////////////
// C++ code generated with wxFormBuilder (version Apr 17 2008)
// http://www.wxformbuilder.org/
//
// PLEASE DO "NOT" EDIT THIS FILE!
///////////////////////////////////////////////////////////////////////////

#ifndef __OptimizationDialogBase__
#define __OptimizationDialogBase__

#include <wx/string.h>
#include <wx/stattext.h>
#include <wx/gdicmn.h>
#include <wx/font.h>
#include <wx/colour.h>
#include <wx/settings.h>
#include <wx/checkbox.h>
#include <wx/sizer.h>
#include <wx/button.h>
#include <wx/dialog.h>

///////////////////////////////////////////////////////////////////////////


///////////////////////////////////////////////////////////////////////////////
/// Class OptimizationDialogBase
///////////////////////////////////////////////////////////////////////////////
class OptimizationDialogBase : public wxDialog 
{
	private:
	
	protected:
		
		wxStaticText* message_;
		wxCheckBox* unusedItemsCheckBox_;
		
		wxStdDialogButtonSizer* buttons_;
		wxButton* buttons_OK;
		wxButton* buttons_Cancel;
		
		// Virtual event handlers, overide them in your derived class
		virtual void onClose( wxCloseEvent& event ){ event.Skip(); }
		
	
	public:
		OptimizationDialogBase( wxWindow* parent, wxWindowID id = wxID_ANY, const wxString& title = wxT("Optimize database"), const wxPoint& pos = wxDefaultPosition, const wxSize& size = wxSize( 280,128 ), long style = wxDEFAULT_DIALOG_STYLE );
		~OptimizationDialogBase();
	
};

#endif //__OptimizationDialogBase__
