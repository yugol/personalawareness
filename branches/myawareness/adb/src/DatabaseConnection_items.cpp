#include <cstdio>
#include <cstdlib>
#include <cstring>
#include <DatabaseConnection.h>
#include "util.h"

using namespace std;

namespace adb {

int readItem(void *param, int colCount, char **values, char **names)
{
	map<int, Item> &items = *reinterpret_cast<map<int, Item>*> (param);
	int id = ::atoi(values[0]);
	items[id] = Item(id, values[1]);
	return 0;
}

void DatabaseConnection::cashItems() const
{
	if (items_.size() > 0) {
		return;
	}

	char stmt[] = "SELECT id, name FROM items ORDER BY id ASC;\n";
	// printf(stmt);
	if (SQLITE_OK != ::sqlite3_exec(database_, stmt, readItem, &items_, NULL)) {
		throw Exception("error selecting items");
	}
}

void DatabaseConnection::addUpdate(Item *item)
{
	items_.clear();

	char stmt[STATEMENT_LEN];
	char nameBuf[NAME_LEN];

	formatStringForDatabase(nameBuf, item->getName());

	int id = item->getId();

	if (0 == id) {
		::sprintf(stmt, "INSERT INTO items (name) VALUES (%s);\n", nameBuf);
		// printf(stmt);
		if (SQLITE_OK != ::sqlite3_exec(database_, stmt, NULL, NULL, NULL)) {
			throw Exception("error inserting item");
		}
		item->setId(::sqlite3_last_insert_rowid(database_));
	} else if (0 < id) {
		::sprintf(stmt, "UPDATE items SET name=%s WHERE id=%d;\n", nameBuf, id);
		// printf(stmt);
		if (SQLITE_OK != ::sqlite3_exec(database_, stmt, NULL, NULL, NULL)) {
			throw Exception("error updating item");
		}
	}
}

void DatabaseConnection::delItem(int id)
{
	items_.clear();
	char stmt[STATEMENT_LEN];
	::sprintf(stmt, "DELETE FROM items WHERE id=%d;\n", id);
	// printf(stmt);
	if (SQLITE_OK != ::sqlite3_exec(database_, stmt, NULL, NULL, NULL)) {
		throw Exception("error deleting item");
	}
}

const Item* DatabaseConnection::getItem(int id) const
{
	cashItems();
	return &(items_[id]);
}

const Item* DatabaseConnection::getItem(const char* name) const
{
	cashItems();
	map<int, Item>::iterator it;
	for (it = items_.begin(); it != items_.end(); ++it) {
		const char* itemName = it->second.getName().c_str();
		int cmp = ::strcmp(itemName, name);
		if (0 == cmp) {
			return &(it->second);
		}
	}
	return 0;
}

void DatabaseConnection::getItems(std::vector<int>* sel) const
{
	cashItems();
	map<int, Item>::const_iterator it;
	for (it = items_.begin(); it != items_.end(); ++it) {
		sel->push_back(it->first);
	}
}

int DatabaseConnection::getItemCount() const
{
	cashItems();
	return items_.size();
}


} // namespace adb
