#include <cstdlib>
#include <sstream>
#include <wx/datetime.h>
#include <Configuration.h>
#include <Date.h>
#include <Item.h>
#include <UiUtil.h>

using namespace std;

const char* UiUtil::MONTH_NAMES[] = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

wxString UiUtil::getApplicationName(const string& databaseFile)
{
	ostringstream sout;
	sout << Configuration::PROJECT_NAME;
	if (databaseFile.size() > 0) {
		sout << " - ";
		streamFileExt(sout, databaseFile);
	}
	wxString applicationName;
	appendStdString(applicationName, sout.rdbuf()->str());
	return applicationName;
}

wxString UiUtil::getUsingStatusMessage(const string& databaseFile)
{
	ostringstream sout;
	if (databaseFile.size() > 0) {
		sout << "Using: ";
		streamFileExt(sout, databaseFile);
	} else {
		sout << "Please open/create a database to start";
	}
	wxString statusMessage;
	appendStdString(statusMessage, sout.rdbuf()->str());
	return statusMessage;
}

wxString UiUtil::makeProperName(wxString rawName)
{
	return rawName.Trim(true).Trim(false);
}

ostream& UiUtil::streamPath(ostream& out, const string& pathFileExt)
{
	int lastSlashPos = pathFileExt.rfind('/');
	int lastBackslashPos = pathFileExt.rfind('\\');
	int namePos = max(lastSlashPos, lastBackslashPos) + 1;
	out << pathFileExt.substr(0, namePos);
	return out;
}

ostream& UiUtil::streamFile(ostream& out, const string& pathFileExt)
{
	int lastSlashPos = pathFileExt.rfind('/');
	int lastBackslashPos = pathFileExt.rfind('\\');
	int namePos = max(lastSlashPos, lastBackslashPos) + 1;
	int dotPos = pathFileExt.rfind('.');
	out << pathFileExt.substr(namePos, dotPos - namePos);
	return out;
}

ostream& UiUtil::streamExt(ostream& out, const std::string& pathFileExt)
{
	int extPos = pathFileExt.rfind('.') + 1;
	out << pathFileExt.substr(extPos);
	return out;
}

ostream& UiUtil::streamFileExt(ostream& out, const string& pathFileExt)
{
	int lastSlashPos = pathFileExt.rfind('/');
	int lastBackslashPos = pathFileExt.rfind('\\');
	int namePos = max(lastSlashPos, lastBackslashPos) + 1;
	out << pathFileExt.substr(namePos);
	return out;
}

void UiUtil::appendWxString(string& to, const wxString& what)
{
	int whatSize = what.Len();
	char* mbstr = new char[whatSize * 4 + 1];
	const wchar_t* wcstr = what.GetData();
	int toSize = wcstombs(mbstr, wcstr, whatSize * sizeof(wchar_t));
	if (toSize > 0) {
		mbstr[toSize] = 0;
		to.append(mbstr);
	}
	delete mbstr;
}

void UiUtil::appendStdString(wxString& to, const string& what)
{
	int whatSize = what.size();
	wchar_t* wcstr = new wchar_t[whatSize * 2 + 1];
	const char* mbstr = what.c_str();
	int toSize = mbstowcs(wcstr, mbstr, whatSize);
	if (toSize > 0) {
		wcstr[toSize] = 0;
		to.Append(wcstr);
	}
	delete wcstr;
}

void UiUtil::adbDate2wxDate(wxDateTime& wxdate, const Date& date)
{
	wxdate.SetDay(date.getDay());
	wxdate.SetMonth(static_cast<wxDateTime::Month> (date.getMonth() - 1));
	wxdate.SetYear(date.getYear());
}

ostream& UiUtil::streamCurrency(ostream& out, double val, bool html)
{

	if (Configuration::instance()->isPrefixCurrency()) {
		out << Configuration::instance()->getCurrencySymbol();
		if (html) {
			out << "&nbsp;";
		} else {
			out << " ";
		}
	}

	if (-0.01 < val && val < 0) {
		val = 0;
	}
	out.precision(2);
	out << fixed << val;

	if (!Configuration::instance()->isPrefixCurrency()) {
		if (html) {
			out << "&nbsp;";
		} else {
			out << " ";
		}
		out << Configuration::instance()->getCurrencySymbol();
	}

	return out;
}

ostream& UiUtil::streamPercent(ostream& out, double val)
{
	out.precision(1);
	out << fixed << val << "%";
	return out;
}

ostream& UiUtil::streamDate(ostream& out, const Date& date)
{
	out << date.getYear();
	out << '-';
	out.fill('0');
	out.width(2);
	out << date.getMonth();
	out << '-';
	out.fill('0');
	out.width(2);
	out << date.getDay();
	return out;
}

void UiUtil::appendCurrency(wxString& to, double val)
{
	ostringstream sout;
	streamCurrency(sout, val);
	appendStdString(to, sout.rdbuf()->str());
}

int UiUtil::compareBeginning(const wxString& needle, const wxString& hay)
{
	size_t needleLen = needle.Len();
	for (size_t i = 0; i < needleLen; ++i) {

		if (i >= needleLen) {
			return 1;
		}

		wxChar ca = wxTolower(needle.GetChar(i));
		wxChar cb = wxTolower(hay.GetChar(i));

		if (Configuration::instance()->isCompareAsciiOnly()) {
			if (ca >= 128) {
				ca = 128;
			}
			if (cb >= 128) {
				cb = 128;
			}
		}

		if (ca < cb) {
			return -1;
		}
		if (ca > cb) {
			return 1;
		}
	}
	return 0;
}

bool UiUtil::compareByName(const Item* a, const Item* b)
{
	wxString wxa, wxb;
	appendStdString(wxa, a->getName());
	appendStdString(wxb, b->getName());
	int cmp = compareBeginning(wxa, wxb);
	return (cmp <= 0);
}
