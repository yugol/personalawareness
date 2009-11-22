package pa.tools;

import static org.junit.Assert.*;

import org.junit.Test;

public class CalculatorTest {
	Calculator calc = new Calculator();

	@Test
	public void testCase01() {
		assertEquals("0", calc.getValue());
	}

	@Test
	public void testCase02() {
		calc.addSymbol('0');
		assertEquals("0", calc.getValue());
		calc.addSymbol('0');
		assertEquals("0", calc.getValue());
	}

	@Test
	public void testCase03() {
		calc.addSymbol('1');
		assertEquals("1", calc.getValue());
		calc.addSymbol('2');
		assertEquals("12", calc.getValue());
	}

	@Test
	public void testCase04() {
		calc.addSymbol('1');
		assertEquals("1", calc.getValue());
		calc.addSymbol('2');
		assertEquals("12", calc.getValue());
		calc.addSymbol('.');
		assertEquals("12", calc.getValue());
		calc.addSymbol('3');
		assertEquals("12.3", calc.getValue());
		calc.addSymbol('4');
		assertEquals("12.34", calc.getValue());
	}

	@Test
	public void testCase05() {
		calc.addSymbol('.');
		assertEquals("0", calc.getValue());
		calc.addSymbol('0');
		assertEquals("0", calc.getValue());
		calc.addSymbol('0');
		assertEquals("0", calc.getValue());
		calc.addSymbol('1');
		assertEquals("0.001", calc.getValue());
	}

	@Test
	public void testCase06() {
		calc.addSymbol('1');
		calc.addSymbol('2');
		calc.addSymbol('3');
		calc.addSymbol('4');
		calc.addSymbol('5');
		calc.addSymbol('6');
		calc.addSymbol('7');
		calc.addSymbol('8');
		calc.addSymbol('9');
		calc.addSymbol('0');
		calc.addSymbol('1');
		calc.addSymbol('2');
		calc.addSymbol('3');
		calc.addSymbol('4');
		calc.addSymbol('5');
		calc.addSymbol('6');
		calc.addSymbol('1');
		calc.addSymbol('.');
		calc.addSymbol('8');
		calc.addSymbol('9');
		assertEquals("123456789012345.89", calc.getValue());
	}
}
