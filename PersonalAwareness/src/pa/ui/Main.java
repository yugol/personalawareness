package pa.ui;

import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;
import java.awt.BorderLayout;
import javax.swing.SwingUtilities;
import java.awt.Point;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JMenuItem;
import javax.swing.JMenuBar;
import javax.swing.JMenu;
import javax.swing.JFrame;
import javax.swing.JDialog;
import java.awt.Dimension;
import java.awt.GridBagLayout;
import java.awt.GridBagConstraints;
import javax.swing.JButton;
import java.awt.Insets;
import java.awt.Rectangle;
import java.lang.String;
import javax.swing.AbstractAction;
import javax.swing.JToolBar;
import javax.swing.SwingConstants;
import java.awt.ComponentOrientation;
import javax.swing.BorderFactory;

public class Main {

	private JFrame jFrame = null;  //  @jve:decl-index=0:visual-constraint="0,-22"
	private JPanel jContentPane = null;
	private JMenuBar jJMenuBar = null;
	private JMenu fileMenu = null;
	private JMenu editMenu = null;
	private JMenu helpMenu = null;
	private JMenuItem exitMenuItem = null;
	private JMenuItem aboutMenuItem = null;
	private JMenuItem cutMenuItem = null;
	private JMenuItem copyMenuItem = null;
	private JMenuItem pasteMenuItem = null;
	private JMenuItem saveMenuItem = null;
	private JDialog aboutDialog = null;  //  @jve:decl-index=0:visual-constraint="3,569"
	private JPanel aboutContentPane = null;
	private JMenuItem transferReasonsMenuItem = null;
	private JMenuItem preferencesMenuItem = null;
	private JMenu mealsMenu = null;
	private JMenuItem manageMealsMenuItem = null;
	private JLabel iconLabel = null;
	private JLabel topAboutLineLabel = null;
	private JLabel botomAboutLabel = null;
	private JButton okAboutButton = null;
	private JToolBar mainToolBar = null;
	private JToolBar mainStatusBar = null;
	private JButton openStorageButton = null;
	private JButton actionsButton = null;
	private JButton notesButton = null;
	private JButton mealsButton = null;
	private JButton financesButton = null;
	private JButton calculatorButton = null;
	private JButton teaTimerButton = null;
	private JButton calendarButton = null;
	private JLabel dateTimeLabel = null;
	private JLabel viewsSpacerLabel = null;
	private JLabel toolsSpacerLabel = null;
	private JMenuItem fileSeparatorMenuItem = null;
	private JMenuItem editReasonsSeparatorMenuItem = null;
	private JMenuItem editPreferencesSeparatorMenuItem = null;
	/**
	 * This method initializes transferReasonsMenuItem
	 * 
	 * @return javax.swing.JMenuItem
	 */
	private JMenuItem getTransferReasonsMenuItem() {
		if (transferReasonsMenuItem == null) {
			transferReasonsMenuItem = new JMenuItem();
			transferReasonsMenuItem.setText("Transfer Reasons...");
		}
		return transferReasonsMenuItem;
	}

	/**
	 * This method initializes preferencesMenuItem
	 * 
	 * @return javax.swing.JMenuItem
	 */
	private JMenuItem getPreferencesMenuItem() {
		if (preferencesMenuItem == null) {
			preferencesMenuItem = new JMenuItem();
			preferencesMenuItem.setText("Preferences...");
		}
		return preferencesMenuItem;
	}

	/**
	 * This method initializes mealsMenu
	 * 
	 * @return javax.swing.JMenu
	 */
	private JMenu getMealsMenu() {
		if (mealsMenu == null) {
			mealsMenu = new JMenu();
			mealsMenu.setText("Meals");
			mealsMenu.add(getManageMealsMenuItem());
		}
		return mealsMenu;
	}

