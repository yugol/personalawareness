package pa.tools;

import java.text.DecimalFormat;

public class Calculator {
	static DecimalFormat df = new DecimalFormat("#.###############");
	static int maxIntDigits = 15;
	static String operations = "+-*/";

	String currentInput;
	char operation;
	Double result;

	public Calculator() {
		setInitialState();
	}

	private void setInitialState() {
		clearCurrentInput();
		operation = '\0';
		result = null;
	}

	private void clearCurrentInput() {
		currentInput = null;
	}

	public void addSymbol(char smb) {
		if ('0' <= smb && smb <= '9') {
			if (isFloat(currentInput)
					|| intDigitsCount(currentInput) < maxIntDigits) {
				if (currentInput == null) {
					currentInput = "" + smb;
				} else {
					currentInput = currentInput + smb;
				}
			}
		} else if (smb == '.' && !isFloat(currentInput)) {
			if (currentInput == null) {
				currentInput = "0";
			}
			currentInput = currentInput + smb;
		} else if (smb == '~') {
			if (currentInput != null) {
				if (currentInput.charAt(0) == '-') {
					currentInput = currentInput.substring(1);
				} else if (!currentInput.equals("0")) {
					currentInput = "-" + currentInput;
				}
			}
		} else if (operations.contains("" + smb)) {
			operation = smb;
			calculate();
		} else if (smb == '=') {
			calculate();
		} else if (smb == 'c') {
			setInitialState();
		}
	}

	private void calculate() {
		double operand = Double.parseDouble(currentInput);
		if (result == null) {
			result = operand;
		} else {
			switch (operation) {
			case '+':
				result += operand;
				break;
			case '-':
				result -= operand;
				break;
			case '*':
				result *= operand;
				break;
			case '/':
				result /= operand;
				break;
			default:
				throw new UnsupportedOperationException("'" + operation + "'");
			}
		}
		clearCurrentInput();
	}

	private int intDigitsCount(String numStr) {
		if (numStr == null) {
			return 1;
		}
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
		return ((numStr != null) && (numStr.contains(".")));
	}

	public String getValue() {
		double val = 0;
		if (currentInput == null) {
			if (result != null) {
				val = result;
			} else {
				val = 0;
			}
		} else {
			val = Double.parseDouble(currentInput);
		}
		return df.format(val);
	}
}
