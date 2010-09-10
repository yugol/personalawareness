///////////////////////////////////////////////////////////////////////////
// C++ code generated with wxFormBuilder (version Apr 17 2008)
// http://www.wxformbuilder.org/
//
// PLEASE DO "NOT" EDIT THIS FILE!
///////////////////////////////////////////////////////////////////////////

#include "AccountsDialogBase.h"

///////////////////////////////////////////////////////////////////////////

AccountsDialogBase::AccountsDialogBase( wxWindow* parent, wxWindowID id, const wxString& title, const wxPoint& pos, const wxSize& size, long style ) : wxDialog( parent, id, title, pos, size, style )
{
	this->SetSizeHints( wxDefaultSize, wxDefaultSize );
	
	wxBoxSizer* dialogSizer;
	dialogSizer = new wxBoxSizer( wxVERTICAL );
	
	listLabel_ = new wxStaticText( this, wxID_ANY, wxT("Accounts:"), wxDefaultPosition, wxDefaultSize, 0 );
	listLabel_->Wrap( -1 );
	dialogSizer->Add( listLabel_, 0, wxALL, 5 );
	
	wxBoxSizer* largeBottomSizer;
	largeBottomSizer = new wxBoxSizer( wxHORIZONTAL );
	
	wxBoxSizer* leftSizer;
	leftSizer = new wxBoxSizer( wxVERTICAL );
	
	accountList_ = new wxListCtrl( this, wxID_ANY, wxDefaultPosition, wxDefaultSize, wxLC_HRULES|wxLC_LIST|wxLC_NO_HEADER|wxLC_REPORT );
	leftSizer->Add( accountList_, 1, wxALL|wxEXPAND, 5 );
	
	largeBottomSizer->Add( leftSizer, 1, wxEXPAND, 5 );
	
	wxBoxSizer* middleSizer;
	middleSizer = new wxBoxSizer( wxVERTICAL );
	
	nameLabel_ = new wxStaticText( this, wxID_ANY, wxT("Account name:"), wxDefaultPosition, wxDefaultSize, 0 );
	nameLabel_->Wrap( -1 );
	middleSizer->Add( nameLabel_, 0, wxALL, 5 );
	
	nameText_ = new wxTextCtrl( this, wxID_ANY, wxEmptyString, wxDefaultPosition, wxDefaultSize, 0 );
	middleSizer->Add( nameText_, 0, wxALL|wxEXPAND, 5 );
	
	typeLabel_ = new wxStaticText( this, wxID_ANY, wxT("Type:"), wxDefaultPosition, wxDefaultSize, 0 );
	typeLabel_->Wrap( -1 );
	middleSizer->Add( typeLabel_, 0, wxALL, 5 );
	
	wxArrayString typeChoice_Choices;
	typeChoice_ = new wxChoice( this, wxID_ANY, wxDefaultPosition, wxDefaultSize, typeChoice_Choices, 0 );
	typeChoice_->SetSelection( 0 );
	middleSizer->Add( typeChoice_, 0, wxALL|wxEXPAND, 5 );
	
	groupLabel_ = new wxStaticText( this, wxID_ANY, wxT("Group:"), wxDefaultPosition, wxDefaultSize, 0 );
	groupLabel_->Wrap( -1 );
	middleSizer->Add( groupLabel_, 0, wxALL, 5 );
	
	groupCombo_ = new wxComboBox( this, wxID_ANY, wxEmptyString, wxDefaultPosition, wxDefaultSize, 0, NULL, 0 ); 
	middleSizer->Add( groupCombo_, 0, wxALL|wxEXPAND, 5 );
	
	valueLabel_ = new wxStaticText( this, wxID_ANY, wxT("Value:"), wxDefaultPosition, wxDefaultSize, 0 );
	valueLabel_->Wrap( -1 );
	middleSizer->Add( valueLabel_, 0, wxALL, 5 );
	
	valueText_ = new wxTextCtrl( this, wxID_ANY, wxEmptyString, wxDefaultPosition, wxDefaultSize, 0 );
	middleSizer->Add( valueText_, 0, wxALL|wxEXPAND, 5 );
	
	commentLabel_ = new wxStaticText( this, wxID_ANY, wxT("Comment:"), wxDefaultPosition, wxDefaultSize, 0 );
	commentLabel_->Wrap( -1 );
	middleSizer->Add( commentLabel_, 0, wxALL, 5 );
	
	commentText_ = new wxTextCtrl( this, wxID_ANY, wxEmptyString, wxDefaultPosition, wxDefaultSize, wxTE_MULTILINE );
	middleSizer->Add( commentText_, 1, wxALL|wxEXPAND, 5 );
	
	largeBottomSizer->Add( middleSizer, 0, wxEXPAND, 5 );
	
	wxBoxSizer* rightSizer;
	rightSizer = new wxBoxSizer( wxVERTICAL );
	
	insertButton_ = new wxButton( this, wxID_ANY, wxT("&Insert"), wxDefaultPosition, wxDefaultSize, 0 );
	rightSizer->Add( insertButton_, 0, wxALL, 5 );
	
	updateButton_ = new wxButton( this, wxID_ANY, wxT("&Update"), wxDefaultPosition, wxDefaultSize, 0 );
	rightSizer->Add( updateButton_, 0, wxALL, 5 );
	
	deleteButton_ = new wxButton( this, wxID_ANY, wxT("&Delete"), wxDefaultPosition, wxDefaultSize, 0 );
	rightSizer->Add( deleteButton_, 0, wxALL, 5 );
	
	wxStaticText* emptyLabel;
	emptyLabel = new wxStaticText( this, wxID_ANY, wxT(" "), wxDefaultPosition, wxDefaultSize, 0 );
	emptyLabel->Wrap( -1 );
	rightSizer->Add( emptyLabel, 0, wxALL, 5 );
	
	clearButton_ = new wxButton( this, wxID_ANY, wxT("C&lear"), wxDefaultPosition, wxDefaultSize, 0 );
	rightSizer->Add( clearButton_, 0, wxALL, 5 );
	
	
	rightSizer->Add( 0, 0, 1, wxEXPAND, 5 );
	
	closeButton_ = new wxButton( this, wxID_ANY, wxT("&Close"), wxDefaultPosition, wxDefaultSize, 0 );
	rightSizer->Add( closeButton_, 0, wxALL, 5 );
	
	largeBottomSizer->Add( rightSizer, 0, wxEXPAND, 5 );
	
	dialogSizer->Add( largeBottomSizer, 1, wxEXPAND, 5 );
	
	this->SetSizer( dialogSizer );
	this->Layout();
	
	// Connect Events
	this->Connect( wxEVT_CLOSE_WINDOW, wxCloseEventHandler( AccountsDialogBase::onCloseDialog ) );
	this->Connect( wxEVT_INIT_DIALOG, wxInitDialogEventHandler( AccountsDialogBase::onInitDialog ) );
	accountList_->Connect( wxEVT_COMMAND_LIST_ITEM_SELECTED, wxListEventHandler( AccountsDialogBase::onSelectAccount ), NULL, this );
	nameText_->Connect( wxEVT_COMMAND_TEXT_UPDATED, wxCommandEventHandler( AccountsDialogBase::onNameText ), NULL, this );
	typeChoice_->Connect( wxEVT_COMMAND_CHOICE_SELECTED, wxCommandEventHandler( AccountsDialogBase::onTypeChange ), NULL, this );
	groupCombo_->Connect( wxEVT_COMMAND_TEXT_UPDATED, wxCommandEventHandler( AccountsDialogBase::onGroupText ), NULL, this );
	valueText_->Connect( wxEVT_COMMAND_TEXT_UPDATED, wxCommandEventHandler( AccountsDialogBase::onValueText ), NULL, this );
	commentText_->Connect( wxEVT_COMMAND_TEXT_UPDATED, wxCommandEventHandler( AccountsDialogBase::onCommentText ), NULL, this );
	insertButton_->Connect( wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler( AccountsDialogBase::onInsert ), NULL, this );
	updateButton_->Connect( wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler( AccountsDialogBase::onUpdate ), NULL, this );
	deleteButton_->Connect( wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler( AccountsDialogBase::onDelete ), NULL, this );
	clearButton_->Connect( wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler( AccountsDialogBase::onClear ), NULL, this );
	closeButton_->Connect( wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler( AccountsDialogBase::onClose ), NULL, this );
}

AccountsDialogBase::~AccountsDialogBase()
{
}
