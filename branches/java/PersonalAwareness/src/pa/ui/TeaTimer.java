package pa.ui;

import javax.swing.SwingUtilities;
import javax.swing.JPanel;
import javax.swing.JFrame;
import java.awt.GridBagLayout;
import javax.swing.JTextField;
import java.awt.GridBagConstraints;
import javax.swing.JLabel;
import java.awt.Font;
import javax.swing.JButton;
import java.awt.Insets;
import java.awt.Dimension;
import javax.swing.SwingConstants;
import javax.swing.BorderFactory;
import javax.swing.border.EtchedBorder;
import javax.swing.border.TitledBorder;
import java.awt.Color;

public class TeaTimer extends JFrame {

	private static final long serialVersionUID = 1L;
	private JPanel jContentPane = null;
	private JTextField hoursTextField = null;
	private JTextField minutesTextField = null;
	private JTextField secondsTextField = null;
	private JLabel hoursLabel = null;
	private JLabel minutesLabel = null;
	private JLabel secondsLabel = null;
	private JButton actionButton = null;
	private JButton resetButton = null;
	private JPanel timePanel = null;
	/**
	 * This method initializes hoursTextField	
	 * 	
	 * @return javax.swing.JTextField	
	 */
	private JTextField getHoursTextField() {
		if (hoursTextField == null) {
			hoursTextField = new JTextField();
			hoursTextField.setFont(new Font("Dialog", Font.PLAIN, 24));
			hoursTextField.setHorizontalAlignment(JTextField.TRAILING);
			hoursTextField.setText("00");
		}
		return hoursTextField;
	}

	/**
	 * This method initializes minutesTextField	
	 * 	
	 * @return javax.swing.JTextField	
	 */
	private JTextField getMinutesTextField() {
		if (minutesTextField == null) {
			minutesTextField = new JTextField();
			minutesTextField.setFont(new Font("Dialog", Font.PLAIN, 24));
			minutesTextField.setHorizontalAlignment(JTextField.TRAILING);
			minutesTextField.setText("00");
		}
		return minutesTextField;
	}

	/**
	 * This method initializes secondsTextField	
	 * 	
	 * @return javax.swing.JTextField	
	 */
	private JTextField getSecondsTextField() {
		if (secondsTextField == null) {
			secondsTextField = new JTextField();
			secondsTextField.setFont(new Font("Dialog", Font.PLAIN, 24));
			secondsTextField.setHorizontalAlignment(JTextField.TRAILING);
			secondsTextField.setText("00");
		}
		return secondsTextField;
	}

	/**
	 * This method initializes actionButton	
	 * 	
	 * @return javax.swing.JButton	
	 */
	private JButton getActionButton() {
		if (actionButton == null) {
			actionButton = new JButton();
			actionButton.setText("Start");
			actionButton.setPreferredSize(new Dimension(62, 30));
		}
		return actionButton;
	}

	/**
	 * This method initializes resetButton	
	 * 	
	 * @return javax.swing.JButton	
	 */
	private JButton getResetButton() {
		if (resetButton == null) {
			resetButton = new JButton();
			resetButton.setText("Reset");
			resetButton.setPreferredSize(new Dimension(67, 30));
		}
		return resetButton;
	}

