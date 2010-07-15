#ifndef ITEM_H
#define ITEM_H

#include <string>

namespace adb {

class DatabaseConnection;

class Item {
	friend class DatabaseConnection;
	friend int readItem(void *param, int colCount, char **values, char **names);

public:
	Item();
	Item(const char *name);
	virtual ~Item();

	int getId() const;
	const std::string& getName() const;
	void setName(const char *name);

protected:

private:
	int id_;
	std::string name_;

	Item(int id, const char *name);

	void setId(int id);
};

inline int Item::getId() const
{
	return id_;
}

inline const std::string& Item::getName() const
{
	return name_;
}

inline void Item::setId(int id)
{
	id_ = id;
}

} // namespace adb

#endif // ITEM_H
