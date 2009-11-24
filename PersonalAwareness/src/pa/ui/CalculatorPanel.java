package pa.ui;

import java.awt.GridBagLayout;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JButton;
import java.awt.GridBagConstraints;
import javax.swing.JTextField;

import pa.tools.Calculator;

import java.awt.Color;
import java.awt.Insets;
import java.awt.Font;
import javax.swing.AbstractAction;
import java.awt.event.ActionEvent;
import javax.swing.Action;

public class CalculatorPanel extends JPanel {

	private static final long serialVersionUID = 1L;
	private JButton oneButton = null;
	private JButton twoButton = null;
	private JButton threeButton = null;
	private JButton fourButton = null;
	private JButton fiveButton = null;
	private JButton sixButton = null;
	private JButton sevenButton = null;
	private JButton eightButton = null;
	private JButton nineButton = null;
	private JButton zeroButton = null;
	private JButton decimalButton = null;
	private JButton signButton = null;
	private JButton addButton = null;
	private JButton subButton = null;
	private JButton mulButton = null;
	private JButton divButton = null;
	private JButton okButton = null;
	private JButton cancelButton = null;
	private JButton clearButton = null;
	private JButton calculateButton = null;
	private JTextField displayTextField = null;
	private Calculator calc = new Calculator();

	/**
	 * This method initializes oneButton
	 * 
	 * @return javax.swing.JButton
	 */
	@SuppressWarnings("serial")
	private JButton getOneButton() {
		if (oneButton == null) {
			Action action = new AbstractAction() {
				public void actionPerformed(ActionEvent e) {
					calc.addSymbol('1');
					updateDisplay();
				}
			};
			action.setEnabled(true);
			oneButton = new JButton();
			oneButton.setAction(action);
			oneButton.setText("1");
			oneButton.setForeground(Color.blue);
		}
		return oneButton;
	}

	/**
	 * This method initializes twoButton
	 * 
	 * @return javax.swing.JButton
	 */
	@SuppressWarnings("serial")
	private JButton getTwoButton() {
		if (twoButton == null) {
			twoButton = new JButton();
			twoButton.setAction(new AbstractAction() {
				public void actionPerformed(ActionEvent e) {
					calc.addSymbol('2');
					updateDisplay();
				}
			});
			twoButton.setText("2");
			twoButton.setForeground(Color.blue);
		}
		return twoButton;
	}

	/**
	 * This method initializes threeButton
	 * 
	 * @return javax.swing.JButton
	 */
	@SuppressWarnings("serial")
	private JButton getThreeButton() {
		if (threeButton == null) {
			threeButton = new JButton();
			threeButton.setAction(new AbstractAction() {
				public void actionPerformed(ActionEvent e) {
					calc.addSymbol('3');
					updateDisplay();
				}
			});
			threeButton.setText("3");
			threeButton.setForeground(Color.blue);
		}
		return threeButton;
	}

	/**
	 * This method initializes fourButton
	 * 
	 * @return javax.swing.JButton
	 */
	@SuppressWarnings("serial")
	private JButton getFourButton() {
		if (fourButton == null) {
			fourButton = new JButton();
			fourButton.setAction(new AbstractAction() {
				public void actionPerformed(ActionEvent e) {
					calc.addSymbol('4');
					updateDisplay();
				}
			});
			fourButton.setText("4");
			fourButton.setForeground(Color.blue);
		}
		return fourButton;
	}

	/**
	 * This method initializes fiveButton
	 * 
	 * @return javax.swing.JButton
	 */
	@SuppressWarnings("serial")
	private JButton getFiveButton() {
		if (fiveButton == null) {
			fiveButton = new JButton();
			fiveButton.setAction(new AbstractAction() {
				public void actionPerformed(ActionEvent e) {
					calc.addSymbol('5');
					updateDisplay();
				}
			});
			fiveButton.setText("5");
			fiveButton.setForeground(Color.blue);
		}
		return fiveButton;
	}

