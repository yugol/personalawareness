///////////////////////////////////////////////////////////////////////////
// C++ code generated with wxFormBuilder (version Apr 17 2008)
// http://www.wxformbuilder.org/
//
// PLEASE DO "NOT" EDIT THIS FILE!
///////////////////////////////////////////////////////////////////////////

#ifndef __PreferencesDialogBase__
#define __PreferencesDialogBase__

#include <wx/string.h>
#include <wx/checkbox.h>
#include <wx/gdicmn.h>
#include <wx/font.h>
#include <wx/colour.h>
#include <wx/settings.h>
#include <wx/sizer.h>
#include <wx/statbox.h>
#include <wx/panel.h>
#include <wx/bitmap.h>
#include <wx/image.h>
#include <wx/icon.h>
#include <wx/stattext.h>
#include <wx/textctrl.h>
#include <wx/notebook.h>
#include <wx/button.h>
#include <wx/dialog.h>

///////////////////////////////////////////////////////////////////////////


///////////////////////////////////////////////////////////////////////////////
/// Class PreferencesDialogBase
///////////////////////////////////////////////////////////////////////////////
class PreferencesDialogBase : public wxDialog 
{
	private:
	
	protected:
		wxNotebook* propertiesNotebook_;
		wxPanel* applicationPage_;
		wxCheckBox* openLastDatabaseCheckBox_;
		wxPanel* viewPage_;
		wxCheckBox* compactTransactionsViewCheckBox_;
		wxCheckBox* hideZeroBalanceAccountsCheckBox_;
		wxPanel* formattingPage_;
		wxStaticText* currencySymbolLabel_;
		wxTextCtrl* currencySymbolText_;
		wxCheckBox* currencyPositionCheckBox_;
		
		wxPanel* internalsPage_;
		wxCheckBox* treatNonAsciiCharsIdenticallyCheckBox_;
		wxStdDialogButtonSizer* buttonsSizer_;
		wxButton* buttonsSizer_OK;
		wxButton* buttonsSizer_Cancel;
		
		// Virtual event handlers, overide them in your derived class
		virtual void onInitDialog( wxInitDialogEvent& event ){ event.Skip(); }
		
	
	public:
		PreferencesDialogBase( wxWindow* parent, wxWindowID id = wxID_ANY, const wxString& title = wxT("Edit preferences"), const wxPoint& pos = wxDefaultPosition, const wxSize& size = wxSize( 400,240 ), long style = wxDEFAULT_DIALOG_STYLE );
		~PreferencesDialogBase();
	
};

#endif //__PreferencesDialogBase__
