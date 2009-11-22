package pa.tools;

import java.text.DecimalFormat;

public class Calculator {
	static DecimalFormat df = new DecimalFormat("#.###############");
	static int maxIntDigits = 15;

	String currentInput = "0";

	public void addSymbol(char smb) {
		if ('0' <= smb && smb <= '9') {
			if (isFloat(currentInput)
					|| intDigitsCount(currentInput) < maxIntDigits) {
				if (currentInput.equals("0")) {
					currentInput = "" + smb;
				} else {
					currentInput = currentInput + smb;
				}
			}
		} else if (smb == '.' && !isFloat(currentInput)) {
			currentInput = currentInput + smb;
		}
	}

	private int intDigitsCount(String numStr) {
		int intDigits = 0;
		for (int i = 0; i < numStr.length(); i++) {
			char ch = numStr.charAt(i);
			if (ch == '.') {
				break;
			}
			++intDigits;
		}
		return intDigits;
	}

	private boolean isFloat(String numStr) {
		return numStr.contains(".");
	}

	public String getValue() {
		double val = Double.parseDouble(currentInput);
		// long intVal = (long) val;
		// if (intVal == val) {
		// return "" + intVal;
		// }
		return df.format(val);
	}

}
