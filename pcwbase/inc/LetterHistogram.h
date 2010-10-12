#ifndef LETTERHISTOGRAM_H_
#define LETTERHISTOGRAM_H_

#include <string>
#include <map>
#include <ostream>

class LetterHistogram {
public:
	typedef std::map<wchar_t, int>::const_iterator const_iterator;

	LetterHistogram();
	virtual ~LetterHistogram();

	void clear();
	size_t size() const;
	void add(wchar_t letter);
	void add(const std::wstring& word);
	int operator[](wchar_t letter) const;
	const_iterator begin() const;
	const_iterator end() const;
	std::wostream& write(std::wostream& out) const;

private:
	std::map<wchar_t, int> histogram_;
};

inline size_t LetterHistogram::size() const
{
	return histogram_.size();
}

inline LetterHistogram::const_iterator LetterHistogram::begin() const
{
	return histogram_.begin();
}

inline LetterHistogram::const_iterator LetterHistogram::end() const
{
	return histogram_.end();
}

#endif /* LETTERHISTOGRAM_H_ */