	/**
	 * This method initializes manageMealsMenuItem
	 * 
	 * @return javax.swing.JMenuItem
	 */
	private JMenuItem getManageMealsMenuItem() {
		if (manageMealsMenuItem == null) {
			manageMealsMenuItem = new JMenuItem();
			manageMealsMenuItem.setText("Manage Meals...");
		}
		return manageMealsMenuItem;
	}

	/**
	 * This method initializes okAboutButton
	 * 
	 * @return javax.swing.JButton
	 */
	@SuppressWarnings("serial")
	private JButton getOkAboutButton() {
		if (okAboutButton == null) {
			okAboutButton = new JButton();
			okAboutButton.setAction(new AbstractAction() {
				public void actionPerformed(ActionEvent e) {
					getAboutDialog().setVisible(false);
				}
			});
			okAboutButton.setText("OK");
			okAboutButton.setActionCommand("");
		}
		return okAboutButton;
	}

	/**
	 * This method initializes mainToolBar	
	 * 	
	 * @return javax.swing.JToolBar	
	 */
	private JToolBar getMainToolBar() {
		if (mainToolBar == null) {
			toolsSpacerLabel = new JLabel();
			toolsSpacerLabel.setText("  ");
			viewsSpacerLabel = new JLabel();
			viewsSpacerLabel.setText("  ");
			viewsSpacerLabel.setHorizontalAlignment(SwingConstants.TRAILING);
			mainToolBar = new JToolBar();
			mainToolBar.setFloatable(false);
			mainToolBar.add(getOpenStorageButton());
			mainToolBar.add(viewsSpacerLabel);
			mainToolBar.add(getActionsButton());
			mainToolBar.add(getNotesButton());
			mainToolBar.add(getMealsButton());
			mainToolBar.add(getFinancesButton());
			mainToolBar.add(toolsSpacerLabel);
			mainToolBar.add(getCalculatorButton());
			mainToolBar.add(getTeaTimerButton());
			mainToolBar.add(getCalendarButton());
		}
		return mainToolBar;
	}

	/**
	 * This method initializes mainStatusBar	
	 * 	
	 * @return javax.swing.JToolBar	
	 */
	private JToolBar getMainStatusBar() {
		if (mainStatusBar == null) {
			dateTimeLabel = new JLabel();
			dateTimeLabel.setText("0000-00-00 00:00:00");
			dateTimeLabel.setHorizontalTextPosition(SwingConstants.RIGHT);
			dateTimeLabel.setHorizontalAlignment(SwingConstants.RIGHT);
			mainStatusBar = new JToolBar();
			mainStatusBar.setFloatable(false);
			mainStatusBar.setComponentOrientation(ComponentOrientation.RIGHT_TO_LEFT);
			mainStatusBar.add(dateTimeLabel);
		}
		return mainStatusBar;
	}

	/**
	 * This method initializes openStorageButton	
	 * 	
	 * @return javax.swing.JButton	
	 */
	private JButton getOpenStorageButton() {
		if (openStorageButton == null) {
			openStorageButton = new JButton();
			openStorageButton.setText("Open");
		}
		return openStorageButton;
	}

	/**
	 * This method initializes actionsButton	
	 * 	
	 * @return javax.swing.JButton	
	 */
	private JButton getActionsButton() {
		if (actionsButton == null) {
			actionsButton = new JButton();
			actionsButton.setText("Actions");
		}
		return actionsButton;
	}

	/**
	 * This method initializes notesButton	
	 * 	
	 * @return javax.swing.JButton	
	 */
	private JButton getNotesButton() {
		if (notesButton == null) {
			notesButton = new JButton();
			notesButton.setText("Notes");
		}
		return notesButton;
	}

	/**
	 * This method initializes mealsButton	
	 * 	
	 * @return javax.swing.JButton	
	 */
	private JButton getMealsButton() {
		if (mealsButton == null) {
			mealsButton = new JButton();
			mealsButton.setText("Meals");
		}
		return mealsButton;
	}

