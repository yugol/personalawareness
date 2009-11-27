package pa.db.dal;

public class AccountType{
	private int id;
	private String name;
	private String note;

	public AccountType() {
		super();
		id = 0;
		name = null;
		note = null;
	}

	public AccountType(int id, String name, String note) {
		super();
		this.id = id;
		this.name = name;
		this.note = note;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getNote() {
		return note;
	}

	public void setNote(String note) {
		this.note = note;
	}

	public int getId() {
		return id;
	}
}
