///////////////////////////////////////////////////////////////////////////
// C++ code generated with wxFormBuilder (version Apr 17 2008)
// http://www.wxformbuilder.org/
//
// PLEASE DO "NOT" EDIT THIS FILE!
///////////////////////////////////////////////////////////////////////////

#include "AutocompleteWindowBase.h"

///////////////////////////////////////////////////////////////////////////

AutocompleteWindowBase::AutocompleteWindowBase( wxWindow* parent, wxWindowID id, const wxString& title, const wxPoint& pos, const wxSize& size, long style ) : wxFrame( parent, id, title, pos, size, style )
{
	this->SetSizeHints( wxDefaultSize, wxDefaultSize );
	
	wxBoxSizer* frameSizer;
	frameSizer = new wxBoxSizer( wxVERTICAL );
	
	optionList_ = new wxListBox( this, wxID_ANY, wxDefaultPosition, wxDefaultSize, 0, NULL, 0 ); 
	frameSizer->Add( optionList_, 1, wxEXPAND, 5 );
	
	this->SetSizer( frameSizer );
	this->Layout();
	
	// Connect Events
	optionList_->Connect( wxEVT_KEY_DOWN, wxKeyEventHandler( AutocompleteWindowBase::onKeyDown ), NULL, this );
	optionList_->Connect( wxEVT_KILL_FOCUS, wxFocusEventHandler( AutocompleteWindowBase::onKillFocus ), NULL, this );
}

AutocompleteWindowBase::~AutocompleteWindowBase()
{
}