	/**
	 * This method initializes financesButton	
	 * 	
	 * @return javax.swing.JButton	
	 */
	private JButton getFinancesButton() {
		if (financesButton == null) {
			financesButton = new JButton();
			financesButton.setText("Finances");
		}
		return financesButton;
	}

	/**
	 * This method initializes calculatorButton	
	 * 	
	 * @return javax.swing.JButton	
	 */
	private JButton getCalculatorButton() {
		if (calculatorButton == null) {
			calculatorButton = new JButton();
			calculatorButton.setText("Calculator");
		}
		return calculatorButton;
	}

	/**
	 * This method initializes teaTimerButton	
	 * 	
	 * @return javax.swing.JButton	
	 */
	private JButton getTeaTimerButton() {
		if (teaTimerButton == null) {
			teaTimerButton = new JButton();
			teaTimerButton.setText("Tea timer");
		}
		return teaTimerButton;
	}

	/**
	 * This method initializes calendarButton	
	 * 	
	 * @return javax.swing.JButton	
	 */
	private JButton getCalendarButton() {
		if (calendarButton == null) {
			calendarButton = new JButton();
			calendarButton.setText("Calendar");
		}
		return calendarButton;
	}

	/**
	 * This method initializes fileSeparatorMenuItem	
	 * 	
	 * @return javax.swing.JMenuItem	
	 */
	private JMenuItem getFileSeparatorMenuItem() {
		if (fileSeparatorMenuItem == null) {
			fileSeparatorMenuItem = new JMenuItem();
			fileSeparatorMenuItem.setEnabled(false);
			fileSeparatorMenuItem.setText("");
		}
		return fileSeparatorMenuItem;
	}

	/**
	 * This method initializes editReasonsSeparatorMenuItem	
	 * 	
	 * @return javax.swing.JMenuItem	
	 */
	private JMenuItem getEditReasonsSeparatorMenuItem() {
		if (editReasonsSeparatorMenuItem == null) {
			editReasonsSeparatorMenuItem = new JMenuItem();
			editReasonsSeparatorMenuItem.setEnabled(false);
		}
		return editReasonsSeparatorMenuItem;
	}

