#include <cctype>
#include <LanguageTraitsEn.h>

using namespace std;

LanguageTraitsEn::LanguageTraitsEn()
{
}

LanguageTraitsEn::~LanguageTraitsEn()
{
}

void LanguageTraitsEn::toUppercase(wstring& word) const
{
	for (size_t i = 0; i < word.size(); ++i) {
		word[i] = toupper(word[i]);
	}
}

void LanguageTraitsEn::removeDiacritics(wstring& word) const
{
}
