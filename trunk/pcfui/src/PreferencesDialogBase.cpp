///////////////////////////////////////////////////////////////////////////
// C++ code generated with wxFormBuilder (version Apr 17 2008)
// http://www.wxformbuilder.org/
//
// PLEASE DO "NOT" EDIT THIS FILE!
///////////////////////////////////////////////////////////////////////////

#include "PreferencesDialogBase.h"

///////////////////////////////////////////////////////////////////////////

PreferencesDialogBase::PreferencesDialogBase( wxWindow* parent, wxWindowID id, const wxString& title, const wxPoint& pos, const wxSize& size, long style ) : wxDialog( parent, id, title, pos, size, style )
{
	this->SetSizeHints( wxDefaultSize, wxDefaultSize );
	
	wxBoxSizer* dialogSizer;
	dialogSizer = new wxBoxSizer( wxVERTICAL );
	
	propertiesNotebook_ = new wxNotebook( this, wxID_ANY, wxDefaultPosition, wxDefaultSize, 0 );
	viewPage_ = new wxPanel( propertiesNotebook_, wxID_ANY, wxDefaultPosition, wxDefaultSize, wxTAB_TRAVERSAL );
	wxStaticBoxSizer* transactionsViewGroup;
	transactionsViewGroup = new wxStaticBoxSizer( new wxStaticBox( viewPage_, wxID_ANY, wxT(" Transactions ") ), wxVERTICAL );
	
	compactTransactionsViewCkBox_ = new wxCheckBox( viewPage_, wxID_ANY, wxT("Display compact transactions in list"), wxDefaultPosition, wxDefaultSize, 0 );
	
	transactionsViewGroup->Add( compactTransactionsViewCkBox_, 0, wxALL, 5 );
	
	viewPage_->SetSizer( transactionsViewGroup );
	viewPage_->Layout();
	transactionsViewGroup->Fit( viewPage_ );
	propertiesNotebook_->AddPage( viewPage_, wxT("View"), true );
	formattingPage_ = new wxPanel( propertiesNotebook_, wxID_ANY, wxDefaultPosition, wxDefaultSize, wxTAB_TRAVERSAL );
	wxStaticBoxSizer* currencyFormattingGroup;
	currencyFormattingGroup = new wxStaticBoxSizer( new wxStaticBox( formattingPage_, wxID_ANY, wxT(" Currency ") ), wxVERTICAL );
	
	wxGridSizer* currencySizer;
	currencySizer = new wxGridSizer( 3, 1, 0, 0 );
	
	wxBoxSizer* currencySymbolSizer;
	currencySymbolSizer = new wxBoxSizer( wxHORIZONTAL );
	
	currencySymbolLabel_ = new wxStaticText( formattingPage_, wxID_ANY, wxT("Symbol:"), wxDefaultPosition, wxDefaultSize, 0 );
	currencySymbolLabel_->Wrap( -1 );
	currencySymbolSizer->Add( currencySymbolLabel_, 0, wxALIGN_CENTER_VERTICAL|wxALL, 5 );
	
	currencySymbolText_ = new wxTextCtrl( formattingPage_, wxID_ANY, wxEmptyString, wxDefaultPosition, wxDefaultSize, 0 );
	currencySymbolSizer->Add( currencySymbolText_, 0, wxALIGN_CENTER_VERTICAL|wxALL, 5 );
	
	currencySizer->Add( currencySymbolSizer, 0, wxALL|wxEXPAND, 5 );
	
	wxBoxSizer* currencyPositionSizer;
	currencyPositionSizer = new wxBoxSizer( wxHORIZONTAL );
	
	currencyPositionCheckBox_ = new wxCheckBox( formattingPage_, wxID_ANY, wxT("Prefix symbol"), wxDefaultPosition, wxDefaultSize, 0 );
	
	currencyPositionSizer->Add( currencyPositionCheckBox_, 0, wxALIGN_CENTER_VERTICAL|wxALL, 5 );
	
	currencySizer->Add( currencyPositionSizer, 0, wxALL|wxEXPAND, 5 );
	
	
	currencySizer->Add( 0, 0, 1, wxEXPAND, 5 );
	
	currencyFormattingGroup->Add( currencySizer, 1, wxEXPAND, 5 );
	
	formattingPage_->SetSizer( currencyFormattingGroup );
	formattingPage_->Layout();
	currencyFormattingGroup->Fit( formattingPage_ );
	propertiesNotebook_->AddPage( formattingPage_, wxT("Formatting"), false );
	internalsPage_ = new wxPanel( propertiesNotebook_, wxID_ANY, wxDefaultPosition, wxDefaultSize, wxTAB_TRAVERSAL );
	wxStaticBoxSizer* unicodeInternalsGroup;
	unicodeInternalsGroup = new wxStaticBoxSizer( new wxStaticBox( internalsPage_, wxID_ANY, wxT(" Unicode ") ), wxVERTICAL );
	
	treatNonAsciiCharsIdenticallyCheckBox_ = new wxCheckBox( internalsPage_, wxID_ANY, wxT("Treat all non-ASCII chars as being identical"), wxDefaultPosition, wxDefaultSize, 0 );
	
	unicodeInternalsGroup->Add( treatNonAsciiCharsIdenticallyCheckBox_, 0, wxALL, 5 );
	
	internalsPage_->SetSizer( unicodeInternalsGroup );
	internalsPage_->Layout();
	unicodeInternalsGroup->Fit( internalsPage_ );
	propertiesNotebook_->AddPage( internalsPage_, wxT("Internals"), false );
	
	dialogSizer->Add( propertiesNotebook_, 1, wxEXPAND | wxALL, 5 );
	
	buttonsSizer_ = new wxStdDialogButtonSizer();
	buttonsSizer_OK = new wxButton( this, wxID_OK );
	buttonsSizer_->AddButton( buttonsSizer_OK );
	buttonsSizer_Cancel = new wxButton( this, wxID_CANCEL );
	buttonsSizer_->AddButton( buttonsSizer_Cancel );
	buttonsSizer_->Realize();
	dialogSizer->Add( buttonsSizer_, 0, wxALL|wxEXPAND, 5 );
	
	this->SetSizer( dialogSizer );
	this->Layout();
	
	// Connect Events
	this->Connect( wxEVT_INIT_DIALOG, wxInitDialogEventHandler( PreferencesDialogBase::onInitDialog ) );
}

PreferencesDialogBase::~PreferencesDialogBase()
{
	// Disconnect Events
	this->Disconnect( wxEVT_INIT_DIALOG, wxInitDialogEventHandler( PreferencesDialogBase::onInitDialog ) );
}
