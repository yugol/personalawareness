#include <cctype>
#include <LanguageTraitsRo.h>

using namespace std;

LanguageTraitsRo::LanguageTraitsRo()
{
}

LanguageTraitsRo::~LanguageTraitsRo()
{
}

void LanguageTraitsRo::toUppercase(wstring& word) const
{
	for (size_t i = 0; i < word.size(); ++i) {
		wchar_t wc = word[i];
		if (wc < 128) {
			word[i] = toupper(wc);
		} else {
			switch (wc) {
				case 259:
					word[i] = 258;
					break;
				case 226:
					word[i] = 194;
					break;
				case 537:
					word[i] = 536;
					break;
				case 539:
					word[i] = 538;
					break;
				case 238:
					word[i] = 206;
					break;

				default:
					break;
			}
		}
	}
}

void LanguageTraitsRo::removeDiacritics(wstring& word) const
{
	for (size_t i = 0; i < word.size(); ++i) {
		wchar_t wc = word[i];
		if (wc > 128) {
			switch (wc) {
				case 258: // Ă
					word[i] = 'A';
					break;
				case 194: // Â
					word[i] = 'A';
					break;
				case 536: // Ș
					word[i] = 'S';
					break;
				case 538: // Ț
					word[i] = 'T';
					break;
				case 206: // Î
					word[i] = 'I';
					break;
				case 214: // Ö
					word[i] = 'O';
					break;
				case 196: // Ä
					word[i] = 'A';
					break;
				case 197: // Å
					word[i] = 'A';
					break;
				case 220: // Ü
					word[i] = 'U';
					break;
				case 201: // É
					word[i] = 'E';
					break;
				case 199: // Ç
					word[i] = 'C';
					break;
				case 217: // Ù
					word[i] = 'U';
					break;

				case 259:
					word[i] = 'a';
					break;
				case 226:
					word[i] = 'a';
					break;
				case 537:
					word[i] = 's';
					break;
				case 539:
					word[i] = 't';
					break;
				case 238:
					word[i] = 'i';
					break;

				default:
					break;
			}
		}
	}
}
