///////////////////////////////////////////////////////////////////////////
// C++ code generated with wxFormBuilder (version Apr 17 2008)
// http://www.wxformbuilder.org/
//
// PLEASE DO "NOT" EDIT THIS FILE!
///////////////////////////////////////////////////////////////////////////

#include "MainWindowBase.h"

///////////////////////////////////////////////////////////////////////////

MainWindowBase::MainWindowBase( wxWindow* parent, wxWindowID id, const wxString& title, const wxPoint& pos, const wxSize& size, long style ) : wxFrame( parent, id, title, pos, size, style )
{
	this->SetSizeHints( wxDefaultSize, wxDefaultSize );
	
	mainMenu_ = new wxMenuBar( 0 );
	databaseMenu_ = new wxMenu();
	wxMenuItem* openCreateMenuItem_;
	openCreateMenuItem_ = new wxMenuItem( databaseMenu_, wxID_ANY, wxString( wxT("&Open/Create...") ) , wxT("Open database or create a new one"), wxITEM_NORMAL );
	databaseMenu_->Append( openCreateMenuItem_ );
	
	databaseMenu_->AppendSeparator();
	
	wxMenuItem* optimizeMenuItem_;
	optimizeMenuItem_ = new wxMenuItem( databaseMenu_, wxID_ANY, wxString( wxT("O&ptimize...") ) , wxEmptyString, wxITEM_NORMAL );
	databaseMenu_->Append( optimizeMenuItem_ );
	
	databaseMenu_->AppendSeparator();
	
	exportSqlMenuItem_ = new wxMenuItem( databaseMenu_, wxID_ANY, wxString( wxT("&Export") ) , wxT("Export database as SQL script"), wxITEM_NORMAL );
	databaseMenu_->Append( exportSqlMenuItem_ );
	
	importSqlMenuItem_ = new wxMenuItem( databaseMenu_, wxID_ANY, wxString( wxT("&Import") ) , wxT("Import database from SQL script"), wxITEM_NORMAL );
	databaseMenu_->Append( importSqlMenuItem_ );
	
	databaseMenu_->AppendSeparator();
	
	wxMenuItem* exitMenuItem_;
	exitMenuItem_ = new wxMenuItem( databaseMenu_, wxID_ANY, wxString( wxT("E&xit") ) + wxT('\t') + wxT("Alt+F4"), wxT("Exit the application"), wxITEM_NORMAL );
	databaseMenu_->Append( exitMenuItem_ );
	
	mainMenu_->Append( databaseMenu_, wxT("Data&base") );
	
	editMenu_ = new wxMenu();
	undoMenuItem_ = new wxMenuItem( editMenu_, wxID_ANY, wxString( wxT("&Undo") ) , wxEmptyString, wxITEM_NORMAL );
	editMenu_->Append( undoMenuItem_ );
	
	redoMenuItem_ = new wxMenuItem( editMenu_, wxID_ANY, wxString( wxT("&Redo") ) , wxEmptyString, wxITEM_NORMAL );
	editMenu_->Append( redoMenuItem_ );
	
	editMenu_->AppendSeparator();
	
	wxMenuItem* accountsMenuItem;
	accountsMenuItem = new wxMenuItem( editMenu_, wxID_ANY, wxString( wxT("&Accounts...") ) , wxT("Edit accounts"), wxITEM_NORMAL );
	editMenu_->Append( accountsMenuItem );
	
	wxMenuItem* itemsMenuItems;
	itemsMenuItems = new wxMenuItem( editMenu_, wxID_ANY, wxString( wxT("Transacted &Items...") ) , wxT("Edit transacted items"), wxITEM_NORMAL );
	editMenu_->Append( itemsMenuItems );
	
	editMenu_->AppendSeparator();
	
	wxMenuItem* preferencesMenuItem;
	preferencesMenuItem = new wxMenuItem( editMenu_, wxID_ANY, wxString( wxT("&Preferences...") ) , wxT("Edit preferences"), wxITEM_NORMAL );
	editMenu_->Append( preferencesMenuItem );
	
	mainMenu_->Append( editMenu_, wxT("&Edit") );
	
	helpMenu_ = new wxMenu();
	wxMenuItem* manualMenuItem;
	manualMenuItem = new wxMenuItem( helpMenu_, wxID_ANY, wxString( wxT("User &Manual") ) + wxT('\t') + wxT("F1"), wxT("Show the help window"), wxITEM_NORMAL );
	helpMenu_->Append( manualMenuItem );
	
	wxMenuItem* homepageMenuItem;
	homepageMenuItem = new wxMenuItem( helpMenu_, wxID_ANY, wxString( wxT("&Web Page") ) , wxT("Navigate to the application's homepage"), wxITEM_NORMAL );
	helpMenu_->Append( homepageMenuItem );
	
	helpMenu_->AppendSeparator();
	
	wxMenuItem* aboutMenuItem;
	aboutMenuItem = new wxMenuItem( helpMenu_, wxID_ANY, wxString( wxT("&About") ) , wxT("Display info about the application"), wxITEM_NORMAL );
	helpMenu_->Append( aboutMenuItem );
	
	mainMenu_->Append( helpMenu_, wxT("&Help") );
	
	this->SetMenuBar( mainMenu_ );
	
	wxBoxSizer* frameSizer;
	frameSizer = new wxBoxSizer( wxVERTICAL );
	
	financialPages_ = new wxNotebook( this, wxID_ANY, wxDefaultPosition, wxDefaultSize, 0 );
	accountsPage_ = new wxPanel( financialPages_, wxID_ANY, wxDefaultPosition, wxDefaultSize, wxTAB_TRAVERSAL );
	accountsSizer_ = new wxBoxSizer( wxVERTICAL );
	
	accountList_ = new wxListCtrl( accountsPage_, wxID_ANY, wxDefaultPosition, wxDefaultSize, wxLC_HRULES|wxLC_REPORT );
	accountsSizer_->Add( accountList_, 1, wxALL|wxEXPAND, 5 );
	
	wxBoxSizer* accountsBottomSizer;
	accountsBottomSizer = new wxBoxSizer( wxHORIZONTAL );
	
	
	accountsBottomSizer->Add( 0, 0, 1, wxEXPAND, 5 );
	
	netBalanceLabel_ = new wxStaticText( accountsPage_, wxID_ANY, wxT("Net balance: 0 '"), wxDefaultPosition, wxDefaultSize, 0 );
	netBalanceLabel_->Wrap( -1 );
	netBalanceLabel_->SetFont( wxFont( wxNORMAL_FONT->GetPointSize(), 70, 90, 92, false, wxEmptyString ) );
	
	accountsBottomSizer->Add( netBalanceLabel_, 0, wxALL, 5 );
	
	accountsSizer_->Add( accountsBottomSizer, 0, wxEXPAND, 5 );
	
	accountsPage_->SetSizer( accountsSizer_ );
	accountsPage_->Layout();
	accountsSizer_->Fit( accountsPage_ );
	financialPages_->AddPage( accountsPage_, wxT("Statement"), true );
	transactionsPage_ = new wxPanel( financialPages_, wxID_ANY, wxDefaultPosition, wxDefaultSize, wxTAB_TRAVERSAL );
	transactionsSizer_ = new wxBoxSizer( wxVERTICAL );
	
	wxBoxSizer* topTransactionsSizer;
	topTransactionsSizer = new wxBoxSizer( wxHORIZONTAL );
	
	selectionViewButton_ = new wxButton( transactionsPage_, wxID_ANY, wxT("."), wxDefaultPosition, wxSize( 16,16 ), 0 );
	topTransactionsSizer->Add( selectionViewButton_, 0, wxALL, 5 );
	
	selectionPanel_ = new wxPanel( transactionsPage_, wxID_ANY, wxDefaultPosition, wxDefaultSize, wxTAB_TRAVERSAL );
	wxBoxSizer* selectionReportsSizer;
	selectionReportsSizer = new wxBoxSizer( wxHORIZONTAL );
	
	wxBoxSizer* selectionSizer;
	selectionSizer = new wxBoxSizer( wxVERTICAL );
	
	wxBoxSizer* selectionTopSizer;
	selectionTopSizer = new wxBoxSizer( wxHORIZONTAL );
	
	periodLabel_ = new wxStaticText( selectionPanel_, wxID_ANY, wxT("Period"), wxDefaultPosition, wxDefaultSize, 0 );
	periodLabel_->Wrap( -1 );
	selectionTopSizer->Add( periodLabel_, 0, wxALIGN_CENTER_VERTICAL|wxLEFT, 5 );
	
	wxArrayString selIntervalChoice_Choices;
	selIntervalChoice_ = new wxChoice( selectionPanel_, wxID_ANY, wxDefaultPosition, wxDefaultSize, selIntervalChoice_Choices, 0 );
	selIntervalChoice_->SetSelection( 0 );
	selectionTopSizer->Add( selIntervalChoice_, 1, wxALL|wxEXPAND, 5 );
	
	selFromLabel_ = new wxStaticText( selectionPanel_, wxID_ANY, wxT("from"), wxDefaultPosition, wxDefaultSize, 0 );
	selFromLabel_->Wrap( -1 );
	selectionTopSizer->Add( selFromLabel_, 0, wxALIGN_CENTER_VERTICAL|wxLEFT, 5 );
	
	selFirstDatePicker_ = new wxDatePickerCtrl( selectionPanel_, wxID_ANY, wxDefaultDateTime, wxDefaultPosition, wxDefaultSize, wxDP_DEFAULT|wxDP_SHOWCENTURY );
	selectionTopSizer->Add( selFirstDatePicker_, 1, wxALL|wxEXPAND, 5 );
	
	selToLabel_ = new wxStaticText( selectionPanel_, wxID_ANY, wxT("to"), wxDefaultPosition, wxDefaultSize, 0 );
	selToLabel_->Wrap( -1 );
	selectionTopSizer->Add( selToLabel_, 0, wxALIGN_CENTER_VERTICAL|wxLEFT, 5 );
	
	selLastDatePicker_ = new wxDatePickerCtrl( selectionPanel_, wxID_ANY, wxDefaultDateTime, wxDefaultPosition, wxDefaultSize, wxDP_DEFAULT|wxDP_SHOWCENTURY );
	selectionTopSizer->Add( selLastDatePicker_, 1, wxALL|wxEXPAND, 5 );
	
	selectionSizer->Add( selectionTopSizer, 0, wxEXPAND, 5 );
	
	wxBoxSizer* selectionBottomSizer;
	selectionBottomSizer = new wxBoxSizer( wxHORIZONTAL );
	
	accountLabel_ = new wxStaticText( selectionPanel_, wxID_ANY, wxT("Account"), wxDefaultPosition, wxDefaultSize, 0 );
	accountLabel_->Wrap( -1 );
	selectionBottomSizer->Add( accountLabel_, 0, wxALIGN_CENTER_VERTICAL|wxBOTTOM|wxLEFT, 5 );
	
	wxArrayString selAccountChoice_Choices;
	selAccountChoice_ = new wxChoice( selectionPanel_, wxID_ANY, wxDefaultPosition, wxDefaultSize, selAccountChoice_Choices, 0 );
	selAccountChoice_->SetSelection( 0 );
	selectionBottomSizer->Add( selAccountChoice_, 1, wxBOTTOM|wxEXPAND|wxLEFT|wxRIGHT, 5 );
	
	itemsLikeLabel_ = new wxStaticText( selectionPanel_, wxID_ANY, wxT("Items like"), wxDefaultPosition, wxDefaultSize, 0 );
	itemsLikeLabel_->Wrap( -1 );
	selectionBottomSizer->Add( itemsLikeLabel_, 0, wxALIGN_CENTER_VERTICAL|wxBOTTOM|wxLEFT, 5 );
	
	selPatternText_ = new wxTextCtrl( selectionPanel_, wxID_ANY, wxEmptyString, wxDefaultPosition, wxDefaultSize, 0 );
	selectionBottomSizer->Add( selPatternText_, 1, wxBOTTOM|wxEXPAND|wxLEFT|wxRIGHT, 5 );
	
	selectionSizer->Add( selectionBottomSizer, 0, wxEXPAND, 5 );
	
	selectionReportsSizer->Add( selectionSizer, 1, wxEXPAND, 5 );
	
	reportsButton_ = new wxButton( selectionPanel_, wxID_ANY, wxT("&Reports"), wxDefaultPosition, wxDefaultSize, 0 );
	selectionReportsSizer->Add( reportsButton_, 0, wxALL, 5 );
	
	selectionPanel_->SetSizer( selectionReportsSizer );
	selectionPanel_->Layout();
	selectionReportsSizer->Fit( selectionPanel_ );
	topTransactionsSizer->Add( selectionPanel_, 1, wxEXPAND | wxALL, 0 );
	
	transactionsSizer_->Add( topTransactionsSizer, 0, wxEXPAND, 5 );
	
	middleTransactionsSizer_ = new wxBoxSizer( wxVERTICAL );
	
	transactionsSizer_->Add( middleTransactionsSizer_, 1, wxEXPAND, 5 );
	
	wxBoxSizer* bottomTransactionsSizer;
	bottomTransactionsSizer = new wxBoxSizer( wxHORIZONTAL );
	
	transactionsViewButton_ = new wxButton( transactionsPage_, wxID_ANY, wxT("."), wxDefaultPosition, wxSize( 16,16 ), 0 );
	bottomTransactionsSizer->Add( transactionsViewButton_, 0, wxALL, 5 );
	
	transactionPanel_ = new wxPanel( transactionsPage_, wxID_ANY, wxDefaultPosition, wxDefaultSize, wxTAB_TRAVERSAL );
	wxBoxSizer* transactionSizer;
	transactionSizer = new wxBoxSizer( wxVERTICAL );
	
	wxBoxSizer* transactionTopSizer;
	transactionTopSizer = new wxBoxSizer( wxHORIZONTAL );
	
	dateLabel_ = new wxStaticText( transactionPanel_, wxID_ANY, wxT("Date"), wxDefaultPosition, wxDefaultSize, 0 );
	dateLabel_->Wrap( -1 );
	transactionTopSizer->Add( dateLabel_, 0, wxALIGN_CENTER_VERTICAL|wxLEFT, 5 );
	
	trDatePicker_ = new wxDatePickerCtrl( transactionPanel_, wxID_ANY, wxDefaultDateTime, wxDefaultPosition, wxDefaultSize, wxDP_DEFAULT|wxDP_SHOWCENTURY );
	transactionTopSizer->Add( trDatePicker_, 2, wxALL|wxEXPAND, 5 );
	
	itemLabel_ = new wxStaticText( transactionPanel_, wxID_ANY, wxT("Item"), wxDefaultPosition, wxDefaultSize, 0 );
	itemLabel_->Wrap( -1 );
	transactionTopSizer->Add( itemLabel_, 0, wxALIGN_CENTER_VERTICAL|wxLEFT, 5 );
	
	trItemText_ = new wxTextCtrl( transactionPanel_, wxID_ANY, wxEmptyString, wxDefaultPosition, wxDefaultSize, 0 );
	transactionTopSizer->Add( trItemText_, 3, wxALL|wxEXPAND, 5 );
	
	valueLabel_ = new wxStaticText( transactionPanel_, wxID_ANY, wxT("Value"), wxDefaultPosition, wxDefaultSize, 0 );
	valueLabel_->Wrap( -1 );
	transactionTopSizer->Add( valueLabel_, 0, wxALIGN_CENTER_VERTICAL|wxLEFT, 5 );
	
	trValueText_ = new wxTextCtrl( transactionPanel_, wxID_ANY, wxEmptyString, wxDefaultPosition, wxDefaultSize, 0 );
	transactionTopSizer->Add( trValueText_, 2, wxALL, 5 );
	
	transactionSizer->Add( transactionTopSizer, 0, wxEXPAND, 5 );
	
	wxBoxSizer* transactionMiddleSizer;
	transactionMiddleSizer = new wxBoxSizer( wxHORIZONTAL );
	
	wxArrayString trSourceChoice_Choices;
	trSourceChoice_ = new wxChoice( transactionPanel_, wxID_ANY, wxDefaultPosition, wxDefaultSize, trSourceChoice_Choices, 0 );
	trSourceChoice_->SetSelection( 0 );
	transactionMiddleSizer->Add( trSourceChoice_, 2, wxBOTTOM|wxEXPAND|wxLEFT|wxRIGHT, 5 );
	
	wxArrayString trDestinationChoice_Choices;
	trDestinationChoice_ = new wxChoice( transactionPanel_, wxID_ANY, wxDefaultPosition, wxDefaultSize, trDestinationChoice_Choices, 0 );
	trDestinationChoice_->SetSelection( 0 );
	transactionMiddleSizer->Add( trDestinationChoice_, 2, wxBOTTOM|wxEXPAND|wxLEFT|wxRIGHT, 5 );
	
	commentLabel_ = new wxStaticText( transactionPanel_, wxID_ANY, wxT("Note"), wxDefaultPosition, wxDefaultSize, 0 );
	commentLabel_->Wrap( -1 );
	transactionMiddleSizer->Add( commentLabel_, 0, wxALIGN_CENTER_VERTICAL|wxBOTTOM|wxLEFT, 5 );
	
	trCommentText_ = new wxTextCtrl( transactionPanel_, wxID_ANY, wxEmptyString, wxDefaultPosition, wxDefaultSize, 0 );
	transactionMiddleSizer->Add( trCommentText_, 3, wxBOTTOM|wxEXPAND|wxLEFT|wxRIGHT, 5 );
	
	transactionSizer->Add( transactionMiddleSizer, 0, wxEXPAND, 5 );
	
	wxBoxSizer* transactionBottomSizer;
	transactionBottomSizer = new wxBoxSizer( wxHORIZONTAL );
	
	trDeleteButton_ = new wxButton( transactionPanel_, wxID_ANY, wxT("&Delete"), wxDefaultPosition, wxDefaultSize, 0 );
	transactionBottomSizer->Add( trDeleteButton_, 0, wxALIGN_RIGHT|wxBOTTOM|wxLEFT, 5 );
	
	
	transactionBottomSizer->Add( 0, 0, 1, wxEXPAND, 5 );
	
	trNewButton_ = new wxButton( transactionPanel_, wxID_ANY, wxT("&New"), wxDefaultPosition, wxDefaultSize, 0 );
	transactionBottomSizer->Add( trNewButton_, 0, wxBOTTOM|wxLEFT|wxRIGHT, 5 );
	
	trAcceptButton_ = new wxButton( transactionPanel_, wxID_ANY, wxT("&Accept"), wxDefaultPosition, wxDefaultSize, 0 );
	transactionBottomSizer->Add( trAcceptButton_, 0, wxBOTTOM|wxLEFT|wxRIGHT, 5 );
	
	transactionSizer->Add( transactionBottomSizer, 0, wxEXPAND, 5 );
	
	transactionPanel_->SetSizer( transactionSizer );
	transactionPanel_->Layout();
	transactionSizer->Fit( transactionPanel_ );
	bottomTransactionsSizer->Add( transactionPanel_, 1, wxEXPAND | wxALL, 0 );
	
	transactionsSizer_->Add( bottomTransactionsSizer, 0, wxEXPAND, 5 );
	
	transactionsPage_->SetSizer( transactionsSizer_ );
	transactionsPage_->Layout();
	transactionsSizer_->Fit( transactionsPage_ );
	financialPages_->AddPage( transactionsPage_, wxT("Transactions"), false );
	
	frameSizer->Add( financialPages_, 1, wxEXPAND | wxALL, 5 );
	
	this->SetSizer( frameSizer );
	this->Layout();
	statusBar_ = this->CreateStatusBar( 1, wxST_SIZEGRIP, wxID_ANY );
	
	// Connect Events
	this->Connect( wxEVT_CLOSE_WINDOW, wxCloseEventHandler( MainWindowBase::onClose ) );
	this->Connect( openCreateMenuItem_->GetId(), wxEVT_COMMAND_MENU_SELECTED, wxCommandEventHandler( MainWindowBase::onOpen ) );
	this->Connect( optimizeMenuItem_->GetId(), wxEVT_COMMAND_MENU_SELECTED, wxCommandEventHandler( MainWindowBase::onOptimizeDatabase ) );
	this->Connect( exportSqlMenuItem_->GetId(), wxEVT_COMMAND_MENU_SELECTED, wxCommandEventHandler( MainWindowBase::onExport ) );
	this->Connect( importSqlMenuItem_->GetId(), wxEVT_COMMAND_MENU_SELECTED, wxCommandEventHandler( MainWindowBase::onImport ) );
	this->Connect( exitMenuItem_->GetId(), wxEVT_COMMAND_MENU_SELECTED, wxCommandEventHandler( MainWindowBase::onQuit ) );
	this->Connect( undoMenuItem_->GetId(), wxEVT_COMMAND_MENU_SELECTED, wxCommandEventHandler( MainWindowBase::onUndo ) );
	this->Connect( redoMenuItem_->GetId(), wxEVT_COMMAND_MENU_SELECTED, wxCommandEventHandler( MainWindowBase::onRedo ) );
	this->Connect( accountsMenuItem->GetId(), wxEVT_COMMAND_MENU_SELECTED, wxCommandEventHandler( MainWindowBase::onAccounts ) );
	this->Connect( itemsMenuItems->GetId(), wxEVT_COMMAND_MENU_SELECTED, wxCommandEventHandler( MainWindowBase::onItems ) );
	this->Connect( preferencesMenuItem->GetId(), wxEVT_COMMAND_MENU_SELECTED, wxCommandEventHandler( MainWindowBase::onPreferences ) );
	this->Connect( manualMenuItem->GetId(), wxEVT_COMMAND_MENU_SELECTED, wxCommandEventHandler( MainWindowBase::onManual ) );
	this->Connect( homepageMenuItem->GetId(), wxEVT_COMMAND_MENU_SELECTED, wxCommandEventHandler( MainWindowBase::onHomepage ) );
	this->Connect( aboutMenuItem->GetId(), wxEVT_COMMAND_MENU_SELECTED, wxCommandEventHandler( MainWindowBase::onAbout ) );
	selectionViewButton_->Connect( wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler( MainWindowBase::onSelectionViewButton ), NULL, this );
	selIntervalChoice_->Connect( wxEVT_COMMAND_CHOICE_SELECTED, wxCommandEventHandler( MainWindowBase::onSelectionIntervalChoice ), NULL, this );
	selFirstDatePicker_->Connect( wxEVT_DATE_CHANGED, wxDateEventHandler( MainWindowBase::onSelectionFirstDateChanged ), NULL, this );
	selLastDatePicker_->Connect( wxEVT_DATE_CHANGED, wxDateEventHandler( MainWindowBase::onSelectionLastDateChanged ), NULL, this );
	selAccountChoice_->Connect( wxEVT_COMMAND_CHOICE_SELECTED, wxCommandEventHandler( MainWindowBase::onSelectionAccountChoice ), NULL, this );
	selPatternText_->Connect( wxEVT_COMMAND_TEXT_UPDATED, wxCommandEventHandler( MainWindowBase::onSelectionPatternText ), NULL, this );
	reportsButton_->Connect( wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler( MainWindowBase::onReports ), NULL, this );
	transactionsViewButton_->Connect( wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler( MainWindowBase::onTransactionViewButton ), NULL, this );
	trDatePicker_->Connect( wxEVT_DATE_CHANGED, wxDateEventHandler( MainWindowBase::onTransactionDateChanged ), NULL, this );
	trItemText_->Connect( wxEVT_KEY_DOWN, wxKeyEventHandler( MainWindowBase::onTransactionItemKeyDown ), NULL, this );
	trItemText_->Connect( wxEVT_COMMAND_TEXT_UPDATED, wxCommandEventHandler( MainWindowBase::onTransactionItemText ), NULL, this );
	trValueText_->Connect( wxEVT_COMMAND_TEXT_UPDATED, wxCommandEventHandler( MainWindowBase::onTransactionValueText ), NULL, this );
	trSourceChoice_->Connect( wxEVT_COMMAND_CHOICE_SELECTED, wxCommandEventHandler( MainWindowBase::onTransactionSourceChoice ), NULL, this );
	trDestinationChoice_->Connect( wxEVT_COMMAND_CHOICE_SELECTED, wxCommandEventHandler( MainWindowBase::onTransactionDestinationChoice ), NULL, this );
	trCommentText_->Connect( wxEVT_COMMAND_TEXT_UPDATED, wxCommandEventHandler( MainWindowBase::onTransactionCommentText ), NULL, this );
	trDeleteButton_->Connect( wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler( MainWindowBase::onDeleteTransaction ), NULL, this );
	trNewButton_->Connect( wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler( MainWindowBase::onNewTransaction ), NULL, this );
	trAcceptButton_->Connect( wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler( MainWindowBase::onAcceptTransaction ), NULL, this );
}

MainWindowBase::~MainWindowBase()
{
}
