///////////////////////////////////////////////////////////////////////////
// C++ code generated with wxFormBuilder (version Apr 17 2008)
// http://www.wxformbuilder.org/
//
// PLEASE DO "NOT" EDIT THIS FILE!
///////////////////////////////////////////////////////////////////////////

#ifndef __AutocompleteWindowBase__
#define __AutocompleteWindowBase__

#include <wx/string.h>
#include <wx/listbox.h>
#include <wx/gdicmn.h>
#include <wx/font.h>
#include <wx/colour.h>
#include <wx/settings.h>
#include <wx/sizer.h>
#include <wx/frame.h>

///////////////////////////////////////////////////////////////////////////


///////////////////////////////////////////////////////////////////////////////
/// Class AutocompleteWindowBase
///////////////////////////////////////////////////////////////////////////////
class AutocompleteWindowBase : public wxFrame 
{
	private:
	
	protected:
		wxListBox* optionList_;
		
		// Virtual event handlers, overide them in your derived class
		virtual void onKeyDown( wxKeyEvent& event ){ event.Skip(); }
		virtual void onKillFocus( wxFocusEvent& event ){ event.Skip(); }
		
	
	public:
		AutocompleteWindowBase( wxWindow* parent, wxWindowID id = wxID_ANY, const wxString& title = wxEmptyString, const wxPoint& pos = wxDefaultPosition, const wxSize& size = wxSize( 500,300 ), long style = wxFRAME_FLOAT_ON_PARENT|wxFRAME_NO_TASKBAR|wxTAB_TRAVERSAL );
		~AutocompleteWindowBase();
	
};

#endif //__AutocompleteWindowBase__
