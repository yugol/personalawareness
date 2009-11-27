package pa.db.hsqldb;

import java.io.File;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.sql.Statement;

import pa.db.DataStorage;
import pa.db.dal.Properties;

public class HsqldbStorage implements DataStorage {

	static {
		try {
			Class.forName("org.hsqldb.jdbcDriver");
		} catch (Exception e) {
			System.out.println("ERROR: failed to load HSQLDB JDBC driver.");
			e.printStackTrace();
			System.exit(1);
		}
	}

	private String dbPath;
	private String dbName;

	private Connection conn = null;

	public HsqldbStorage(String path) throws SQLException {
		super();
		File dbFolder = new File(path);
		dbPath = dbFolder.getAbsolutePath();
		dbName = dbPath.substring(dbPath.lastIndexOf(File.separator) + 1);
		open();
	}

	public String getPath() {
		return dbPath;
	}

	@Override
	public void open() throws SQLException {
		String dbId = "jdbc:hsqldb:file:" + dbPath.replace(File.separator, "/");
		File dbFolder = new File(dbPath);
		if (!dbFolder.isDirectory()) {
			if (dbFolder.isFile()) {
				throw new UnsupportedOperationException(dbPath + " - is a file");
			} else {
				if (!dbFolder.mkdirs()) {
					throw new UnsupportedOperationException(
							"Could not create database folder");
				}
			}
		}
		dbId += "/" + dbName;
		conn = DriverManager.getConnection(dbId, "sa", "");
	}

	@Override
	public void close() throws SQLException {
		Statement stat = conn.createStatement();
		stat.execute("SHUTDOWN COMPACT");
		stat.close();
		conn.close();
	}

	@Override
	public void create() throws SQLException {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void delete() throws SQLException {
		close();

	}

	@Override
	public void dump(String sqlFile) {
		// TODO Auto-generated method stub

	}

	@Override
	public void restore(String sqlFile) {
		// TODO Auto-generated method stub

	}

	@Override
	public Properties getProperties() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public void setProperties(Properties prop) {
		// TODO Auto-generated method stub

	}
}
