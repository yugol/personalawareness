///////////////////////////////////////////////////////////////////////////
// C++ code generated with wxFormBuilder (version Apr 17 2008)
// http://www.wxformbuilder.org/
//
// PLEASE DO "NOT" EDIT THIS FILE!
///////////////////////////////////////////////////////////////////////////

#ifndef __AboutDialogBase__
#define __AboutDialogBase__

#include <wx/bitmap.h>
#include <wx/image.h>
#include <wx/icon.h>
#include <wx/statbmp.h>
#include <wx/gdicmn.h>
#include <wx/font.h>
#include <wx/colour.h>
#include <wx/settings.h>
#include <wx/string.h>
#include <wx/stattext.h>
#include <wx/sizer.h>
#include <wx/panel.h>
#include <wx/textctrl.h>
#include <wx/notebook.h>
#include <wx/button.h>
#include <wx/dialog.h>

///////////////////////////////////////////////////////////////////////////


///////////////////////////////////////////////////////////////////////////////
/// Class AboutDialogBase
///////////////////////////////////////////////////////////////////////////////
class AboutDialogBase : public wxDialog 
{
	private:
	
	protected:
		wxNotebook* sectionsNotebook_;
		wxPanel* applicationPage_;
		wxStaticBitmap* iconBitmap_;
		
		wxStaticText* projectNameLabel_;
		
		
		wxStaticText* versionLabel_;
		
		
		wxStaticText* usageLabel_;
		
		
		wxStaticText* copyrightLabel_;
		
		
		wxPanel* changesPage_;
		wxTextCtrl* changesText_;
		wxPanel* creditsPage_;
		wxTextCtrl* creditsText_;
		wxPanel* licensePage_;
		wxTextCtrl* licenseText_;
		wxButton* closeButton_;
		
		// Virtual event handlers, overide them in your derived class
		virtual void onClose( wxCommandEvent& event ){ event.Skip(); }
		
	
	public:
		AboutDialogBase( wxWindow* parent, wxWindowID id = wxID_ANY, const wxString& title = wxT("About"), const wxPoint& pos = wxDefaultPosition, const wxSize& size = wxSize( 400,260 ), long style = wxDEFAULT_DIALOG_STYLE );
		~AboutDialogBase();
	
};

#endif //__AboutDialogBase__