	/**
	 * This method initializes sixButton
	 * 
	 * @return javax.swing.JButton
	 */
	@SuppressWarnings("serial")
	private JButton getSixButton() {
		if (sixButton == null) {
			sixButton = new JButton();
			sixButton.setAction(new AbstractAction() {
				public void actionPerformed(ActionEvent e) {
					calc.addSymbol('6');
					updateDisplay();
				}
			});
			sixButton.setText("6");
			sixButton.setForeground(Color.blue);
		}
		return sixButton;
	}

	/**
	 * This method initializes sevenButton
	 * 
	 * @return javax.swing.JButton
	 */
	@SuppressWarnings("serial")
	private JButton getSevenButton() {
		if (sevenButton == null) {
			sevenButton = new JButton();
			sevenButton.setAction(new AbstractAction() {
				public void actionPerformed(ActionEvent e) {
					calc.addSymbol('7');
					updateDisplay();
				}
			});
			sevenButton.setText("7");
			sevenButton.setForeground(Color.blue);
		}
		return sevenButton;
	}

	/**
	 * This method initializes eightButton
	 * 
	 * @return javax.swing.JButton
	 */
	@SuppressWarnings("serial")
	private JButton getEightButton() {
		if (eightButton == null) {
			eightButton = new JButton();
			eightButton.setAction(new AbstractAction() {
				public void actionPerformed(ActionEvent e) {
					calc.addSymbol('8');
					updateDisplay();
				}
			});
			eightButton.setText("8");
			eightButton.setForeground(Color.blue);
		}
		return eightButton;
	}

	/**
	 * This method initializes nineButton
	 * 
	 * @return javax.swing.JButton
	 */
	@SuppressWarnings("serial")
	private JButton getNineButton() {
		if (nineButton == null) {
			nineButton = new JButton();
			nineButton.setAction(new AbstractAction() {
				public void actionPerformed(ActionEvent e) {
					calc.addSymbol('9');
					updateDisplay();
				}
			});
			nineButton.setText("9");
			nineButton.setForeground(Color.blue);
		}
		return nineButton;
	}

	/**
	 * This method initializes zeroButton
	 * 
	 * @return javax.swing.JButton
	 */
	@SuppressWarnings("serial")
	private JButton getZeroButton() {
		if (zeroButton == null) {
			zeroButton = new JButton();
			zeroButton.setAction(new AbstractAction() {
				public void actionPerformed(ActionEvent e) {
					calc.addSymbol('0');
					updateDisplay();
				}
			});
			zeroButton.setText("0");
			zeroButton.setForeground(Color.blue);
		}
		return zeroButton;
	}

	/**
	 * This method initializes decimalButton
	 * 
	 * @return javax.swing.JButton
	 */
	@SuppressWarnings("serial")
	private JButton getDecimalButton() {
		if (decimalButton == null) {
			decimalButton = new JButton();
			decimalButton.setAction(new AbstractAction() {
				public void actionPerformed(ActionEvent e) {
					calc.addSymbol('.');
					updateDisplay();
				}
			});
			decimalButton.setText(".");
			decimalButton.setForeground(Color.blue);
		}
		return decimalButton;
	}

	/**
	 * This method initializes signButton
	 * 
	 * @return javax.swing.JButton
	 */
	@SuppressWarnings("serial")
	private JButton getSignButton() {
		if (signButton == null) {
			signButton = new JButton();
			signButton.setAction(new AbstractAction() {
				public void actionPerformed(ActionEvent e) {
					calc.addSymbol('~');
					updateDisplay();
				}
			});
			signButton.setText("-");
			signButton.setForeground(Color.blue);
		}
		return signButton;
	}

	/**
	 * This method initializes addButton
	 * 
	 * @return javax.swing.JButton
	 */
	@SuppressWarnings("serial")
	private JButton getAddButton() {
		if (addButton == null) {
			addButton = new JButton();
			addButton.setAction(new AbstractAction() {
				public void actionPerformed(ActionEvent e) {
					calc.addSymbol('+');
					updateDisplay();
				}
			});
			addButton.setText("+");
			addButton.setForeground(Color.red);
		}
		return addButton;
	}

