package pa.db.dal;

public class Properties {
	private String dbVersion = "1";
	private String currencySymbol = "$";
	private boolean placeCurrencySymbolAfterValue = false;
		

	public String getDbVersion() {
		return dbVersion;
	}

	public void setDbVersion(String dbVersion) {
		this.dbVersion = dbVersion;
	}

	public String getCurrencySymbol() {
		return currencySymbol;
	}

	public void setCurrencySymbol(String currencySymbol) {
		this.currencySymbol = currencySymbol;
	}

	public boolean isPlaceCurrencySymbolAfterValue() {
		return placeCurrencySymbolAfterValue;
	}

	public void setPlaceCurrencySymbolAfterValue(
			boolean placeCurrencySymbolAfterValue) {
		this.placeCurrencySymbolAfterValue = placeCurrencySymbolAfterValue;
	}
}
