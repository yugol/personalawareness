package pa.db;

import java.sql.SQLException;

import pa.db.dal.Properties;

public interface DataStorage {
	public void open() throws SQLException;
	
	public void close() throws SQLException;

	public void create() throws SQLException;

	public void delete() throws SQLException;

	public void dump(String sqlFile);

	public void restore(String sqlFile);

	// query;

	public Properties getProperties();

	public void setProperties(Properties prop);
}