	/**
	 * This method initializes subButton
	 * 
	 * @return javax.swing.JButton
	 */
	@SuppressWarnings("serial")
	private JButton getSubButton() {
		if (subButton == null) {
			subButton = new JButton();
			subButton.setAction(new AbstractAction() {
				public void actionPerformed(ActionEvent e) {
					calc.addSymbol('-');
					updateDisplay();
				}
			});
			subButton.setText("-");
			subButton.setForeground(Color.red);
		}
		return subButton;
	}

	/**
	 * This method initializes mulButton
	 * 
	 * @return javax.swing.JButton
	 */
	@SuppressWarnings("serial")
	private JButton getMulButton() {
		if (mulButton == null) {
			mulButton = new JButton();
			mulButton.setAction(new AbstractAction() {
				public void actionPerformed(ActionEvent e) {
					calc.addSymbol('*');
					updateDisplay();
				}
			});
			mulButton.setText("*");
			mulButton.setForeground(Color.red);
		}
		return mulButton;
	}

	/**
	 * This method initializes divButton
	 * 
	 * @return javax.swing.JButton
	 */
	@SuppressWarnings("serial")
	private JButton getDivButton() {
		if (divButton == null) {
			divButton = new JButton();
			divButton.setAction(new AbstractAction() {
				public void actionPerformed(ActionEvent e) {
					calc.addSymbol('/');
					updateDisplay();
				}
			});
			divButton.setText("/");
			divButton.setForeground(Color.red);
		}
		return divButton;
	}

	/**
	 * This method initializes okButton
	 * 
	 * @return javax.swing.JButton
	 */
	private JButton getOkButton() {
		if (okButton == null) {
			okButton = new JButton();
			okButton.setText("OK");
			okButton.setVisible(false);
		}
		return okButton;
	}

	/**
	 * This method initializes cancelButton
	 * 
	 * @return javax.swing.JButton
	 */
	private JButton getCancelButton() {
		if (cancelButton == null) {
			cancelButton = new JButton();
			cancelButton.setText("Cancel");
			cancelButton.setVisible(false);
		}
		return cancelButton;
	}

	/**
	 * This method initializes clearButton
	 * 
	 * @return javax.swing.JButton
	 */
	@SuppressWarnings("serial")
	private JButton getClearButton() {
		if (clearButton == null) {
			clearButton = new JButton();
			clearButton.setAction(new AbstractAction() {
				public void actionPerformed(ActionEvent e) {
					calc.addSymbol('c');
					updateDisplay();
				}
			});
			clearButton.setText("CE");
			clearButton.setForeground(Color.magenta);
		}
		return clearButton;
	}

	/**
	 * This method initializes calculateButton
	 * 
	 * @return javax.swing.JButton
	 */
	@SuppressWarnings("serial")
	private JButton getCalculateButton() {
		if (calculateButton == null) {
			calculateButton = new JButton();
			calculateButton.setAction(new AbstractAction() {
				public void actionPerformed(ActionEvent e) {
					calc.addSymbol('=');
					updateDisplay();
				}
			});
			calculateButton.setText("=");
			calculateButton.setForeground(Color.magenta);
		}
		return calculateButton;
	}