	/**
	 * This method initializes timePanel	
	 * 	
	 * @return javax.swing.JPanel	
	 */
	private JPanel getTimePanel() {
		if (timePanel == null) {
			GridBagConstraints gridBagConstraints10 = new GridBagConstraints();
			gridBagConstraints10.anchor = GridBagConstraints.EAST;
			gridBagConstraints10.gridx = 2;
			gridBagConstraints10.gridy = 1;
			gridBagConstraints10.insets = new Insets(0, 0, 6, 8);
			GridBagConstraints gridBagConstraints9 = new GridBagConstraints();
			gridBagConstraints9.anchor = GridBagConstraints.EAST;
			gridBagConstraints9.gridx = 1;
			gridBagConstraints9.gridy = 1;
			gridBagConstraints9.insets = new Insets(0, 0, 6, 8);
			GridBagConstraints gridBagConstraints8 = new GridBagConstraints();
			gridBagConstraints8.anchor = GridBagConstraints.EAST;
			gridBagConstraints8.gridx = 0;
			gridBagConstraints8.gridy = 1;
			gridBagConstraints8.insets = new Insets(0, 0, 6, 8);
			GridBagConstraints gridBagConstraints7 = new GridBagConstraints();
			gridBagConstraints7.fill = GridBagConstraints.BOTH;
			gridBagConstraints7.gridx = 2;
			gridBagConstraints7.gridy = 0;
			gridBagConstraints7.weightx = 1.0D;
			gridBagConstraints7.insets = new Insets(8, 8, 0, 8);
			GridBagConstraints gridBagConstraints61 = new GridBagConstraints();
			gridBagConstraints61.fill = GridBagConstraints.BOTH;
			gridBagConstraints61.gridx = 1;
			gridBagConstraints61.gridy = 0;
			gridBagConstraints61.weightx = 1.0D;
			gridBagConstraints61.insets = new Insets(8, 8, 0, 8);
			GridBagConstraints gridBagConstraints = new GridBagConstraints();
			gridBagConstraints.fill = GridBagConstraints.BOTH;
			gridBagConstraints.gridx = 0;
			gridBagConstraints.gridy = 0;
			gridBagConstraints.weightx = 1.0D;
			gridBagConstraints.insets = new Insets(8, 8, 0, 8);
			timePanel = new JPanel();
			timePanel.setLayout(new GridBagLayout());
			timePanel.setBorder(BorderFactory.createTitledBorder(BorderFactory.createEtchedBorder(EtchedBorder.LOWERED), "Notify me in:", TitledBorder.DEFAULT_JUSTIFICATION, TitledBorder.DEFAULT_POSITION, new Font("Dialog", Font.BOLD, 14), new Color(51, 51, 51)));
			timePanel.add(getHoursTextField(), gridBagConstraints);
			timePanel.add(getMinutesTextField(), gridBagConstraints61);
			timePanel.add(getSecondsTextField(), gridBagConstraints7);
			timePanel.add(hoursLabel, gridBagConstraints8);
			timePanel.add(minutesLabel, gridBagConstraints9);
			timePanel.add(secondsLabel, gridBagConstraints10);
		}
		return timePanel;
	}

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		SwingUtilities.invokeLater(new Runnable() {
			public void run() {
				TeaTimer thisClass = new TeaTimer();
				thisClass.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
				thisClass.setVisible(true);
			}
		});
	}

	/**
	 * This is the default constructor
	 */
	public TeaTimer() {
		super();
		initialize();
	}

	/**
	 * This method initializes this
	 * 
	 * @return void
	 */
	private void initialize() {
		this.setSize(270, 170);
		this.setResizable(false);
		this.setName("teaTimerFrame");
		this.setMaximumSize(new Dimension(270, 170));
		this.setMinimumSize(new Dimension(270, 170));
		this.setPreferredSize(new Dimension(270, 170));
		this.setContentPane(getJContentPane());
		this.setTitle("Tea timer");
	}

	/**
	 * This method initializes jContentPane
	 * 
	 * @return javax.swing.JPanel
	 */
	private JPanel getJContentPane() {
		if (jContentPane == null) {
			GridBagConstraints gridBagConstraints51 = new GridBagConstraints();
			gridBagConstraints51.gridx = 0;
			gridBagConstraints51.fill = GridBagConstraints.BOTH;
			gridBagConstraints51.gridwidth = 2;
			gridBagConstraints51.weightx = 1.0D;
			gridBagConstraints51.insets = new Insets(4, 4, 4, 4);
			gridBagConstraints51.gridy = 0;
			GridBagConstraints gridBagConstraints21 = new GridBagConstraints();
			gridBagConstraints21.gridx = 1;
			gridBagConstraints21.fill = GridBagConstraints.BOTH;
			gridBagConstraints21.insets = new Insets(0, 2, 8, 6);
			gridBagConstraints21.weighty = 1.0D;
			gridBagConstraints21.weightx = 0.0D;
			gridBagConstraints21.gridy = 1;
			GridBagConstraints gridBagConstraints11 = new GridBagConstraints();
			gridBagConstraints11.gridx = 0;
			gridBagConstraints11.gridwidth = 1;
			gridBagConstraints11.fill = GridBagConstraints.BOTH;
			gridBagConstraints11.insets = new Insets(0, 6, 8, 2);
			gridBagConstraints11.weightx = 1.0D;
			gridBagConstraints11.weighty = 1.0D;
			gridBagConstraints11.gridy = 1;
			secondsLabel = new JLabel();
			secondsLabel.setText("second(s)");
			secondsLabel.setPreferredSize(new Dimension(60, 16));
			secondsLabel.setHorizontalAlignment(SwingConstants.TRAILING);
			minutesLabel = new JLabel();
			minutesLabel.setText("minute(s)");
			minutesLabel.setPreferredSize(new Dimension(60, 16));
			minutesLabel.setHorizontalAlignment(SwingConstants.TRAILING);
			hoursLabel = new JLabel();
			hoursLabel.setText("hour(s)");
			hoursLabel.setHorizontalTextPosition(SwingConstants.TRAILING);
			hoursLabel.setHorizontalAlignment(SwingConstants.TRAILING);
			hoursLabel.setPreferredSize(new Dimension(60, 16));
			jContentPane = new JPanel();
			jContentPane.setLayout(new GridBagLayout());
			jContentPane.add(getActionButton(), gridBagConstraints11);
			jContentPane.add(getResetButton(), gridBagConstraints21);
			jContentPane.add(getTimePanel(), gridBagConstraints51);
		}
		return jContentPane;
	}

}  //  @jve:decl-index=0:visual-constraint="10,10"
