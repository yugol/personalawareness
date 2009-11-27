package pa.db.hsqldb;

import static org.junit.Assert.*;

import java.io.File;
import java.sql.SQLException;

import org.junit.Test;

import pa.db.dal.Properties;

public class HsqldbStorageTest {

	@Test
	public void testCreateDelete() throws SQLException {
		File wd = new File(".");
		String dbPath = wd.getAbsolutePath().substring(0, wd.getAbsolutePath().length() - 2) + File.separator + "test";
		System.out.println(dbPath);
		HsqldbStorage storage = new HsqldbStorage(dbPath);
		
		Properties prop = storage.getProperties();
		assertEquals("1", prop.getDbVersion());
		assertEquals("$", prop.getCurrencySymbol());
		assertEquals(false, prop.isPlaceCurrencySymbolAfterValue());
		
		storage.delete();
		assertFalse(new File(storage.getPath()).exists());
	}

}
