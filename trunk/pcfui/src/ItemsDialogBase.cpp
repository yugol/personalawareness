///////////////////////////////////////////////////////////////////////////
// C++ code generated with wxFormBuilder (version Apr 17 2008)
// http://www.wxformbuilder.org/
//
// PLEASE DO "NOT" EDIT THIS FILE!
///////////////////////////////////////////////////////////////////////////

#include "ItemsDialogBase.h"

///////////////////////////////////////////////////////////////////////////

ItemsDialogBase::ItemsDialogBase( wxWindow* parent, wxWindowID id, const wxString& title, const wxPoint& pos, const wxSize& size, long style ) : wxDialog( parent, id, title, pos, size, style )
{
	this->SetSizeHints( wxDefaultSize, wxDefaultSize );
	
	wxFlexGridSizer* dialogSizer;
	dialogSizer = new wxFlexGridSizer( 2, 2, 0, 0 );
	dialogSizer->AddGrowableCol( 0 );
	dialogSizer->AddGrowableRow( 1 );
	dialogSizer->SetFlexibleDirection( wxBOTH );
	dialogSizer->SetNonFlexibleGrowMode( wxFLEX_GROWMODE_SPECIFIED );
	
	wxBoxSizer* searchSizer;
	searchSizer = new wxBoxSizer( wxHORIZONTAL );
	
	patternLabel_ = new wxStaticText( this, wxID_ANY, wxT("Search by name:"), wxDefaultPosition, wxDefaultSize, 0 );
	patternLabel_->Wrap( -1 );
	searchSizer->Add( patternLabel_, 0, wxALIGN_CENTER|wxALL, 5 );
	
	patternText_ = new wxTextCtrl( this, wxID_ANY, wxEmptyString, wxDefaultPosition, wxDefaultSize, 0 );
	searchSizer->Add( patternText_, 1, wxALL|wxEXPAND, 5 );
	
	dialogSizer->Add( searchSizer, 1, wxEXPAND, 5 );
	
	wxBoxSizer* emptySizer;
	emptySizer = new wxBoxSizer( wxVERTICAL );
	
	dialogSizer->Add( emptySizer, 1, wxEXPAND, 5 );
	
	itemList_ = new wxListCtrl( this, wxID_ANY, wxDefaultPosition, wxDefaultSize, wxLC_HRULES|wxLC_LIST|wxLC_NO_HEADER|wxLC_REPORT|wxLC_SINGLE_SEL );
	dialogSizer->Add( itemList_, 1, wxALL|wxEXPAND, 5 );
	
	wxBoxSizer* buttonsSizer;
	buttonsSizer = new wxBoxSizer( wxVERTICAL );
	
	renameButton_ = new wxButton( this, wxID_ANY, wxT("&Rename"), wxDefaultPosition, wxDefaultSize, 0 );
	buttonsSizer->Add( renameButton_, 0, wxALL, 5 );
	
	deleteButton_ = new wxButton( this, wxID_ANY, wxT("&Delete"), wxDefaultPosition, wxDefaultSize, 0 );
	buttonsSizer->Add( deleteButton_, 0, wxALL, 5 );
	
	
	buttonsSizer->Add( 0, 0, 1, wxEXPAND, 5 );
	
	closeButton_ = new wxButton( this, wxID_ANY, wxT("&Close"), wxDefaultPosition, wxDefaultSize, 0 );
	buttonsSizer->Add( closeButton_, 0, wxALL, 5 );
	
	dialogSizer->Add( buttonsSizer, 1, wxEXPAND, 5 );
	
	this->SetSizer( dialogSizer );
	this->Layout();
	
	// Connect Events
	this->Connect( wxEVT_CLOSE_WINDOW, wxCloseEventHandler( ItemsDialogBase::onCloseDialog ) );
	this->Connect( wxEVT_INIT_DIALOG, wxInitDialogEventHandler( ItemsDialogBase::onInitDialog ) );
	patternText_->Connect( wxEVT_COMMAND_TEXT_UPDATED, wxCommandEventHandler( ItemsDialogBase::onPatternText ), NULL, this );
	itemList_->Connect( wxEVT_COMMAND_LIST_ITEM_SELECTED, wxListEventHandler( ItemsDialogBase::onItemSelected ), NULL, this );
	renameButton_->Connect( wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler( ItemsDialogBase::onRename ), NULL, this );
	deleteButton_->Connect( wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler( ItemsDialogBase::onDelete ), NULL, this );
	closeButton_->Connect( wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler( ItemsDialogBase::onClose ), NULL, this );
}

ItemsDialogBase::~ItemsDialogBase()
{
}
