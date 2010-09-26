///////////////////////////////////////////////////////////////////////////
// C++ code generated with wxFormBuilder (version Apr 17 2008)
// http://www.wxformbuilder.org/
//
// PLEASE DO "NOT" EDIT THIS FILE!
///////////////////////////////////////////////////////////////////////////

#ifndef __MainWindowBase__
#define __MainWindowBase__

#include <wx/string.h>
#include <wx/bitmap.h>
#include <wx/image.h>
#include <wx/icon.h>
#include <wx/menu.h>
#include <wx/gdicmn.h>
#include <wx/font.h>
#include <wx/colour.h>
#include <wx/settings.h>
#include <wx/listctrl.h>
#include <wx/stattext.h>
#include <wx/sizer.h>
#include <wx/panel.h>
#include <wx/button.h>
#include <wx/choice.h>
#include <wx/datectrl.h>
#include <wx/dateevt.h>
#include <wx/textctrl.h>
#include <wx/notebook.h>
#include <wx/statusbr.h>
#include <wx/frame.h>

///////////////////////////////////////////////////////////////////////////


///////////////////////////////////////////////////////////////////////////////
/// Class MainWindowBase
///////////////////////////////////////////////////////////////////////////////
class MainWindowBase : public wxFrame 
{
	private:
	
	protected:
		wxMenuBar* mainMenu_;
		wxMenu* databaseMenu_;
		wxMenuItem* exportSqlMenuItem_;
		wxMenuItem* importSqlMenuItem_;
		wxMenu* editMenu_;
		wxMenuItem* undoMenuItem_;
		wxMenuItem* redoMenuItem_;
		wxMenu* helpMenu_;
		wxNotebook* financialPages_;
		wxPanel* accountsPage_;
		wxBoxSizer* accountsSizer_;
		wxListCtrl* accountList_;
		
		wxStaticText* netBalanceLabel_;
		wxPanel* transactionsPage_;
		wxBoxSizer* transactionsSizer_;
		wxButton* selectionViewButton_;
		wxPanel* selectionPanel_;
		wxStaticText* periodLabel_;
		wxChoice* selIntervalChoice_;
		wxStaticText* selFromLabel_;
		wxDatePickerCtrl* selFirstDatePicker_;
		wxStaticText* selToLabel_;
		wxDatePickerCtrl* selLastDatePicker_;
		wxStaticText* accountLabel_;
		wxChoice* selAccountChoice_;
		wxStaticText* itemsLikeLabel_;
		wxTextCtrl* selPatternText_;
		wxButton* reportsButton_;
		wxBoxSizer* middleTransactionsSizer_;
		wxButton* transactionsViewButton_;
		wxPanel* transactionPanel_;
		wxStaticText* dateLabel_;
		wxDatePickerCtrl* trDatePicker_;
		wxStaticText* itemLabel_;
		wxTextCtrl* trItemText_;
		wxStaticText* valueLabel_;
		wxTextCtrl* trValueText_;
		wxChoice* trSourceChoice_;
		wxChoice* trDestinationChoice_;
		wxStaticText* commentLabel_;
		wxTextCtrl* trCommentText_;
		wxButton* trDeleteButton_;
		
		wxButton* trNewButton_;
		wxButton* trAcceptButton_;
		wxStatusBar* statusBar_;
		
		// Virtual event handlers, overide them in your derived class
		virtual void onClose( wxCloseEvent& event ){ event.Skip(); }
		virtual void onOpen( wxCommandEvent& event ){ event.Skip(); }
		virtual void onExport( wxCommandEvent& event ){ event.Skip(); }
		virtual void onImport( wxCommandEvent& event ){ event.Skip(); }
		virtual void onQuit( wxCommandEvent& event ){ event.Skip(); }
		virtual void onUndo( wxCommandEvent& event ){ event.Skip(); }
		virtual void onRedo( wxCommandEvent& event ){ event.Skip(); }
		virtual void onAccounts( wxCommandEvent& event ){ event.Skip(); }
		virtual void onItems( wxCommandEvent& event ){ event.Skip(); }
		virtual void onPreferences( wxCommandEvent& event ){ event.Skip(); }
		virtual void onManual( wxCommandEvent& event ){ event.Skip(); }
		virtual void onHomepage( wxCommandEvent& event ){ event.Skip(); }
		virtual void onAbout( wxCommandEvent& event ){ event.Skip(); }
		virtual void onSelectionViewButton( wxCommandEvent& event ){ event.Skip(); }
		virtual void onSelectionIntervalChoice( wxCommandEvent& event ){ event.Skip(); }
		virtual void onSelectionFirstDateChanged( wxDateEvent& event ){ event.Skip(); }
		virtual void onSelectionLastDateChanged( wxDateEvent& event ){ event.Skip(); }
		virtual void onSelectionAccountChoice( wxCommandEvent& event ){ event.Skip(); }
		virtual void onSelectionPatternText( wxCommandEvent& event ){ event.Skip(); }
		virtual void onReports( wxCommandEvent& event ){ event.Skip(); }
		virtual void onTransactionViewButton( wxCommandEvent& event ){ event.Skip(); }
		virtual void onTransactionDateChanged( wxDateEvent& event ){ event.Skip(); }
		virtual void onTransactionItemKeyDown( wxKeyEvent& event ){ event.Skip(); }
		virtual void onTransactionItemText( wxCommandEvent& event ){ event.Skip(); }
		virtual void onTransactionValueText( wxCommandEvent& event ){ event.Skip(); }
		virtual void onTransactionSourceChoice( wxCommandEvent& event ){ event.Skip(); }
		virtual void onTransactionDestinationChoice( wxCommandEvent& event ){ event.Skip(); }
		virtual void onTransactionCommentText( wxCommandEvent& event ){ event.Skip(); }
		virtual void onDeleteTransaction( wxCommandEvent& event ){ event.Skip(); }
		virtual void onNewTransaction( wxCommandEvent& event ){ event.Skip(); }
		virtual void onAcceptTransaction( wxCommandEvent& event ){ event.Skip(); }
		
	
	public:
		MainWindowBase( wxWindow* parent, wxWindowID id = wxID_ANY, const wxString& title = wxT("Main Window"), const wxPoint& pos = wxDefaultPosition, const wxSize& size = wxSize( 700,525 ), long style = wxDEFAULT_FRAME_STYLE|wxTAB_TRAVERSAL );
		~MainWindowBase();
	
};

#endif //__MainWindowBase__
