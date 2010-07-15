#ifndef TRANSACTION_H
#define TRANSACTION_H

#include <string>
#include <Date.h>

namespace adb {

class DatabaseConnection;

class Transaction {
	friend class DatabaseConnection;

public:
	Transaction();
	Transaction(int id);
	Transaction(const char *date, double val, int from, int to, int item, const char *desc);
	virtual ~Transaction();

	int getId() const;
	const Date* getDate() const;
	double getValue() const;
	int getFromId() const;
	int getToId() const;
	int getItemId() const;
	const std::string& getDescription() const;
	void setDate(const char* date);
	void setDate(time_t when);
	void setValue(double val);
	void setFromId(int from);
	void setToId(int to);
	void setItemId(int item);
	void setDescription(const char *desc);

protected:

private:
	int id_;
	Date date_;
	double value_;
	int from_;
	int to_;
	int item_;
	std::string description_;

	void setId(int id);
};

inline int Transaction::getId() const
{
	return id_;
}

inline const Date* Transaction::getDate() const
{
	return &date_;
}

inline double Transaction::getValue() const
{
	return value_;
}

inline int Transaction::getFromId() const
{
	return from_;
}

inline int Transaction::getToId() const
{
	return to_;
}

inline int Transaction::getItemId() const
{
	return item_;
}

inline const std::string& Transaction::getDescription() const
{
	return description_;
}

inline void Transaction::setDate(const char* date)
{
	this->date_.setValue(date);
}

inline void Transaction::setDate(time_t when)
{
	this->date_.setValue(when);
}

inline void Transaction::setValue(double val)
{
	this->value_ = val;
}

inline void Transaction::setFromId(int from)
{
	this->from_ = from;
}

inline void Transaction::setToId(int to)
{
	this->to_ = to;
}

inline void Transaction::setItemId(int item)
{
	this->item_ = item;
}

inline void Transaction::setId(int id)
{
	this->id_ = id;
}

} // namespace adb

#endif // TRANSACTION_H
