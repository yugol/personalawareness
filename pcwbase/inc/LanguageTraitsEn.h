#ifndef LANGUAGETRAITSEN_H_
#define LANGUAGETRAITSEN_H_

#include "LanguageTraits.h"

class LanguageTraitsEn: public LanguageTraits {
public:
	LanguageTraitsEn();
	virtual ~LanguageTraitsEn();

	virtual void toUppercase(std::wstring& word) const;
	virtual void removeDiacritics(std::wstring& word) const;
};

#endif /* LANGUAGETRAITSEN_H_ */
