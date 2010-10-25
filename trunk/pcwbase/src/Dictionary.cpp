#include <cstdlib>
#include <iostream>
#include <Exception.h>
#include <BaseUtil.h>
#include <Dictionary.h>

using namespace std;

static void toWword(wchar_t* ww, const char* w, int maxLen)
{
	unsigned wchar_t wc;
	unsigned char c;
	for (int i = 0; i < maxLen; ++i) {
		c = w[i];
		if (c == 0 || c == '\r' || c == '\n') {
			break;
		} else if (c < 128) {
			(*ww) = c;
			++ww;
		} else if (c < 224) {
			wc = (c & 31) << 6;
			wc += (w[++i] & 63);
			(*ww) = wc;
			++ww;
		}
		// TODO: complete here
	}
	(*ww) = 0;
}

Dictionary::Dictionary(const LanguageTraits* languageTraits) :
	languageTraits_(languageTraits)
{
	clear();
}

Dictionary::~Dictionary()
{
	delete languageTraits_;
}

const LetterHistogram& Dictionary::operator[](const std::wstring& word) const
{
	const_iterator it = words_.find(word);
	if (it == words_.end()) {
		THROW("no such word in dictionary");
	}
	return it->second;
}

void Dictionary::clear()
{
	letterHistogram_.clear();
	maxWordLength_ = 0;
	minWordLength_ = 0;
	words_.clear();
}

void Dictionary::add(const wchar_t* buffer)
{
	wstring word = buffer;
	int wordLength = word.size();
	if (wordLength > 0) {

		languageTraits_->toUppercase(word);
		languageTraits_->removeDiacritics(word);

		if (words_.find(word) == words_.end()) {

			LetterHistogram& hist = words_[word];
			for (int i = 0; i < wordLength; ++i) {
				wchar_t wc = word[i];
				//				if (wc >= 128) {
				//					wcout << "*!!! " << buffer << endl;
				//					wcout << static_cast<unsigned int> (wc) << endl;
				//				}
				letterHistogram_.add(wc);
				hist.add(wc);
			}

			if (wordLength > maxWordLength_) {
				maxWordLength_ = wordLength;
			}
			if (getWordCount() == 1) {
				minWordLength_ = wordLength;
			} else if (wordLength < minWordLength_) {
				minWordLength_ = wordLength;
			}
		}
	}
}

void Dictionary::readWords(istream& in)
{
	char word[BaseUtil::MAX_WORD_LENGTH];
	wchar_t wword[BaseUtil::MAX_WORD_LENGTH];
	while (in.getline(word, BaseUtil::MAX_WORD_LENGTH)) {
		toWword(wword, word, BaseUtil::MAX_WORD_LENGTH);
		if (wword[0] != 0) {
			add(wword);
		}
	}
}

