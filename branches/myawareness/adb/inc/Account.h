#ifndef ACCOUNT_H
#define ACCOUNT_H

#include <string>

namespace adb {

class DbConnection;

class Account {
	friend class DatabaseConnection;
	friend int readAccount(void *param, int colCount, char **values, char **names);

public:
	enum AccType {
		DEBT = 0, ACCOUNT = 1, CREDIT = 2
	};

	Account();
	Account(int type, const char *name, const char *group = 0, double ival = 0, const char *desc = 0);
	virtual ~Account();

	int getId() const;
	int getType() const;
	const std::string& getName() const;
	const std::string getFullName() const;
	const std::string& getGroup() const;
	double getInitialValue() const;
	const std::string& getDescription() const;
	void setName(const char*);
	void setGroup(const char*);
	void setInitialValue(double);
	void setDescription(const char*);
	void print();

protected:

private:
	int id_;
	int type_;
	std::string name_;
	std::string group_;
	double initialValue_;
	std::string description_;

	Account(int id, int type, const char *name, const char *group, double ival, const char *desc);

	void setId(int id);
};

inline int Account::getId() const
{
	return id_;
}

inline int Account::getType() const
{
	return type_;
}

inline const std::string& Account::getName() const
{
	return name_;
}

inline const std::string& Account::getGroup() const
{
	return group_;
}

inline double Account::getInitialValue() const
{
	return initialValue_;
}

inline const std::string& Account::getDescription() const
{
	return description_;
}

} // namespace adb

#endif // ACCOUNT_H