	/**
	 * This method initializes displayTextField
	 * 
	 * @return javax.swing.JTextField
	 */
	private JTextField getDisplayTextField() {
		if (displayTextField == null) {
			displayTextField = new JTextField();
			displayTextField.setFont(new Font("Dialog", Font.PLAIN, 18));
			displayTextField.setText("12345");
			displayTextField.setEditable(false);
			displayTextField.setHorizontalAlignment(JTextField.RIGHT);
		}
		return displayTextField;
	}

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		CalculatorPanel cp = new CalculatorPanel();
		JFrame jFrame = new JFrame();
		jFrame.setContentPane(cp);
		jFrame.pack();
		jFrame.setVisible(true);
	}

	/**
	 * This is the default constructor
	 */
	public CalculatorPanel() {
		super();
		initialize();
		updateDisplay();
	}

	private void updateDisplay() {
		getDisplayTextField().setText(calc.getValue());
	}

	/**
	 * This method initializes this
	 * 
	 * @return void
	 */
	private void initialize() {
		GridBagConstraints gridBagConstraints20 = new GridBagConstraints();
		gridBagConstraints20.fill = GridBagConstraints.BOTH;
		gridBagConstraints20.gridy = 0;
		gridBagConstraints20.weightx = 1.0;
		gridBagConstraints20.gridwidth = 5;
		gridBagConstraints20.insets = new Insets(1, 1, 5, 1);
		gridBagConstraints20.gridx = 0;
		GridBagConstraints gridBagConstraints19 = new GridBagConstraints();
		gridBagConstraints19.gridx = 4;
		gridBagConstraints19.fill = GridBagConstraints.BOTH;
		gridBagConstraints19.insets = new Insets(1, 1, 1, 1);
		gridBagConstraints19.gridy = 4;
		GridBagConstraints gridBagConstraints18 = new GridBagConstraints();
		gridBagConstraints18.gridx = 4;
		gridBagConstraints18.fill = GridBagConstraints.BOTH;
		gridBagConstraints18.insets = new Insets(1, 1, 1, 1);
		gridBagConstraints18.gridy = 3;
		GridBagConstraints gridBagConstraints17 = new GridBagConstraints();
		gridBagConstraints17.gridx = 4;
		gridBagConstraints17.fill = GridBagConstraints.BOTH;
		gridBagConstraints17.insets = new Insets(1, 1, 1, 1);
		gridBagConstraints17.gridy = 2;
		GridBagConstraints gridBagConstraints16 = new GridBagConstraints();
		gridBagConstraints16.gridx = 4;
		gridBagConstraints16.fill = GridBagConstraints.BOTH;
		gridBagConstraints16.insets = new Insets(1, 1, 1, 1);
		gridBagConstraints16.gridy = 1;
		GridBagConstraints gridBagConstraints15 = new GridBagConstraints();
		gridBagConstraints15.gridx = 3;
		gridBagConstraints15.fill = GridBagConstraints.BOTH;
		gridBagConstraints15.insets = new Insets(1, 3, 1, 3);
		gridBagConstraints15.gridy = 4;
		GridBagConstraints gridBagConstraints14 = new GridBagConstraints();
		gridBagConstraints14.gridx = 3;
		gridBagConstraints14.fill = GridBagConstraints.BOTH;
		gridBagConstraints14.insets = new Insets(1, 3, 1, 3);
		gridBagConstraints14.gridy = 3;
		GridBagConstraints gridBagConstraints13 = new GridBagConstraints();
		gridBagConstraints13.gridx = 3;
		gridBagConstraints13.fill = GridBagConstraints.BOTH;
		gridBagConstraints13.insets = new Insets(1, 3, 1, 3);
		gridBagConstraints13.gridy = 2;
		GridBagConstraints gridBagConstraints12 = new GridBagConstraints();
		gridBagConstraints12.gridx = 3;
		gridBagConstraints12.fill = GridBagConstraints.BOTH;
		gridBagConstraints12.insets = new Insets(1, 3, 1, 3);
		gridBagConstraints12.gridy = 1;
		GridBagConstraints gridBagConstraints11 = new GridBagConstraints();
		gridBagConstraints11.gridx = 2;
		gridBagConstraints11.fill = GridBagConstraints.BOTH;
		gridBagConstraints11.insets = new Insets(1, 1, 1, 1);
		gridBagConstraints11.gridy = 4;
		GridBagConstraints gridBagConstraints10 = new GridBagConstraints();
		gridBagConstraints10.gridx = 1;
		gridBagConstraints10.fill = GridBagConstraints.BOTH;
		gridBagConstraints10.insets = new Insets(1, 1, 1, 1);
		gridBagConstraints10.gridy = 4;
		GridBagConstraints gridBagConstraints9 = new GridBagConstraints();
		gridBagConstraints9.gridx = 0;
		gridBagConstraints9.fill = GridBagConstraints.BOTH;
		gridBagConstraints9.insets = new Insets(1, 1, 1, 1);
		gridBagConstraints9.gridy = 4;
		GridBagConstraints gridBagConstraints8 = new GridBagConstraints();
		gridBagConstraints8.gridx = 2;
		gridBagConstraints8.fill = GridBagConstraints.BOTH;
		gridBagConstraints8.insets = new Insets(1, 1, 1, 1);
		gridBagConstraints8.gridy = 3;
		GridBagConstraints gridBagConstraints7 = new GridBagConstraints();
		gridBagConstraints7.gridx = 1;
		gridBagConstraints7.fill = GridBagConstraints.BOTH;
		gridBagConstraints7.insets = new Insets(1, 1, 1, 1);
		gridBagConstraints7.gridy = 3;
		GridBagConstraints gridBagConstraints6 = new GridBagConstraints();
		gridBagConstraints6.gridx = 0;
		gridBagConstraints6.fill = GridBagConstraints.BOTH;
		gridBagConstraints6.insets = new Insets(1, 1, 1, 1);
		gridBagConstraints6.gridy = 3;
		GridBagConstraints gridBagConstraints5 = new GridBagConstraints();
		gridBagConstraints5.gridx = 2;
		gridBagConstraints5.fill = GridBagConstraints.BOTH;
		gridBagConstraints5.insets = new Insets(1, 1, 1, 1);
		gridBagConstraints5.gridy = 2;
		GridBagConstraints gridBagConstraints4 = new GridBagConstraints();
		gridBagConstraints4.gridx = 1;
		gridBagConstraints4.fill = GridBagConstraints.BOTH;
		gridBagConstraints4.insets = new Insets(1, 1, 1, 1);
		gridBagConstraints4.gridy = 2;
		GridBagConstraints gridBagConstraints3 = new GridBagConstraints();
		gridBagConstraints3.gridx = 0;
		gridBagConstraints3.fill = GridBagConstraints.BOTH;
		gridBagConstraints3.insets = new Insets(1, 1, 1, 1);
		gridBagConstraints3.gridy = 2;
		GridBagConstraints gridBagConstraints2 = new GridBagConstraints();
		gridBagConstraints2.gridx = 2;
		gridBagConstraints2.fill = GridBagConstraints.BOTH;
		gridBagConstraints2.insets = new Insets(1, 1, 1, 1);
		gridBagConstraints2.gridy = 1;
		GridBagConstraints gridBagConstraints1 = new GridBagConstraints();
		gridBagConstraints1.gridx = 1;
		gridBagConstraints1.fill = GridBagConstraints.BOTH;
		gridBagConstraints1.insets = new Insets(1, 1, 1, 1);
		gridBagConstraints1.gridy = 1;
		GridBagConstraints gridBagConstraints = new GridBagConstraints();
		gridBagConstraints.gridx = 0;
		gridBagConstraints.fill = GridBagConstraints.BOTH;
		gridBagConstraints.insets = new Insets(1, 1, 1, 1);
		gridBagConstraints.gridy = 1;
		this.setSize(254, 163);
		this.setLayout(new GridBagLayout());
		this.add(getOneButton(), gridBagConstraints);
		this.add(getTwoButton(), gridBagConstraints1);
		this.add(getThreeButton(), gridBagConstraints2);
		this.add(getFourButton(), gridBagConstraints3);
		this.add(getFiveButton(), gridBagConstraints4);
		this.add(getSixButton(), gridBagConstraints5);
		this.add(getSevenButton(), gridBagConstraints6);
		this.add(getEightButton(), gridBagConstraints7);
		this.add(getNineButton(), gridBagConstraints8);
		this.add(getZeroButton(), gridBagConstraints9);
		this.add(getDecimalButton(), gridBagConstraints10);
		this.add(getSignButton(), gridBagConstraints11);
		this.add(getAddButton(), gridBagConstraints12);
		this.add(getSubButton(), gridBagConstraints13);
		this.add(getMulButton(), gridBagConstraints14);
		this.add(getDivButton(), gridBagConstraints15);
		this.add(getOkButton(), gridBagConstraints16);
		this.add(getCancelButton(), gridBagConstraints17);
		this.add(getClearButton(), gridBagConstraints18);
		this.add(getCalculateButton(), gridBagConstraints19);
		this.add(getDisplayTextField(), gridBagConstraints20);
	}

} // @jve:decl-index=0:visual-constraint="10,10"
