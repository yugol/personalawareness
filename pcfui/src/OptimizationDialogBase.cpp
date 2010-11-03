///////////////////////////////////////////////////////////////////////////
// C++ code generated with wxFormBuilder (version Apr 17 2008)
// http://www.wxformbuilder.org/
//
// PLEASE DO "NOT" EDIT THIS FILE!
///////////////////////////////////////////////////////////////////////////

#include "OptimizationDialogBase.h"

///////////////////////////////////////////////////////////////////////////

OptimizationDialogBase::OptimizationDialogBase( wxWindow* parent, wxWindowID id, const wxString& title, const wxPoint& pos, const wxSize& size, long style ) : wxDialog( parent, id, title, pos, size, style )
{
	this->SetSizeHints( wxDefaultSize, wxDefaultSize );
	
	wxBoxSizer* dialogSizer;
	dialogSizer = new wxBoxSizer( wxVERTICAL );
	
	wxBoxSizer* cancelButtonSizer;
	cancelButtonSizer = new wxBoxSizer( wxVERTICAL );
	
	
	cancelButtonSizer->Add( 0, 0, 1, wxEXPAND, 5 );
	
	message_ = new wxStaticText( this, wxID_ANY, wxT("%message%"), wxDefaultPosition, wxDefaultSize, 0 );
	message_->Wrap( -1 );
	cancelButtonSizer->Add( message_, 0, wxALL, 5 );
	
	unusedItemsCheckBox_ = new wxCheckBox( this, wxID_ANY, wxT("Remove unused items"), wxDefaultPosition, wxDefaultSize, 0 );
	
	cancelButtonSizer->Add( unusedItemsCheckBox_, 0, wxALL, 5 );
	
	
	cancelButtonSizer->Add( 0, 0, 2, wxEXPAND, 5 );
	
	buttons_ = new wxStdDialogButtonSizer();
	buttons_OK = new wxButton( this, wxID_OK );
	buttons_->AddButton( buttons_OK );
	buttons_Cancel = new wxButton( this, wxID_CANCEL );
	buttons_->AddButton( buttons_Cancel );
	buttons_->Realize();
	cancelButtonSizer->Add( buttons_, 0, wxEXPAND, 5 );
	
	dialogSizer->Add( cancelButtonSizer, 1, wxALL|wxEXPAND, 5 );
	
	this->SetSizer( dialogSizer );
	this->Layout();
	
	// Connect Events
	this->Connect( wxEVT_CLOSE_WINDOW, wxCloseEventHandler( OptimizationDialogBase::onClose ) );
}

OptimizationDialogBase::~OptimizationDialogBase()
{
}
