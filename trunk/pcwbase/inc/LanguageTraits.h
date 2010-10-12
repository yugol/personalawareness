#ifndef LANGUAGETRAITS_H_
#define LANGUAGETRAITS_H_

#include <string>

class LanguageTraits {
public:
	LanguageTraits();
	virtual ~LanguageTraits();

	virtual void toUppercase(std::wstring& word) const = 0;
	virtual void removeDiacritics(std::wstring& word) const = 0;
};

#endif /* LANGUAGETRAITS_H_ */
