#ifndef LANGUAGETRAITSRO_H_
#define LANGUAGETRAITSRO_H_

#include "LanguageTraits.h"

class LanguageTraitsRo: public LanguageTraits {
public:
	LanguageTraitsRo();
	virtual ~LanguageTraitsRo();

	virtual void toUppercase(std::wstring& word) const;
	virtual void removeDiacritics(std::wstring& word) const;
};

#endif /* LANGUAGETRAITSRO_H_ */
