///////////////////////////////////////////////////////////////////////////
// C++ code generated with wxFormBuilder (version Apr 17 2008)
// http://www.wxformbuilder.org/
//
// PLEASE DO "NOT" EDIT THIS FILE!
///////////////////////////////////////////////////////////////////////////

#include "AboutDialogBase.h"

///////////////////////////////////////////////////////////////////////////

AboutDialogBase::AboutDialogBase( wxWindow* parent, wxWindowID id, const wxString& title, const wxPoint& pos, const wxSize& size, long style ) : wxDialog( parent, id, title, pos, size, style )
{
	this->SetSizeHints( wxDefaultSize, wxDefaultSize );
	
	wxBoxSizer* dialogSizer;
	dialogSizer = new wxBoxSizer( wxVERTICAL );
	
	sectionsNotebook_ = new wxNotebook( this, wxID_ANY, wxDefaultPosition, wxDefaultSize, wxNB_BOTTOM );
	applicationPage_ = new wxPanel( sectionsNotebook_, wxID_ANY, wxDefaultPosition, wxDefaultSize, wxTAB_TRAVERSAL );
	wxBoxSizer* applicationPageSizer;
	applicationPageSizer = new wxBoxSizer( wxHORIZONTAL );
	
	iconBitmap_ = new wxStaticBitmap( applicationPage_, wxID_ANY, wxNullBitmap, wxDefaultPosition, wxDefaultSize, 0 );
	applicationPageSizer->Add( iconBitmap_, 0, wxALL, 5 );
	
	wxBoxSizer* linesSizer;
	linesSizer = new wxBoxSizer( wxVERTICAL );
	
	wxBoxSizer* nameSizer;
	nameSizer = new wxBoxSizer( wxHORIZONTAL );
	
	
	nameSizer->Add( 0, 0, 1, wxEXPAND, 5 );
	
	personalLabel_ = new wxStaticText( applicationPage_, wxID_ANY, wxT("Personal"), wxDefaultPosition, wxDefaultSize, 0 );
	personalLabel_->Wrap( -1 );
	personalLabel_->SetFont( wxFont( 16, 70, 90, 92, false, wxEmptyString ) );
	
	nameSizer->Add( personalLabel_, 0, wxALL, 2 );
	
	awarenessLabel_ = new wxStaticText( applicationPage_, wxID_ANY, wxT("Awareness"), wxDefaultPosition, wxDefaultSize, 0 );
	awarenessLabel_->Wrap( -1 );
	awarenessLabel_->SetFont( wxFont( 16, 70, 93, 92, false, wxEmptyString ) );
	
	nameSizer->Add( awarenessLabel_, 0, wxALL, 2 );
	
	
	nameSizer->Add( 0, 0, 1, wxEXPAND, 5 );
	
	linesSizer->Add( nameSizer, 0, wxEXPAND|wxTOP, 20 );
	
	wxBoxSizer* versionSizer;
	versionSizer = new wxBoxSizer( wxHORIZONTAL );
	
	
	versionSizer->Add( 0, 0, 1, wxEXPAND, 5 );
	
	versionLabel_ = new wxStaticText( applicationPage_, wxID_ANY, wxT("version"), wxDefaultPosition, wxDefaultSize, 0 );
	versionLabel_->Wrap( -1 );
	versionLabel_->SetFont( wxFont( 14, 70, 90, 90, false, wxEmptyString ) );
	
	versionSizer->Add( versionLabel_, 0, wxALL, 2 );
	
	
	versionSizer->Add( 0, 0, 1, wxEXPAND, 5 );
	
	linesSizer->Add( versionSizer, 0, wxEXPAND, 5 );
	
	wxBoxSizer* usageSizer;
	usageSizer = new wxBoxSizer( wxHORIZONTAL );
	
	
	usageSizer->Add( 0, 0, 1, wxEXPAND, 5 );
	
	usageLabel_ = new wxStaticText( applicationPage_, wxID_ANY, wxT("A simple pesonal financial management application"), wxDefaultPosition, wxDefaultSize, wxALIGN_CENTRE );
	usageLabel_->Wrap( 250 );
	usageSizer->Add( usageLabel_, 0, wxALL, 10 );
	
	
	usageSizer->Add( 0, 0, 1, wxEXPAND, 5 );
	
	linesSizer->Add( usageSizer, 0, wxEXPAND, 5 );
	
	wxBoxSizer* copyrightSizer;
	copyrightSizer = new wxBoxSizer( wxHORIZONTAL );
	
	
	copyrightSizer->Add( 0, 0, 1, wxEXPAND, 5 );
	
	copyrightLabel_ = new wxStaticText( applicationPage_, wxID_ANY, wxT("Copyright © 2010 Iulian Goriac "), wxDefaultPosition, wxDefaultSize, 0 );
	copyrightLabel_->Wrap( -1 );
	copyrightSizer->Add( copyrightLabel_, 0, wxALL, 5 );
	
	
	copyrightSizer->Add( 0, 0, 1, wxEXPAND, 5 );
	
	linesSizer->Add( copyrightSizer, 0, wxEXPAND, 5 );
	
	
	linesSizer->Add( 0, 0, 1, wxEXPAND, 5 );
	
	applicationPageSizer->Add( linesSizer, 1, wxEXPAND, 5 );
	
	applicationPage_->SetSizer( applicationPageSizer );
	applicationPage_->Layout();
	applicationPageSizer->Fit( applicationPage_ );
	sectionsNotebook_->AddPage( applicationPage_, wxT("Application"), true );
	creditsPage_ = new wxPanel( sectionsNotebook_, wxID_ANY, wxDefaultPosition, wxDefaultSize, wxTAB_TRAVERSAL );
	creditsPage_->Hide();
	
	sectionsNotebook_->AddPage( creditsPage_, wxT("Credits"), false );
	licensePage_ = new wxPanel( sectionsNotebook_, wxID_ANY, wxDefaultPosition, wxDefaultSize, wxTAB_TRAVERSAL );
	wxBoxSizer* licenseSizer;
	licenseSizer = new wxBoxSizer( wxVERTICAL );
	
	licenseText_ = new wxTextCtrl( licensePage_, wxID_ANY, wxT("Copyright (c) 2010 Iulian Goriac\n\nPermission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the \"Software\"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:\n\nThe above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.\n\nTHE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE."), wxDefaultPosition, wxDefaultSize, wxTE_MULTILINE|wxTE_READONLY|wxTE_WORDWRAP );
	licenseSizer->Add( licenseText_, 1, wxALL|wxEXPAND, 10 );
	
	licensePage_->SetSizer( licenseSizer );
	licensePage_->Layout();
	licenseSizer->Fit( licensePage_ );
	sectionsNotebook_->AddPage( licensePage_, wxT("License"), false );
	
	dialogSizer->Add( sectionsNotebook_, 1, wxEXPAND|wxLEFT|wxRIGHT|wxTOP, 5 );
	
	closeButton_ = new wxButton( this, wxID_ANY, wxT("&Close"), wxDefaultPosition, wxDefaultSize, 0 );
	dialogSizer->Add( closeButton_, 0, wxALIGN_RIGHT|wxBOTTOM|wxRIGHT, 5 );
	
	this->SetSizer( dialogSizer );
	this->Layout();
	
	// Connect Events
	this->Connect( wxEVT_INIT_DIALOG, wxInitDialogEventHandler( AboutDialogBase::onInitDialog ) );
	closeButton_->Connect( wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler( AboutDialogBase::onClose ), NULL, this );
}

AboutDialogBase::~AboutDialogBase()
{
}
