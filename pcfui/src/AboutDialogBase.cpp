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
	
	sectionsNotebook_ = new wxNotebook( this, wxID_ANY, wxDefaultPosition, wxDefaultSize, 0 );
	applicationPage_ = new wxPanel( sectionsNotebook_, wxID_ANY, wxDefaultPosition, wxDefaultSize, wxTAB_TRAVERSAL );
	wxBoxSizer* applicationPageSizer;
	applicationPageSizer = new wxBoxSizer( wxHORIZONTAL );
	
	wxBoxSizer* iconSizer_;
	iconSizer_ = new wxBoxSizer( wxVERTICAL );
	
	
	iconSizer_->Add( 0, 0, 1, wxEXPAND, 5 );
	
	iconBitmap_ = new wxStaticBitmap( applicationPage_, wxID_ANY, wxNullBitmap, wxDefaultPosition, wxDefaultSize, 0 );
	iconSizer_->Add( iconBitmap_, 1, wxBOTTOM|wxLEFT|wxTOP, 5 );
	
	
	iconSizer_->Add( 0, 0, 1, wxEXPAND, 5 );
	
	applicationPageSizer->Add( iconSizer_, 0, wxEXPAND|wxLEFT, 5 );
	
	wxBoxSizer* linesSizer;
	linesSizer = new wxBoxSizer( wxVERTICAL );
	
	
	linesSizer->Add( 0, 0, 2, wxEXPAND, 5 );
	
	wxBoxSizer* nameSizer;
	nameSizer = new wxBoxSizer( wxHORIZONTAL );
	
	
	nameSizer->Add( 0, 0, 1, wxEXPAND, 5 );
	
	projectNameLabel_ = new wxStaticText( applicationPage_, wxID_ANY, wxT("Project name"), wxDefaultPosition, wxDefaultSize, 0 );
	projectNameLabel_->Wrap( -1 );
	projectNameLabel_->SetFont( wxFont( 16, 70, 90, 92, false, wxEmptyString ) );
	
	nameSizer->Add( projectNameLabel_, 0, wxALL, 5 );
	
	
	nameSizer->Add( 0, 0, 1, wxEXPAND, 5 );
	
	linesSizer->Add( nameSizer, 0, wxEXPAND, 15 );
	
	wxBoxSizer* versionSizer;
	versionSizer = new wxBoxSizer( wxHORIZONTAL );
	
	
	versionSizer->Add( 0, 0, 1, wxEXPAND, 5 );
	
	versionLabel_ = new wxStaticText( applicationPage_, wxID_ANY, wxT("project version"), wxDefaultPosition, wxDefaultSize, 0 );
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
	
	
	linesSizer->Add( 0, 0, 3, wxEXPAND, 5 );
	
	applicationPageSizer->Add( linesSizer, 1, wxEXPAND|wxRIGHT, 5 );
	
	applicationPage_->SetSizer( applicationPageSizer );
	applicationPage_->Layout();
	applicationPageSizer->Fit( applicationPage_ );
	sectionsNotebook_->AddPage( applicationPage_, wxT("Application"), false );
	databasePage_ = new wxPanel( sectionsNotebook_, wxID_ANY, wxDefaultPosition, wxDefaultSize, wxTAB_TRAVERSAL );
	wxBoxSizer* databaseSizer;
	databaseSizer = new wxBoxSizer( wxVERTICAL );
	
	databaseText_ = new wxTextCtrl( databasePage_, wxID_ANY, wxEmptyString, wxDefaultPosition, wxDefaultSize, wxTE_MULTILINE|wxTE_READONLY|wxTE_WORDWRAP );
	databaseSizer->Add( databaseText_, 1, wxALL|wxEXPAND, 10 );
	
	databasePage_->SetSizer( databaseSizer );
	databasePage_->Layout();
	databaseSizer->Fit( databasePage_ );
	sectionsNotebook_->AddPage( databasePage_, wxT("Database"), false );
	changesPage_ = new wxPanel( sectionsNotebook_, wxID_ANY, wxDefaultPosition, wxDefaultSize, wxTAB_TRAVERSAL );
	wxBoxSizer* changesSizer;
	changesSizer = new wxBoxSizer( wxVERTICAL );
	
	changesText_ = new wxTextCtrl( changesPage_, wxID_ANY, wxEmptyString, wxDefaultPosition, wxDefaultSize, wxTE_MULTILINE|wxTE_READONLY|wxTE_WORDWRAP );
	changesSizer->Add( changesText_, 1, wxALL|wxEXPAND, 10 );
	
	changesPage_->SetSizer( changesSizer );
	changesPage_->Layout();
	changesSizer->Fit( changesPage_ );
	sectionsNotebook_->AddPage( changesPage_, wxT("Changes"), false );
	creditsPage_ = new wxPanel( sectionsNotebook_, wxID_ANY, wxDefaultPosition, wxDefaultSize, wxTAB_TRAVERSAL );
	wxBoxSizer* creditsSizer;
	creditsSizer = new wxBoxSizer( wxVERTICAL );
	
	creditsText_ = new wxTextCtrl( creditsPage_, wxID_ANY, wxT("\nSQLite\nhttp://www.sqlite.org/\n\nwxWidgets\nhttp://www.wxwidgets.org/\n"), wxDefaultPosition, wxDefaultSize, wxTE_MULTILINE|wxTE_READONLY|wxTE_WORDWRAP );
	creditsSizer->Add( creditsText_, 1, wxALL|wxEXPAND, 10 );
	
	creditsPage_->SetSizer( creditsSizer );
	creditsPage_->Layout();
	creditsSizer->Fit( creditsPage_ );
	sectionsNotebook_->AddPage( creditsPage_, wxT("Dependencies"), false );
	licensePage_ = new wxPanel( sectionsNotebook_, wxID_ANY, wxDefaultPosition, wxDefaultSize, wxTAB_TRAVERSAL );
	wxBoxSizer* licenseSizer;
	licenseSizer = new wxBoxSizer( wxVERTICAL );
	
	licenseText_ = new wxTextCtrl( licensePage_, wxID_ANY, wxT("\nPersonal Cash Flow\nCopyright (C) 2010 Iulian Goriac (iulian.goriac@gmail.com)\n\nThis program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.\n\nThis program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.\n\nYou should have received a copy of the GNU General Public License along with this program. If not, see\n<http://www.gnu.org/licenses/>.\n"), wxDefaultPosition, wxDefaultSize, wxTE_MULTILINE|wxTE_READONLY|wxTE_WORDWRAP );
	licenseSizer->Add( licenseText_, 1, wxALL|wxEXPAND, 10 );
	
	licensePage_->SetSizer( licenseSizer );
	licensePage_->Layout();
	licenseSizer->Fit( licensePage_ );
	sectionsNotebook_->AddPage( licensePage_, wxT("License"), true );
	
	dialogSizer->Add( sectionsNotebook_, 1, wxEXPAND|wxLEFT|wxRIGHT|wxTOP, 5 );
	
	wxBoxSizer* closeButtonSizer;
	closeButtonSizer = new wxBoxSizer( wxHORIZONTAL );
	
	
	closeButtonSizer->Add( 0, 0, 1, wxEXPAND, 5 );
	
	closeButton_ = new wxButton( this, wxID_ANY, wxT("&Close"), wxDefaultPosition, wxDefaultSize, 0 );
	closeButtonSizer->Add( closeButton_, 0, wxALL, 5 );
	
	
	closeButtonSizer->Add( 0, 0, 1, wxEXPAND, 5 );
	
	dialogSizer->Add( closeButtonSizer, 0, wxEXPAND, 5 );
	
	this->SetSizer( dialogSizer );
	this->Layout();
	
	// Connect Events
	closeButton_->Connect( wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler( AboutDialogBase::onClose ), NULL, this );
}

AboutDialogBase::~AboutDialogBase()
{
}