	/**
	 * This method initializes editPreferencesSeparatorMenuItem	
	 * 	
	 * @return javax.swing.JMenuItem	
	 */
	private JMenuItem getEditPreferencesSeparatorMenuItem() {
		if (editPreferencesSeparatorMenuItem == null) {
			editPreferencesSeparatorMenuItem = new JMenuItem();
			editPreferencesSeparatorMenuItem.setEnabled(false);
		}
		return editPreferencesSeparatorMenuItem;
	}

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		SwingUtilities.invokeLater(new Runnable() {
			public void run() {
				Main application = new Main();
				application.getJFrame().setVisible(true);
			}
		});
	}

	/**
	 * This method initializes jFrame
	 * 
	 * @return javax.swing.JFrame
	 */
	private JFrame getJFrame() {
		if (jFrame == null) {
			jFrame = new JFrame();
			jFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
			jFrame.setJMenuBar(getJJMenuBar());
			jFrame.setSize(717, 500);
			jFrame.setContentPane(getJContentPane());
			jFrame.setTitle("Personal Awareness");
		}
		return jFrame;
	}

	/**
	 * This method initializes jContentPane
	 * 
	 * @return javax.swing.JPanel
	 */
	private JPanel getJContentPane() {
		if (jContentPane == null) {
			jContentPane = new JPanel();
			jContentPane.setLayout(new BorderLayout());
			jContentPane.setBorder(BorderFactory.createEmptyBorder(0, 0, 0, 0));
			jContentPane.add(getMainToolBar(), BorderLayout.NORTH);
			jContentPane.add(getMainStatusBar(), BorderLayout.SOUTH);
		}
		return jContentPane;
	}

	/**
	 * This method initializes jJMenuBar
	 * 
	 * @return javax.swing.JMenuBar
	 */
	private JMenuBar getJJMenuBar() {
		if (jJMenuBar == null) {
			jJMenuBar = new JMenuBar();
			jJMenuBar.add(getFileMenu());
			jJMenuBar.add(getEditMenu());
			jJMenuBar.add(getMealsMenu());
			jJMenuBar.add(getHelpMenu());
		}
		return jJMenuBar;
	}

	/**
	 * This method initializes jMenu
	 * 
	 * @return javax.swing.JMenu
	 */
	private JMenu getFileMenu() {
		if (fileMenu == null) {
			fileMenu = new JMenu();
			fileMenu.setText("File");
			fileMenu.add(getSaveMenuItem());
			fileMenu.add(getFileSeparatorMenuItem());
			fileMenu.add(getExitMenuItem());
		}
		return fileMenu;
	}

	/**
	 * This method initializes jMenu
	 * 
	 * @return javax.swing.JMenu
	 */
	private JMenu getEditMenu() {
		if (editMenu == null) {
			editMenu = new JMenu();
			editMenu.setText("Edit");
			editMenu.add(getCutMenuItem());
			editMenu.add(getCopyMenuItem());
			editMenu.add(getPasteMenuItem());
			editMenu.add(getEditReasonsSeparatorMenuItem());
			editMenu.add(getTransferReasonsMenuItem());
			editMenu.add(getEditPreferencesSeparatorMenuItem());
			editMenu.add(getPreferencesMenuItem());
		}
		return editMenu;
	}

	/**
	 * This method initializes jMenu
	 * 
	 * @return javax.swing.JMenu
	 */
	private JMenu getHelpMenu() {
		if (helpMenu == null) {
			helpMenu = new JMenu();
			helpMenu.setText("Help");
			helpMenu.add(getAboutMenuItem());
		}
		return helpMenu;
	}

	/**
	 * This method initializes jMenuItem
	 * 
	 * @return javax.swing.JMenuItem
	 */
	private JMenuItem getExitMenuItem() {
		if (exitMenuItem == null) {
			exitMenuItem = new JMenuItem();
			exitMenuItem.setText("Exit");
			exitMenuItem.addActionListener(new ActionListener() {
				public void actionPerformed(ActionEvent e) {
					System.exit(0);
				}
			});
		}
		return exitMenuItem;
	}

	/**
	 * This method initializes jMenuItem
	 * 
	 * @return javax.swing.JMenuItem
	 */
	private JMenuItem getAboutMenuItem() {
		if (aboutMenuItem == null) {
			aboutMenuItem = new JMenuItem();
			aboutMenuItem.setText("About");
			aboutMenuItem.addActionListener(new ActionListener() {
				public void actionPerformed(ActionEvent e) {
					JDialog aboutDialog = getAboutDialog();
					aboutDialog.pack();
					Point loc = getJFrame().getLocation();
					loc.translate(20, 20);
					aboutDialog.setLocation(loc);
					aboutDialog.setVisible(true);
				}
			});
		}
		return aboutMenuItem;
	}

	/**
	 * This method initializes aboutDialog
	 * 
	 * @return javax.swing.JDialog
	 */
	private JDialog getAboutDialog() {
		if (aboutDialog == null) {
			aboutDialog = new JDialog(getJFrame(), true);
			aboutDialog.setTitle("About");
			aboutDialog.setMinimumSize(new Dimension(220, 120));
			aboutDialog.setMaximumSize(new Dimension(1000, 1000));
			aboutDialog.setPreferredSize(new Dimension(275, 132));
			aboutDialog.setResizable(false);
			aboutDialog.setBounds(new Rectangle(0, 0, 275, 132));
			aboutDialog.setContentPane(getAboutContentPane());
		}
		return aboutDialog;
	}

	/**
	 * This method initializes aboutContentPane
	 * 
	 * @return javax.swing.JPanel
	 */
	private JPanel getAboutContentPane() {
		if (aboutContentPane == null) {
			GridBagConstraints gridBagConstraints3 = new GridBagConstraints();
			gridBagConstraints3.gridx = 0;
			gridBagConstraints3.anchor = GridBagConstraints.SOUTH;
			gridBagConstraints3.ipady = 0;
			gridBagConstraints3.insets = new Insets(10, 0, 0, 0);
			gridBagConstraints3.gridwidth = 2;
			gridBagConstraints3.gridy = 2;
			GridBagConstraints gridBagConstraints2 = new GridBagConstraints();
			gridBagConstraints2.gridx = 1;
			gridBagConstraints2.ipadx = 0;
			gridBagConstraints2.ipady = 0;
			gridBagConstraints2.anchor = GridBagConstraints.WEST;
			gridBagConstraints2.insets = new Insets(4, 4, 4, 0);
			gridBagConstraints2.gridy = 1;
			botomAboutLabel = new JLabel();
			botomAboutLabel.setText("Copyright (c) 2009; Iulian Goriac");
			GridBagConstraints gridBagConstraints1 = new GridBagConstraints();
			gridBagConstraints1.gridx = 1;
			gridBagConstraints1.ipadx = 0;
			gridBagConstraints1.ipady = 0;
			gridBagConstraints1.anchor = GridBagConstraints.WEST;
			gridBagConstraints1.insets = new Insets(4, 4, 4, 0);
			gridBagConstraints1.gridy = 0;
			topAboutLineLabel = new JLabel();
			topAboutLineLabel.setText("Personal Awareness");
			GridBagConstraints gridBagConstraints = new GridBagConstraints();
			gridBagConstraints.gridx = 0;
			gridBagConstraints.gridheight = 2;
			gridBagConstraints.ipadx = 0;
			gridBagConstraints.ipady = 0;
			gridBagConstraints.insets = new Insets(4, 4, 4, 4);
			gridBagConstraints.gridy = 0;
			iconLabel = new JLabel();
			iconLabel.setText("ICON");
			aboutContentPane = new JPanel();
			aboutContentPane.setLayout(new GridBagLayout());
			aboutContentPane.add(iconLabel, gridBagConstraints);
			aboutContentPane.add(topAboutLineLabel, gridBagConstraints1);
			aboutContentPane.add(botomAboutLabel, gridBagConstraints2);
			aboutContentPane.add(getOkAboutButton(), gridBagConstraints3);
		}
		return aboutContentPane;
	}

	/**
	 * This method initializes jMenuItem
	 * 
	 * @return javax.swing.JMenuItem
	 */
	private JMenuItem getCutMenuItem() {
		if (cutMenuItem == null) {
			cutMenuItem = new JMenuItem();
			cutMenuItem.setText("Accounts...");
			cutMenuItem.setActionCommand("");
		}
		return cutMenuItem;
	}

	/**
	 * This method initializes jMenuItem
	 * 
	 * @return javax.swing.JMenuItem
	 */
	private JMenuItem getCopyMenuItem() {
		if (copyMenuItem == null) {
			copyMenuItem = new JMenuItem();
			copyMenuItem.setText("Account Types...");
		}
		return copyMenuItem;
	}

	/**
	 * This method initializes jMenuItem
	 * 
	 * @return javax.swing.JMenuItem
	 */
	private JMenuItem getPasteMenuItem() {
		if (pasteMenuItem == null) {
			pasteMenuItem = new JMenuItem();
			pasteMenuItem.setText("Budget Categories...");
		}
		return pasteMenuItem;
	}

	/**
	 * This method initializes jMenuItem
	 * 
	 * @return javax.swing.JMenuItem
	 */
	private JMenuItem getSaveMenuItem() {
		if (saveMenuItem == null) {
			saveMenuItem = new JMenuItem();
			saveMenuItem.setText("Open Storage...");
			saveMenuItem.setActionCommand("");
		}
		return saveMenuItem;
	}

}
